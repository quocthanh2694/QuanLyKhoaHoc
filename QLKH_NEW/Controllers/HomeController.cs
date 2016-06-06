using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using QLKH_NEW.Models;
using System.IO;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Threading;


namespace QLKH_NEW.Controllers
{

    public class HomeController : Controller
    {

        QLKHEntities db = new QLKHEntities();

        public ActionResult Index()
        {
            try
            {
                if (Session["LoginByGoogle"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                LyLichKhoaHoc llkhFromS = (LyLichKhoaHoc)Session["LoginByGoogle"];
                int id = llkhFromS.IDLyLichKhoaHoc;
                Session["LoginByGoogle"] = null;
                Session["LoginByGoogle"] = llkhFromS;
                //List Ly lich khoa hoc - Ngoai Ngu
                List<LyLichKhoaHoc_NgoaiNgu> listLlkkNN = db.LyLichKhoaHoc_NgoaiNgu.Where(s => s.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLKHNN"] = listLlkkNN;

                //List Ly Lich Khoa Hoc - Qua Trinh Cong Tac
                List<LyLichKhoaHoc_QuaTrinhCongTac> listLlKH_QTCT = db.LyLichKhoaHoc_QuaTrinhCongTac.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLKHQTCT"] = listLlKH_QTCT;

                //List Ly lich khoa hoc - qua trinh Dao Tao
                List<LyLichKhoaHoc_QuaTrinhDaoTao> listLLKH_QTDT = db.LyLichKhoaHoc_QuaTrinhDaoTao.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLKHQTDT"] = listLLKH_QTDT;

                //Ly lich khoa hoc - De tai da hoan thanh
                List<LyLichKhoaHoc_DeTaiDaHoanThanh> LLKH_DTDHT = db.LyLichKhoaHoc_DeTaiDaHoanThanh.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLKHDTDHT"] = LLKH_DTDHT;

                //Ly lich khoa hoc - Bai bao dang
                //Quốc tế
                List<LyLichKhoaHoc_BaiBaoDang> LLKH_BBDQT = db.LyLichKhoaHoc_BaiBaoDang.Where(n => n.IDLyLichKhoaHoc == id && n.LoaiBaoDang == "Bài Báo Quốc Tế").ToList();
                Session["ListLLKHBBDQT"] = LLKH_BBDQT;

                //Trong nước
                List<LyLichKhoaHoc_BaiBaoDang> LLKH_BBDTN = db.LyLichKhoaHoc_BaiBaoDang.Where(n => n.IDLyLichKhoaHoc == id && n.LoaiBaoDang == "Bài Báo Trong Nước").ToList();
                Session["ListLLKHBBDTN"] = LLKH_BBDTN;

                //Hoi thao quoc te
                List<LyLichKhoaHoc_HoiThao> LLKH_BBDKYQT = db.LyLichKhoaHoc_HoiThao.Where(n => n.IDLyLichKhoaHoc == id && n.LoaiHoiThao == "Hội Thảo Quốc Tế").ToList();
                Session["ListLLKHBBDKYQT"] = LLKH_BBDKYQT;

                //Hoi thao trong nuoc
                List<LyLichKhoaHoc_HoiThao> LLKH_BBDKYTN = db.LyLichKhoaHoc_HoiThao.Where(n => n.IDLyLichKhoaHoc == id && n.LoaiHoiThao == "Hội Thảo Trong Nước").ToList();
                Session["ListLLKHBBDKYTN"] = LLKH_BBDKYTN;

                //Ly lich khoa hoc - Sach
                List<LyLichKhoaHoc_Sach> LLKH_Sach = db.LyLichKhoaHoc_Sach.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLKHSach"] = LLKH_Sach;

                //Ly lich khoa hoc - Seminar
                List<LyLichKhoaHoc_Seminar> LLKH_Seminar = db.LyLichKhoaHoc_Seminar.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLLKHSeminar"] = LLKH_Seminar;

                //Ly lich khoa hoc - Huong dan NCKH
                List<LyLichKhoaHoc_HuongDanNCKH> LLKH_HDNCKH = db.LyLichKhoaHoc_HuongDanNCKH.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLLKHHDNCKH"] = LLKH_HDNCKH;

                //Ly lich khoa hoc - Tinh huong nghien cuu
                List<LyLichKhoaHoc_TinhHuongNghienCuu> LLKH_THNC = db.LyLichKhoaHoc_TinhHuongNghienCuu.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLLKHTHNC"] = LLKH_THNC;

                //Ly lich khoa hoc - Chuyen Giao Cong Nghe
                List<LyLichKhoaHoc_ChuyenGiaoCongNghe> LLKH_CGCN = db.LyLichKhoaHoc_ChuyenGiaoCongNghe.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLLKHCGCN"] = LLKH_CGCN;

                //Ly lich khoa hoc - Dang ky de tai NCKH
                List<LyLichKhoaHoc_DangKyDeTaiNCKH> LLKH_DKDTNCKH = db.LyLichKhoaHoc_DangKyDeTaiNCKH.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLLKHDKDTNCKH"] = LLKH_DKDTNCKH;

                //Ly lich khoa hoc - Hoat dong khac
                List<LyLichKhoaHoc_HoatDongKhac> LLKH_HDK = db.LyLichKhoaHoc_HoatDongKhac.Where(n => n.IDLyLichKhoaHoc == id).ToList();
                Session["ListLLLKHHDK"] = LLKH_HDK;

                if (TempData["LuuThanhCong"] != null)
                    ViewBag.LuuThanhCong = 0;
                else
                    ViewBag.LuuThanhCong = 2;
                //List Ngoai Ngu
                ViewBag.NgoaiNgu = new SelectList(db.NgoaiNgus.ToList().OrderBy(n => n.IDNgoaiNgu), "IDNgoaiNgu", "Ngoaingu1");
                LyLichKhoaHoc llkh = db.LyLichKhoaHocs.Find(id);

                //List Don Vi
                ViewBag.MaDonVi = new SelectList(db.DonVis.ToList().OrderBy(n => n.MaDonVi), "MaDonVi", "TenDonVi", llkh.MaDonVi);


                return View(llkh);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Index(LyLichKhoaHoc llkh1, HttpPostedFileBase fileUpload, FormCollection f)
        {
            //List Don Vi
            ViewBag.MaDonVi = new SelectList(db.DonVis.ToList().OrderBy(n => n.MaDonVi), "MaDonVi", "TenDonVi", llkh1.MaDonVi);
            //List ngoai ngu
            ViewBag.NgoaiNgu = new SelectList(db.NgoaiNgus.ToList().OrderBy(n => n.IDNgoaiNgu), "IDNgoaiNgu", "Ngoaingu1");


            if (CheckSession(Session["ListLLKHNN"]))
            {
                TempData["LuuThanhCong"] = 1;
                ViewBag.LuuThanhCong = 0;
                return RedirectToAction("Index", "Home");
            }





            string path = "";

            if (fileUpload != null)
            {
                try
                {
                    if (fileUpload.ContentType.Contains("image"))
                    {
                        Guid imageName = Guid.NewGuid();
                        // tên file chưa random
                        //string fileName = Path.GetFileName(fileUpload.FileName);

                        //tên đã random
                        string name = imageName + Path.GetExtension(fileUpload.FileName);

                        //Lưu đường dẫn của file
                        path = Path.Combine(Server.MapPath("~/Images"), name);
                        //if (!System.IO.File.Exists(path))
                        //{
                        WebImage img = new WebImage(fileUpload.InputStream);
                        if (img.Width > 150)
                            img.Resize(150, 200);

                        img.Save(path);


                        // fileUpload.SaveAs(path);
                        //}
                        //else
                        //{
                        // System.IO.File.Delete(path);
                        // fileUpload.SaveAs(path);
                        //}

                        try
                        {

                            //Xoa file ảnh cũ
                            string pathOld = Request.MapPath("~/Images/" + db.LyLichKhoaHocs.Find(llkh1.IDLyLichKhoaHoc).UrlAnh);

                            if (System.IO.File.Exists(pathOld))
                            {
                                System.IO.File.Delete(pathOld);
                            }
                        }
                        catch { }

                        // Lưu ảnh mới
                        llkh1.UrlAnh = name;
                    }
                }
                catch { }

            }

            try
            {
                foreach (var item in db.LyLichKhoaHocs.ToList())
                {
                    if (item.IDLyLichKhoaHoc == llkh1.IDLyLichKhoaHoc)
                    {
                        item.Ho = llkh1.Ho;
                        item.Ten = llkh1.Ten;
                        item.NgaySinh = llkh1.NgaySinh;
                        item.GioiTinh = llkh1.GioiTinh;
                        item.MaDonVi = llkh1.MaDonVi;
                        item.ChucVu = llkh1.ChucVu;
                        item.HocVi = llkh1.HocVi;
                        item.NamCapHocVi = llkh1.NamCapHocVi;
                        item.HocHam = llkh1.HocHam;
                        item.NamPhongHocHam = llkh1.NamPhongHocHam;
                        item.DiaChiCQ = llkh1.DiaChiCQ;
                        item.DiChiCaNhan = llkh1.DiChiCaNhan;
                        item.DienThoaiCQ = llkh1.DienThoaiCQ;
                        item.DienThoaiCaNhan = llkh1.DienThoaiCaNhan;
                        //item.EmailCQ = llkh1.EmailCQ;
                        llkh1.EmailCQ = item.EmailCQ;

                        item.EmailCaNhan = llkh1.EmailCaNhan;
                        if (llkh1.UrlAnh != null)
                            item.UrlAnh = llkh1.UrlAnh;
                        else
                            llkh1.UrlAnh = item.UrlAnh;
                        break;
                    }
                }
            }
            catch { }
            try
            {


                SaveNgoaiNgu(llkh1.IDLyLichKhoaHoc);
                SaveQuaTrinhCongtac(llkh1.IDLyLichKhoaHoc);
                SaveQuaTrinhDaoTao(llkh1.IDLyLichKhoaHoc);
                SaveDeTaiDaHoanThanh(llkh1.IDLyLichKhoaHoc);

                SaveBaiBaoDangQuocTe(llkh1.IDLyLichKhoaHoc);
                SaveBaiBaoDangTrongNuoc(llkh1.IDLyLichKhoaHoc);
                SaveBaiBaoDangHoiThaoQuocTe(llkh1.IDLyLichKhoaHoc);
                SaveBaiBaoDangHoiThaoTrongNuoc(llkh1.IDLyLichKhoaHoc);

                SaveSach(llkh1.IDLyLichKhoaHoc);
                SaveSeminar(llkh1.IDLyLichKhoaHoc);
                SaveHDNCKH(llkh1.IDLyLichKhoaHoc);
                SaveTinhHuongNghienCuu(llkh1.IDLyLichKhoaHoc);
                SaveChuyenGiaoCongNghe(llkh1.IDLyLichKhoaHoc);
                SaveDangKyDeTaiNCKH(llkh1.IDLyLichKhoaHoc);
                SaveHoatDongKhac(llkh1.IDLyLichKhoaHoc);


                // Save
                db.SaveChanges();
            }
            catch
            {
                TempData["LuuThanhCong"] = 1;
                ViewBag.LuuThanhCong = 0;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.LuuThanhCong = 1;
            return View(llkh1);

        }


        private bool CheckSession(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public ActionResult CheckSession_Them()
        //{
        //    if (CheckSession(Session["ListLLKHNN"]))
        //    {
        //        return Json(new { url = "", check = 1 });
        //    }
        //    return null;
        //}






        #region SaveBaiBaoDangHoiThaoTrongNuoc
        private void SaveBaiBaoDangHoiThaoTrongNuoc(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHBBDKYTN"] == null)
                return;
            List<LyLichKhoaHoc_HoiThao> list = db.LyLichKhoaHoc_HoiThao.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc && s.LoaiHoiThao == "Hội Thảo Trong Nước").ToList();
            List<LyLichKhoaHoc_HoiThao> list_S = (List<LyLichKhoaHoc_HoiThao>)Session["ListLLKHBBDKYTN"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDHoiThao == item.IDHoiThao)
                    {
                        //     item.LoaiBaoDang = item_s.CapDoDeTai;
                        item.TenBaiBao = item_s.TenBaiBao;
                        item.TenTacGia = item_s.TenTacGia;
                        item.TenHoiNghi = item_s.TenHoiNghi;
                        item.CapToChuc = item_s.CapToChuc;
                        item.NgayToChuc = item_s.NgayToChuc;
                        item.SoHieuISBN = item_s.SoHieuISBN;
                        item.SanPhamCuaDeTai = item_s.SanPhamCuaDeTai;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_HoiThao.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDHoiThao == item_s.IDHoiThao)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_HoiThao.Remove(item);
                }
            }
        }
        #endregion

        #region SaveBaiBaoDangHoiThaoQuocTe
        private void SaveBaiBaoDangHoiThaoQuocTe(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHBBDKYQT"] == null)
                return;
            List<LyLichKhoaHoc_HoiThao> list = db.LyLichKhoaHoc_HoiThao.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc && s.LoaiHoiThao == "Hội Thảo Quốc Tế").ToList();
            List<LyLichKhoaHoc_HoiThao> list_S = (List<LyLichKhoaHoc_HoiThao>)Session["ListLLKHBBDKYQT"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDHoiThao == item.IDHoiThao)
                    {
                        //     item.LoaiBaoDang = item_s.CapDoDeTai;
                        item.TenBaiBao = item_s.TenBaiBao;
                        item.TenTacGia = item_s.TenTacGia;
                        item.TenHoiNghi = item_s.TenHoiNghi;
                        item.CapToChuc = item_s.CapToChuc;
                        item.NgayToChuc = item_s.NgayToChuc;
                        item.SoHieuISBN = item_s.SoHieuISBN;
                        item.SanPhamCuaDeTai = item_s.SanPhamCuaDeTai;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_HoiThao.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDHoiThao == item_s.IDHoiThao)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_HoiThao.Remove(item);
                }
            }
        }
        #endregion

        #region SaveBaiBaoDangTrongNuoc
        private void SaveBaiBaoDangTrongNuoc(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHBBDTN"] == null)
                return;
            List<LyLichKhoaHoc_BaiBaoDang> list = db.LyLichKhoaHoc_BaiBaoDang.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc && s.LoaiBaoDang == "Bài Báo Trong Nước").ToList();
            List<LyLichKhoaHoc_BaiBaoDang> list_S = (List<LyLichKhoaHoc_BaiBaoDang>)Session["ListLLKHBBDTN"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDBaiBaoDang == item.IDBaiBaoDang)
                    {
                        //     item.LoaiBaoDang = item_s.CapDoDeTai;
                        item.TenBaiBao = item_s.TenBaiBao;
                        item.TenTacGia = item_s.TenTacGia;
                        item.TenTapChi = item_s.TenTapChi;
                        item.NgayXuatBan = item_s.NgayXuatBan;
                        item.SanPhamCuaDeTai = item_s.SanPhamCuaDeTai;
                        item.SoHieu = item_s.SoHieu;
                        item.DiemIF = item_s.DiemIF;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_BaiBaoDang.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDBaiBaoDang == item_s.IDBaiBaoDang)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_BaiBaoDang.Remove(item);
                }
            }
        }
        #endregion

        #region SaveBaiBaoDangQuocTe
        private void SaveBaiBaoDangQuocTe(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHBBDQT"] == null)
                return;
            List<LyLichKhoaHoc_BaiBaoDang> list = db.LyLichKhoaHoc_BaiBaoDang.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc && s.LoaiBaoDang == "Bài Báo Quốc Tế").ToList();
            List<LyLichKhoaHoc_BaiBaoDang> list_S = (List<LyLichKhoaHoc_BaiBaoDang>)Session["ListLLKHBBDQT"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDBaiBaoDang == item.IDBaiBaoDang)
                    {
                        //     item.LoaiBaoDang = item_s.CapDoDeTai;
                        item.TenBaiBao = item_s.TenBaiBao;
                        item.TenTacGia = item_s.TenTacGia;
                        item.TenTapChi = item_s.TenTapChi;
                        item.NgayXuatBan = item_s.NgayXuatBan;
                        item.SanPhamCuaDeTai = item_s.SanPhamCuaDeTai;
                        item.SoHieu = item_s.SoHieu;
                        item.DiemIF = item_s.DiemIF;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_BaiBaoDang.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDBaiBaoDang == item_s.IDBaiBaoDang)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_BaiBaoDang.Remove(item);
                }
            }
        }

        #endregion

        #region SaveHoatDongKhac
        private void SaveHoatDongKhac(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLLKHHDK"] == null)
                return;
            List<LyLichKhoaHoc_HoatDongKhac> list = db.LyLichKhoaHoc_HoatDongKhac.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_HoatDongKhac> list_S = (List<LyLichKhoaHoc_HoatDongKhac>)Session["ListLLLKHHDK"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDHoatDongKhac == item.IDHoatDongKhac)
                    {
                        item.TenHoatDong = item_s.TenHoatDong;
                        item.NoiDung = item_s.NoiDung;
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.GhiChu = item_s.GhiChu;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_HoatDongKhac.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDHoatDongKhac == item_s.IDHoatDongKhac)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_HoatDongKhac.Remove(item);
                }
            }
        }
        #endregion

        #region SaveDangKyDeTaiNCKH
        private void SaveDangKyDeTaiNCKH(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLLKHDKDTNCKH"] == null)
                return;
            List<LyLichKhoaHoc_DangKyDeTaiNCKH> list = db.LyLichKhoaHoc_DangKyDeTaiNCKH.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_DangKyDeTaiNCKH> list_S = (List<LyLichKhoaHoc_DangKyDeTaiNCKH>)Session["ListLLLKHDKDTNCKH"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDDangKyDeTaiNCKH == item.IDDangKyDeTaiNCKH)
                    {
                        item.TenDeTai = item_s.TenDeTai;
                        item.MaCapDoDeTai = item_s.MaCapDoDeTai;
                        item.MucDoThamGia = item_s.MucDoThamGia;
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_DangKyDeTaiNCKH.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDDangKyDeTaiNCKH == item_s.IDDangKyDeTaiNCKH)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_DangKyDeTaiNCKH.Remove(item);
                }
            }
        }

        #endregion

        #region SaveChuyenGiaoCongNghe
        private void SaveChuyenGiaoCongNghe(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLLKHCGCN"] == null)
                return;
            List<LyLichKhoaHoc_ChuyenGiaoCongNghe> list = db.LyLichKhoaHoc_ChuyenGiaoCongNghe.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_ChuyenGiaoCongNghe> list_S = (List<LyLichKhoaHoc_ChuyenGiaoCongNghe>)Session["ListLLLKHCGCN"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDChuyenGiaoCongNghe == item.IDChuyenGiaoCongNghe)
                    {
                        item.TenHoatDong = item_s.TenHoatDong;
                        item.SanPhamCuaDeTai = item_s.SanPhamCuaDeTai;
                        item.DoanhThu = item_s.DoanhThu;
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.TacGia = item_s.TacGia;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_ChuyenGiaoCongNghe.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDChuyenGiaoCongNghe == item_s.IDChuyenGiaoCongNghe)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_ChuyenGiaoCongNghe.Remove(item);
                }
            }
        }
        #endregion

        #region SaveTinhHuongNghienCuu
        private void SaveTinhHuongNghienCuu(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLLKHTHNC"] == null)
                return;
            List<LyLichKhoaHoc_TinhHuongNghienCuu> list = db.LyLichKhoaHoc_TinhHuongNghienCuu.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_TinhHuongNghienCuu> list_S = (List<LyLichKhoaHoc_TinhHuongNghienCuu>)Session["ListLLLKHTHNC"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDTinhHuongNghienCuu == item.IDTinhHuongNghienCuu)
                    {
                        item.TenTinhHuong = item_s.TenTinhHuong;
                        item.CapDo = item_s.CapDo;
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.GhiChu = item_s.GhiChu;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_TinhHuongNghienCuu.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDTinhHuongNghienCuu == item_s.IDTinhHuongNghienCuu)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_TinhHuongNghienCuu.Remove(item);
                }
            }
        }
        #endregion

        #region SaveHDNCKH
        private void SaveHDNCKH(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLLKHHDNCKH"]==null)
                return;
            List<LyLichKhoaHoc_HuongDanNCKH> list = db.LyLichKhoaHoc_HuongDanNCKH.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_HuongDanNCKH> list_S = (List<LyLichKhoaHoc_HuongDanNCKH>)Session["ListLLLKHHDNCKH"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDHuongDanNCKH == item.IDHuongDanNCKH)
                    {
                        item.TenDeTai = item_s.TenDeTai;
                        item.KeQuaKhoaDanhGia = item_s.KeQuaKhoaDanhGia;
                        item.KeQuaTruongDanhGia = item_s.KeQuaTruongDanhGia;
                        item.GiaiThuong = item_s.GiaiThuong;
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.GhiChu = item_s.GhiChu;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_HuongDanNCKH.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDHuongDanNCKH == item_s.IDHuongDanNCKH)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_HuongDanNCKH.Remove(item);
                }
            }
        }
        #endregion

        #region SaveSeminar
        private void SaveSeminar(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLLKHSeminar"] == null)
                return;
            List<LyLichKhoaHoc_Seminar> list = db.LyLichKhoaHoc_Seminar.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_Seminar> list_S = (List<LyLichKhoaHoc_Seminar>)Session["ListLLLKHSeminar"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDSeminar == item.IDSeminar)
                    {
                        item.TenBaoCao = item_s.TenBaoCao;
                        item.TenTacGia = item_s.TenTacGia;
                        item.CapSeminar = item_s.CapSeminar;
                        item.NgayThucHien = item_s.NgayThucHien;
                        item.GhiChu = item_s.GhiChu;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_Seminar.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDSeminar == item_s.IDSeminar)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_Seminar.Remove(item);
                }
            }
        }
        #endregion

        #region SaveSach
        private void SaveSach(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHSach"] == null)
                return;
            List<LyLichKhoaHoc_Sach> list = db.LyLichKhoaHoc_Sach.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_Sach> list_S = (List<LyLichKhoaHoc_Sach>)Session["ListLLKHSach"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDSach == item.IDSach)
                    {
                        item.TenSach = item_s.TenSach;
                        item.NhaXuatBan = item_s.NhaXuatBan;
                        item.NgayXuatBan = item_s.NgayXuatBan;
                        item.ChuBien = item_s.ChuBien;
                        item.ThamGia = item_s.ThamGia;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_Sach.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDSach == item_s.IDSach)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_Sach.Remove(item);
                }
            }
        }
        #endregion

        #region SaveDeTaiDaHoanThanh
        private void SaveDeTaiDaHoanThanh(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHDTDHT"] == null)
                return;
            List<LyLichKhoaHoc_DeTaiDaHoanThanh> list = db.LyLichKhoaHoc_DeTaiDaHoanThanh.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_DeTaiDaHoanThanh> list_S = (List<LyLichKhoaHoc_DeTaiDaHoanThanh>)Session["ListLLKHDTDHT"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDDeTaiDaHoanThanh == item.IDDeTaiDaHoanThanh)
                    {
                        item.CapDoDeTai = item_s.CapDoDeTai;
                        item.TenDeTai = item_s.TenDeTai;
                        item.MaSoVaCapQuanLy = item_s.MaSoVaCapQuanLy;
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.KinhPhi = item_s.KinhPhi;
                        item.ChuNhiem = item_s.ChuNhiem;
                        item.ThamGia = item_s.ThamGia;
                        item.NgayNghiemThu = item_s.NgayNghiemThu;
                        item.KetQua = item_s.KetQua;
                        item.GioNCKHQuyDoi = item_s.GioNCKHQuyDoi;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_DeTaiDaHoanThanh.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDDeTaiDaHoanThanh == item_s.IDDeTaiDaHoanThanh)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_DeTaiDaHoanThanh.Remove(item);
                }
            }
        }
        #endregion

        #region SaveQuaTrinhDaoTao
        private void SaveQuaTrinhDaoTao(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHQTDT"] == null)
                return;
            List<LyLichKhoaHoc_QuaTrinhDaoTao> list = db.LyLichKhoaHoc_QuaTrinhDaoTao.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_QuaTrinhDaoTao> list_S = (List<LyLichKhoaHoc_QuaTrinhDaoTao>)Session["ListLLKHQTDT"];

            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDQuaTrinhDaoTao == item.IDQuaTrinhDaoTao)
                    {
                        item.BacDaoTao = item_s.BacDaoTao;
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.NoiDaoTao = item_s.NoiDaoTao;
                        item.Nganh = item_s.Nganh;
                        item.TenLuanAnTotNghiep = item_s.TenLuanAnTotNghiep;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_QuaTrinhDaoTao.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDQuaTrinhDaoTao == item_s.IDQuaTrinhDaoTao)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_QuaTrinhDaoTao.Remove(item);
                }
            }

        }
        #endregion

        #region SaveQuaTrinhCongtac
        private void SaveQuaTrinhCongtac(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHQTCT"] == null)
                return;
            List<LyLichKhoaHoc_QuaTrinhCongTac> list = db.LyLichKhoaHoc_QuaTrinhCongTac.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
            List<LyLichKhoaHoc_QuaTrinhCongTac> list_S = (List<LyLichKhoaHoc_QuaTrinhCongTac>)Session["ListLLKHQTCT"];
            bool flag;

            foreach (var item_s in list_S)
            {
                flag = false;
                foreach (var item in list)
                {
                    // Update
                    if (item_s.IDQuaTrinhCongTac == item.IDQuaTrinhCongTac)
                    {
                        item.TuNgay = item_s.TuNgay;
                        item.DenNgay = item_s.DenNgay;
                        item.NoiCongTac = item_s.NoiCongTac;
                        item.ChucVu = item_s.ChucVu;
                        flag = true;
                        break;
                    }
                }
                //Insert
                if (!flag)
                {
                    db.LyLichKhoaHoc_QuaTrinhCongTac.Add(item_s);
                }

            }
            // Delete
            foreach (var item in list)
            {
                flag = false;
                foreach (var item_s in list_S)
                {
                    if (item.IDQuaTrinhCongTac == item_s.IDQuaTrinhCongTac)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    db.LyLichKhoaHoc_QuaTrinhCongTac.Remove(item);
                }
            }
        }
        #endregion

        #region SaveNgoaiNgu
        private void SaveNgoaiNgu(int iDLyLichKhoaHoc)
        {
            if (Session["ListLLKHNN"] == null)
                return;
            try
            {
                List<LyLichKhoaHoc_NgoaiNgu> list = db.LyLichKhoaHoc_NgoaiNgu.Where(s => s.IDLyLichKhoaHoc == iDLyLichKhoaHoc).ToList();
                List<LyLichKhoaHoc_NgoaiNgu> list_S = (List<LyLichKhoaHoc_NgoaiNgu>)Session["ListLLKHNN"];
                bool flag;

                foreach (var item_s in list_S)
                {
                    flag = false;
                    foreach (var item in list)
                    {
                        // Update
                        if (item_s.IDNgoaiNgu == item.IDNgoaiNgu)
                        {
                            item.Nghe = item_s.Nghe;
                            item.Noi = item_s.Noi;
                            item.Doc = item_s.Doc;
                            item.Viet = item_s.Viet;
                            flag = true;
                            break;
                        }
                    }
                    //Insert
                    if (!flag)
                    {
                        db.LyLichKhoaHoc_NgoaiNgu.Add(item_s);
                    }

                }
                // Delete
                foreach (var item in list)
                {
                    flag = false;
                    foreach (var item_s in list_S)
                    {
                        if (item.IDNgoaiNgu == item_s.IDNgoaiNgu)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        db.LyLichKhoaHoc_NgoaiNgu.Remove(item);
                    }
                }
            }
            catch { }
        }
        #endregion





        #region Ly lich khoa hoc - Ngoai ngu
        [HttpPost]
        public ActionResult ThemNgN(int idllkh, int id, string nghe, string noi, string doc, string viet)
        {
            if (CheckSession(Session["ListLLKHNN"]))
            {
                return Json(new { url = "" });
            }

            //CheckSession_Them();

            LyLichKhoaHoc_NgoaiNgu llkhnn_new;
            List<LyLichKhoaHoc_NgoaiNgu> list_llkhnn = (List<LyLichKhoaHoc_NgoaiNgu>)Session["ListLLKHNN"];
            bool flag = false;
            foreach (var item in list_llkhnn)
            {
                if (item.IDLyLichKhoaHoc == idllkh && item.IDNgoaiNgu == id)
                {
                    item.Nghe = nghe;
                    item.Noi = noi;
                    item.Doc = doc;
                    item.Viet = viet;
                    flag = true;
                    break;
                }

            }
            if (!flag)
            {
                llkhnn_new = new LyLichKhoaHoc_NgoaiNgu();
                llkhnn_new.IDLyLichKhoaHoc = idllkh;
                llkhnn_new.IDNgoaiNgu = id;
                llkhnn_new.Nghe = nghe;
                llkhnn_new.Noi = noi;
                llkhnn_new.Doc = doc;
                llkhnn_new.Viet = viet;
                list_llkhnn.Add(llkhnn_new);
            }
            Session["ListLLKHNN"] = list_llkhnn;

            return Json(new { url = Url.Action("Partial_NgoaiNgu") });
        }
        [HttpPost]
        public ActionResult Partial_NgoaiNgu()
        {
            return PartialView("Partial_NgoaiNgu");
        }
        [HttpPost]
        public ActionResult XoaNN(int idnn)
        {
            if (CheckSession(Session["ListLLKHNN"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_NgoaiNgu> list_LLKH_NN = (List<LyLichKhoaHoc_NgoaiNgu>)Session["ListLLKHNN"];
            foreach (var item in list_LLKH_NN)
            {
                if (item.IDNgoaiNgu == idnn)
                {
                    list_LLKH_NN.Remove(item);
                    break;
                }
            }
            Session["ListLLKHNN"] = list_LLKH_NN;

            return Json(new { url = Url.Action("Partial_NgoaiNgu") });
        }

        #endregion

        #region Ly lich khoa hoc - Qua trinh cong tac

        [HttpPost]
        public ActionResult ThemQTCT(int idLLKH, string tungay, string denngay, string noicongtac, string chucvu)
        {
            if (CheckSession(Session["ListLLKHQTCT"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_QuaTrinhCongTac LLKH_QTCT;
            List<LyLichKhoaHoc_QuaTrinhCongTac> list_LLKKH_QTCT = (List<LyLichKhoaHoc_QuaTrinhCongTac>)Session["ListLLKHQTCT"];
            if (list_LLKKH_QTCT.Count > 0)
                maxID = list_LLKKH_QTCT.Max(n => n.IDQuaTrinhCongTac);
            else
                maxID = 0;

            LLKH_QTCT = new LyLichKhoaHoc_QuaTrinhCongTac();
            LLKH_QTCT.IDQuaTrinhCongTac = maxID + 1;
            LLKH_QTCT.IDLyLichKhoaHoc = idLLKH;
            LLKH_QTCT.TuNgay = tungay;
            LLKH_QTCT.DenNgay = denngay;
            LLKH_QTCT.NoiCongTac = noicongtac;
            LLKH_QTCT.ChucVu = chucvu;

            list_LLKKH_QTCT.Add(LLKH_QTCT);
            Session["ListLLKHQTCT"] = list_LLKKH_QTCT;

            return Json(new { url = Url.Action("Partial_QuaTrinhCongTac") });
        }

        [HttpPost]
        public ActionResult Partial_QuaTrinhCongTac()
        {
            return PartialView("Partial_QuaTrinhCongTac");
        }
        [HttpPost]
        public ActionResult XoaQTCT(int idqtct)
        {
            if (CheckSession(Session["ListLLKHQTCT"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_QuaTrinhCongTac> list_LLKH_QTCT = (List<LyLichKhoaHoc_QuaTrinhCongTac>)Session["ListLLKHQTCT"];
            foreach (var item in list_LLKH_QTCT)
            {
                if (item.IDQuaTrinhCongTac == idqtct)
                {
                    list_LLKH_QTCT.Remove(item);
                    break;
                }
            }
            Session["ListLLKHQTCT"] = list_LLKH_QTCT;

            return Json(new { url = Url.Action("Partial_QuaTrinhCongTac") });
        }

        #endregion

        #region Ly lich khoa hoc - Qua trinh dao tao
        [HttpPost]
        public ActionResult ThemQTDT(int idLLKH, string bacdt, string tungay, string denngay, string noidaotao, string nganh, string tentuanantotnghiep)
        {
            if (CheckSession(Session["ListLLKHQTDT"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_QuaTrinhDaoTao LLKH_QTDT;
            List<LyLichKhoaHoc_QuaTrinhDaoTao> list_LLKKH_QTDT = (List<LyLichKhoaHoc_QuaTrinhDaoTao>)Session["ListLLKHQTDT"];

            if (list_LLKKH_QTDT.Count > 0)
                maxID = list_LLKKH_QTDT.Max(n => n.IDQuaTrinhDaoTao);
            else
                maxID = 0;


            LLKH_QTDT = new LyLichKhoaHoc_QuaTrinhDaoTao();
            LLKH_QTDT.IDQuaTrinhDaoTao = maxID + 1;
            LLKH_QTDT.IDLyLichKhoaHoc = idLLKH;
            LLKH_QTDT.BacDaoTao = bacdt;
            LLKH_QTDT.TuNgay = tungay;
            LLKH_QTDT.DenNgay = denngay;
            LLKH_QTDT.NoiDaoTao = noidaotao;
            LLKH_QTDT.Nganh = nganh;
            LLKH_QTDT.TenLuanAnTotNghiep = tentuanantotnghiep;

            list_LLKKH_QTDT.Add(LLKH_QTDT);
            Session["ListLLKHQTDT"] = list_LLKKH_QTDT;

            return Json(new { url = Url.Action("Partial_QuaTrinhDaoTao") });
        }

        [HttpPost]
        public ActionResult Partial_QuaTrinhDaoTao()
        {
            return PartialView("Partial_QuaTrinhDaoTao");
        }
        [HttpPost]
        public ActionResult XoaQTDT(int idqtdt)
        {
            if (CheckSession(Session["ListLLKHQTDT"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_QuaTrinhDaoTao> list_LLKKH_QTDT = (List<LyLichKhoaHoc_QuaTrinhDaoTao>)Session["ListLLKHQTDT"];
            foreach (var item in list_LLKKH_QTDT)
            {
                if (item.IDQuaTrinhDaoTao == idqtdt)
                {
                    list_LLKKH_QTDT.Remove(item);
                    break;
                }
            }
            Session["ListLLKHQTDT"] = list_LLKKH_QTDT;

            return Json(new { url = Url.Action("Partial_QuaTrinhDaoTao") });
        }
        #endregion

        #region Ly lich khoa hoc - De tai da hoan thanh
        [HttpPost]
        public ActionResult ThemDTDHT(int idLLKH, string capdodetai, string tendetai, string masovacapquanly, string tungay, string denngay, string kinhphi, string chunhiem, string thamgia, string ngaynghiemthu, string ketqua, string gioNCKHQuyDoi)
        {
            if (CheckSession(Session["ListLLKHDTDHT"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_DeTaiDaHoanThanh LLKH_DTDHT;
            List<LyLichKhoaHoc_DeTaiDaHoanThanh> list_LLKKH_DTDHT = (List<LyLichKhoaHoc_DeTaiDaHoanThanh>)Session["ListLLKHDTDHT"];

            if (list_LLKKH_DTDHT.Count > 0)
                maxID = list_LLKKH_DTDHT.Max(n => n.IDDeTaiDaHoanThanh);
            else
                maxID = 0;


            LLKH_DTDHT = new LyLichKhoaHoc_DeTaiDaHoanThanh();
            LLKH_DTDHT.IDDeTaiDaHoanThanh = maxID + 1;
            LLKH_DTDHT.IDLyLichKhoaHoc = idLLKH;
            LLKH_DTDHT.CapDoDeTai = capdodetai;
            LLKH_DTDHT.TenDeTai = tendetai;
            LLKH_DTDHT.MaSoVaCapQuanLy = masovacapquanly;
            LLKH_DTDHT.TuNgay = tungay;
            LLKH_DTDHT.DenNgay = denngay;
            LLKH_DTDHT.KinhPhi = kinhphi;
            LLKH_DTDHT.ChuNhiem = chunhiem;
            LLKH_DTDHT.ThamGia = thamgia;
            LLKH_DTDHT.NgayNghiemThu = ngaynghiemthu;
            LLKH_DTDHT.KetQua = ketqua;
            LLKH_DTDHT.GioNCKHQuyDoi = gioNCKHQuyDoi;

            list_LLKKH_DTDHT.Add(LLKH_DTDHT);
            Session["ListLLKHDTDHT"] = list_LLKKH_DTDHT;

            return Json(new { url = Url.Action("Partial_DeTaiDaHoanThanh") });
        }

        [HttpPost]
        public ActionResult Partial_DeTaiDaHoanThanh()
        {
            return PartialView("Partial_DeTaiDaHoanThanh");
        }
        [HttpPost]
        public ActionResult XoaDTDHT(int iddtdht)
        {
            if (CheckSession(Session["ListLLKHDTDHT"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_DeTaiDaHoanThanh> list_LLKKH_DTDHT = (List<LyLichKhoaHoc_DeTaiDaHoanThanh>)Session["ListLLKHDTDHT"];
            foreach (var item in list_LLKKH_DTDHT)
            {
                if (item.IDDeTaiDaHoanThanh == iddtdht)
                {
                    list_LLKKH_DTDHT.Remove(item);
                    break;
                }
            }
            Session["ListLLKHDTDHT"] = list_LLKKH_DTDHT;

            return Json(new { url = Url.Action("Partial_DeTaiDaHoanThanh") });
        }
        #endregion

        #region Ly lich khoa hoc - Bai bao dang tren tap chi quoc te
        [HttpPost]
        public ActionResult ThemBBDTrenTapChiQT(int idLLKH, string loaibaodang, string tenBaiBaoQT, string tentacgiaQT, string tenTapChiQT, string ngayxuatbanQT, string sanPhamCuaDeTai, string sohieu, string diemIFQT, string gioNCKHQD)
        {
            if (CheckSession(Session["ListLLKHBBDQT"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_BaiBaoDang LLKH_BBDQT;
            List<LyLichKhoaHoc_BaiBaoDang> list_LLKKH_BBD_QT = (List<LyLichKhoaHoc_BaiBaoDang>)Session["ListLLKHBBDQT"];

            if (list_LLKKH_BBD_QT.Count > 0)
                maxID = list_LLKKH_BBD_QT.Max(n => n.IDBaiBaoDang);
            else
                maxID = 0;


            LLKH_BBDQT = new LyLichKhoaHoc_BaiBaoDang();
            LLKH_BBDQT.IDBaiBaoDang = maxID + 1;
            LLKH_BBDQT.IDLyLichKhoaHoc = idLLKH;
            LLKH_BBDQT.LoaiBaoDang = loaibaodang;
            LLKH_BBDQT.TenBaiBao = tenBaiBaoQT;
            LLKH_BBDQT.TenTacGia = tentacgiaQT;
            LLKH_BBDQT.TenTapChi = tenTapChiQT;
            LLKH_BBDQT.NgayXuatBan = ngayxuatbanQT;
            LLKH_BBDQT.SanPhamCuaDeTai = sanPhamCuaDeTai;
            LLKH_BBDQT.SoHieu = sohieu;
            LLKH_BBDQT.DiemIF = diemIFQT;
            LLKH_BBDQT.GioNCKHQuyDoi = gioNCKHQD;



            list_LLKKH_BBD_QT.Add(LLKH_BBDQT);
            Session["ListLLKHBBDQT"] = list_LLKKH_BBD_QT;

            return Json(new { url = Url.Action("Partial_BaiBaoDangQT") });
        }

        [HttpPost]
        public ActionResult Partial_BaiBaoDangQT()
        {
            return PartialView("Partial_BaiBaoDangQT");
        }
        [HttpPost]
        public ActionResult XoaBBDTrenTapChiQT(int idbbdQT)
        {
            if (CheckSession(Session["ListLLKHBBDQT"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_BaiBaoDang> list_LLKKH_BBDQT = (List<LyLichKhoaHoc_BaiBaoDang>)Session["ListLLKHBBDQT"];
            foreach (var item in list_LLKKH_BBDQT)
            {
                if (item.IDBaiBaoDang == idbbdQT)
                {
                    list_LLKKH_BBDQT.Remove(item);
                    break;
                }
            }
            Session["ListLLKHBBDQT"] = list_LLKKH_BBDQT;

            return Json(new { url = Url.Action("Partial_BaiBaoDangQT") });
        }
        #endregion

        #region Ly lich khoa hoc - Bai bao dang tren tap chi trong nuoc
        [HttpPost]
        public ActionResult ThemBBDTrenTapChiTN(int idLLKH, string loaibaodang, string tenBaiBaoTN, string tentacgiaTN, string tenTapChiTN, string ngayxuatbanTN, string sanPhamCuaDeTai, string sohieu, string diemIFTN, string gioNCKHQD)
        {
            if (CheckSession(Session["ListLLKHBBDTN"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_BaiBaoDang LLKH_BBDTN;
            List<LyLichKhoaHoc_BaiBaoDang> list_LLKKH_BBD_TN = (List<LyLichKhoaHoc_BaiBaoDang>)Session["ListLLKHBBDTN"];

            if (list_LLKKH_BBD_TN.Count > 0)
                maxID = list_LLKKH_BBD_TN.Max(n => n.IDBaiBaoDang);
            else
                maxID = 0;


            LLKH_BBDTN = new LyLichKhoaHoc_BaiBaoDang();
            LLKH_BBDTN.IDBaiBaoDang = maxID + 1;
            LLKH_BBDTN.IDLyLichKhoaHoc = idLLKH;
            LLKH_BBDTN.LoaiBaoDang = loaibaodang;
            LLKH_BBDTN.TenBaiBao = tenBaiBaoTN;
            LLKH_BBDTN.TenTacGia = tentacgiaTN;
            LLKH_BBDTN.TenTapChi = tenTapChiTN;
            LLKH_BBDTN.NgayXuatBan = ngayxuatbanTN;
            LLKH_BBDTN.SanPhamCuaDeTai = sanPhamCuaDeTai;
            LLKH_BBDTN.SoHieu = sohieu;
            LLKH_BBDTN.DiemIF = diemIFTN;
            LLKH_BBDTN.GioNCKHQuyDoi = gioNCKHQD;



            list_LLKKH_BBD_TN.Add(LLKH_BBDTN);
            Session["ListLLKHBBDTN"] = list_LLKKH_BBD_TN;

            return Json(new { url = Url.Action("Partial_BaiBaoDangTN") });
        }

        [HttpPost]
        public ActionResult Partial_BaiBaoDangTN()
        {
            return PartialView("Partial_BaiBaoDangTN");
        }
        [HttpPost]
        public ActionResult XoaBBDTrenTapChiTN(int idbbdTN)
        {
            if (CheckSession(Session["ListLLKHBBDTN"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_BaiBaoDang> list_LLKKH_BBDTN = (List<LyLichKhoaHoc_BaiBaoDang>)Session["ListLLKHBBDTN"];
            foreach (var item in list_LLKKH_BBDTN)
            {
                if (item.IDBaiBaoDang == idbbdTN)
                {
                    list_LLKKH_BBDTN.Remove(item);
                    break;
                }
            }
            Session["ListLLKHBBDTN"] = list_LLKKH_BBDTN;

            return Json(new { url = Url.Action("Partial_BaiBaoDangTN") });
        }
        #endregion

        #region Ly lich khoa hoc - Bai bao dang tren ky yeu hoi thao quoc te
        [HttpPost]
        public ActionResult ThemBBDTrenKyYeuHoiThaoQT(int idLLKH, string loaibaodang, string tenBaiBaoKYQT, string tenTacGiaKYQT, string tenHoiNghiKYQT, string capToChucKYQT, string ngayToChucKYQT, string soHieuKYQT, string sanPhamCuaDeTaiKYQT, string gioNCKHQuyDoiKYQT)
        {
            if (CheckSession(Session["ListLLKHBBDKYQT"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_HoiThao LLKH_BBDKYQT;
            List<LyLichKhoaHoc_HoiThao> list_LLKKH_BBD_KYQT = (List<LyLichKhoaHoc_HoiThao>)Session["ListLLKHBBDKYQT"];

            if (list_LLKKH_BBD_KYQT.Count > 0)
                maxID = list_LLKKH_BBD_KYQT.Max(n => n.IDHoiThao);
            else
                maxID = 0;


            LLKH_BBDKYQT = new LyLichKhoaHoc_HoiThao();
            LLKH_BBDKYQT.IDHoiThao = maxID + 1;
            LLKH_BBDKYQT.IDLyLichKhoaHoc = idLLKH;
            LLKH_BBDKYQT.LoaiHoiThao = loaibaodang;
            LLKH_BBDKYQT.TenBaiBao = tenBaiBaoKYQT;
            LLKH_BBDKYQT.TenTacGia = tenTacGiaKYQT;
            LLKH_BBDKYQT.TenHoiNghi = tenHoiNghiKYQT;
            LLKH_BBDKYQT.CapToChuc = capToChucKYQT;
            LLKH_BBDKYQT.NgayToChuc = ngayToChucKYQT;
            LLKH_BBDKYQT.SoHieuISBN = soHieuKYQT;
            LLKH_BBDKYQT.SanPhamCuaDeTai = sanPhamCuaDeTaiKYQT;
            LLKH_BBDKYQT.GioNCKHQuyDoi = gioNCKHQuyDoiKYQT;



            list_LLKKH_BBD_KYQT.Add(LLKH_BBDKYQT);
            Session["ListLLKHBBDKYQT"] = list_LLKKH_BBD_KYQT;

            return Json(new { url = Url.Action("Partial_BaiBaoDangKYQT") });
        }

        [HttpPost]
        public ActionResult Partial_BaiBaoDangKYQT()
        {
            return PartialView("Partial_BaiBaoDangKYQT");
        }
        [HttpPost]
        public ActionResult XoaBBDTrenKyYeuHoiThaoQT(int idbbdKYQT)
        {
            if (CheckSession(Session["ListLLKHBBDKYQT"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_HoiThao> list_LLKKH_BBDKYQT = (List<LyLichKhoaHoc_HoiThao>)Session["ListLLKHBBDKYQT"];
            foreach (var item in list_LLKKH_BBDKYQT)
            {
                if (item.IDHoiThao == idbbdKYQT)
                {
                    list_LLKKH_BBDKYQT.Remove(item);
                    break;
                }
            }
            Session["ListLLKHBBDKYQT"] = list_LLKKH_BBDKYQT;

            return Json(new { url = Url.Action("Partial_BaiBaoDangKYQT") });
        }
        #endregion

        #region Ly lich khoa hoc - Bai bao dang tren ky yeu hoi thao trong nuoc
        [HttpPost]
        public ActionResult ThemBBDTrenKyYeuHoiThaoTN(int idLLKH, string loaibaodang, string tenBaiBaoKYTN, string tenTacGiaKYTN, string tenHoiNghiKYTN, string capToChucKYTN, string ngayToChucKYTN, string soHieuKYTN, string sanPhamCuaDeTaiKYTN, string gioNCKHQuyDoiKYTN)
        {
            if (CheckSession(Session["ListLLKHBBDKYTN"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_HoiThao LLKH_BBDKYTN;
            List<LyLichKhoaHoc_HoiThao> list_LLKKH_BBD_KYTN = (List<LyLichKhoaHoc_HoiThao>)Session["ListLLKHBBDKYTN"];

            if (list_LLKKH_BBD_KYTN.Count > 0)
                maxID = list_LLKKH_BBD_KYTN.Max(n => n.IDHoiThao);
            else
                maxID = 0;


            LLKH_BBDKYTN = new LyLichKhoaHoc_HoiThao();
            LLKH_BBDKYTN.IDHoiThao = maxID + 1;
            LLKH_BBDKYTN.IDLyLichKhoaHoc = idLLKH;
            LLKH_BBDKYTN.LoaiHoiThao = loaibaodang;
            LLKH_BBDKYTN.TenBaiBao = tenBaiBaoKYTN;
            LLKH_BBDKYTN.TenTacGia = tenTacGiaKYTN;
            LLKH_BBDKYTN.TenHoiNghi = tenHoiNghiKYTN;
            LLKH_BBDKYTN.CapToChuc = capToChucKYTN;
            LLKH_BBDKYTN.NgayToChuc = ngayToChucKYTN;
            LLKH_BBDKYTN.SoHieuISBN = soHieuKYTN;
            LLKH_BBDKYTN.SanPhamCuaDeTai = sanPhamCuaDeTaiKYTN;
            LLKH_BBDKYTN.GioNCKHQuyDoi = gioNCKHQuyDoiKYTN;



            list_LLKKH_BBD_KYTN.Add(LLKH_BBDKYTN);
            Session["ListLLKHBBDKYTN"] = list_LLKKH_BBD_KYTN;

            return Json(new { url = Url.Action("Partial_BaiBaoDangKYTN") });
        }

        [HttpPost]
        public ActionResult Partial_BaiBaoDangKYTN()
        {
            return PartialView("Partial_BaiBaoDangKYTN");
        }
        [HttpPost]
        public ActionResult XoaBBDTrenKyYeuHoiThaoTN(int idbbdKYTN)
        {
            if (CheckSession(Session["ListLLKHBBDKYTN"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_HoiThao> list_LLKKH_BBDKYTN = (List<LyLichKhoaHoc_HoiThao>)Session["ListLLKHBBDKYTN"];
            foreach (var item in list_LLKKH_BBDKYTN)
            {
                if (item.IDHoiThao == idbbdKYTN)
                {
                    list_LLKKH_BBDKYTN.Remove(item);
                    break;
                }
            }
            Session["ListLLKHBBDKYTN"] = list_LLKKH_BBDKYTN;

            return Json(new { url = Url.Action("Partial_BaiBaoDangKYTN") });
        }
        #endregion

        #region Ly lich khoa hoc - Sach
        [HttpPost]
        public ActionResult ThemSach(int idLLKH, string tensach, string nhaxuatban, string ngayxuatban, string chubien, string thamgia, string gioNCKHquydoi)
        {
            if (CheckSession(Session["ListLLKHSach"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_Sach LLKH_Sach;
            List<LyLichKhoaHoc_Sach> list_LLKKH_Sach = (List<LyLichKhoaHoc_Sach>)Session["ListLLKHSach"];

            if (list_LLKKH_Sach.Count > 0)
                maxID = list_LLKKH_Sach.Max(n => n.IDSach);
            else
                maxID = 0;


            LLKH_Sach = new LyLichKhoaHoc_Sach();
            LLKH_Sach.IDSach = maxID + 1;
            LLKH_Sach.IDLyLichKhoaHoc = idLLKH;
            LLKH_Sach.TenSach = tensach;
            LLKH_Sach.NhaXuatBan = nhaxuatban;
            LLKH_Sach.NgayXuatBan = ngayxuatban;
            LLKH_Sach.ChuBien = chubien;
            LLKH_Sach.ThamGia = thamgia;
            LLKH_Sach.GioNCKHQuyDoi = gioNCKHquydoi;


            list_LLKKH_Sach.Add(LLKH_Sach);
            Session["ListLLKHSach"] = list_LLKKH_Sach;

            return Json(new { url = Url.Action("Partial_Sach") });
        }

        [HttpPost]
        public ActionResult Partial_Sach()
        {
            return PartialView("Partial_Sach");
        }
        [HttpPost]
        public ActionResult XoaSach(int idSach)
        {
            if (CheckSession(Session["ListLLKHSach"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_Sach> list_LLKKH_Sach = (List<LyLichKhoaHoc_Sach>)Session["ListLLKHSach"];
            foreach (var item in list_LLKKH_Sach)
            {
                if (item.IDSach == idSach)
                {
                    list_LLKKH_Sach.Remove(item);
                    break;
                }
            }
            Session["ListLLKHSach"] = list_LLKKH_Sach;

            return Json(new { url = Url.Action("Partial_Sach") });
        }
        #endregion

        #region Ly lich khoa hoc - Seminar
        [HttpPost]
        public ActionResult ThemSeminar(int idLLKH, string tenbaocaoseminar, string tentacgiaseminar, string capseminar, string ngaythuchienseminar, string ghichuseminar, string gioNCKHquydoiseminar)
        {
            if (CheckSession(Session["ListLLLKHSeminar"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_Seminar LLKH_Seminar;
            List<LyLichKhoaHoc_Seminar> list_LLKKH_Seminar = (List<LyLichKhoaHoc_Seminar>)Session["ListLLLKHSeminar"];

            if (list_LLKKH_Seminar.Count > 0)
                maxID = list_LLKKH_Seminar.Max(n => n.IDSeminar);
            else
                maxID = 0;


            LLKH_Seminar = new LyLichKhoaHoc_Seminar();
            LLKH_Seminar.IDSeminar = maxID + 1;
            LLKH_Seminar.IDLyLichKhoaHoc = idLLKH;
            LLKH_Seminar.TenBaoCao = tenbaocaoseminar;
            LLKH_Seminar.TenTacGia = tentacgiaseminar;
            LLKH_Seminar.CapSeminar = capseminar;
            LLKH_Seminar.NgayThucHien = ngaythuchienseminar;
            LLKH_Seminar.GhiChu = ghichuseminar;
            LLKH_Seminar.GioNCKHQuyDoi = gioNCKHquydoiseminar;


            list_LLKKH_Seminar.Add(LLKH_Seminar);
            Session["ListLLLKHSeminar"] = list_LLKKH_Seminar;

            return Json(new { url = Url.Action("Partial_Seminar") });
        }

        [HttpPost]
        public ActionResult Partial_Seminar()
        {
            return PartialView("Partial_Seminar");
        }
        [HttpPost]
        public ActionResult XoaSeminar(int idSeminar)
        {
            if (CheckSession(Session["ListLLLKHSeminar"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_Seminar> list_LLKKH_Seminar = (List<LyLichKhoaHoc_Seminar>)Session["ListLLLKHSeminar"];
            foreach (var item in list_LLKKH_Seminar)
            {
                if (item.IDSeminar == idSeminar)
                {
                    list_LLKKH_Seminar.Remove(item);
                    break;
                }
            }
            Session["ListLLLKHSeminar"] = list_LLKKH_Seminar;

            return Json(new { url = Url.Action("Partial_Seminar") });
        }
        #endregion

        #region Ly lich khoa hoc - Huong dan NCKH
        [HttpPost]
        public ActionResult ThemHDNCKH(int idLLKH, string tendetaiHD, string kqkhoaHD, string kqtruongHD, string giaithuongHD, string tungayHD, string denngayHD, string ghichuHD, string gioNCKHQuyDoiHD)
        {
            if (CheckSession(Session["ListLLLKHHDNCKH"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_HuongDanNCKH LLKH_HDNCKH;
            List<LyLichKhoaHoc_HuongDanNCKH> list_LLKKH_HDNCKH = (List<LyLichKhoaHoc_HuongDanNCKH>)Session["ListLLLKHHDNCKH"];

            if (list_LLKKH_HDNCKH.Count > 0)
                maxID = list_LLKKH_HDNCKH.Max(n => n.IDHuongDanNCKH);
            else
                maxID = 0;


            LLKH_HDNCKH = new LyLichKhoaHoc_HuongDanNCKH();
            LLKH_HDNCKH.IDHuongDanNCKH = maxID + 1;
            LLKH_HDNCKH.IDLyLichKhoaHoc = idLLKH;
            LLKH_HDNCKH.TenDeTai = tendetaiHD;
            LLKH_HDNCKH.KeQuaKhoaDanhGia = kqkhoaHD;
            LLKH_HDNCKH.KeQuaTruongDanhGia = kqtruongHD;
            LLKH_HDNCKH.TuNgay = tungayHD;
            LLKH_HDNCKH.DenNgay = denngayHD;
            LLKH_HDNCKH.GiaiThuong = giaithuongHD;
            LLKH_HDNCKH.GhiChu = ghichuHD;
            LLKH_HDNCKH.GioNCKHQuyDoi = gioNCKHQuyDoiHD;


            list_LLKKH_HDNCKH.Add(LLKH_HDNCKH);
            Session["ListLLLKHHDNCKH"] = list_LLKKH_HDNCKH;

            return Json(new { url = Url.Action("Partial_HuongDanSinhVienNCKH") });
        }

        [HttpPost]
        public ActionResult Partial_HuongDanSinhVienNCKH()
        {
            return PartialView("Partial_HuongDanSinhVienNCKH");
        }
        [HttpPost]
        public ActionResult XoaHDNCKH(int idHDNCKH)
        {
            if (CheckSession(Session["ListLLLKHHDNCKH"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_HuongDanNCKH> list_LLKKH_HDNCKH = (List<LyLichKhoaHoc_HuongDanNCKH>)Session["ListLLLKHHDNCKH"];
            foreach (var item in list_LLKKH_HDNCKH)
            {
                if (item.IDHuongDanNCKH == idHDNCKH)
                {
                    list_LLKKH_HDNCKH.Remove(item);
                    break;
                }
            }
            Session["ListLLLKHHDNCKH"] = list_LLKKH_HDNCKH;

            return Json(new { url = Url.Action("Partial_HuongDanSinhVienNCKH") });
        }
        #endregion

        #region Ly lich khoa hoc - Tinh huong nghien cuu
        [HttpPost]
        public ActionResult ThemTHNC(int idLLKH, string tentinhhuong, string capdo, string tungay, string denngay, string ghichu, string gioNCKHquydoi)
        {
            if (CheckSession(Session["ListLLLKHTHNC"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_TinhHuongNghienCuu LLKH_THNC;
            List<LyLichKhoaHoc_TinhHuongNghienCuu> list_LLKKH_THNC = (List<LyLichKhoaHoc_TinhHuongNghienCuu>)Session["ListLLLKHTHNC"];

            if (list_LLKKH_THNC.Count > 0)
                maxID = list_LLKKH_THNC.Max(n => n.IDTinhHuongNghienCuu);
            else
                maxID = 0;


            LLKH_THNC = new LyLichKhoaHoc_TinhHuongNghienCuu();
            LLKH_THNC.IDTinhHuongNghienCuu = maxID + 1;
            LLKH_THNC.IDLyLichKhoaHoc = idLLKH;
            LLKH_THNC.TenTinhHuong = tentinhhuong;
            LLKH_THNC.CapDo = capdo;
            LLKH_THNC.TuNgay = tungay;
            LLKH_THNC.DenNgay = denngay;
            LLKH_THNC.GhiChu = ghichu;
            LLKH_THNC.GioNCKHQuyDoi = gioNCKHquydoi;


            list_LLKKH_THNC.Add(LLKH_THNC);
            Session["ListLLLKHTHNC"] = list_LLKKH_THNC;

            return Json(new { url = Url.Action("Partial_TinhHuongNghienCuu") });
        }

        [HttpPost]
        public ActionResult Partial_TinhHuongNghienCuu()
        {
            return PartialView("Partial_TinhHuongNghienCuu");
        }
        [HttpPost]
        public ActionResult XoaTHNC(int idTHNC)
        {
            if (CheckSession(Session["ListLLLKHTHNC"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_TinhHuongNghienCuu> list_LLKKH_THNC = (List<LyLichKhoaHoc_TinhHuongNghienCuu>)Session["ListLLLKHTHNC"];
            foreach (var item in list_LLKKH_THNC)
            {
                if (item.IDTinhHuongNghienCuu == idTHNC)
                {
                    list_LLKKH_THNC.Remove(item);
                    break;
                }
            }
            Session["ListLLLKHTHNC"] = list_LLKKH_THNC;

            return Json(new { url = Url.Action("Partial_TinhHuongNghienCuu") });
        }
        #endregion

        #region Ly lich khoa hoc - Chuyen giao cong nghe
        [HttpPost]
        public ActionResult ThemCGCN(int idLLKH, string tenhoatdong, string tensanpham, string doanhthu, string tungay, string denngay, string tacgia, string gioNCKHQuyDoi)
        {
            if (CheckSession(Session["ListLLLKHCGCN"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_ChuyenGiaoCongNghe LLKH_CGCN;
            List<LyLichKhoaHoc_ChuyenGiaoCongNghe> list_LLKKH_CGCN = (List<LyLichKhoaHoc_ChuyenGiaoCongNghe>)Session["ListLLLKHCGCN"];

            if (list_LLKKH_CGCN.Count > 0)
                maxID = list_LLKKH_CGCN.Max(n => n.IDChuyenGiaoCongNghe);
            else
                maxID = 0;


            LLKH_CGCN = new LyLichKhoaHoc_ChuyenGiaoCongNghe();
            LLKH_CGCN.IDChuyenGiaoCongNghe = maxID + 1;
            LLKH_CGCN.IDLyLichKhoaHoc = idLLKH;
            LLKH_CGCN.TenHoatDong = tenhoatdong;
            LLKH_CGCN.SanPhamCuaDeTai = tensanpham;
            LLKH_CGCN.DoanhThu = doanhthu;
            LLKH_CGCN.TuNgay = tungay;
            LLKH_CGCN.DenNgay = denngay;
            LLKH_CGCN.TacGia = tacgia;
            LLKH_CGCN.GioNCKHQuyDoi = gioNCKHQuyDoi;


            list_LLKKH_CGCN.Add(LLKH_CGCN);
            Session["ListLLLKHCGCN"] = list_LLKKH_CGCN;

            return Json(new { url = Url.Action("Partial_HoatDongChuyenGiaoCongNghe") });
        }

        [HttpPost]
        public ActionResult Partial_HoatDongChuyenGiaoCongNghe()
        {
            return PartialView("Partial_HoatDongChuyenGiaoCongNghe");
        }
        [HttpPost]
        public ActionResult XoaCGCN(int idCGCN)
        {
            if (CheckSession(Session["ListLLLKHCGCN"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_ChuyenGiaoCongNghe> list_LLKKH_CGCN = (List<LyLichKhoaHoc_ChuyenGiaoCongNghe>)Session["ListLLLKHCGCN"];
            foreach (var item in list_LLKKH_CGCN)
            {
                if (item.IDChuyenGiaoCongNghe == idCGCN)
                {
                    list_LLKKH_CGCN.Remove(item);
                    break;
                }
            }
            Session["ListLLLKHCGCN"] = list_LLKKH_CGCN;

            return Json(new { url = Url.Action("Partial_HoatDongChuyenGiaoCongNghe") });
        }
        #endregion

        #region Ly lich khoa hoc - Dang ky de tai nghien cuu khoa hoc
        [HttpPost]
        public ActionResult ThemDKDTNCKH(int idLLKH, string tendetai, string capdodetai, string mucdothamgia, string tungay, string denngay, string gioNCKHquydoi)
        {
            if (CheckSession(Session["ListLLLKHDKDTNCKH"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_DangKyDeTaiNCKH LLKH_DKDTNCKH;
            List<LyLichKhoaHoc_DangKyDeTaiNCKH> list_LLKKH_DKDTNCKH = (List<LyLichKhoaHoc_DangKyDeTaiNCKH>)Session["ListLLLKHDKDTNCKH"];

            if (list_LLKKH_DKDTNCKH.Count > 0)
                maxID = list_LLKKH_DKDTNCKH.Max(n => n.IDDangKyDeTaiNCKH);
            else
                maxID = 0;


            LLKH_DKDTNCKH = new LyLichKhoaHoc_DangKyDeTaiNCKH();
            LLKH_DKDTNCKH.IDDangKyDeTaiNCKH = maxID + 1;
            LLKH_DKDTNCKH.IDLyLichKhoaHoc = idLLKH;
            LLKH_DKDTNCKH.TenDeTai = tendetai;
            LLKH_DKDTNCKH.MaCapDoDeTai = capdodetai;
            LLKH_DKDTNCKH.MucDoThamGia = mucdothamgia;
            LLKH_DKDTNCKH.TuNgay = tungay;
            LLKH_DKDTNCKH.DenNgay = denngay;
            LLKH_DKDTNCKH.GioNCKHQuyDoi = gioNCKHquydoi;


            list_LLKKH_DKDTNCKH.Add(LLKH_DKDTNCKH);
            Session["ListLLLKHDKDTNCKH"] = list_LLKKH_DKDTNCKH;

            return Json(new { url = Url.Action("Partial_DangKyDeTaiNCKH") });
        }

        [HttpPost]
        public ActionResult Partial_DangKyDeTaiNCKH()
        {
            return PartialView("Partial_DangKyDeTaiNCKH");
        }
        [HttpPost]
        public ActionResult XoaDKDTNCKH(int idDKDTNCKH)
        {
            if (CheckSession(Session["ListLLLKHDKDTNCKH"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_DangKyDeTaiNCKH> list_LLKKH_DKDTNCKH = (List<LyLichKhoaHoc_DangKyDeTaiNCKH>)Session["ListLLLKHDKDTNCKH"];
            foreach (var item in list_LLKKH_DKDTNCKH)
            {
                if (item.IDDangKyDeTaiNCKH == idDKDTNCKH)
                {
                    list_LLKKH_DKDTNCKH.Remove(item);
                    break;
                }
            }
            Session["ListLLLKHDKDTNCKH"] = list_LLKKH_DKDTNCKH;

            return Json(new { url = Url.Action("Partial_DangKyDeTaiNCKH") });
        }
        #endregion

        #region Ly lich khoa hoc - Hoat Dong Khac

        [HttpPost]
        public ActionResult ThemHDK(int idLLKH, string tenhoatdong, string noidung, string tungay, string denngay, string ghichu, string gioNCKHquydoi)
        {
            if (CheckSession(Session["ListLLLKHHDK"]))
            {
                return Json(new { url = "" });
            }
            int maxID;
            LyLichKhoaHoc_HoatDongKhac LLKH_HDK;
            List<LyLichKhoaHoc_HoatDongKhac> list_LLKKH_HDK = (List<LyLichKhoaHoc_HoatDongKhac>)Session["ListLLLKHHDK"];

            if (list_LLKKH_HDK.Count > 0)
                maxID = list_LLKKH_HDK.Max(n => n.IDHoatDongKhac);
            else
                maxID = 0;


            LLKH_HDK = new LyLichKhoaHoc_HoatDongKhac();
            LLKH_HDK.IDHoatDongKhac = maxID + 1;
            LLKH_HDK.IDLyLichKhoaHoc = idLLKH;
            LLKH_HDK.TenHoatDong = tenhoatdong;
            LLKH_HDK.NoiDung = noidung;
            LLKH_HDK.TuNgay = tungay;
            LLKH_HDK.DenNgay = denngay;
            LLKH_HDK.GhiChu = ghichu;
            LLKH_HDK.GioNCKHQuyDoi = gioNCKHquydoi;


            list_LLKKH_HDK.Add(LLKH_HDK);
            Session["ListLLLKHHDK"] = list_LLKKH_HDK;

            return Json(new { url = Url.Action("Partial_HoatDongKhac") });
        }

        [HttpPost]
        public ActionResult Partial_HoatDongKhac()
        {
            return PartialView("Partial_HoatDongKhac");
        }
        [HttpPost]
        public ActionResult XoaHDK(int idHDK)
        {
            if (CheckSession(Session["ListLLLKHHDK"]))
            {
                return Json(new { url = "" });
            }
            List<LyLichKhoaHoc_HoatDongKhac> list_LLKKH_HDK = (List<LyLichKhoaHoc_HoatDongKhac>)Session["ListLLLKHHDK"];
            foreach (var item in list_LLKKH_HDK)
            {
                if (item.IDHoatDongKhac == idHDK)
                {
                    list_LLKKH_HDK.Remove(item);
                    break;
                }
            }
            Session["ListLLLKHHDK"] = list_LLKKH_HDK;

            return Json(new { url = Url.Action("Partial_HoatDongKhac") });
        }
        #endregion





        //public ActionResult SessionTimeout()
        //{


        //    Session.Timeout = Session.Timeout + 20;

        //    return Json("", JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetSessionTimeout()
        //{
        //    Configuration conf = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        //    SessionStateSection section = (SessionStateSection)conf.GetSection("system.web/sessionState");
        //    int timeout = (int)section.Timeout.TotalMilliseconds;


        //    return Json(timeout, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Print()
        {
            if (Session["LoginByGoogle"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            LyLichKhoaHoc llkhFromS = (LyLichKhoaHoc)Session["LoginByGoogle"];
            int id = llkhFromS.IDLyLichKhoaHoc;
            LyLichKhoaHoc llkh = db.LyLichKhoaHocs.Find(id);
            return View(llkh);

        }
        public ActionResult TestSession()
        {
            if (Session["LoginByGoogle"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (Session["ListLLKHNN"] == null)
            {
                return Json(new { url = "true" });
            }
            return Json(new { url = "false" });
        }
        public ActionResult LogOut()
        {
            Session["LoginByGoogle"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult LogOutAjax()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //FormsAuthentication.SignOut();
            Session["LoginByGoogle"] = null;
            return Json(new { });
        }
    }
}