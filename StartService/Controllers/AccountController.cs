using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StartService.Data;
using StartService.Dtos;
using StartService.Models;
using Binance.Spot;
using Binance.Spot.Models;
using Binance.Common;
using Newtonsoft.Json;

namespace StartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _repo;
        private readonly IMapper _mapper;
        
        private readonly connectionString _connectionString;

        public AccountController(IAccountRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("getAllAccounts")]
        public ActionResult<IEnumerable<AccountDto>> GetAllAccounts()
        {
            var accountItems = _repo.GetAllAccounts();

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accountItems));
        }

        [HttpGet("{id}", Name = "GetAccountById")]
        public ActionResult<AccountDto> GetAccountById(int id)
        {
            var accountItem = _repo.GetAccountById(id);
            if (accountItem != null)
            {
                return Ok(_mapper.Map<AccountDto>(accountItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AccountDto> CreateAccount(AccountCreateDto acc)
        {
            var accountModel = _mapper.Map<Account>(acc);
            _repo.CreateAccount(accountModel);
            _repo.SaveChanges();

            var accountReadDto = _mapper.Map<AccountDto>(accountModel);

            return CreatedAtRoute(nameof(GetAccountById), new { Id = accountReadDto.Id }, accountReadDto);
        }

        [HttpGet("getAccountAsset")]
        public async Task<ActionResult<String>> getAccountAllAsset()
        {
            HttpClient httpClient = new HttpClient();
            var connectionString = new connectionString();

            var wallet = new Wallet(httpClient, apiKey: connectionString.ApiKey, apiSecret: connectionString.ApiSecret);

            var result = await wallet.UserAsset();

            var response = JsonConvert.DeserializeObject<List<AccountAsset>>(result);

            return Ok(response);
        }




    }

}