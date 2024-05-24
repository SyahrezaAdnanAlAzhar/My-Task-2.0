using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

// penamaan file AccountMyTask_<username>.json
// contoh AccountMyTask_reza29.json

namespace MyTaskLibrary
{
    public static class CRUDAccount
    {
        // Mencari file json dengan parameter input username, kemudian return object account yang tersimpan di json tersebut
        private static Account FindAccount(string username)
        {
            //mencari file json dengan username pada parameter input
            //jika ditemukan maka return data object Account dari file tersebut
            //jika tidak ditemukan maka return null
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
                    validationResult = validator.Validate(newAccount, ruleSet: "Username");

                    if (!validationResult.IsValid)
                    {
                        // Tampilkan pesan kesalahan jika validasi gagal
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid && FindAccount(newAccount.userName).Equals(null));

                // Input nama
                do
                {
                    Console.Write("Nama: ");
                    newAccount.name = Console.ReadLine();
                    validationResult = validator.Validate(newAccount, ruleSet: "Nama");

                    if (!validationResult.IsValid)
                    {
                        // Tampilkan pesan kesalahan jika validasi gagal
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
                        // Tampilkan pesan kesalahan jika validasi gagal
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
                        // Tampilkan pesan kesalahan jika validasi gagal
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid);

            } while (!validationResult.IsValid);

            newAccount.state = AccountState.SignedOut;
            newAccount.listTask = null;

            return newAccount;
        }

        // Method yang berguna untuk melakukan sign up sebuah account dan menulis file json baru untuk account tersebut
        public static void SignUpAccount()
        {
            // melakukan pemanggilan function GetInputAccountData untuk proses input data
            // melakukan penulisan file json
        }

        // Method yang berguna untuk melakukan sign in sebuah account
        public static void SignInAccount(AccountValidator validator)
        {
            // di sini akan membaca username dan password
            // jika username dan password valid maka akan merubah state dari account menjadi signedIn
            // tetapi sebelum merubah username tersebut menjadi signedIn, harus melakukan pengecekan terlebih dahulu
            // mengecek apakah ada akun lain yang signedIn, jika ada maka dirubah dulu menjadi signedOut
        }

        // Function yang berguna untuk mencari file json account yang state nya signedIn
        public static Account FindActiveAccount()
        {
            //var jsonFiles = Directory.GetFiles("AccountMyTask_*.json");
            return null;
        }

        // Procedure yang berguna untuk melakukan sign out dari suatu akun, sehingga merubah state nya menjadi signedOut
        public static void SignOutAccount(Account account, string password)
        {

        }

        // Procedure untuk melakukan update attribute name dari account yang sebagai input parameter
        public static void UpdateAccountName(Account account)
        {
            // proses menerima input nama baru dilakukan di dalam procedure
            // setelah meneriman input nama baru maka lakukan pemebaruan attribute name
            // pastikan menggunakan Account validator untuk memvalidasi input nama barunya
        }

        // Procedure untuk melakukan update attribute email dari account yang sebagai input parameter
        public static void UpdateAccountEmail(Account account)
        {
            // sebelum melakukan proses update, user harus memasukkan password yang benar terlebih dahulu
            // proses menerima input email baru dilakukan di dalam procedure
            // setelah meneriman input email baru maka lakukan pemebaruan attribute email
            // pastikan menggunakan Account validator untuk memvalidasi input email barunya
        }

        // Procedure untuk melakukan update attribute passwrod dari account yang sebagai input parameter
        public static void UpdateAccountPassword(Account account)
        {
            // sebelum melakukan proses update user, harus memasukkan password yang lama dan benar terlebih dahulu
            // proses menerima input password baru dilakukan di dalam procedure
            // setelah meneriman input password baru maka lakukan pemebaruan attribute password
            // pastikan menggunakan Account validator untuk memvalidasi input password barunya
        }

        // Procedure untuk melakukan delete suatu account dan akan menghapus file json nya
        public static void DeleteAccount(Account account)
        {
            // menghapus file json yang menyimpan data account dari parameter input
            // pastikan untuk melakukan validasi password terlebih dahulu
            // penamaan file AccountMyTask_<username>.json
            // contoh AccountMyTask_reza29.json
        }
    }
}
