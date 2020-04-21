using AccountingTest.Domain.Models;
using AccountingTest.Web.ViewModels;
using AutoMapper;

namespace AccountingTest.Web.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountViewModel>();
            CreateMap<Transaction, TransactionViewModel>();
        }
    }
}
