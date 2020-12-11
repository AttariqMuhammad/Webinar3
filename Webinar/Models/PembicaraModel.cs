using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webinar.Models
{
    public class PembicaraModel
    {
        public int ID { get; set; }
        [Required, Display(Name = "Nama Depan")]
        public string NamaDepan { get; set; }
        [Required, Display(Name = "Nama Belakang")]
        public string NamaBelakang { get; set; }

        [Required,Display(Name = "Full Name")]
        public string NamaPanjang
        {
            get { return NamaDepan  +" "+ NamaBelakang; }
        }

        public string Email { get; set; } // coba nanti tambah jumlah maks huruh email

        public string Kontak { get; set; }

        [Display(Name = "Riwayat")]
        public virtual ICollection<WebinarModel> WebinarModel { get; set; }
    }
}
