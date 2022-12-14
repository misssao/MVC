using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhungQuocChien_2001190438.Models;

namespace PhungQuocChien_2001190438.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        DataClassesDataContext db = new DataClassesDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(string MaSP, string strURL)
        {
            NongSan ns = db.NongSans.SingleOrDefault(n => n.idSP == MaSP);
            if(ns == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if(spCheck != null)
            {
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);
            }
            GioHang itemGioHang = new GioHang(MaSP);
            lstGioHang.Add(itemGioHang);
            return Redirect(strURL);
        }

        public double TinhTongSoLuong()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
                return 0;
            return lstGioHang.Sum(n => n.SoLuong);
        }

        public double TinhTongTien()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
                return 0;
            return lstGioHang.Sum(n => n.ThanhTien);
        }


        public ActionResult XemGioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        [HttpGet]
        public ActionResult SuaGioHang(string MaSP)
        {
            if (Session["GioHang"] == null)
                return RedirectToAction("DanhMucSanPham", "SanPham");
            NongSan sp = db.NongSans.SingleOrDefault(n => n.idSP == MaSP);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if(spCheck == null)
            {
                return RedirectToAction("DanhMucSanPham", "SanPham");
            }
            ViewBag.GioHang = lstGioHang;
            return View(spCheck);
        }

        [HttpPost]
        public ActionResult UpdateGH(string MaSP, FormCollection f)
        {
            List<GioHang> lstGH = LayGioHang();
            GioHang itemGHUpdate = lstGH.Find(n => n.MaSP == MaSP);
            itemGHUpdate.SoLuong = int.Parse(f["SoLuong"].ToString());
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.DonGia;
            return RedirectToAction("XemGioHang");
        }

        [HttpGet]
        public ActionResult XoaGioHang(string MaSP)
        {
            if (Session["GioHang"] == null)
                return RedirectToAction("DanhMucSanPham", "SanPham");
            NongSan sp = db.NongSans.SingleOrDefault(n => n.idSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("DanhMucSanPham", "SanPham");
            }
            lstGioHang.Remove(spCheck);
            return RedirectToAction("XemGioHang");
        }

        //public ActionResult DatHang()
        //{
        //    if (Session["GioHang"] == null)
        //        return RedirectToAction("DanhMucSanPham", "SanPham");
        //    DonDatHang ddh = new DonDatHang();
        //    ddh.NgayDatHang = DateTime.Now;
        //    ddh.HinhThucGiaoHang = "";
        //    ddh.GhiChu = "";
        //    db.DonDatHangs.InsertOnSubmit(ddh);
        //    db.SubmitChanges();

        //    return RedirectToAction("XemGioHang");
        //}

        public ActionResult GioHangPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.tongsoluong = 0;
                ViewBag.tongtien = 0;
                return PartialView();
            }
            ViewBag.tongsoluong = TinhTongSoLuong();
            ViewBag.tongtien = TinhTongTien();
            return PartialView();
        }
    }
}
