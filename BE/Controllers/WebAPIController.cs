using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sneaker.Models;

namespace Sneaker.Controllers
{
    public class WebAPIController : ApiController
    {
        [HttpGet]
        public List<SanPham> GetSanPhamList()
        {
            DataYikesDataContext data = new DataYikesDataContext();
            return data.SanPhams.ToList();
        }
        [HttpGet]
        public SanPham GetSanPham(int id)
        {
            DataYikesDataContext data = new DataYikesDataContext();
            return data.SanPhams.FirstOrDefault(s => s.MaSP == id);
        }
    }
}
