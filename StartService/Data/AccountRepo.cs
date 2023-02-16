using StartService.Models;

namespace StartService.Data
{
    public class AccountRepo : IAccountRepo
    {
        private readonly ServiceDbContext _context;

        public AccountRepo(ServiceDbContext context)
        {
            _context = context;
        }

        public void CreateAccount(Account acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException(nameof(acc));
            }
            _context.Accounts.Add(acc);
        }

        public void DeleteAccount(Account acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException(nameof(acc));
            }
            _context.Accounts.Remove(acc);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAccount(Account acc)
        {
            // Nothing
        }
    }
}