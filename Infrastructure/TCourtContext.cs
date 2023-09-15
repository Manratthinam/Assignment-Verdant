using Domain.dbDomain;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure
{
    public class TCourtContext:DbContext
    {
        public TCourtContext(DbContextOptions<TCourtContext> options): base(options) {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<CourtInfo> CourtInfo { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfiguration();
            modelBuilder.HasDefaultSchema(null);
            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetProperties()))
            {
                item.SetColumnName(item.Name.ToLower());
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
