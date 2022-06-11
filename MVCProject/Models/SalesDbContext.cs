using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models
{
    public class SalesDbContext : IdentityDbContext<ApplicationUser>/*,IdentityRole,int> *//*DbContext*/
    {
        //2 constructore
        public SalesDbContext() : base()
        {

        }
        //injection

        public SalesDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //pass connection option -Migration
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVCSalesDbProject;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }



        //dbset ==>class table
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
       



    }
}
