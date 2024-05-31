using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Account.Business.Dtoes
{
    public class AccountDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public int RequestCount { get; set; }

    }
}
