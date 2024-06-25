using MyTaskData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAccountLibrary
{
    public abstract class AccountOperation
    {
        protected Account account;

        public AccountOperation(Account account)
        {
            this.account = account;
        }

        public void Execute()
        {
            PerformOperation();
            ReWriteUpdatedFile();
        }

        protected abstract void PerformOperation();

        private void ReWriteUpdatedFile()
        {
            CRUDAccount.ReWriteUpdatedFile(account);
        }
    }

}
