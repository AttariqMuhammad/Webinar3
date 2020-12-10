using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webinar.Models
{
    public class PenggunaModel
    {
        [Key]
        public int PenggunaID { get; set; }
        [Display(Name = "Nama Depan")]
        public string NamaDepan { get; set; }
        [Display(Name = "Nama Belakang")]
        public string NamaBelakang { get; set; }
        [Key, StringLength(50)]
        [Required, Display(Name = "Full Name")]
        public string NamaPanjang
        {
            get { return NamaDepan + ", " + NamaBelakang; }
        }

        public virtual ICollection<PendaftaranModel> pendaftaranModel { get; set; }
    }
}
