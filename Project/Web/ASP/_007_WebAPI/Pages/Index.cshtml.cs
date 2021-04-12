using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace _007_WebAPI.Pages
{
    public class IndexModel : PageModel
    {
        public IHostEnvironment HostEnvironment { get; }
        public IndexModel(IHostEnvironment hostEnvironment)
        {
            HostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet() { return RedirectToPage("index1"); }

        //public void OnGet() { }
        //public ContentResult OnGet() { return Content("HI"); }
        //public ForbidResult OnGet() { return Forbid(); }
        //public NotFoundResult OnGet() { return NotFound(); }
    }
}
