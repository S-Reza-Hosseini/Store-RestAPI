namespace Store.Migrations.Migrations;
using FluentMigrator;

[Migration(202410121335)]
public class _202410121335_UpdateProductsTable:Migration
{
    public override void Up()
    {
        Alter.Table("Products")
            .AddColumn("Inventory").AsInt32().WithDefaultValue(0);
    }

    public override void Down()
    {
        Delete.Column("Inventory").FromTable("Products");
    }
}