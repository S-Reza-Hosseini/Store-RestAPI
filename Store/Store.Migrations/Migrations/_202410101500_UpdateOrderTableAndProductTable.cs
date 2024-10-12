namespace Store.Migrations.Migrations;
using FluentMigrator;

[Migration(202410101500)]
public class _202410101500_UpdateOrderTable:Migration
{
    public override void Up()
    {
        Alter.Table("Orders")
            .AddColumn("TotalPrice").AsDecimal(18, 2).WithDefaultValue(0);

        Alter.Table("Products")
            .AddColumn("Price").AsDecimal(18, 2).WithDefaultValue(0);
    }

    public override void Down()
    {
        Delete.Column("TotalPrice").FromTable("Orders");
        Delete.Column("Price").FromTable("Products");
    }
}