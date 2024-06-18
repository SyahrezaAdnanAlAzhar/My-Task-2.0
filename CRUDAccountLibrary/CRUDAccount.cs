using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MyTaskData;

namespace CRUDAccountLibrary
{
    // Kelas Account yang digunakan untuk serialize/deserialize data JSON
    public class Account
    {
        public string userName { get; set; }
        public string nama { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public CRUDAccount.AccountState state { get; set; }
        public List<MyTaskData.Task> listTask { get; set; }
    }

    public static class CRUDAccount
    {
        private static string accountDirectory = @"C:\Users\user1\source\repos\My-Task-2.0\CRUDAccountLibrary";

        static CRUDAccount()
        {
            if (!Directory.Exists(accountDirectory))
            {
                Directory.CreateDirectory(accountDirectory);
            }
        }

        public enum AccountState
        {
            SignedOut,
            SignedIn
        }

        // Mencari file json dengan parameter input username, kemudian return object account yang tersimpan di json tersebut
        public static Account FindAccount(string username)
        {
            string filePath = Path.Combine(accountDirectory, $"AccountMyTask_{username}.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Account>(json);
            }
            return null;
        }

        // Function yang berfungsi menerima input data
        public static Account GetInputAccountData(AccountValidator validator)
        {
            Account newAccount = new Account();
            ValidationResult validationResult;

            // Looping hingga semua atribut valid
            do
            {
                // Input username
                do
                {
                    Console.Write("Username: ");
                    newAccount.userName = Console.ReadLine();
                    validationResult = validator.Validate(newAccount, options => options.IncludeRuleSets("Username"));

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid || FindAccount(newAccount.userName) != null);

                // Input nama
                do
                {
                    Console.Write("Nama: ");
                    newAccount.nama = Console.ReadLine();
                    validationResult = validator.Validate(newAccount, options => options.IncludeRuleSets("Nama"));

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid);

                // Input email
                do
                {
                    Console.Write("Email: ");
                    newAccount.email = Console.ReadLine();
                    validationResult = validator.Validate(newAccount, options => options.IncludeRuleSets("Email"));

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid);

                // Input password
                do
                {
                    Console.Write("Password: ");
                    newAccount.password = Console.ReadLine();
                    validationResult = validator.Validate(newAccount, options => options.IncludeRuleSets("Password"));

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid);

            } while (!validationResult.IsValid);

            newAccount.state = AccountState.SignedOut;
            newAccount.listTask = new List<MyTaskData.Task>();

            return newAccount;
        }

        // Method yang berguna untuk melakukan sign up sebuah account dan menulis file json baru untuk account tersebut
        public static void SignUpAccount(AccountValidator validator)
        {
            Account newAccount = GetInputAccountData(validator);

            string filePath = Path.Combine(accountDirectory, $"AccountMyTask_{newAccount.userName}.json");
            string json = JsonSerializer.Serialize(newAccount);
            File.WriteAllText(filePath, json);
        }

        // Method yang berguna untuk melakukan sign in sebuah account
        public static void SignInAccount(AccountValidator validator)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Account account = FindAccount(username);
            if (account == null || account.password != password)
            {
                Console.WriteLine("Invalid username or password.");
                return;
            }

            Account activeAccount = FindActiveAccount();
            if (activeAccount != null)
            {
                activeAccount.state = AccountState.SignedOut;
                ReWriteUpdatedFile(activeAccount);
            }

            account.state = AccountState.SignedIn;
            ReWriteUpdatedFile(account);
            Console.WriteLine("Signed in successfully.");
        }

        // Function yang berguna untuk mencari file json account yang state nya signedIn
        public static Account FindActiveAccount()
        {
            var jsonFiles = Directory.GetFiles(accountDirectory, "AccountMyTask_*.json");
            foreach (var file in jsonFiles)
            {
                string json = File.ReadAllText(file);
                Account account = JsonSerializer.Deserialize<Account>(json);
                if (account.state == AccountState.SignedIn)
                {
                    return account;
                }
            }
            return null;
        }

        // Procedure yang berguna untuk melakukan sign out dari suatu akun, sehingga merubah state nya menjadi signedOut
        public static void SignOutAccount(Account account, string password)
        {
            if (account.password != password)
            {
                Console.WriteLine("Invalid password.");
                return;
            }

            account.state = AccountState.SignedOut;
            ReWriteUpdatedFile(account);
            Console.WriteLine("Signed out successfully.");
        }

        // Procedure untuk melakukan update attribute name dari account yang sebagai input parameter
        public static void UpdateAccountName(Account account)
        {
            Console.Write("Nama baru: ");
            string newName = Console.ReadLine();
            account.nama = newName;

            AccountValidator validator = new AccountValidator();
            ValidationResult result = validator.Validate(account, options => options.IncludeRuleSets("Nama"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return;
            }

            ReWriteUpdatedFile(account);
            Console.WriteLine("Nama berhasil diupdate.");
        }

        // Procedure untuk melakukan update attribute email dari account yang sebagai input parameter
        public static void UpdateAccountEmail(Account account)
        {
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (account.password != password)
            {
                Console.WriteLine("Invalid password.");
                return;
            }

            Console.Write("Email baru: ");
            string newEmail = Console.ReadLine();
            account.email = newEmail;

            AccountValidator validator = new AccountValidator();
            ValidationResult result = validator.Validate(account, options => options.IncludeRuleSets("Email"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return;
            }

            ReWriteUpdatedFile(account);
            Console.WriteLine("Email berhasil diupdate.");
        }

        // Procedure untuk melakukan update attribute password dari account yang sebagai input parameter
        public static void UpdateAccountPassword(Account account)
        {
            Console.Write("Password lama: ");
            string oldPassword = Console.ReadLine();

            if (account.password != oldPassword)
            {
                Console.WriteLine("Invalid password.");
                return;
            }

            Console.Write("Password baru: ");
            string newPassword = Console.ReadLine();
            account.password = newPassword;

            AccountValidator validator = new AccountValidator();
            ValidationResult result = validator.Validate(account, options => options.IncludeRuleSets("Password"));
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return;
            }

            ReWriteUpdatedFile(account);
            Console.WriteLine("Password berhasil diupdate.");
        }

        // Procedure untuk melakukan delete suatu account dan akan menghapus file json nya
        public static void DeleteAccount(Account account)
        {
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (account.password != password)
            {
                Console.WriteLine("Invalid password.");
                return;
            }

            string filePath = Path.Combine(accountDirectory, $"AccountMyTask_{account.userName}.json");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("Account berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("File account tidak ditemukan.");
            }
        }

        // melakukan penulisan ulang di suatu file json pada object yang menjadi parameter input
        public static void ReWriteUpdatedFile(Account account)
        {
            string filePath = Path.Combine(accountDirectory, $"AccountMyTask_{account.userName}.json");
            string json = JsonSerializer.Serialize(account);
            File.WriteAllText(filePath, json);
        }
    }
}
