namespace WebCinema.Models.Cinema
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext()
            : base("name=MovieDbContext")
        {
        }

        public virtual DbSet<Advertising> Advertisings { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<RoleGroup> RoleGroups { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<ShowTime> ShowTimes { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TypeOfMovie> TypeOfMovies { get; set; }
        public virtual DbSet<TypeOfNew> TypeOfNews { get; set; }
        public virtual DbSet<TypeOfSeat> TypeOfSeats { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<Verify> Verifies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(e => e.Format_)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Trailer)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Poster)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Thumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.TypeOfMovies)
                .WithMany(e => e.Movies)
                .Map(m => m.ToTable("MovieTypes").MapLeftKey("MovieId").MapRightKey("TypeId"));

            modelBuilder.Entity<News>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Seat>()
                .Property(e => e.SeatId)
                .IsUnicode(false);

            modelBuilder.Entity<Seat>()
                .Property(e => e.Row_)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Password_)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Verifies)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.SeatId)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Verifies)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeOfSeat>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Password_)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Verify>()
                .Property(e => e.Payment)
                .HasPrecision(18, 0);
        }
    }
}
