//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppleStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chi_Tiet_Don_Hang
    {
        public int id { get; set; }
        public string tenSP { get; set; }
        public Nullable<double> gia { get; set; }
        public Nullable<int> soluong { get; set; }
        public Nullable<double> tonggia { get; set; }
        public int idSP { get; set; }
        public int idDonHang { get; set; }
    
        public virtual Don_Hang Don_Hang { get; set; }
        public virtual San_Pham San_Pham { get; set; }
    }
}
