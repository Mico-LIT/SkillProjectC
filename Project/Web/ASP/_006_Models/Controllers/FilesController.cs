using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _006_Models.Controllers
{
    public class FilesController : Controller
    {
        IHostEnvironment hostEnvironment { get; }

        public FilesController(IHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// Нюанс. Если отправляем по виртуальному пути. Файл должен быть размещен в wwwroot
        /// </summary>
        public VirtualFileResult _001_VirtualFileResult()
        {
            var filePath = Path.Combine("~/Files", "Test.txt");
            return File(filePath, "application/txt", "Greet User.txt");
        }

        public IActionResult _002_IActionResult_ReturnFile()
        {
            var filePath = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Files/Test.txt");
            string contentType = "application/txt";
            string nameFile = "Greet User.txt";
            return PhysicalFile(filePath, contentType, nameFile);
        }

        public FileResult _003_FileResult_ByteFile()
        {
            var filePath = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Files/Test.txt");
            byte[] byteFile = System.IO.File.ReadAllBytes(filePath);
            string contentType = "application/txt";
            string nameFile = "Greet User.txt";
            return File(byteFile, contentType, nameFile);
        }

        public FileResult _004_FileResult_FileStream()
        {
            var filePath = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Files/Test.txt");
            FileStream fileStream = new System.IO.FileStream(filePath, FileMode.Open);
            string contentType = "application/txt";
            string nameFile = "Greet User.txt";
            return File(fileStream, contentType, nameFile);
        }
    }
}
