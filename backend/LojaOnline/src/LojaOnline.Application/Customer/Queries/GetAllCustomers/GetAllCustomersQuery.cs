using System.Collections.Generic;
using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IQuery<Result<List<CustomerDto>>>
    {
    }
}
