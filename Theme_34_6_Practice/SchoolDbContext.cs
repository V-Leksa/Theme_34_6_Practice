using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using ILogger = NLog.ILogger;

namespace Theme_34_6_Practice
{
    public class SchoolDbContext:DbContext
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public DbSet<Student> Students { get; set; } = null!;

        public SchoolDbContext()
        {
            try
            {
                if (Database.CanConnect())
                {
                    Database.EnsureCreated();
                }
                else
                {
                    Database.EnsureDeleted();
                    Database.EnsureCreated();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании базы {ex.Message}");
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ver = new Version(8, 0, 25);
            MySqlServerVersion mySqlSrvVer = new MySqlServerVersion(ver);
            optionsBuilder.UseMySql("server=192.168.31.12;database=StudentRegistration;user=operator;password=debian", mySqlSrvVer);

            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget("fileTarget")
            {
                FileName = "logs/logfile.log",
                Layout = "${longdate} ${uppercase:${level}} ${message}"
            };
            config.AddRuleForAllLevels(fileTarget);
            LogManager.Configuration = config;

            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddNLog()));
        }
        public override void Dispose()
        {
            base.Dispose();
            LogManager.Shutdown();
            
        }
    }
}
