using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcApplication1.Models
{
    public class YiLiaoContext : DbContext
    {
        // 您可以向此文件中添加自定义代码。更改不会被覆盖。
        // 
        // 如果您希望只要更改模型架构，Entity Framework
        // 就会自动删除并重新生成数据库，则将以下
        // 代码添加到 Global.asax 文件中的 Application_Start 方法。
        // 注意: 这将在每次更改模型时销毁并重新创建数据库。
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MvcApplication1.Models.YiLiaoContext>());

        public DbSet<ReadersModels> ReadersModels { get; set; }
        public DbSet<HealthModels> HealthModels { get; set; }
        public DbSet<HospitalImagesModels> HospitalImagesModels { get; set; }

        public DbSet<DoctorsModels> DoctorsModels { get; set; }

        public DbSet<MessageInfoModels> MessageInfoModels { get; set; }

        public DbSet<NewsModels> NewsModels { get; set; }

        public DbSet<UsersModels> UsersModels { get; set; }
        public DbSet<SinglePageModels> SinglePageModels { get; set; }
        public DbSet<MedicalTechModels> MedicalTechModels { get; set; }
        public DbSet<ImageUrlModels> ImageUrlModelses { get; set; }
        public DbSet<ReplyModel> ReplyModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<MessageInfoModels>().HasMany(s => s.Reply).WithRequired(s => s.Message).HasForeignKey(s=>s.MessageId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MessageInfoModels>().HasRequired(s => s.Users).WithMany().HasForeignKey(s=>s.userId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MessageInfoModels>().HasOptional(s=>s.ReplyLast).WithMany().HasForeignKey(s=>s.ReplyLastId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ReplyModel>().HasRequired(s=>s.Users).WithMany().HasForeignKey(s=>s.userId).WillCascadeOnDelete(false);
            modelBuilder.Entity<HospitalImagesModels>().HasMany(s=>s.imageUrlModels).WithOptional(i=>i.HImages).HasForeignKey(i=>i.HImagesId).WillCascadeOnDelete(false);

            
        }
    }
}
