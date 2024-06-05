using Code_First.Contexts;
using Code_First.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Services
{
    public interface IAccountService
    {
        Task<AccountResponseModel> GetAccountAsync(int accountId);
    }

    public class AccountService : IAccountService
    {
        private readonly DatabaseContext _context;

        public AccountService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<AccountResponseModel> GetAccountAsync(int accountId)
        {
            var account = await _context.Accounts
                .Include(a => a.Roles)
                .Include(a => a.Shopping_Carts)
                .ThenInclude(sc => sc.Products)
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (account == null)
            {
                return null;
            }

            return new AccountResponseModel
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Phone = account.Phone,
                Role = account.Roles.Name,
                Cart = account.Shopping_Carts.Select(sc => new AccountResponseModel.CartItem
                {
                    ProductId = sc.ProductId,
                    ProductName = sc.Products.Name,
                    Amount = sc.Amount
                }).ToList()
            };
        }
    }
}
