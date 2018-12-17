using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaPalace.DataAccess
{
    public partial class PizzaDBContext : DbContext
    {
        public PizzaDBContext()
        {
        }

        public PizzaDBContext(DbContextOptions<PizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Drinks> Drinks { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Inventorydrinks> Inventorydrinks { get; set; }
        public virtual DbSet<Inventorypizzas> Inventorypizzas { get; set; }
        public virtual DbSet<Inventorysides> Inventorysides { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Orderdetails> Orderdetails { get; set; }
        public virtual DbSet<Ordereddrinks> Ordereddrinks { get; set; }
        public virtual DbSet<Orderedpizzas> Orderedpizzas { get; set; }
        public virtual DbSet<Orderedsides> Orderedsides { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Pizzastore> Pizzastore { get; set; }
        public virtual DbSet<Sides> Sides { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("pk_customer_userid");

                entity.ToTable("Customer", "PizzaSC");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Dateplaced).HasColumnName("dateplaced");

                entity.Property(e => e.Deflocationid).HasColumnName("deflocationid");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Haveorder).HasColumnName("haveorder");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Deflocation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Deflocationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_to_location_locationid");
            });

            modelBuilder.Entity<Drinks>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("pk_drinks_name");

                entity.ToTable("Drinks", "PizzaSC");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasDefaultValueSql("((1.25))");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History", "PizzaSC");

                entity.Property(e => e.Historyid).HasColumnName("historyid");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_history_to_orderdetails_orderid");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_history_to_pizzastore_storeid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_history_to_customer_userid");
            });

            modelBuilder.Entity<Inventorydrinks>(entity =>
            {
                entity.HasKey(e => e.Inventdrinkid)
                    .HasName("pk_inventorydrinks");

                entity.ToTable("Inventorydrinks", "PizzaSC");

                entity.Property(e => e.Inventdrinkid).HasColumnName("inventdrinkid");

                entity.Property(e => e.Drinkname)
                    .IsRequired()
                    .HasColumnName("drinkname")
                    .HasMaxLength(50);

                entity.Property(e => e.Itemamount)
                    .HasColumnName("itemamount")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.HasOne(d => d.DrinknameNavigation)
                    .WithMany(p => p.Inventorydrinks)
                    .HasForeignKey(d => d.Drinkname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorydrinks_to_drinks_name");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventorydrinks)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorydrinks_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Inventorypizzas>(entity =>
            {
                entity.HasKey(e => e.Inventpizzasid)
                    .HasName("pk_inventorypizzas");

                entity.ToTable("Inventorypizzas", "PizzaSC");

                entity.Property(e => e.Inventpizzasid).HasColumnName("inventpizzasid");

                entity.Property(e => e.Itemamount)
                    .HasColumnName("itemamount")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.Pizzaname)
                    .IsRequired()
                    .HasColumnName("pizzaname")
                    .HasMaxLength(50);

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.HasOne(d => d.PizzanameNavigation)
                    .WithMany(p => p.Inventorypizzas)
                    .HasForeignKey(d => d.Pizzaname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorypizzas_to_pizzas_name");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventorypizzas)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorypizzas_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Inventorysides>(entity =>
            {
                entity.HasKey(e => e.Inventsidesid)
                    .HasName("pk_inventorysides");

                entity.ToTable("Inventorysides", "PizzaSC");

                entity.Property(e => e.Inventsidesid).HasColumnName("inventsidesid");

                entity.Property(e => e.Itemamount)
                    .HasColumnName("itemamount")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.Sidename)
                    .IsRequired()
                    .HasColumnName("sidename")
                    .HasMaxLength(50);

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.HasOne(d => d.SidenameNavigation)
                    .WithMany(p => p.Inventorysides)
                    .HasForeignKey(d => d.Sidename)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorysides_to_sides_name");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventorysides)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorysides_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "PizzaSC");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(2);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Orderdetails>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("pk_orderdetails_orderid");

                entity.ToTable("Orderdetails", "PizzaSC");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Dateplaced).HasColumnName("dateplaced");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.Property(e => e.Totalcost).HasColumnName("totalcost");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_customers_userid");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_location_locationid");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Ordereddrinks>(entity =>
            {
                entity.ToTable("Ordereddrinks", "PizzaSC");

                entity.Property(e => e.Ordereddrinksid).HasColumnName("ordereddrinksid");

                entity.Property(e => e.Drinkname)
                    .IsRequired()
                    .HasColumnName("drinkname")
                    .HasMaxLength(50);

                entity.Property(e => e.Drinkqty).HasColumnName("drinkqty");

                entity.Property(e => e.Drinkscost).HasColumnName("drinkscost");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.HasOne(d => d.DrinknameNavigation)
                    .WithMany(p => p.Ordereddrinks)
                    .HasForeignKey(d => d.Drinkname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordereddrinks_to_drinks_name");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ordereddrinks)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordereddrinks_to_order_orderid");
            });

            modelBuilder.Entity<Orderedpizzas>(entity =>
            {
                entity.ToTable("Orderedpizzas", "PizzaSC");

                entity.Property(e => e.Orderedpizzasid).HasColumnName("orderedpizzasid");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Pizzaname)
                    .IsRequired()
                    .HasColumnName("pizzaname")
                    .HasMaxLength(50);

                entity.Property(e => e.Pizzaqty).HasColumnName("pizzaqty");

                entity.Property(e => e.Pizzascost).HasColumnName("pizzascost");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderedpizzas)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderedpizzas_to_order_orderid");

                entity.HasOne(d => d.PizzanameNavigation)
                    .WithMany(p => p.Orderedpizzas)
                    .HasForeignKey(d => d.Pizzaname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderedpizzas_to_pizzas_name");
            });

            modelBuilder.Entity<Orderedsides>(entity =>
            {
                entity.ToTable("Orderedsides", "PizzaSC");

                entity.Property(e => e.Orderedsidesid).HasColumnName("orderedsidesid");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Sidename)
                    .IsRequired()
                    .HasColumnName("sidename")
                    .HasMaxLength(50);

                entity.Property(e => e.Sideqty).HasColumnName("sideqty");

                entity.Property(e => e.Sidescost).HasColumnName("sidescost");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderedsides)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderedsides_to_order_orderid");

                entity.HasOne(d => d.SidenameNavigation)
                    .WithMany(p => p.Orderedsides)
                    .HasForeignKey(d => d.Sidename)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderedsides_to_sides_name");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("pk_pizzas_name");

                entity.ToTable("Pizzas", "PizzaSC");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasDefaultValueSql("((6.75))");
            });

            modelBuilder.Entity<Pizzastore>(entity =>
            {
                entity.HasKey(e => e.Storeid)
                    .HasName("pk_pizzastore_storeid");

                entity.ToTable("Pizzastore", "PizzaSC");

                entity.HasIndex(e => e.Locationid)
                    .HasName("UQ__Pizzasto__306F78A7C729B045")
                    .IsUnique();

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Location)
                    .WithOne(p => p.Pizzastore)
                    .HasForeignKey<Pizzastore>(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pizzastore_to_location_locationid");
            });

            modelBuilder.Entity<Sides>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("pk_sides_name");

                entity.ToTable("Sides", "PizzaSC");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasDefaultValueSql("((4.50))");
            });
        }
    }
}
