using PHAMVANTHANH2011064477.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHAMVANTHANH2011064477.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataDataContext data = new MyDataDataContext();

        public ActionResult ListSinhVien()
        {
            //Thuc hien truy van de lay sach
            var all_sv = from ss in data.SinhViens select ss;
            //Do du lieu vao giao dien
            return View(all_sv);
        }

        public ActionResult Detail(String id)
        {
            var D_sv = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sv);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_mssv = collection["MaSV"];
            var E_tensv = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];

            if (string.IsNullOrEmpty(E_mssv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV =E_mssv.ToString();
                s.HoTen = E_tensv.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh.ToString();
                s.MaNganh = E_manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Create();
        }
        public ActionResult Edit(String id)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(String id, FormCollection collection)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            var E_tensv = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];
            E_sinhvien.MaSV = id;
            if (string.IsNullOrEmpty(E_tensv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sinhvien.HoTen = E_tensv;
                E_sinhvien.GioiTinh= E_gioitinh;
                E_sinhvien.NgaySinh= E_ngaysinh;
                E_sinhvien.Hinh = E_hinh;
                E_sinhvien.MaNganh = E_manganh;
                UpdateModel(E_sinhvien);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(String id)
        {
            var D_sv = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sv);
        }
        [HttpPost]
        public ActionResult Delete(String id, FormCollection collection)
        {
            var D_sv = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sv);
            data.SubmitChanges();
            return RedirectToAction("ListSinhVien");
        }
        public ActionResult Index()
        {
            return View();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}