using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sneaker.Models
{
    public class ContactViewModel
    {
        public int MaLH { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc.")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tiêu đề là bắt buộc.")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Nội dung là bắt buộc.")]
        public string NoiDung { get; set; }

        public DateTime CreateAt { get; set; }
    }
}