using PHAMVANTHANH2011064477.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHAMVANTHANH2011064477.Controllers
{
    public class HocPhanController : Controller
    {
        // GET: HocPhan
        MyDataDataContext data = new MyDataDataContext();

        public ActionResult ListHocPhan()
        {
            var all_hp = from ss in data.HocPhans select ss;
            //Do du lieu vao giao dien
            return View(all_hp);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}