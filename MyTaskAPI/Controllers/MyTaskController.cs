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
        private List<Account> _listAccount = new List<Account>();
        public static Account ActivedAccount;

        public class SignUpInputModel
        {
            public string userName { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }

        public class SignInInputModel
        {
            public string userName { get; set; }
            public string password { get; set; }
        }

        // Method untuk menyimpan semua object account yang tersimpan pada semua file json account
        private List<Account> LoadAllAccount(string jsonFileName)
        {
            try
            {
                string data = System.IO.File.ReadAllText(jsonFileName);
                return JsonConvert.DeserializeObject<List<Account>>(data) ?? new List<Account>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Account>();
            }
        }

        // Method untuk menemukan dan menyimpan account yang sedang aktif
        private Account LoadActivedAccount(List<Account> listAccount)
        {
            return listAccount.FirstOrDefault(a => a.accountState == AccountState.SignedIn);
        }

        private void SaveAccountToJsonFile(Account account)
        {
            // Menentukan path file berdasarkan username
            string fileName = $"AccountMyTask_{account.userName}.json";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Mengonversi objek account ke dalam format JSON
            string jsonData = JsonConvert.SerializeObject(account, Formatting.Indented);

            // Menyimpan data JSON ke dalam file
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        [HttpPost]
        [Route("Account/SignUp")]
        public ActionResult SignUpAccount([FromBody] SignUpInputModel input)
        {
            // Membangun path file berdasarkan username
            string fileName = $"AccountMyTask_{input.userName}.json";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Periksa apakah file untuk username tersebut sudah ada
            if (System.IO.File.Exists(filePath))
            {
                return BadRequest("Akun dengan username tersebut sudah ada.");
            }

            var newAccount = new Account
            {
                userName = input.userName,
                name = input.name,
                password = input.password,
                email = input.email,
                accountState = AccountState.SignedOut, // Default state
                listTask = new List<Task>() // Empty task list
            };

            AccountValidator validator = new AccountValidator();
            var usernameCheck = validator.Validate(newAccount, "Username");
            if (!usernameCheck.IsValid)
            {
                return BadRequest(usernameCheck.Errors.Select(e => e.ErrorMessage));
            }

            var nameCheck = validator.Validate(newAccount, "Nama");
            if (!nameCheck.IsValid)
            {
                return BadRequest(nameCheck.Errors.Select(e => e.ErrorMessage));
            }

            var emailCheck = validator.Validate(newAccount, "Email");
            if (!emailCheck.IsValid)
            {
                return BadRequest(emailCheck.Errors.Select(e => e.ErrorMessage));
            }

            var passwordCheck = validator.Validate(newAccount, "Password");
            if (!passwordCheck.IsValid)
            {
                return BadRequest(passwordCheck.Errors.Select(e => e.ErrorMessage));
            }

            _listAccount.Add(newAccount);
            SaveAccountToJsonFile(newAccount);

            return Ok($"Account dengan username {input.userName} telah ditambahkan");
        }

        [HttpPut]
        [Route("Account/SignIn")]
        public ActionResult SignInAccount([FromBody] SignInInputModel input)
        {

            // Membangun path file berdasarkan username
            string fileName = $"AccountMyTask_{input.userName}.json";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Periksa apakah file untuk username tersebut sudah ada
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest("Akun tidak ditemukan, silahkan registrasi");
            }

            // Jika file ada, baca konten file dan deserialisasi menjadi objek Account
            string fileContent = System.IO.File.ReadAllText(filePath);
            Account account = JsonConvert.DeserializeObject<Account>(fileContent);

            // Memeriksa password
            if (account.password != input.password)
            {
                return BadRequest("Password is incorrect.");
            }

            // Jika password benar, ubah accountState menjadi 1
            account.accountState = AccountState.SignedIn;
            ActivedAccount = account;

            // Simpan perubahan ke file JSON
            string updatedContent = JsonConvert.SerializeObject(account, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, updatedContent);

            return Ok($"Account dengan username {input.userName} telah berhasil sign in");
        }

        [HttpPut]
        [Route("Account/SignOut")]
        public ActionResult SignOutAccount()
        {
            if (ActivedAccount == null)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini.");
            }

            // Membangun path file berdasarkan username dari ActivedAccount
            string fileName = $"AccountMyTask_{ActivedAccount.userName}.json";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Mengatur accountState menjadi SignedOut
            ActivedAccount.accountState = AccountState.SignedOut;

            // Simpan perubahan ke file JSON
            string updatedContent = JsonConvert.SerializeObject(ActivedAccount, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, updatedContent);

            // Mengatur ActivedAccount menjadi null setelah berhasil sign out
            ActivedAccount = null;

            // Berikan respons sukses
            return Ok("Signed out successfully.");
        }

        [HttpDelete]
        [Route("Account/DeleteAccount")]
        public ActionResult DeleteAccount(string password)
        {
            // Membangun path file berdasarkan username dari ActivedAccount
            string fileName = $"AccountMyTask_{ActivedAccount.userName}.json";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (ActivedAccount.password == password)
            {
                // Menghapus file Account_{username}.json yang berkaitan dengan akun
                System.IO.File.Delete(filePath);

                // Mengatur ActivedAccount menjadi null setelah berhasil sign out
                ActivedAccount = null;

                return Ok("Akun dan semua task terkait telah berhasil dihapus.");
            }
            else
            {
                return BadRequest("Password is incorrect.");
            }

        }

        /*[HttpGet]
        [Route("Task/ShowAllTask")]
        public ActionResult<List<Task>> GetAllTasks()
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            // Membaca file Task_{username}.json
            string taskPath = $"Task_{ActivedAccount.userName}.json";
            if (!System.IO.File.Exists(taskPath))
            {
                return NotFound("File task tidak ditemukan.");
            }

            try
            {
                var tasksJson = System.IO.File.ReadAllText(taskPath);
                var tasks = JsonConvert.DeserializeObject<List<Task>>(tasksJson);
                return Ok(tasks ?? new List<Task>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan saat membaca file task: {ex.Message}");
            }
        }*/

        [HttpGet]
        [Route("Task/ShowAllTask")]
        public ActionResult<List<Task>> GetAllTasks()
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            return Ok(ActivedAccount.listTask);
        }

        /*[HttpPost]
        [Route("Task/Create")]
        public ActionResult CreateTask([FromBody] Task task)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            // Membaca file Task_{username}.json
            string taskPath = $"Task_{ActivedAccount.userName}.json";
            List<Task> tasks;
            if (System.IO.File.Exists(taskPath))
            {
                var tasksJson = System.IO.File.ReadAllText(taskPath);
                tasks = JsonConvert.DeserializeObject<List<Task>>(tasksJson) ?? new List<Task>();
            }
            else
            {
                tasks = new List<Task>();
            }

            // Menambahkan task baru ke dalam daftar
            tasks.Add(task);

            // Menulis kembali daftar task ke dalam file Task_{username}.json
            try
            {
                var updatedTasksJson = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                System.IO.File.WriteAllText(taskPath, updatedTasksJson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan saat menyimpan task: {ex.Message}");
            }

            return Ok($"Task dengan judul '{task.judul}' telah berhasil ditambahkan.");
        }*/

        [HttpPost]
        [Route("Task/Create")]
        public ActionResult CreateTask([FromBody] Task task)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            TaskValidator taskValidator = new TaskValidator();
            ValidationResult results = taskValidator.Validate(task);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors.Select(e => e.ErrorMessage));
            }

            task.taskState = TaskState.ToDo; // Default state
            ActivedAccount.listTask.Add(task);

            return Ok($"Task dengan judul '{task.judul}' telah berhasil ditambahkan.");
        }

        /*[HttpPut]
        [Route("Task/Update")]
        public ActionResult UpdateTask([FromBody] Task updatedTask)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            string taskPath = $"Task_{ActivedAccount.userName}.json";
            if (!System.IO.File.Exists(taskPath))
            {
                return NotFound("File task tidak ditemukan.");
            }

            try
            {
                var tasksJson = System.IO.File.ReadAllText(taskPath);
                var tasks = JsonConvert.DeserializeObject<List<Task>>(tasksJson) ?? new List<Task>();

                // Mencari task yang akan diperbarui
                var taskIndex = tasks.FindIndex(t => t.judul == updatedTask.judul);
                if (taskIndex == -1)
                {
                    return NotFound($"Task dengan judul '{updatedTask.judul}' tidak ditemukan.");
                }

                // Memperbarui task
                tasks[taskIndex] = updatedTask;

                // Menulis kembali daftar task yang telah diperbarui ke file
                var updatedTasksJson = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                System.IO.File.WriteAllText(taskPath, updatedTasksJson);

                return Ok($"Task dengan judul '{updatedTask.judul}' telah berhasil diperbarui.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan saat memperbarui task: {ex.Message}");
            }
        }*/

        [HttpPut]
        [Route("Task/Update")]
        public ActionResult UpdateTask([FromBody] Task updatedTask)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            var task = ActivedAccount.listTask.FirstOrDefault(t => t.judul == updatedTask.judul);
            if (task == null)
            {
                return NotFound($"Task dengan judul '{updatedTask.judul}' tidak ditemukan.");
            }

            TaskValidator taskValidator = new TaskValidator();
            ValidationResult results = taskValidator.Validate(task);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors.Select(e => e.ErrorMessage));
            }

            ActivedAccount.listTask.Remove(task);
            ActivedAccount.listTask.Add(updatedTask);

            return Ok($"Task dengan judul '{updatedTask.judul}' telah berhasil diperbarui.");
        }

        /*[HttpDelete]
        [Route("Task/Delete")]
        public ActionResult DeleteTask(string judulTask)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            string taskPath = $"Task_{ActivedAccount.userName}.json";
            if (!System.IO.File.Exists(taskPath))
            {
                return NotFound("File task tidak ditemukan.");
            }

            try
            {
                var tasksJson = System.IO.File.ReadAllText(taskPath);
                var tasks = JsonConvert.DeserializeObject<List<Task>>(tasksJson) ?? new List<Task>();

                // Mencari dan menghapus task berdasarkan judul
                var taskToRemove = tasks.FirstOrDefault(t => t.judul == judulTask);
                if (taskToRemove == null)
                {
                    return NotFound($"Task dengan judul '{judulTask}' tidak ditemukan.");
                }

                tasks.Remove(taskToRemove);

                // Menulis kembali daftar task yang telah diperbarui ke file
                var updatedTasksJson = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                System.IO.File.WriteAllText(taskPath, updatedTasksJson);

                return Ok($"Task dengan judul '{judulTask}' telah berhasil dihapus.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan saat menghapus task: {ex.Message}");
            }
        }*/

        [HttpDelete]
        [Route("Task/Delete")]
        public ActionResult DeleteTask(string judulTask)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            var task = ActivedAccount.listTask.FirstOrDefault(t => t.judul == judulTask);
            if (task == null)
            {
                return NotFound($"Task dengan judul '{judulTask}' tidak ditemukan.");
            }

            ActivedAccount.listTask.Remove(task);

            return Ok($"Task dengan judul '{judulTask}' telah berhasil dihapus.");
        }

        /*[HttpPut]
        [Route("Task/MarkAsDone")]
        public ActionResult UpdateTaskStateToDone(string judulTask)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            string taskPath = $"Task_{ActivedAccount.userName}.json";
            if (!System.IO.File.Exists(taskPath))
            {
                return NotFound("File task tidak ditemukan.");
            }

            try
            {
                var tasksJson = System.IO.File.ReadAllText(taskPath);
                var tasks = JsonConvert.DeserializeObject<List<MyTaskData.Task>>(tasksJson) ?? new List<MyTaskData.Task>();

                // Mencari task yang akan diubah statenya
                var task = tasks.FirstOrDefault(t => t.judul == judulTask);
                if (task == null)
                {
                    return NotFound($"Task dengan judul '{judulTask}' tidak ditemukan.");
                }

                // Menggunakan metode UpdateState untuk mengubah state task menjadi Done
                task.UpdateState(TriggerTaskState.Menyelesaikan);

                // Menulis kembali daftar task yang telah diperbarui ke file
                var updatedTasksJson = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                System.IO.File.WriteAllText(taskPath, updatedTasksJson);

                return Ok($"Task dengan judul '{judulTask}' telah ditandai sebagai selesai.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan saat mengubah state task: {ex.Message}");
            }
        }*/

        [HttpPut]
        [Route("Task/MarkAsDone")]
        public ActionResult MarkTaskAsDone(string judulTask)
        {
            if (ActivedAccount == null || ActivedAccount.accountState != AccountState.SignedIn)
            {
                return BadRequest("Tidak ada akun yang aktif saat ini. Silakan sign in terlebih dahulu.");
            }

            var task = ActivedAccount.listTask.FirstOrDefault(t => t.judul == judulTask);
            if (task == null)
            {
                return NotFound($"Task dengan judul '{judulTask}' tidak ditemukan.");
            }

            task.taskState = TaskState.Done;

            return Ok($"Task dengan judul '{judulTask}' telah ditandai sebagai selesai.");
        }

    }

}
