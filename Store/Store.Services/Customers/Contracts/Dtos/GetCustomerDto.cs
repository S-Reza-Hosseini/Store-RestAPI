using System.ComponentModel.DataAnnotations;

namespace Store.Services.Customers.Contracts.Dtos;

public class GetCustomerDto
{
   
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    
}