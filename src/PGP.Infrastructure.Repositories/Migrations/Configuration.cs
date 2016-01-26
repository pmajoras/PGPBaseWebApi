namespace PGP.Infrastructure.Repositories.Migrations
{
    using Domain.Tasks;
    using EF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<EFBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFBaseContext context)
        {
            context.RegisterNew(new Task()
            {
                Name = "teste",
                Stamp = new Domain.ActionStamp() { CreationDate = DateTime.Now }
            });

            context.SaveContextChanges();
        }
    }
}
