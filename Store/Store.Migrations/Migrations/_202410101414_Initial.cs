namespace Store.Migrations.Migrations;
using FluentMigrator;

[Migration(202410101414)]
public class _202410101414_Initial:Migration
{
    public override void Up()
    {
        Create.Table("Customers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("FirstName").AsString(100).NotNullable()
            .WithColumn("LastName").AsString(100).NotNullable()
            .WithColumn("PhoneNumber").AsString(11).NotNullable();

        Create.Table("Products")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("Description").AsString(500).Nullable();

        Create.Table("Orders")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().Identity()
            .WithColumn("CustomerId").AsInt32().NotNullable()
            .WithColumn("DateTime").AsDateTime().NotNullable();

        Create.Table("OrderItems")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("CustomerId").AsInt32().NotNullable()
            .WithColumn("ProductId").AsInt32().NotNullable()
            .WithColumn("OrderId").AsInt32().NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable();

    }

    public override void Down()
    {
        Delete.Table("Customers");
        Delete.Table("Products");
        Delete.Table("Orders");
        Delete.Table("OrderItems");
    }
}