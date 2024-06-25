using MyTaskData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAccountLibrary
{
    public class UpdateAccountNameOperation : AccountOperation
    {
        private string newName;

        public UpdateAccountNameOperation(Account account, string newName) : base(account)
        {
            this.newName = newName;
        }

        protected override void PerformOperation()
        {
            account.name = newName;
        }
    }

}
