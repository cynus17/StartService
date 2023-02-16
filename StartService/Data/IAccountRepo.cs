using StartService.Models;

namespace StartService.Data
{
    public interface IAccountRepo
    {
        bool SaveChanges();
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int id);
        void CreateAccount(Account acc);
        void UpdateAccount(Account acc);
        void DeleteAccount(Account acc);
    }
}