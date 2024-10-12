namespace Store.Migrations.Migrations;
using FluentMigrator;

[Migration(202411102220)]
public class _202411102220_UpdateSomeTables:Migration
{
    public override void Up()
    {
        Create.ForeignKey()
            .FromTable("OrderItems")
            .ForeignColumn("OrderId")
            .ToTable("Orders")
            .PrimaryColumns("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("Fk_OrderItems_OrderId_Orders_Id");
    }
}