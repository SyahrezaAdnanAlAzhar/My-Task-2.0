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
using MySql.Data.MySqlClient;
using static MyTaskData.Task;

namespace MyTaskAPI.Controllers
{
    [ApiController]
    public class MyTaskController : ControllerBase
    {
        private readonly Database _database;
        public MyTaskController()
        {
            Database database = new Database("127.0.0.1", "mytask", "root");
            _database = database;
        }

        // Method 1: SignUpAccount
        [HttpPost("SignUpAccount")]
        public IActionResult SignUpAccount([FromBody] Account account)
        {
            MySqlConnection connection = _database.GetConnection();
            _database.OpenConnection(connection);

            try
            {
                // Validasi menggunakan validator account
                var validator = new AccountValidator();
                var validationResult = validator.Validate(account);

                if (!validationResult.IsValid)
                {
                    return BadRequest("Invalid account data");
                }

                // Insert data ke dalam tabel account
                string query = @"INSERT INTO account (username, name, email, password, accountstate)
                                 VALUES (@Username, @Name, @Email, @Password, 'SignedOut')";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", account.userName);
                command.Parameters.AddWithValue("@Name", account.name);
                command.Parameters.AddWithValue("@Email", account.email);
                command.Parameters.AddWithValue("@Password", account.password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok("Account created successfully");
                }
                else
                {
                    return BadRequest("Failed to create account");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection(connection);
            }
        }

        // Method 2: SignInAccount
        [HttpPut("SignInAccount")]
        public IActionResult SignInAccount(string username, string password)
        {
            MySqlConnection connection = _database.GetConnection();
            _database.OpenConnection(connection);

            try
            {
                // Cek apakah username ada di tabel account
                string query = "SELECT COUNT(*) FROM account WHERE username = @Username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                {
                    return BadRequest("Username not found");
                }

                // Validasi password
                query = "SELECT password FROM account WHERE username = @Username";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                string storedPassword = command.ExecuteScalar().ToString();

                if (storedPassword != password)
                {
                    return BadRequest("Incorrect password");
                }

                // Set semua accountstate menjadi 'SignedOut'
                query = "UPDATE account SET accountstate = 'SignedOut'";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                // Set accountstate menjadi 'SignedIn' untuk username yang diberikan
                query = "UPDATE account SET accountstate = 'SignedIn' WHERE username = @Username";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.ExecuteNonQuery();

                return Ok("Sign in successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection(connection);
            }
        }

        // Method 3: SignOutAccount
        [HttpPost("SignOutAccount")]
        public IActionResult SignOutAccount()
        {
            MySqlConnection connection = _database.GetConnection();
            _database.OpenConnection(connection);

            try
            {
                // Set semua accountstate menjadi 'SignedOut'
                string query = "UPDATE account SET accountstate = 'SignedOut'";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                return Ok("Sign out successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection(connection);
            }
        }

        // Method 4: GetActiveAccount
        private Account GetActiveAccount()
        {
            MySqlConnection connection = _database.GetConnection();
            _database.OpenConnection(connection);

            try
            {
                string query = "SELECT * FROM account WHERE accountstate = 'SignedIn'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Account activeAccount = new Account
                    {
                        userName = reader["username"].ToString(),
                        name = reader["name"].ToString(),
                        email = reader["email"].ToString(),
                        password = reader["password"].ToString(),
                        accountState = (AccountState)Enum.Parse(typeof(AccountState), reader["accountstate"].ToString())
                    };

                    return activeAccount;
                }
                else
                {
                    return null; // Jika tidak ditemukan akun yang 'SignedIn'
                }
            }
            finally
            {
                _database.CloseConnection(connection);
            }
        }

