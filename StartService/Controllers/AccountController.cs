using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StartService.Data;
using StartService.Dtos;

namespace StartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _repo;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountDto>> GetAllAccounts()
        {
            var accountItems = _repo.GetAllAccounts();

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accountItems)); ;
        }

    }
}