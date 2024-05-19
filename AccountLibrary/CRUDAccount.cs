using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

// Penamaan file username.json

namespace AccountLibrary
{
    public static class CRUDAccount
    {
        // Mencari file json dengan parameter input username, kemudian return object account yang tersimpan di json tersebut
        private static Account findAccount(string username)
        {
            //mencari file json dengan username pada parameter input
            //jika ditemukan maka return data object Account dari file tersebut
            //jika tidak ditemukan maka return null
            return null;
        }

        // 
        public static Account getInputAccountData(AccountValidator validator)
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

                } while (!validationResult.IsValid);

                // Input nama
                do
                {
                    Console.Write("Nama: ");
                    newAccount.nama = Console.ReadLine();
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

            newAccount.listTask = null;

            return newAccount;
        }
    }
}
