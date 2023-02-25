
namespace AppleStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Loai_San_Pham
    {
        public Loai_San_Pham()
        {
            this.San_Pham = new HashSet<San_Pham>();
        }
    
        public int id { get; set; }
        [DisplayName("Tên lo?i s?n ph?m")]
        [Required]
        public string tenloaiSP { get; set; }
    
        public virtual ICollection<San_Pham> San_Pham { get; set; }
    }
}
