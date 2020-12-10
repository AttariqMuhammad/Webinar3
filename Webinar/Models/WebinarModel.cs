using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webinar.Models
{
    public class WebinarModel
    {
        public int WebinarModelID { get; set; }
        [Required]
        public string JudulWebinar { get; set; }
        public string Deskripsi { get; set; }
        //public string Tanggal { get; set; }
        [DataType(DataType.Date)] // using System.ComponentModel.DataAnnotations;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Tanggal { get; set; }
        public string Platform { get; set; }
        public string GambarUrl { get; set; }
        public int PembicaraModelID { get; set; }
        public virtual PembicaraModel PembicaraModel { get; set; }
        public virtual ICollection<PendaftaranModel> pendaftaranModel { get; set; }
         


    }
}
