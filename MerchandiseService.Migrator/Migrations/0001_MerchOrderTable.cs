
using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    class MerchOrderTable : Migration
    {
        public override void Down()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists orders ()
            
            ");
        }

        public override void Up()
        {
            throw new System.NotImplementedException();
        }
    }
}
