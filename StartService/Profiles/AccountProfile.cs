using AutoMapper;
using StartService.Dtos;
using StartService.Models;

namespace StartService.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountCreateDto, Account>();
        }
    }
}