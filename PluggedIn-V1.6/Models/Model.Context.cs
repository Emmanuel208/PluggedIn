using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace PluggedIn_V1._6.Models
{
    public class Model
    {
       


        public partial class PluggedInlogin : DbContext
        {
            public PluggedInlogin()
                : base("name=PluggedInlogin")
            {

            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }


            public DbSet<storeInfo> storeInfos { get; set; }

        }
    }
    }
