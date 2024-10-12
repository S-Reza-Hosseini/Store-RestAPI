namespace Store.Migrations.Migrations;
using FluentMigrator;

[Migration(202410120735)]
public class _202410120735_UpdateOrderItemsTable:Migration
{
    public override void Up()
    {
        Delete.Column("CustomerId").FromTable("OrderItems");
    }

    public override void Down()
    {
        Alter.Table("OrderItems").AddColumn("CustomerId");
    }
}