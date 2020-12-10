using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Webinar.Models;


namespace Webinar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Webinar.Models.WebinarModel> WebinarModels { get; set; }
        public DbSet<PenggunaModel> PenggunaModels { get; set; }
        public DbSet<PendaftaranModel> PendaftaranModels { get; set; }
        public DbSet<PembicaraModel> PembicaraModels { get; set; }


    }


}
