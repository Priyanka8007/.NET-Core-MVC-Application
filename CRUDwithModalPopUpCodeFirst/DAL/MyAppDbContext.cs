using CRUDwithModalPopUpCodeFirst.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace CRUDwithModalPopUpCodeFirst.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { set; get; }
    }
}
