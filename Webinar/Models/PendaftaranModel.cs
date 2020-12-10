using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webinar.Models
{
    public class PendaftaranModel
    {
        public int PendaftaranModelID { get; set; }
        public int PenggunaModelID { get; set; }
        public virtual PenggunaModel PenggunaModel { get; set; }

        public int WebinarModelID { get; set; }

        public virtual WebinarModel WebinarModel { get; set; }

    }
}
