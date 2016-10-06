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
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieType> MovieTypes { get; set; }
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BillDetail>()
                .Property(e => e.Note)
                .IsUnicode(false);

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
                .HasMany(e => e.MovieTypes)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<News>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Seat>()
                .Property(e => e.SeatId)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Password_)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.SeatId)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeOfMovie>()
                .HasMany(e => e.MovieTypes)
                .WithRequired(e => e.TypeOfMovie)
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
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
