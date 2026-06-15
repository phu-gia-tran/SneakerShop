using Sneaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web.Mvc;

namespace Sneaker.Controllers
{
    public class HomeController : Controller
    {
        private DataYikesDataContext db = new DataYikesDataContext();

        private List<SanPham> LatestProducts(int count)
        {
            return db.SanPhams.OrderByDescending(a => a.MaSP).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var sanpham = new List<SanPham>();

            try
            {
                sanpham = LatestProducts(8);
            }
            catch (Exception)
            {
                ViewBag.DatabaseWarning = "Chua ket noi duoc database. Trang chu dang hien thi giao dien frontend.";
            }

            return View(sanpham);
        }

        public ActionResult About()
        {
            ViewBag.pageTitle = "Về chúng tôi";
            ViewBag.pageSubTitle = "Giới thiệu";
            return View();
        }

        public ActionResult Contact()   
        {
            ViewBag.pageTitle = "Liên hệ với chúng tôi";
            ViewBag.pageSubTitle = "Liên hệ";
            return View();
        }
        [HttpPost]
        public ActionResult SubmitForm(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var lienHe = new LienHe
                    {
                        HoTen = model.HoTen,
                        Email = model.Email,
                        TieuDe = model.TieuDe,
                        NoiDung = model.NoiDung,
                        CreatedAt = DateTime.Now
                    };

                    db.LienHes.InsertOnSubmit(lienHe);
                    db.SubmitChanges();

                    ViewBag.SuccessMessage = "Khách hàng đã gửi liên hệ thành công!";
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"Đã xảy ra lỗi: {ex.Message}";
                }
            }

            return View("Contact", model);
        }

        public ActionResult Information(int makh)
        {
            return View(db.KhachHangs.SingleOrDefault(kh => kh.MaKH == makh));
        }
    }
}