        // Method 5: UpdateAccount
        [HttpPut("UpdateAccount")]
        public IActionResult UpdateAccount([FromBody] Account account)
        {
            MySqlConnection connection = _database.GetConnection();
            _database.OpenConnection(connection);

            try
            {
                // Cek apakah ada account yang sedang 'SignedIn'
                Account activeAccount = GetActiveAccount();

                if (activeAccount == null)
                {
                    return NotFound("No active account found");
                }

                // Update account yang 'SignedIn' dengan data baru
                string query = @"UPDATE account
                                 SET name = @Name, email = @Email, password = @Password
                                 WHERE accountstate = 'SignedIn'";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", account.name);
                command.Parameters.AddWithValue("@Email", account.email);
                command.Parameters.AddWithValue("@Password", account.password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok("Account updated successfully");
                }
                else
                {
                    return BadRequest("Failed to update account");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection(connection);
            }
        }


        // Method 6: DeleteAccount
        [HttpDelete("DeleteAccount")]
        public IActionResult DeleteAccount(string password)
        {
            MySqlConnection connection = _database.GetConnection();
            _database.OpenConnection(connection);

            try
            {
                // Cek apakah ada account yang sedang 'SignedIn'
                string query = "SELECT COUNT(*) FROM account WHERE accountstate = 'SignedIn'";
                MySqlCommand command = new MySqlCommand(query, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                {
                    return BadRequest("No active account found");
                }

                // Cek apakah password sesuai dengan account yang 'SignedIn'
                query = "SELECT password FROM account WHERE accountstate = 'SignedIn'";
                command = new MySqlCommand(query, connection);
                string storedPassword = command.ExecuteScalar().ToString();

                if (storedPassword != password)
                {
                    return BadRequest("Incorrect password");
                }

                // Hapus task terkait dengan username yang 'SignedIn'
                query = @"DELETE task FROM task
                          INNER JOIN account ON task.username = account.username
                          WHERE account.accountstate = 'SignedIn'";

                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                // Hapus row account yang 'SignedIn'
                query = "DELETE FROM account WHERE accountstate = 'SignedIn'";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                return Ok("Account deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            finally
            {
                _database.CloseConnection(connection);
            }
        }

        // Method 7: GetAllTask()
        [HttpGet("GetAllTask")]
        public IActionResult GetAllTask()
        {
            try
            {
                // Mendapatkan akun yang sedang aktif ('SignedIn')
                Account activeAccount = GetActiveAccount();

                if (activeAccount == null)
                {
                    return NotFound("No active account found."); // Atau bisa juga BadRequest
                }

                MySqlConnection connection = _database.GetConnection();
                _database.OpenConnection(connection);

                string query = "SELECT * FROM task WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", activeAccount.userName);

                MySqlDataReader reader = command.ExecuteReader();
                List<Task> tasks = new List<Task>();

                while (reader.Read())
                {
                    Task task = new Task
                    {
                        judul = reader["judul"].ToString(),
                        deskripsi = reader["deskripsi"].ToString(),
                        taskState = (TaskState)Enum.Parse(typeof(TaskState), reader["taskstate"].ToString()),
                    };

                    tasks.Add(task);
                }

                _database.CloseConnection(connection);

                if (tasks.Count == 0)
                {
                    return NotFound("No tasks found for active account.");
                }

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Method 8: CreateTask()
        [HttpPost("CreateTask")]
        public IActionResult CreateTask([FromBody] Task task)
        {
            try
            {
                // Step 1: Mendapatkan akun yang sedang aktif ('SignedIn')
                Account activeAccount = GetActiveAccount();

                // Step 2: Validasi apakah ada akun yang aktif
                if (activeAccount == null)
                {
                    return BadRequest("No active account found.");
                }

                // Step 3: Validasi input menggunakan validator TaskValidator
                var validator = new TaskValidator();
                var validationResult = validator.Validate(task, "Default"); // Menggunakan ruleSet "Default"

                // Step 4: Jika validasi tidak berhasil, kembalikan BadRequest dengan pesan error
                if (!validationResult.IsValid)
                {
                    string errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                    return BadRequest($"Invalid task data: {errors}");
                }

                // Step 5: Buka koneksi ke database
                MySqlConnection connection = _database.GetConnection();
                _database.OpenConnection(connection);

                // Step 6: Query untuk insert task ke dalam tabel task
                string query = "INSERT INTO task (judul, deskripsi, tanggalmulai, tanggalselesai, " +
                                "jenistugas, namaprioritas, taskstate, username) " +
                                "VALUES (@judul, @deskripsi, @tanggalmulai, @tanggalselesai, " +
                                "@jenistugas, @namaprioritas, @taskstate, @username)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@judul", task.judul);
                command.Parameters.AddWithValue("@deskripsi", task.deskripsi);
                command.Parameters.AddWithValue("@tanggalmulai", task.tanggalMulai);
                command.Parameters.AddWithValue("@tanggalselesai", task.tanggalSelesai);
                command.Parameters.AddWithValue("@jenistugas", task.jenisTugas);
                command.Parameters.AddWithValue("namaprioritas", task.namaPrioritas);
                command.Parameters.AddWithValue("@taskstate", task.taskState.ToString());
                command.Parameters.AddWithValue("@username", activeAccount.userName);

                // Step 7: Execute query untuk insert task
                int rowsAffected = command.ExecuteNonQuery();

                // Step 8: Tutup koneksi ke database
                _database.CloseConnection(connection);

                // Step 9: Jika rowsAffected <= 0, berarti gagal insert task
                if (rowsAffected <= 0)
                {
                    return BadRequest("Failed to create task.");
                }

                // Step 10: Jika berhasil, kembalikan respon OK dengan pesan sukses
                return Ok("Task created successfully.");
            }
            catch (Exception ex)
            {
                // Step 11: Tangani exception jika terjadi error selama proses
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Method 9: UpdateTask(Task task)
        [HttpPut("UpdateTask")]
        public IActionResult UpdateTask([FromBody] Task task)
        {
            try
            {
                // Mendapatkan akun yang sedang aktif ('SignedIn')
                Account activeAccount = GetActiveAccount();

                if (activeAccount == null)
                {
                    return BadRequest("No active account found.");
                }

                MySqlConnection connection = _database.GetConnection();
                _database.OpenConnection(connection);

                // Memeriksa apakah task dengan judul tersebut ada dan milik user yang 'SignedIn'
                string query = "SELECT COUNT(*) FROM task WHERE judul = @judul AND username = @username";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                checkCommand.Parameters.AddWithValue("@judul", task.judul);
                checkCommand.Parameters.AddWithValue("@username", activeAccount.userName);

                long existingTaskCount = (long)checkCommand.ExecuteScalar();

                if (existingTaskCount <= 0)
                {
                    _database.CloseConnection(connection);
                    return NotFound("Task not found or does not belong to active account.");
                }

                // Melakukan update task
                string updateQuery = "UPDATE task SET deskripsi = @deskripsi, tanggalmulai = @tanggalmulai, " +
                                    "tanggalselesai = @tanggalselesai, jenistugas = @jenistugas, namaprioritas = @namaprioritas, " +
                                    "taskstate = @taskstate WHERE judul = @judul AND username = @username";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@deskripsi", task.deskripsi);
                updateCommand.Parameters.AddWithValue("@tanggalmulai", task.tanggalMulai);
                updateCommand.Parameters.AddWithValue("@tanggalselesai", task.tanggalSelesai);
                updateCommand.Parameters.AddWithValue("@jenistugas", task.jenisTugas);
                updateCommand.Parameters.AddWithValue("@namaprioritas", task.namaPrioritas);
                updateCommand.Parameters.AddWithValue("@taskstate", task.taskState.ToString());
                updateCommand.Parameters.AddWithValue("@judul", task.judul);
                updateCommand.Parameters.AddWithValue("@username", activeAccount.userName);

                int rowsAffected = updateCommand.ExecuteNonQuery();

                _database.CloseConnection(connection);

                if (rowsAffected <= 0)
                {
                    return BadRequest("Failed to update task.");
                }

                return Ok("Task updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Method 10: DeleteTask(string judul)
        [HttpDelete("DeleteTask")]
        public IActionResult DeleteTask(string judul)
        {
            try
            {
                // Mendapatkan akun yang sedang aktif ('SignedIn')
                Account activeAccount = GetActiveAccount();

                if (activeAccount == null)
                {
                    return BadRequest("No active account found.");
                }

                MySqlConnection connection = _database.GetConnection();
                _database.OpenConnection(connection);

                // Memeriksa apakah task dengan judul tersebut ada dan milik user yang 'SignedIn'
                string query = "SELECT COUNT(*) FROM task WHERE judul = @judul AND username = @username";
                MySqlCommand checkCommand = new MySqlCommand(query, connection);
                checkCommand.Parameters.AddWithValue("@judul", judul);
                checkCommand.Parameters.AddWithValue("@username", activeAccount.userName);

                long existingTaskCount = (long)checkCommand.ExecuteScalar();

                if (existingTaskCount <= 0)
                {
                    _database.CloseConnection(connection);
                    return NotFound("Task not found or does not belong to active account.");
                }

                // Melakukan penghapusan task
                string deleteQuery = "DELETE FROM task WHERE judul = @judul AND username = @username";
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@judul", judul);
                deleteCommand.Parameters.AddWithValue("@username", activeAccount.userName);

                int rowsAffected = deleteCommand.ExecuteNonQuery();

                _database.CloseConnection(connection);

                if (rowsAffected <= 0)
                {
                    return BadRequest("Failed to delete task.");
                }

                return Ok("Task deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Method 11: GetAllJudulTask()
        [HttpGet("GetAllJudulTask")]
        public IActionResult GetAllJudulTask()
        {
            try
            {
                // Mendapatkan akun yang sedang aktif ('SignedIn')
                Account activeAccount = GetActiveAccount();

                if (activeAccount == null)
                {
                    return NotFound("No active account found.");
                }

                MySqlConnection connection = _database.GetConnection();
                _database.OpenConnection(connection);

                string query = "SELECT judul FROM task WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", activeAccount.userName);

                MySqlDataReader reader = command.ExecuteReader();
                List<string> judulTasks = new List<string>();

                while (reader.Read())
                {
                    string judul = reader["judul"].ToString();
                    judulTasks.Add(judul);
                }

                _database.CloseConnection(connection);

                if (judulTasks.Count == 0)
                {
                    return NotFound("No tasks found for active account.");
                }

                return Ok(judulTasks);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Method 12: GetATask(string judul)
        [HttpGet("GetATask/{judul}")]
        public IActionResult GetATask(string judul)
        {
            try
            {
                // Mendapatkan akun yang sedang aktif ('SignedIn')
                Account activeAccount = GetActiveAccount();

                if (activeAccount == null)
                {
                    return NotFound("No active account found.");
                }

                MySqlConnection connection = _database.GetConnection();
                _database.OpenConnection(connection);

                // Memeriksa apakah task dengan judul tersebut ada dan milik user yang 'SignedIn'
                string query = "SELECT * FROM task WHERE judul = @judul AND username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@judul", judul);
                command.Parameters.AddWithValue("@username", activeAccount.userName);

                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    _database.CloseConnection(connection);
                    return NotFound("Task not found or does not belong to active account.");
                }

                Task task = new Task
                {
                    judul = reader["judul"].ToString(),
                    deskripsi = reader["deskripsi"].ToString(),
                    tanggalMulai = Convert.ToDateTime(reader["tanggalmulai"]),
                    tanggalSelesai = Convert.ToDateTime(reader["tanggalselesai"]),
                    jenisTugas = (JenisTugas)Enum.Parse(typeof(JenisTugas), reader["jenistugas"].ToString()),
                    namaPrioritas = (Prioritas)Enum.Parse(typeof(Prioritas), reader["namaprioritas"].ToString()),
                    taskState = (TaskState)Enum.Parse(typeof(TaskState), reader["taskstate"].ToString())
                };

                _database.CloseConnection(connection);

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // end
    }

}
