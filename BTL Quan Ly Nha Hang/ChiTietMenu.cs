//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL_Quan_Ly_Nha_Hang
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietMenu
    {
        public int ma_ct_mn { get; set; }
        public Nullable<int> ma_menu { get; set; }
        public Nullable<int> ma_sp { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
