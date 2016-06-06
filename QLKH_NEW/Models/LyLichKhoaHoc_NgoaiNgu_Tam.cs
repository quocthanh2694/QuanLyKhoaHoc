using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKH_NEW.Models
{
    public class LyLichKhoaHoc_NgoaiNgu_Tam
    {
        public int IDLyLichKhoaHoc { get; set; }
        public int IDNgoaiNgu { get; set; }
        public string NgoaiNgu { get; set; }
        public string Nghe { get; set; }
        public string Noi { get; set; }
        public string Viet { get; set; }
        public string Doc { get; set; }
        public LyLichKhoaHoc_NgoaiNgu_Tam()
        {

        }
    }
}