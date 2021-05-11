using _002_Parsing_CBR.Models;
using _002_Parsing_CBR.Utilit;
using Leaf.xNet;
using System;
using System.Text;

namespace _002_Parsing_CBR
{
    /// <summary>
    /// 
    /// Необходимо написать программу, которая загружает данные со страницы:
    /// http://www.cbr.ru/currency_base/daily/
    /// 
    /// и собирает данные по всем курсам валют, которые выдает эта страница.
    /// Для загрузки страницы необходимо использовать библиотеку xNET: https://github.com/X-rus/xNet,
    /// остальные компоненты - стандартные для среды разработки.
    /// Для курсов валют неободимо создать отдельный класс.Поля класса и структуру выбираете сами.
    /// Как минимум - строковое название валюты и float - курс.
    /// Название валют можно не склонять.
    /// 
    /// Каждый найденный курс валют должен передавться в пустой метод AddCource() класса, который вы создали для валют.
    /// Среда разработки MS VisualStudio 2017 язык разработки - C#
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string content = string.Empty;

            try
            {
                using (var request = new HttpRequest())
                {
                    request.UserAgent = Http.IEUserAgent();

                    var urlParams = new RequestParams();
                    urlParams["date_req"] = DateTime.Now.ToString("dd.MM.yyyy");

                    content = request.Get("http://www.cbr.ru/currency_base/daily/", urlParams).ToString();
                }

                if (!string.IsNullOrEmpty(content))
                {
                    var tableHtml = content.ElementById("content").ElementByName("table");

                    var currencyRatesList = CurrencyRates.HelperByHtmlTabls(tableHtml);

                    //foreach (var item in currencyRatesList)
                    //    CurrencyRates.AddCource(item);

                    foreach (var item in currencyRatesList)
                        Console.WriteLine(string.Format("{0,5}|{1,5}|{2,5}|{4,15}|{3,5} {5}",
                            item.DigitCode, item.LettersCode, item.Units, item.Currency, item.Course, Environment.NewLine));

                }
                else
                {
                    Console.WriteLine("Error in loading website");
                }
            }
            catch (Exception)
            {

                throw;
            }

            Console.ReadKey();
        }

    }
}
