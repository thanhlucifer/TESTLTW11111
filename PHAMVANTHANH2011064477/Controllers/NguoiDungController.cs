using PHAMVANTHANH2011064477.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHAMVANTHANH2011064477.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        MyDataDataContext data = new MyDataDataContext();
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var mssv = collection["MaSV"];
            SinhVien sv = data.SinhViens.SingleOrDefault(n => n.MaSV == mssv);
            if (sv != null)
            {
                ViewBag.ThongBao = "Chuc mung dang nhap thanh cong";
                Session["TaiKhoan"] = sv;
            }
            else
            {
                ViewBag.ThongBao = "Dang nhap that bai";

            }
            return RedirectToAction("ListSinhVien", "SinhVien");
        }
    }
}