using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicManagement.Models
{
    public partial class ClinicContext : DbContext
    {
        public ClinicContext()
        {
        }

        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BacSi> BacSis { get; set; } = null!;
        public virtual DbSet<BenhNhan> BenhNhans { get; set; } = null!;
        public virtual DbSet<DonThuoc> DonThuocs { get; set; } = null!;
        public virtual DbSet<DonThuocKhamBenh> DonThuocKhamBenhs { get; set; } = null!;
        public virtual DbSet<KhamBenh> KhamBenhs { get; set; } = null!;
        public virtual DbSet<LichHen> LichHens { get; set; } = null!;
        public virtual DbSet<LoaiThuoc> LoaiThuocs { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<Quyen> Quyens { get; set; } = null!;
        public virtual DbSet<Thuoc> Thuocs { get; set; } = null!;
        public virtual DbSet<YTa> Yta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Nguyen;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BacSi>(entity =>
            {
                entity.HasKey(e => e.MaBacSi)
                    .HasName("PK__BacSi__E022715E99C7C928");

                entity.ToTable("BacSi");

                entity.Property(e => e.BangCap).HasMaxLength(50);

                entity.Property(e => e.ChucVu).HasMaxLength(50);

                entity.Property(e => e.ChuyenMon).HasMaxLength(50);

                entity.Property(e => e.DiaChi).HasMaxLength(256);

                entity.Property(e => e.GioiTinh).HasMaxLength(20);

                entity.Property(e => e.Ho).HasMaxLength(256);

                entity.Property(e => e.MaNd).HasColumnName("MaND");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai).HasMaxLength(20);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.MaNdNavigation)
                    .WithMany(p => p.BacSis)
                    .HasForeignKey(d => d.MaNd)
                    .HasConstraintName("FK__BacSi__MaND__3C69FB99");
            });

            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.HasKey(e => e.MaBenhNhan)
                    .HasName("PK__BenhNhan__22A8B330BBE477A6");

                entity.ToTable("BenhNhan");

                entity.Property(e => e.DiaChi).HasMaxLength(256);

                entity.Property(e => e.GioiTinh).HasMaxLength(20);

                entity.Property(e => e.Ho).HasMaxLength(256);

                entity.Property(e => e.MaNd).HasColumnName("MaND");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoCccd)
                    .HasMaxLength(50)
                    .HasColumnName("SoCCCD");

                entity.Property(e => e.SoDienThoai).HasMaxLength(20);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.MaNdNavigation)
                    .WithMany(p => p.BenhNhans)
                    .HasForeignKey(d => d.MaNd)
                    .HasConstraintName("FK__BenhNhan__MaND__4222D4EF");
            });

            modelBuilder.Entity<DonThuoc>(entity =>
            {
                entity.HasKey(e => e.MaDonThuoc)
                    .HasName("PK__DonThuoc__3EF99EE1845AA14A");

                entity.ToTable("DonThuoc");

                entity.Property(e => e.KetLuan).HasMaxLength(256);

                entity.Property(e => e.NgayKeDon).HasColumnType("date");

                entity.Property(e => e.TrieuChung).HasMaxLength(256);

                entity.HasOne(d => d.MaLichHenNavigation)
                    .WithMany(p => p.DonThuocs)
                    .HasForeignKey(d => d.MaLichHen)
                    .HasConstraintName("FK__DonThuoc__MaLich__5070F446");

                entity.HasOne(d => d.MaThuocNavigation)
                    .WithMany(p => p.DonThuocs)
                    .HasForeignKey(d => d.MaThuoc);
            });

            modelBuilder.Entity<DonThuocKhamBenh>(entity =>
            {
                entity.HasKey(e => new { e.MaDonThuoc, e.MaKhamBenh })
                    .HasName("PK__DonThuoc__C4BBDFEFA7CE2E88");

                entity.ToTable("DonThuocKhamBenh");

                entity.Property(e => e.CacXetNghiem).HasMaxLength(256);

                entity.Property(e => e.HenTaiKham).HasColumnType("date");

                entity.Property(e => e.KetLuan).HasMaxLength(256);

                entity.Property(e => e.NgayGioKham).HasColumnType("datetime");

                entity.Property(e => e.QuaTrinhDieuTri).HasMaxLength(256);

                entity.Property(e => e.TienSuBenh).HasMaxLength(256);

                entity.HasOne(d => d.MaKhamBenhNavigation)
                    .WithMany(p => p.DonThuocKhamBenhs)
                    .HasForeignKey(d => d.MaKhamBenh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonThuocK__MaKha__5812160E");

                entity.HasOne(d => d.MaDonThuocNavigation)
                    .WithMany(p => p.DonThuocKhamBenhs)
                    .HasForeignKey(d => d.MaDonThuoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonThuocK__MaThu__571DF1D5");
            });

            modelBuilder.Entity<KhamBenh>(entity =>
            {
                entity.HasKey(e => e.MaKhamBenh)
                    .HasName("PK__KhamBenh__F0A29CF9E7FBAD28");

                entity.ToTable("KhamBenh");

                entity.Property(e => e.CacXetNghiem).HasMaxLength(256);

                entity.Property(e => e.HenTaiKham).HasColumnType("date");

                entity.Property(e => e.KetLuan).HasMaxLength(256);

                entity.Property(e => e.NgayGioKham).HasColumnType("datetime");

                entity.Property(e => e.QuaTrinhDieuTri).HasMaxLength(256);

                entity.Property(e => e.TienSuBenh).HasMaxLength(256);

                entity.HasOne(d => d.MaBacSiNavigation)
                    .WithMany(p => p.KhamBenhs)
                    .HasForeignKey(d => d.MaBacSi)
                    .HasConstraintName("FK__KhamBenh__MaBacS__5441852A");

                entity.HasOne(d => d.MaBenhNhanNavigation)
                    .WithMany(p => p.KhamBenhs)
                    .HasForeignKey(d => d.MaBenhNhan)
                    .HasConstraintName("FK__KhamBenh__MaBenh__534D60F1");

                entity.HasOne(d => d.MaLichHenNavigation)
                    .WithMany(p => p.KhamBenhs)
                    .HasForeignKey(d => d.MaLichHen)
                    .HasConstraintName("FK__KhamBenh__MaLich__5535A963");
            });

            modelBuilder.Entity<LichHen>(entity =>
            {
                entity.HasKey(e => e.MaLichHen)
                    .HasName("PK__LichHen__150F264F2B9BE2F9");

                entity.ToTable("LichHen");

                entity.Property(e => e.NgayGioHen).HasColumnType("datetime");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.MaBacSiNavigation)
                    .WithMany(p => p.LichHens)
                    .HasForeignKey(d => d.MaBacSi)
                    .HasConstraintName("FK__LichHen__MaBacSi__45F365D3");

                entity.HasOne(d => d.MaBenhNhanNavigation)
                    .WithMany(p => p.LichHens)
                    .HasForeignKey(d => d.MaBenhNhan)
                    .HasConstraintName("FK__LichHen__MaBenhN__44FF419A");
            });

            modelBuilder.Entity<LoaiThuoc>(entity =>
            {
                entity.HasKey(e => e.MaLoaiThuoc)
                    .HasName("PK__LoaiThuo__F9F1B9900ED73902");

                entity.ToTable("LoaiThuoc");

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenLoaiThuoc).HasMaxLength(50);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNd)
                    .HasName("PK__NguoiDun__2725D724250424FA");

                entity.ToTable("NguoiDung");

                entity.Property(e => e.MaNd).HasColumnName("MaND");

                entity.Property(e => e.Avatar).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Ho).HasMaxLength(256);

                entity.Property(e => e.MatKhau).HasMaxLength(256);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.TenDangNhap).HasMaxLength(100);

                entity.HasOne(d => d.MaQuyenNavigation)
                    .WithMany(p => p.NguoiDungs)
                    .HasForeignKey(d => d.MaQuyen)
                    .HasConstraintName("FK__NguoiDung__MaQuy__398D8EEE");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.HasKey(e => e.MaQuyen)
                    .HasName("PK__Quyen__1D4B7ED4E9FC93E9");

                entity.ToTable("Quyen");

                entity.Property(e => e.MoTaQuyen).HasMaxLength(256);

                entity.Property(e => e.TenQuyen).HasMaxLength(50);
            });

            modelBuilder.Entity<Thuoc>(entity =>
            {
                entity.HasKey(e => e.MaThuoc)
                    .HasName("PK__Thuoc__4BB1F6208C422F4B");

                entity.ToTable("Thuoc");

                entity.Property(e => e.GiaNiemYet).HasColumnType("money");

                entity.Property(e => e.HangSanXuat).HasMaxLength(100);

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenThuoc).HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiThuocNavigation)
                    .WithMany(p => p.Thuocs)
                    .HasForeignKey(d => d.MaLoaiThuoc)
                    .HasConstraintName("FK__Thuoc__MaLoaiThu__4D94879B");
            });

            modelBuilder.Entity<YTa>(entity =>
            {
                entity.HasKey(e => e.MaYta)
                    .HasName("PK__YTa__2096BFE27BFFA190");

                entity.ToTable("YTa");

                entity.Property(e => e.MaYta).HasColumnName("MaYTa");

                entity.Property(e => e.BangCap).HasMaxLength(50);

                entity.Property(e => e.ChuyenMon).HasMaxLength(50);

                entity.Property(e => e.DiaChi).HasMaxLength(256);

                entity.Property(e => e.GioiTinh).HasMaxLength(20);

                entity.Property(e => e.Ho).HasMaxLength(256);

                entity.Property(e => e.MaNd).HasColumnName("MaND");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai).HasMaxLength(20);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.MaNdNavigation)
                    .WithMany(p => p.Yta)
                    .HasForeignKey(d => d.MaNd)
                    .HasConstraintName("FK__YTa__MaND__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
