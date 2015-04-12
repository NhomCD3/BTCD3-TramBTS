using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTramBTS
{
    public class TramContext : DbContext
    {
        //static string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Database";
        static string path = new DirectoryInfo(Environment.CurrentDirectory).FullName;
        static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\TramBTS_DB.mdf;Integrated Security=True;Connect Timeout=30";

        public TramContext()
            : base(connectionString)
            //: base("name=offlineData")
        {
            //Database.SetInitializer<TramContext>(new CreateDatabaseIfNotExists<TramContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TramContext, QLTramBTS.Migrations.Configuration>("TramDBConnectionString"));
            //Database.SetInitializer<TramContext>(new MigrateDatabaseToLatestVersion<TramContext, QLTramBTS.Migrations.Configuration>("TramBTS_DB1"));

            //var path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Database";
            //Database.Connection.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\TramBTS_DB.mdf;Integrated Security=True;";
        }

        public DbSet<Tram> Tram { get; set; }
        public DbSet<ChayMayNo> ChayMayNo { get; set; }
    }
}
