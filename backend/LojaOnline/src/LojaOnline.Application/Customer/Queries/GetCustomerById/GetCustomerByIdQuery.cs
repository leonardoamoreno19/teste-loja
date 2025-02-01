using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IQuery<Result<CustomerDto>>
    {
        public int Id { get; set; }
    }
}
