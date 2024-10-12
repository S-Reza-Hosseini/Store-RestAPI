using FluentMigrator;

namespace Store.Migrations.Migrations;

[Migration(202410120830)]
public class _202410120830_UpdateOrderItemsTable:Migration
{
    public override void Up()
    {
        Alter.Table("OrderItems").AddColumn("Cost").AsDecimal(18, 2).WithDefaultValue(0);
    }

    public override void Down()
    {
        Delete.Column("Cost").FromTable("OrderItems");
    }
}