using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLTV.Models
{
    public partial class QLTVContext : DbContext
    {
        public QLTVContext()
        {
        }

        public QLTVContext(DbContextOptions<QLTVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDanhMuc> TblDanhMucs { get; set; } = null!;
        public virtual DbSet<TblDanhSachMuon> TblDanhSachMuons { get; set; } = null!;
        public virtual DbSet<TblNguoiDung> TblNguoiDungs { get; set; } = null!;
        public virtual DbSet<TblQuyen> TblQuyens { get; set; } = null!;
        public virtual DbSet<TblSach> TblSaches { get; set; } = null!;
        public virtual DbSet<TblTaiKhoan> TblTaiKhoans { get; set; } = null!;
        public virtual DbSet<TblTheMuon> TblTheMuons { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PQ7LVJL\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDanhMuc>(entity =>
            {
                entity.HasKey(e => e.SMaDanhMuc)
                    .HasName("PK__tblDanhM__7D62A86F8FCB4038");

                entity.ToTable("tblDanhMuc");

                entity.Property(e => e.SMaDanhMuc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaDanhMuc");

                entity.Property(e => e.STenDanhMuc)
                    .HasMaxLength(20)
                    .HasColumnName("sTenDanhMuc");
            });

            modelBuilder.Entity<TblDanhSachMuon>(entity =>
            {
                entity.HasKey(e => e.SMaDanhSach)
                    .HasName("PK__tblDanhS__8DBFA015847F2667");

                entity.ToTable("tblDanhSachMuon");

                entity.Property(e => e.SMaDanhSach)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaDanhSach");

                entity.Property(e => e.SMaSach)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaSach");

                entity.Property(e => e.SMaTheMuon)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaTheMuon");

                entity.HasOne(d => d.SMaDanhSachNavigation)
                    .WithOne(p => p.TblDanhSachMuon)
                    .HasForeignKey<TblDanhSachMuon>(d => d.SMaDanhSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblDanhSa__sMaDa__5629CD9C");

                entity.HasOne(d => d.SMaTheMuonNavigation)
                    .WithMany(p => p.TblDanhSachMuons)
                    .HasForeignKey(d => d.SMaTheMuon)
                    .HasConstraintName("FK__tblDanhSa__sMaTh__5535A963");
            });

            modelBuilder.Entity<TblNguoiDung>(entity =>
            {
                entity.HasKey(e => e.SMaNguoiDung)
                    .HasName("PK__tblNguoi__47E09BE3C780583C");

                entity.ToTable("tblNguoiDung");

                entity.Property(e => e.SMaNguoiDung)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaNguoiDung");

                entity.Property(e => e.DNgaySinh)
                    .HasColumnType("date")
                    .HasColumnName("dNgaySinh");

                entity.Property(e => e.SCccd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sCCCD");

                entity.Property(e => e.SDiaChi)
                    .HasMaxLength(100)
                    .HasColumnName("sDiaChi");

                entity.Property(e => e.SMaTheMuon)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaTheMuon");

                entity.Property(e => e.STenNguoiDung)
                    .HasMaxLength(50)
                    .HasColumnName("sTenNguoiDung");

                entity.HasOne(d => d.SMaTheMuonNavigation)
                    .WithMany(p => p.TblNguoiDungs)
                    .HasForeignKey(d => d.SMaTheMuon)
                    .HasConstraintName("FK__tblNguoiD__sMaTh__571DF1D5");
            });

            modelBuilder.Entity<TblQuyen>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__tblQuyen__DDDED94E1B414431");

                entity.ToTable("tblQuyen");

                entity.Property(e => e.SId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sID");

                entity.Property(e => e.IMaQuyen).HasColumnName("iMaQuyen");

                entity.Property(e => e.STenQuyen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sTenQuyen");
            });

            modelBuilder.Entity<TblSach>(entity =>
            {
                entity.HasKey(e => e.SMaSach)
                    .HasName("PK__tblSach__BE472D1CE2D534AF");

                entity.ToTable("tblSach");

                entity.Property(e => e.SMaSach)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaSach");

                entity.Property(e => e.FGiaTien).HasColumnName("fGiaTien");

                entity.Property(e => e.ISoLuong).HasColumnName("iSoLuong");

                entity.Property(e => e.SDuongDan)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sDuongDan");

                entity.Property(e => e.SMaDanhMuc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaDanhMuc");

                entity.Property(e => e.SMoTa)
                    .HasMaxLength(50)
                    .HasColumnName("sMoTa");

                entity.Property(e => e.SNhaXuatBan)
                    .HasMaxLength(50)
                    .HasColumnName("sNhaXuatBan");

                entity.Property(e => e.STenSach)
                    .HasMaxLength(50)
                    .HasColumnName("sTenSach");

                entity.Property(e => e.STenTacGia)
                    .HasMaxLength(50)
                    .HasColumnName("sTenTacGia");

                entity.Property(e => e.STrangThai)
                    .HasMaxLength(50)
                    .HasColumnName("sTrangThai");

                entity.HasOne(d => d.SMaDanhMucNavigation)
                    .WithMany(p => p.TblSaches)
                    .HasForeignKey(d => d.SMaDanhMuc)
                    .HasConstraintName("FK__tblSach__sMaDanh__59FA5E80");
            });

            modelBuilder.Entity<TblTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.STaiKhoan)
                    .HasName("PK__tblTaiKh__868A5E9D88AE4BA6");

                entity.ToTable("tblTaiKhoan");

                entity.Property(e => e.STaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sTaiKhoan");

                entity.Property(e => e.SMaNguoiDung)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaNguoiDung");

                entity.Property(e => e.SMaQuyen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaQuyen");

                entity.Property(e => e.SMatKhau)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sMatKhau");

                entity.HasOne(d => d.SMaNguoiDungNavigation)
                    .WithMany(p => p.TblTaiKhoans)
                    .HasForeignKey(d => d.SMaNguoiDung)
                    .HasConstraintName("FK__tblTaiKho__sMaNg__59063A47");

                entity.HasOne(d => d.SMaQuyenNavigation)
                    .WithMany(p => p.TblTaiKhoans)
                    .HasForeignKey(d => d.SMaQuyen)
                    .HasConstraintName("FK__tblTaiKho__sMaQu__5812160E");
            });

            modelBuilder.Entity<TblTheMuon>(entity =>
            {
                entity.HasKey(e => e.SMaTheMuon)
                    .HasName("PK__tblTheMu__21924A48D814BB79");

                entity.ToTable("tblTheMuon");

                entity.Property(e => e.SMaTheMuon)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sMaTheMuon");

                entity.Property(e => e.DNgayMuon)
                    .HasColumnType("date")
                    .HasColumnName("dNgayMuon");

                entity.Property(e => e.DNgayTra)
                    .HasColumnType("date")
                    .HasColumnName("dNgayTra");

                entity.Property(e => e.DNgayTraDuKien)
                    .HasColumnType("date")
                    .HasColumnName("dNgayTraDuKien");

                entity.Property(e => e.DNgayTraThucTe)
                    .HasColumnType("date")
                    .HasColumnName("dNgayTraThucTe");

                entity.Property(e => e.STrangThai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sTrangThai");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
