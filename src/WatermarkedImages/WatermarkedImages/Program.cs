using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

class Program
{

    static readonly string WatermarkText = "WatermarkText";
    static void Main()
    {
        // Укажите путь к вашей исходной папке с картинками
        string sourceFolderPath = @"C:\Users\***\Downloads\Telegram Desktop\ДДДД\Scan\MM";

        // Название отдельной папки для сохранения
        string outputFolderName = "WatermarkedImages";


        if (!Directory.Exists(sourceFolderPath))
        {
            Console.WriteLine($"Исходная папка не найдена: {sourceFolderPath}");
            return;
        }

        // Создаем отдельную папку для результатов (если её еще нет)
        string targetFolderPath = Path.Combine(sourceFolderPath, outputFolderName);
        if (!Directory.Exists(targetFolderPath))
        {
            Directory.CreateDirectory(targetFolderPath);
            Console.WriteLine($"Создана папка для сохранения: {targetFolderPath}\n");
        }

        // Поддерживаемые форматы
        string[] extensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.webp" };
        int processedCount = 0;

        foreach (string extension in extensions)
        {
            string[] files = Directory.GetFiles(sourceFolderPath, extension);

            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);

                // Формируем имя файла с префиксом и полный путь в новую папку
                string newFileName = fileName;
                string outputPath = Path.Combine(targetFolderPath, newFileName);

                try
                {
                    AddDiagonalWatermark(filePath, outputPath, WatermarkText);
                    //ProcessDocumentScan(outputPath, outputPath);
                    Console.WriteLine($"[Успешно] {fileName} -> {outputFolderName}/{newFileName}");
                    processedCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка] Не удалось обработать {fileName}: {ex.Message}");
                }

                //break;
            }
        }

        Console.WriteLine($"\nГотово! Обработано файлов: {processedCount}");
        Console.WriteLine($"Результаты сохранены в: {targetFolderPath}");
    }

    public static void AddDiagonalWatermark(string inputPath, string outputPath, string text)
    {
        using (Image image = Image.Load(inputPath))
        {
            // 1. Берем системный шрифт
            if (!SystemFonts.TryGet("Arial", out FontFamily family))
            {
                using var enumerator = SystemFonts.Collection.Families.GetEnumerator();
                if (enumerator.MoveNext()) family = enumerator.Current;
                else throw new Exception("В системе не найдено ни одного шрифта!");
            }

            // 2. Размер шрифта подстраиваем под размер фото
            float fontSize = 160;
            Font font = family.CreateFont(fontSize, FontStyle.Bold);

            // 3. Измеряем размер одной надписи
            FontRectangle rect = TextMeasurer.MeasureBounds(text, new TextOptions(font));

            // 4. Расстояния между надписями (шаг сетки)
            float stepX = rect.Width + 40;
            float stepY = rect.Height + 20;

            // 5. Создаем отдельный прозрачный слой увеличенного размера (с запасом под поворот)
            int overlaySize = Math.Max(image.Width, image.Height) * 2;
            using (Image<Rgba32> watermarkOverlay = new Image<Rgba32>(overlaySize, overlaySize))
            {
                Brush brush = Brushes.Solid(Color.Chocolate.WithAlpha(0.045f));
                Random random = new Random();

                // Рисуем сетку текстов по всей площади слоя
                watermarkOverlay.Mutate(ctx =>
                {
                    for (float y = 0; y < overlaySize; y += stepY)
                    {
                        for (float x = 0; x < overlaySize; x += stepX)
                        {
                            // Рандомный сдвиг для создания хаотичного паттерна
                            float offsetX = random.Next(-15, 15);
                            float offsetY = random.Next(-15, 15);

                            ctx.DrawText(text, font, brush, new PointF(x + offsetX, y + offsetY));
                        }
                    }

                    // Поворачиваем весь слой с текстами на -30 градусов по диагонали
                    ctx.Rotate(-30f);
                });

                // 6. Накладываем повернутый слой на исходную картинку по центру
                image.Mutate(ctx =>
                {
                    int cropX = (watermarkOverlay.Width - image.Width) / 2;
                    int cropY = (watermarkOverlay.Height - image.Height) / 2;

                    // Обрезаем водяной знак ровно под размер основного фото и накладываем
                    using (Image<Rgba32> croppedWatermark = watermarkOverlay.Clone(c => c.Crop(new Rectangle(cropX, cropY, image.Width, image.Height))))
                    {
                        ctx.DrawImage(croppedWatermark, new Point(0, 0), 1f);
                    }
                });
            }

            // 1. Получаем или создаем EXIF-профиль для изображения
            ExifProfile exif = image.Metadata.ExifProfile ?? new ExifProfile();

            // 2. Записываем текстовые метаданные (строки)
            exif.SetValue(ExifTag.Artist, "D12");               // Автор
            exif.SetValue(ExifTag.Copyright, $"{DateTime.Now:d}_{WatermarkText}");       // Авторские права
            //exif.SetValue(ExifTag.ImageDescription, "Сканированный документ с водяным знаком"); // Описание
            //exif.SetValue(ExifTag.Software, "My Custom Watermark App");  // Программа обработки

            // 3. Записываем данные об оборудовании
            exif.SetValue(ExifTag.Make, "Document Scanner Pro");        // Производитель
            // 5. Привязываем обновленный EXIF-профиль к изображению
            image.Metadata.ExifProfile = exif;

            // 7. Сохраняем итоговый результат
            image.Save(outputPath);
        }
    }

    /// <summary>
    /// Превращает обычную фотографию документа в Ч/Б скан высокой чёткости.
    /// </summary>
    public static void ProcessDocumentScan(string inputPath, string outputPath)
    {
        using (Image image = Image.Load(inputPath))
        {
            image.Mutate(ctx =>
            {
                // 1. Переводим в черно-белые оттенки (Grayscale)
                ctx.Grayscale();

                // 2. Сильно повышаем контраст (чтобы серый фон стал белым, а буквы — черными)
                ctx.Contrast(1.8f);

                // 3. Поднимаем яркость, чтобы убрать тени от камеры/освещения
                ctx.Brightness(2.05f);

                // 4. Повышаем резкость текста (Gaussian Sharpen)
                ctx.GaussianSharpen(10.9f);

                // 5. Применяем бинаризацию (Binary Threshold) — оставляет ТОЛЬКО чистый черный и белый
                // Порог 0.6f–0.7f идеально подходит для большинства документов
                ctx.BinaryThreshold(0.95f);
            });

            // Сохраняем итоговый "скан"
            image.Save(outputPath);
        }
    }
}