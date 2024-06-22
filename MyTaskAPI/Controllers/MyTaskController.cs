using Microsoft.AspNetCore.Mvc;
using MyTaskData;
using System.IO;
using CRUDAccountLibrary;
using CRUDTaskLibrary;
using Newtonsoft.Json;
using FluentValidation.Results;
using Task = MyTaskData.Task;
using Account = MyTaskData.Account;
using System.Security.Principal;

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
            AccountValidator validator = new AccountValidator();
            ValidationResult validationResult = validator.Validate(account);

            // Melakukan validasi input data
            if (!validationResult.IsValid)
            {
                return BadRequest("Data Account yang dimasukkan tidak valid");
            }

            // Menambahkan pada data account yang sudah valid ke dalam _listAccount
            _listAccount.Add(account);

            // Memperbarui data MyTaskDataPath.json yang telah ditambahkan json path dari account baru
            string jsonPath = $"AccountMyTask_{account.userName}.json";
            _dataPath.Paths.Add(jsonPath);
            _dataPath.WriteToFile("MyTaskDataPath.json");

            // Membuat file json baru untuk account baru
            try
            {
                string jsonContent = JsonConvert.SerializeObject(account, Formatting.Indented);
                System.IO.File.WriteAllText(jsonPath, jsonContent);
            }
            catch(Exception e)
            {
                return BadRequest($"Terjadi error pada pembuatan file json account baru. Error : {e.Message}");
            }

            return Ok($"Account dengan username {account.userName} telah ditambahkan");
        }

        [HttpPut]
        [Route("Account/SignIn")]
        public ActionResult SignInAccount(string username,  string password)
        {
            string jsonPath = $"AccountMyTask_{username}.json";

            // Melakukan pengecekan apakah username pada parameter input terdapat pada _dataPath
            if (!_dataPath.Paths.Contains(jsonPath))
            {
                return BadRequest($"{username} belum terdaftar pada data MyTask, silahkan Sign Up terlebih dahulu");
            }

            // Membaca data account yang memiliki username sesuai dengan parameter input
            Account account = new Account();
            try
            {
                string jsonString = System.IO.File.ReadAllText(jsonPath);
                account = JsonConvert.DeserializeObject<Account>(jsonString);
            }catch (Exception e)
            {
                return BadRequest($"Terjadi error pada pembacaan file json, Error: {e.Message}");
            }

            // Pengecekkan password
            if (account.password.Equals(password)){
                ActivedAccount = account;
            }
            else
            {
                return BadRequest("Password yang anda masukkan salah");
            }
            
            return Ok($"Account dengan username {username} telah berhasil sign in");
        }

        [HttpPut]
        [Route("Account/SignOut")]
        public ActionResult SignOutAccount(string password)
        {
            if (ActivedAccount.password.Equals(password))
            {
                ActivedAccount = null;
            }
            else
            {
                return BadRequest("Password yang anda masukkan salah");
            }
            return Ok($"Account dengan username {ActivedAccount.userName} berhasil sign out");
        }

        [HttpGet]
        [Route("Account/ReadDataAccount")]
        public ActionResult<Account> ReadDataAccount(string username)
        {
            string jsonPath = $"AccountMyTask_{username}.json";

            // Melakukan pengecekan apakah username pada parameter input terdapat pada _dataPath
            if (!_dataPath.Paths.Contains(jsonPath))
            {
                return BadRequest($"{username} belum terdaftar pada data MyTask");
            }

            // Membaca data account yang memiliki username sesuai dengan parameter input
            Account account = new Account();
            try
            {
                string jsonString = System.IO.File.ReadAllText(jsonPath);
                account = JsonConvert.DeserializeObject<Account>(jsonString);
            }
            catch (Exception e)
            {
                return BadRequest($"Terjadi error pada pembacaan file json, Error: {e.Message}");
            }

            return Ok(account);
        }

        [HttpGet]
        [Route("Account/ReadDataAllAccount")]
        public ActionResult<List<Account>> ReadAllDataAccount()
        {
            if (_listAccount.Equals(null))
            {
                return Ok("Tidak ada account sama sekali");
            }
            return Ok(_listAccount);
        }

        [HttpDelete]
        [Route("Account/DeleteAccount")]
        public ActionResult DeleteAccount(string username)
        {
            string jsonPath = $"AccountMyTask_{username}.json";

            // Melakukan penghapusan nama file pada _dataPath
            bool isDeleted = _dataPath.Paths.Remove(jsonPath);
            
            if (!isDeleted)
            {
                return BadRequest($"{username} belum terdaftar pada data MyTask");
            }

            // Memperbarui file MyTaskDataPath.json dengan
            _dataPath.WriteToFile("MyTaskDataPath.json");

            // Memperbarui _listAccount terhadap _dataPath yang sudah terhapus 1 account
            this._listAccount = LoadAllAccount(_dataPath);

            // Menghapus file json dari account yang hendak dihapus
            try
            {
                if (System.IO.File.Exists(jsonPath))
                {
                    System.IO.File.Delete(jsonPath);
                }
                else
                {
                    return BadRequest($"File json dengan username {username} tidak ditemukan");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Terjadi kesalahan dalam melakukan penghapusan file account: {e.Message}");
            }
            

            return Ok($"Account dengan username {username} telah terhapus filenya dan pada data MyTask");
        }

        [HttpGet]
        [Route("Task/ShowAllTask")]
        public ActionResult<List<Task>> GetAllTasks()
        {
            if (ActivedAccount == null)
            {
                return BadRequest("Tidak ada akun yang aktif. Silakan sign in terlebih dahulu.");
            }

            if (ActivedAccount.listTask == null || !ActivedAccount.listTask.Any())
            {
                return NotFound("Tidak ada task yang tersedia.");
            }

            return Ok(ActivedAccount.listTask);
        }

        [HttpPost]
        [Route("Task/Create")]
        public ActionResult CreateTask([FromBody] Task task)
        {
            if (ActivedAccount == null)
            {
                return BadRequest("Tidak ada akun yang aktif. Silakan sign in terlebih dahulu.");
            }

            TaskValidator validator = new TaskValidator();
            ValidationResult validationResult = validator.Validate(task);

            if (!validationResult.IsValid)
            {
                return BadRequest("Data Task yang dimasukkan tidak valid.");
            }

            ActivedAccount.listTask.Add(task);

            // Update file JSON
            string jsonPath = $"AccountMyTask_{ActivedAccount.userName}.json";
            string jsonContent = JsonConvert.SerializeObject(ActivedAccount, Formatting.Indented);
            System.IO.File.WriteAllText(jsonPath, jsonContent);

            return Ok($"Task dengan judul {task.judul} telah berhasil ditambahkan.");
        }

        [HttpPut]
        [Route("Task/Update")]
        public ActionResult UpdateTask([FromBody] Task updatedTask)
        {
            if (ActivedAccount == null)
            {
                return BadRequest("Tidak ada akun yang aktif. Silakan sign in terlebih dahulu.");
            }

            var taskIndex = ActivedAccount.listTask.FindIndex(t => t.judul == updatedTask.judul);
            if (taskIndex == -1)
            {
                return NotFound("Task tidak ditemukan.");
            }

            ActivedAccount.listTask[taskIndex] = updatedTask;

            // Update file JSON
            string jsonPath = $"AccountMyTask_{ActivedAccount.userName}.json";
            string jsonContent = JsonConvert.SerializeObject(ActivedAccount, Formatting.Indented);
            System.IO.File.WriteAllText(jsonPath, jsonContent);

            return Ok($"Task dengan judul {updatedTask.judul} telah berhasil diupdate.");
        }

        [HttpDelete]
        [Route("Task/Delete")]
        public ActionResult DeleteTask(string judulTask)
        {
            if (ActivedAccount == null)
            {
                return BadRequest("Tidak ada akun yang aktif. Silakan sign in terlebih dahulu.");
            }

            var taskToDelete = ActivedAccount.listTask.FirstOrDefault(t => t.judul == judulTask);
            if (taskToDelete == null)
            {
                return NotFound("Task tidak ditemukan.");
            }

            ActivedAccount.listTask.Remove(taskToDelete);

            // Update file JSON
            string jsonPath = $"AccountMyTask_{ActivedAccount.userName}.json";
            string jsonContent = JsonConvert.SerializeObject(ActivedAccount, Formatting.Indented);
            System.IO.File.WriteAllText(jsonPath, jsonContent);

            return Ok($"Task dengan judul {judulTask} telah berhasil dihapus.");
        }

        [HttpPut]
        [Route("Task/UpdateState")]
        public ActionResult UpdateTaskState(string judulTask, TriggerTaskState trigger)
        {
            if (ActivedAccount == null)
            {
                return BadRequest("Tidak ada akun yang aktif. Silakan sign in terlebih dahulu.");
            }

            // Mencari task berdasarkan judul
            var task = ActivedAccount.listTask.FirstOrDefault(t => t.judul == judulTask);
            if (task == null)
            {
                return NotFound("Task tidak ditemukan.");
            }

            // Memperbarui state task menggunakan metode UpdateState yang ada di class Task
            task.UpdateState(trigger);

            // Update file JSON
            string jsonPath = $"AccountMyTask_{ActivedAccount.userName}.json";
            string jsonContent = JsonConvert.SerializeObject(ActivedAccount, Formatting.Indented);
            System.IO.File.WriteAllText(jsonPath, jsonContent);

            return Ok($"State task dengan judul '{judulTask}' telah berhasil diupdate menjadi {task.taskState}.");
        }

    }

}
