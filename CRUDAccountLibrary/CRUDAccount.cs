using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using MyTaskData;
using Account = MyTaskData.Account;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Newtonsoft.Json;

namespace CRUDAccountLibrary
{
    public static class CRUDAccount
    {
        // penamaan file AccountMyTask_<username>.json
        // contoh AccountMyTask_reza29.json

        // Mencari file json dengan parameter input username, kemudian return object account yang tersimpan di json tersebut
        public static Account FindAccount(string username)
        {
            //mencari file json dengan username pada parameter input
            //jika ditemukan maka return data object Account dari file tersebut
            //jika tidak ditemukan maka return null
            string filePath = $"AccountMyTask_{username}.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Account>(json);
            }
            else
            {
                return null;
            }
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
                    validationResult = validator.Validate(newAccount, ruleSet: "Username");

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
                    newAccount.name = Console.ReadLine();
                    validationResult = validator.Validate(newAccount, ruleSet: "Nama");

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
                    validationResult = validator.Validate(newAccount, ruleSet: "Email");

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
                    validationResult = validator.Validate(newAccount, ruleSet: "Password");

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid);

            } while (!validationResult.IsValid);

            newAccount.accountState = MyTaskData.AccountState.SignedOut;
            newAccount.listTask = new List<MyTaskData.Task>();

            return newAccount;
        }

        // Method yang berguna untuk melakukan sign up sebuah account dan menulis file json baru untuk account tersebut
        public static void SignUpAccount()
        {
            AccountValidator validator = new AccountValidator();
            Account newAccount = GetInputAccountData(validator);

            string filePath = $"AccountMyTask_{newAccount.userName}.json";
            string json = JsonConvert.SerializeObject(newAccount, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Berhasil Melakukan Sign Up!");
        }

        // Method yang berguna untuk melakukan sign in sebuah account
        public static void SignInAccount()
        {
            Account account;
            string username;
            string password;
            do
            {
                Console.Write("Username: ");
                username = Console.ReadLine();

                Console.Write("Password: ");
                password = Console.ReadLine();

                account = FindAccount(username);
                if (account == null || account.password != password)
                {
                    Console.WriteLine("Invalid username or password.");
                }
            } while (account == null || account.password != password);

            Account activeAccount = FindActiveAccount();
            if (activeAccount != null && activeAccount.userName != account.userName)
            {
                activeAccount.accountState = MyTaskData.AccountState.SignedOut;
                ReWriteUpdatedFile(activeAccount);
            }

            account.accountState = MyTaskData.AccountState.SignedIn;
            ReWriteUpdatedFile(account);
            Console.WriteLine("Signed in successfully.");
        }

        // Function yang berguna untuk mencari file json account yang state nya signedIn
        public static Account FindActiveAccount()
        {
            string searchPattern = "AccountMyTask_*.json";
            var jsonFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), searchPattern);

            foreach (var file in jsonFiles)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    Account account = JsonConvert.DeserializeObject<Account>(json);
                    if (account.accountState == MyTaskData.AccountState.SignedIn)
                    {
                        return account;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file {file}: {ex.Message}");
                    // Lanjutkan ke file berikutnya jika terjadi kesalahan
                }
            }
            return null;
            
        }

        // Procedure yang berguna untuk melakukan sign out dari suatu akun, sehingga merubah state nya menjadi signedOut
        public static void SignOutAccount(Account account)
        {
            string password;
            do
            {
                Console.Write("Masukkan Password: ");
                password = Console.ReadLine();
                if (account.password != password)
                {
                    Console.WriteLine("Invalid password.");
                }
            } while (account.password != password);

            account.accountState = MyTaskData.AccountState.SignedOut;
            ReWriteUpdatedFile(account);
            Console.WriteLine("Signed out successfully.");
        }

        // Procedure untuk melakukan update attribute name dari account yang sebagai input parameter
        public static void UpdateAccountName(Account account)
        {
            AccountValidator validator = new AccountValidator();
            ValidationResult result;
            string newName;
            do
            {
                Console.Write("Nama baru: ");
                newName = Console.ReadLine();
                result = validator.Validate(account, ruleSet: "Nama");

                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!result.IsValid);

            account.name = newName;
            ReWriteUpdatedFile(account);
            Console.WriteLine("Nama berhasil diupdate.");
        }

        // Procedure untuk melakukan update attribute email dari account yang sebagai input parameter
        public static void UpdateAccountEmail(Account account)
        {
            AccountValidator validator = new AccountValidator();
            ValidationResult result;
            string newEmail;
            string password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (account.password != password)
                {
                    Console.WriteLine("Invalid password.");
                }

            } while (password != account.password);
            do
            {
                Console.Write("Email baru: ");
                newEmail = Console.ReadLine();
                result = validator.Validate(account, ruleSet: "Email");

                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                    return;
                }

            } while (!result.IsValid);

            account.email = newEmail;
            ReWriteUpdatedFile(account);
            Console.WriteLine("Email berhasil diupdate.");
        }

        // Procedure untuk melakukan update attribute password dari account yang sebagai input parameter
        public static void UpdateAccountPassword(Account account)
        {
            AccountValidator validator = new AccountValidator();
            ValidationResult result;
            string oldPassword;
            string newPassword;
            do
            {
                Console.Write("Password lama: ");
                oldPassword = Console.ReadLine();
                if (account.password != oldPassword)
                {
                    Console.WriteLine("Invalid password.");
                }

            } while (oldPassword != account.password);

            do
            {
                Console.Write("Password baru: ");
                newPassword = Console.ReadLine();
                result = validator.Validate(account, ruleSet: "Password");
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            } while (!result.IsValid);
            
            account.password = newPassword;
            ReWriteUpdatedFile(account);
            Console.WriteLine("Password berhasil diupdate.");
        }

        // Procedure untuk melakukan delete suatu account dan akan menghapus file json nya
        public static void DeleteAccount(Account account)
        {
            string password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (password != account.password)
                {
                    Console.WriteLine("Invalid password.");
                }

            } while (password != account.password);

            string filePath = $"AccountMyTask_{account.userName}.json";
            File.Delete(filePath);
            Console.WriteLine("Account berhasil dihapus.");
            
        }

        // melakukan penulisan ulang di suatu file json pada object yang menjadi parameter input
        public static void ReWriteUpdatedFile(Account account)
        {
            string filePath = $"AccountMyTask_{account.userName}.json";
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static void PrintAllDataAkun(Account account)
        {
            Console.WriteLine("==============INFO AKUN==============");
            Console.WriteLine("Username : " + account.userName);
            Console.WriteLine("Nama     : " + account.name);
            Console.WriteLine("Email    : " + account.email);
            Console.WriteLine("=====================================");
        }
    }
}
