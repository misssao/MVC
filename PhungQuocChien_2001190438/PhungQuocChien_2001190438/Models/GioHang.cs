using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhungQuocChien_2001190438.Models
{
    public class GioHang
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Hinh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }

        public GioHang(string sMaSP) 
        {
            using(DataClassesDataContext db = new DataClassesDataContext())
            {
                this.MaSP = sMaSP;
                NongSan ns = db.NongSans.Single(n => n.idSP == sMaSP);
                this.TenSP = ns.TenSP;
                this.Hinh = ns.HinhDaiDien;
                this.DonGia = (double)ns.DonGia;
                this.SoLuong = 1;
                this.ThanhTien = DonGia * SoLuong;
            }
        }

        public GioHang(string sMaSP, int iSoLuong)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                this.MaSP = sMaSP;
                NongSan ns = db.NongSans.Single(n => n.idSP == sMaSP);
                this.TenSP = ns.TenSP;
                this.Hinh = ns.HinhDaiDien;
                this.DonGia = (double)ns.DonGia;
                this.SoLuong = iSoLuong;
                this.ThanhTien = DonGia * SoLuong;
            }
        }
    }
}