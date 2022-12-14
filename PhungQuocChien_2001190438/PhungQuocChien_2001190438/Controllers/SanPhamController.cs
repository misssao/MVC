using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhungQuocChien_2001190438.Models;

namespace PhungQuocChien_2001190438.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        DataClassesDataContext db = new DataClassesDataContext();

        public ActionResult Details(string name)
        {
            //List<NongSan> dsNS = db.NongSans.ToList();
            NongSan ns = db.NongSans.Single(n => n.idSP == name);
            List<GiaoHang> dsGiaoHang = db.GiaoHangs.Where(n => n.MaSP == name).ToList();
            ViewBag.giaohang = dsGiaoHang;
            return View(ns);
        }

        public ActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTKhoan = f["txtTenDN"].ToString();
            string sMkhau = f["txtMatKhau"].ToString();

            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.DienThoai == sTKhoan && n.MatKhau == sMkhau);
            if(kh != null)
            {
                Session["TaiKhoan"] = kh;
                return RedirectToAction("DanhMucSanPham");
            }
            else
            {
                return Content("Dang nhap that bai </br> <a href='/SanPham/DanhMucSanPham'>Quay lai Trang chu</a>");
            }

        }

        public ActionResult LoadDanhMuc()
        {
            List<DanhMuc> lstDanhMuc = db.DanhMucs.ToList();
            return PartialView(lstDanhMuc);
        }

        public ActionResult DanhMucSanPham()
        {
            List<NongSan> dsNongSan = db.NongSans.ToList();
            ViewBag.lstNongSan = dsNongSan;
            return View();
        }

        public ActionResult DanhMucSanPhamTheoMa(int id)
        {
            List<Loai> dsLoai = db.Loais.Where(n => n.MaDanhMuc == id).ToList();
            //var dsNongSan = db.NongSans.Where(n => n.MaLoaiSP == dsLoai.MaLoai);
            List<NongSan> dsNongSan = new List<NongSan>();
            for (int i = 0; i < dsLoai.Count-1; i++)
            {
                foreach (var item in db.NongSans.ToList())
                {
                    if(item.MaLoaiSP == dsLoai[i].MaLoai)
                    {
                        dsNongSan.Add(item);
                    }
                }
            }
            ViewBag.lstNongSan = dsNongSan;
            return View();
        }

        [ChildActionOnly]
        public ActionResult SanPhamPartial()
        {
            return PartialView();
        }
    }
}
