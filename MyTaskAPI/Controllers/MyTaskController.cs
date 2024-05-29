using Microsoft.AspNetCore.Mvc;
using MyTaskData;
using CRUDAccountLibrary;
using CRUDTaskLibrary;
using Newtonsoft.Json;
using FluentValidation.Results;
using Task = MyTaskData.Task;

namespace MyTaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyTaskController : ControllerBase
    {
        const string JsonDataPath = "MyTaskDataPath.json";
        private DataPath _dataPath = new DataPath();
        private List<Account> _listAccount = new List<Account>();
        public Account ActivedAccount = new Account();

        public MyTaskController()
        {
            this._dataPath = LoadAllPath(JsonDataPath);
            this._listAccount = LoadAllAccount(_dataPath);
            this.ActivedAccount = LoadActivedAccount(_listAccount);
        }

        // Method untuk menyimpan semua path dari semua file json account
        private DataPath LoadAllPath(string jsonFileName)
        {
            DataPath dataPath = new DataPath();
            try
            {
                return dataPath.ReadFromFile(JsonDataPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dataPath;
        }

        // Method untuk menyimpan semua object account yang tersimpan pada semua file json account
        private List<Account> LoadAllAccount(DataPath dataPath)
        {
            List<Account> listAccount = new List<Account>();
            try
            {
                foreach (var accountPath in dataPath.Paths)
                {
                    string data = System.IO.File.ReadAllText(accountPath);
                    Account account = JsonConvert.DeserializeObject<Account>(data);
                    listAccount.Add(account);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return listAccount;
        }

        // Method untuk menemukan dan menyimpan account yang sedang aktif
        private Account LoadActivedAccount(List<Account> listAccount)
        {
            try
            {
                foreach (var a  in listAccount)
                {
                    if (a.accountState.Equals(AccountState.SignedIn))
                    {
                        return a;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        [HttpPost]
        [Route("Account/SignUp")]
        public ActionResult SignUpAccount(Account account)
        {
            return null;
        }

        [HttpPut]
        [Route("Account/SignIn")]
        public ActionResult SignInAccount(string username,  string password)
        {
            return null;
        }

        [HttpPut]
        [Route("Account/SignOut")]
        public ActionResult SignUpAccount(string username, string password)
        {
            return null;
        }



    }
}
