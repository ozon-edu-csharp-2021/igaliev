using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class EmployeeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("employees")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("first_name").AsString().NotNullable()
                .WithColumn("last_name").AsString().NotNullable()
                .WithColumn("middle_name").AsString().NotNullable()
                .WithColumn("emai").AsString().NotNullable()
                .WithColumn("clothing_size").AsInt32().NotNullable();
                
            //Execute.Sql(@"
            //    CREATE TABLE if not exists employees(
            //        id BIGSERIAL PRIMARY KEY,
            //        first_name TEXT NOT NULL,
            //        last_name TEXT NOT NULL,
            //        middle_name TEXT NOT NULL,
            //        email TEXT NOT NULL,
            //        clothing_size INT NOT NULL
            //    );");
        }

        public override void Down()
        {
            Delete.Table("employees");
            //Execute.Sql("DROP TABLE if exists employees;");
        }
    }
}
