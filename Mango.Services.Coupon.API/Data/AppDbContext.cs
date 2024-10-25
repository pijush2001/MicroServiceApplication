using Microsoft.EntityFrameworkCore;
using Mango.Services.CouponAPI.Models;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponCode = "20OFF",
                CouponId = 1,
                DiscountAmount = 20,
                MinimumAmount = 200
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponCode = "50OFF",
                CouponId = 2,
                DiscountAmount = 50,
                MinimumAmount = 500
            });
        }
    }
}
