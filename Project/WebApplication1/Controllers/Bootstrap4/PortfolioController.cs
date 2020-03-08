using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// TODO Bootstrap Portfolio
namespace WebApplication1.Controllers.Bootstrap4
{
    public class PortfolioController : Controller
    {
        //http://cvresumetemplate.com/maha-personal-cv-resume-html-template/home-two-w.html#mh-contact
        public ActionResult Index()
        {
            return View();
        }

        //https://medium.com/@stasonmars/%D1%83%D0%B7%D0%BD%D0%B0%D0%B5%D0%BC-bootstrap-4-%D0%B7%D0%B0-30-%D0%BC%D0%B8%D0%BD%D1%83%D1%82-%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%B2%D0%B0%D1%8F-%D0%BB%D0%B5%D0%BD%D0%B4%D0%B8%D0%BD%D0%B3-d268d52d6c84
        // GET: Portfolio
        public ActionResult Template()
        {
            return View();
        }
    }
}