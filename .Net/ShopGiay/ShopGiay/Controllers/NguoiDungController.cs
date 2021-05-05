using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopGiay.Models;

namespace ShopGiay.Controllers
{
    public class NguoiDungController : Controller
    {
        ShopGiaydbContextDataContext data = new ShopGiaydbContextDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var taikhoan = collection["TaiKhoan"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(taikhoan))
            {
                ViewData["Loi1"] = "Vui lòng nhập tài khoản!";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
            }
            else
            {
                User user = data.Users.SingleOrDefault(n => n.TaiKhoan == taikhoan && n.MatKhau == matkhau);
                if (user != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập thành công!";
                    Session["Taikhoan"] = user;
                }
                else
                {
                    ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng!";
                }
                return View();

            }
            return RedirectToAction("Index", "Home");

        }
    

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection,User user)
        {
            if (ModelState.IsValid)
                { 
            var taikhoan = collection["TaiKhoan"];
            var matkhau = collection["MatKhau"];
            var hoten = collection["HoTen"];
            var diachi = collection["DiaChi"];
            var sodienthoai = collection["SoDienThoai"];
            var email = collection["Email"];

            if (String.IsNullOrEmpty(taikhoan))
            {
                ViewData["Loi1"] = "Vui lòng nhập tài khoản!";
            }
           else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Vui lòng nhập mật khẩu!";
            }
            else if (String.IsNullOrEmpty(hoten))
                {
                    ViewData["Loi3"] = "Vui lòng nhập Họ tên!";
                }
            else if (String.IsNullOrEmpty(diachi))
                {
                    ViewData["Loi4"] = "Vui lòng nhập Địa chỉ!";
                }
            else if (String.IsNullOrEmpty(sodienthoai))
                {
                    ViewData["Loi5"] = "Vui lòng nhập Số điện thoại!";
                }
            else if (String.IsNullOrEmpty(email))
                {
                    ViewData["Loi6"] = "Vui lòng nhập Email!";
                }
            else
            {              
                //Gán giá trị mới cho đối tượng
                user.TaiKhoan = taikhoan;
                user.MatKhau = matkhau;
                user.HoTen = hoten;
                user.DiaChi = diachi;
                user.Email = email;
                user.SoDienThoai = sodienthoai;
                data.Users.InsertOnSubmit(user);
                data.SubmitChanges();               
                return RedirectToAction("DangNhap");
                
            }
            }

            return this.DangKy();
        }
    }
}