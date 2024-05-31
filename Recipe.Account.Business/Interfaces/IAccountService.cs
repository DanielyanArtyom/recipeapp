using Recipe.Account.Business.Dtoes;

namespace Recipe.Account.Business.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateAccount(CreateAccountRequest requestedUser);
        AccountDTO GetAccount(Guid accountId);
    }
}