//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKH_NEW.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChucNangCon
    {
        public int IDChucNangCon { get; set; }
        public Nullable<int> IDChucNangCha { get; set; }
        public string TenChucNang { get; set; }
        public string MoTa { get; set; }
    
        public virtual ChucNangCha ChucNangCha { get; set; }
    }
}