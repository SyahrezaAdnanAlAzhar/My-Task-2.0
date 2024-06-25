using MyTaskData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAccountLibrary
{
    public class CreateAccountOperation : AccountOperation
    {
        public CreateAccountOperation(Account account) : base(account) { }

        protected override void PerformOperation()
        {
            string filePath = $"AccountMyTask_{account.userName}.json";
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

}
