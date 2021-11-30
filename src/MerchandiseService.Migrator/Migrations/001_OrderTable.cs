using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class OrderTable : Migration
    {

        public override void Down()
        {
            Execute.Sql(@"
                 CREATE TABLE if not exists orders(
                    id BIGSERIAL PRIMARY KEY,
                    merch_pack INT NOT NULL,
                    status INT NOT NULL,
                    employee_id INT NOT NULL
                    manager_id INT NOT NULL,
                    merch_pack INT NOT NULL,
                    date_of_issue TIMESTAMP ,);
            ");
        }

        public override void Up()
        {
            Execute.Sql("DROP TABLE if exists orders;");
        }
    }
}