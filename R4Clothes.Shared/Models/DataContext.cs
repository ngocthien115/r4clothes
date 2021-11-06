using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public partial class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ChiaSe> ChiaSes { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<QuanTri> QuanTris { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<DanhGiaSanPham> DanhGiaSanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<YeuThich> YeuThichs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne<SanPham>(s => s.SanPham)
                .WithMany(c => c.ChiTietHoaDons)
                .HasForeignKey(m => m.Masanpham)
                .OnDelete(DeleteBehavior.NoAction);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
