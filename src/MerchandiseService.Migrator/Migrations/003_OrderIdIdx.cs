using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseService.Migrator.Migrations
{
    [Migration(3, TransactionBehavior.None)]
    class OrderIdIdx : ForwardOnlyMigration
    {
        public override void Up()
        {
            //       Create.Index("orders_order_id_idx")
            //.OnTable("orders")
            //.InSchema("public")
            //.OnColumn("id"); ;
            Execute.Sql("CREATE INDEX CONCURRENTLY orders_order_id_idx ON orders (id);");
        }
    }
}
