using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiRest.Model.Bender
{
    public partial class BenderContext : DbContext
    {
        public BenderContext()
        {
        }

        public BenderContext(DbContextOptions<BenderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Combo> Combos { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductHasCombo> ProductHasCombos { get; set; } = null!;
        public virtual DbSet<ProductHasOrder> ProductHasOrders { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionDB.BenderConnectionString, ServerVersion.Parse("8.0.19-mysql"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.Idbranch)
                    .HasName("PRIMARY");

                entity.ToTable("branch");

                entity.Property(e => e.Idbranch)
                    .ValueGeneratedNever()
                    .HasColumnName("idbranch");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Tablequantity).HasColumnName("tablequantity");
            });

            modelBuilder.Entity<Combo>(entity =>
            {
                entity.HasKey(e => e.Idcombo)
                    .HasName("PRIMARY");

                entity.ToTable("combo");

                entity.Property(e => e.Idcombo)
                    .ValueGeneratedNever()
                    .HasColumnName("idcombo");

                entity.Property(e => e.Idproduct).HasColumnName("idproduct");

                entity.Property(e => e.Namecombo)
                    .HasMaxLength(45)
                    .HasColumnName("namecombo");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idinvoice)
                    .HasName("PRIMARY");

                entity.ToTable("invoice");

                entity.Property(e => e.Idinvoice)
                    .ValueGeneratedNever()
                    .HasColumnName("idinvoice");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Idorder)
                    .HasMaxLength(45)
                    .HasColumnName("idorder");

                entity.Property(e => e.Idproduct).HasColumnName("idproduct");

                entity.Property(e => e.Idtable).HasColumnName("idtable");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Paymentmethod)
                    .HasMaxLength(45)
                    .HasColumnName("paymentmethod");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Idmenu)
                    .HasName("PRIMARY");

                entity.ToTable("menu");

                entity.Property(e => e.Idmenu)
                    .ValueGeneratedNever()
                    .HasColumnName("idmenu");

                entity.Property(e => e.Idproductcombo)
                    .HasMaxLength(45)
                    .HasColumnName("idproductcombo");

                entity.Property(e => e.Idstock)
                    .HasMaxLength(45)
                    .HasColumnName("idstock");

                entity.Property(e => e.Price)
                    .HasPrecision(5, 2)
                    .HasColumnName("price");

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.Idorder, e.MesaIdmesa, e.MesaSucursalIdsucursal, e.CombosIdcombos })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("order");

                entity.HasIndex(e => e.CombosIdcombos, "fk_orden_combos1_idx");

                entity.HasIndex(e => new { e.MesaIdmesa, e.MesaSucursalIdsucursal }, "fk_orden_mesa1_idx");

                entity.Property(e => e.Idorder).HasColumnName("idorder");

                entity.Property(e => e.MesaIdmesa).HasColumnName("mesa_idmesa");

                entity.Property(e => e.MesaSucursalIdsucursal).HasColumnName("mesa_sucursal_idsucursal");

                entity.Property(e => e.CombosIdcombos).HasColumnName("combos_idcombos");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Idproduct)
                    .HasMaxLength(45)
                    .HasColumnName("idproduct");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.HasOne(d => d.CombosIdcombosNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CombosIdcombos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orden_combos1");

                entity.HasOne(d => d.Mesa)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => new { d.MesaIdmesa, d.MesaSucursalIdsucursal })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orden_mesa1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.InvoiceIdinvoice, "fk_producto_factura1_idx");

                entity.Property(e => e.Idproduct)
                    .ValueGeneratedNever()
                    .HasColumnName("idproduct");

                entity.Property(e => e.InvoiceIdinvoice).HasColumnName("invoice_idinvoice");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasMaxLength(45)
                    .HasColumnName("price");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(45)
                    .HasColumnName("supplier");

                entity.HasOne(d => d.InvoiceIdinvoiceNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.InvoiceIdinvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_factura1");
            });

            modelBuilder.Entity<ProductHasCombo>(entity =>
            {
                entity.HasKey(e => new { e.ProductoIdproducto, e.CombosIdcombos, e.Idproductocombo })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("product_has_combo");

                entity.HasIndex(e => e.CombosIdcombos, "fk_producto_has_combos_combos1_idx");

                entity.HasIndex(e => e.ProductoIdproducto, "fk_producto_has_combos_producto1_idx");

                entity.Property(e => e.ProductoIdproducto).HasColumnName("producto_idproducto");

                entity.Property(e => e.CombosIdcombos).HasColumnName("combos_idcombos");

                entity.Property(e => e.Idproductocombo)
                    .HasMaxLength(45)
                    .HasColumnName("idproductocombo");

                entity.HasOne(d => d.CombosIdcombosNavigation)
                    .WithMany(p => p.ProductHasCombos)
                    .HasForeignKey(d => d.CombosIdcombos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_has_combos_combos1");

                entity.HasOne(d => d.ProductoIdproductoNavigation)
                    .WithMany(p => p.ProductHasCombos)
                    .HasForeignKey(d => d.ProductoIdproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_has_combos_producto1");

                entity.HasMany(d => d.MenuIdmenus)
                    .WithMany(p => p.ProductHasCombos)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductHasCombosHasCartum",
                        l => l.HasOne<Menu>().WithMany().HasForeignKey("MenuIdmenu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_producto_has_combos_has_carta_carta1"),
                        r => r.HasOne<ProductHasCombo>().WithMany().HasForeignKey("ProductHasComboProductIdproduct", "ProductHasComboComboIdcombo", "ProductHasComboIdproductcombo").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_producto_has_combos_has_carta_producto_has_combos1"),
                        j =>
                        {
                            j.HasKey("ProductHasComboProductIdproduct", "ProductHasComboComboIdcombo", "ProductHasComboIdproductcombo", "MenuIdmenu").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                            j.ToTable("product_has_combos_has_carta");

                            j.HasIndex(new[] { "MenuIdmenu" }, "fk_producto_has_combos_has_carta_carta1_idx");

                            j.HasIndex(new[] { "ProductHasComboProductIdproduct", "ProductHasComboComboIdcombo", "ProductHasComboIdproductcombo" }, "fk_producto_has_combos_has_carta_producto_has_combos1_idx");

                            j.IndexerProperty<int>("ProductHasComboProductIdproduct").HasColumnName("product_has_combo_product_idproduct");

                            j.IndexerProperty<int>("ProductHasComboComboIdcombo").HasColumnName("product_has_combo_combo_idcombo");

                            j.IndexerProperty<string>("ProductHasComboIdproductcombo").HasMaxLength(45).HasColumnName("product_has_combo_idproductcombo");

                            j.IndexerProperty<int>("MenuIdmenu").HasColumnName("menu_idmenu");
                        });
            });

            modelBuilder.Entity<ProductHasOrder>(entity =>
            {
                entity.HasKey(e => new { e.ProductIdproduct, e.OrderIdorder })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("product_has_order");

                entity.HasIndex(e => e.OrderIdorder, "fk_producto_has_orden_orden1_idx");

                entity.HasIndex(e => e.ProductIdproduct, "fk_producto_has_orden_producto1_idx");

                entity.Property(e => e.ProductIdproduct).HasColumnName("product_idproduct");

                entity.Property(e => e.OrderIdorder).HasColumnName("order_idorder");

                entity.HasOne(d => d.ProductIdproductNavigation)
                    .WithMany(p => p.ProductHasOrders)
                    .HasForeignKey(d => d.ProductIdproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_has_orden_producto1");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.IdPurchase)
                    .HasName("PRIMARY");

                entity.ToTable("purchase");

                entity.HasIndex(e => e.ProductIdproduct, "fk_Compra_producto_idx");

                entity.Property(e => e.IdPurchase)
                    .ValueGeneratedNever()
                    .HasColumnName("idPurchase");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Nitsupplier)
                    .HasMaxLength(45)
                    .HasColumnName("nitsupplier");

                entity.Property(e => e.ProductIdproduct).HasColumnName("product_idproduct");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(45)
                    .HasColumnName("quantity");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(45)
                    .HasColumnName("supplier");

                entity.HasOne(d => d.ProductIdproductNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ProductIdproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Compra_producto");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PRIMARY");

                entity.ToTable("rol");

                entity.Property(e => e.Idrol)
                    .ValueGeneratedNever()
                    .HasColumnName("idrol");

                entity.Property(e => e.Rolname)
                    .HasMaxLength(45)
                    .HasColumnName("rolname");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Idstock)
                    .HasName("PRIMARY");

                entity.ToTable("stock");

                entity.HasIndex(e => e.ProductIdproduct, "fk_existencias_producto1_idx");

                entity.Property(e => e.Idstock)
                    .ValueGeneratedNever()
                    .HasColumnName("idstock");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.ProductIdproduct).HasColumnName("product_idproduct");

                entity.Property(e => e.Stock1).HasColumnName("stock");

                entity.HasOne(d => d.ProductIdproductNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductIdproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_existencias_producto1");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => new { e.Idtable, e.BranchIdbranch })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("table");

                entity.HasIndex(e => e.BranchIdbranch, "fk_mesa_sucursal1_idx");

                entity.Property(e => e.Idtable).HasColumnName("idtable");

                entity.Property(e => e.BranchIdbranch).HasColumnName("branch_idbranch");

                entity.Property(e => e.Availability)
                    .HasMaxLength(45)
                    .HasColumnName("availability");

                entity.HasOne(d => d.BranchIdbranchNavigation)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.BranchIdbranch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mesa_sucursal1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Iduser, e.RolIdrol })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user");

                entity.HasIndex(e => e.RolIdrol, "fk_usuario_rol1_idx");

                entity.HasIndex(e => e.BranchIdbranch, "fk_usuario_sucursal1_idx");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.RolIdrol).HasColumnName("rol_idrol");

                entity.Property(e => e.BranchIdbranch).HasColumnName("branch_idbranch");

                entity.Property(e => e.Names)
                    .HasMaxLength(45)
                    .HasColumnName("names");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("password");

                entity.HasOne(d => d.BranchIdbranchNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BranchIdbranch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_sucursal1");

                entity.HasOne(d => d.RolIdrolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolIdrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_rol1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
