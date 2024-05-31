using AutoMapper;
using Recipe.Account.Business.Dtoes;
using Recipe.Account.Business.Interfaces;
using Recipe.Account.Data.Context;
using Recipe.Account.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Account.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAccount(CreateAccountRequest requestedUser)
        {
            try
            {
                var dupilcateUser = this._unitOfWork.Accounts.GetBy(x => x.UserId == requestedUser.UserId);

                if (dupilcateUser is not null)
                {
                    throw new Exception("Account already exists!");
                }

                var mappedUser = this._mapper.Map<AccountEntity>(requestedUser);

                this._unitOfWork.Accounts.Add(mappedUser);

                await this._unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }

        }

        public AccountDTO GetAccount(Guid accountId)
        {
            try
            {
                var acc = this._unitOfWork.Accounts.GetBy(x => x.UserId == accountId);

                if (acc is null)
                {
                    throw new Exception("Account not found!");
                }

                return this._mapper.Map<AccountDTO>(acc);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }

        }
    }
}
