using MyTaskData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAccountLibrary
{
    public class DeleteAccountOperation : AccountOperation
    {
        public DeleteAccountOperation(Account account) : base(account) { }

        protected override void PerformOperation()
        {
            string filePath = $"AccountMyTask_{account.userName}.json";
            File.Delete(filePath);
        }
    }

}
