using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Db tabloları ile proje classlarını bağlamak.
    public class SurgiTrackContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SurgicalRecordsDB;Trusted_Connection=true");
        }
        public DbSet<AnalAtrezi> AnalAtrezi { get; set; }
        public DbSet<AntiReflu> AntiReflu { get; set; }
        public DbSet<Apandisit> Apandisit { get; set; }
        public DbSet<DiyafragmaHernisi> DiyafragmaHernisi { get; set; }
        public DbSet<EkstrofiVesikalis> EkstrofiVesikalis { get; set; }
        public DbSet<KolonPullThroughErkek> KolonPullThroughErkek { get; set; }
        public DbSet<KolonPullThroughKadin> KolonPullThroughKadin { get; set; }
        public DbSet<Ameliyat> Ameliyatlar { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
