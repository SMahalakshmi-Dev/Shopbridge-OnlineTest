using Shopbridge.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace Shopbridge.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<mvcProductmodel> prodList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            prodList = response.Content.ReadAsAsync<IEnumerable<mvcProductmodel>>().Result;
            return View(prodList);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new mvcProductmodel());
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcProductmodel prodmodel,HttpPostedFileBase file)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", prodmodel).Result;
            
            string fileName = Path.GetFileNameWithoutExtension(prodmodel.ImageFile.FileName);
            string extension = Path.GetExtension(prodmodel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            prodmodel.prodImage = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            prodmodel.ImageFile.SaveAs(fileName);
            return RedirectToAction("Index");
        }
    }
} 