using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAccountLibrary;
using CRUDTaskLibrary;
using MyTaskData;
using Task = MyTaskData.Task;
using System.Threading;

namespace Progam_My_Task_2._0
{
    public static class Menu
    {
        public static Account activeAccount = CRUDAccount.FindActiveAccount(); 
        public static void MenuMasuk()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("          PILIH AKUN             ");
            Console.WriteLine("=================================");
            Console.WriteLine("| 1. Sign Up                    |");
            Console.WriteLine("| 2. Sign In                    |");
            Console.WriteLine("| 3. Keluar                     |");
            Console.WriteLine("=================================");
            Console.Write("Pilih opsi (1-3): ");
            int pilihan;
            do
            {
                pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        Console.WriteLine("--------Sign Up--------");
                        CRUDAccount.SignUpAccount();
                        Thread.Sleep(2000);
                        MenuMasuk();
                        break;
                    case 2:
                        Console.WriteLine("--------Sign In--------");
                        CRUDAccount.SignInAccount();
                        Thread.Sleep(2000);
                        MenuUtama();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opsi tidak Valid. Harus antara 1-3");
                        break;
                }
            } while (pilihan > 3);
            
        }
        public static void MenuUtama()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("          MENU UTAMA             ");
            Console.WriteLine("=================================");
            Console.WriteLine("| 1. Lihat Semua Tugas          |");
            Console.WriteLine("| 2. Update Tugas               |");
            Console.WriteLine("| 3. Tambah Tugas Baru          |");
            Console.WriteLine("| 4. Hapus Tugas                |");
            Console.WriteLine("| 5. Lihat Info Profil Akun     |");
            Console.WriteLine("| 6. Update Profil Akun         |");
            Console.WriteLine("| 7. Hapus Akun                 |");
            Console.WriteLine("| 8. Sign Out / Keluar          |");
            Console.WriteLine("=================================");
            Console.Write("Pilih opsi (1-8): ");
            int pilihan;
            do
            {
                pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        MenuLihatTugas();
                        break;
                    case 2:
                        MenuUpdateTugas();
                        break;
                    case 3:
                        CRUDTask.CreateTask(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 4:
                        CRUDTask.DeleteTask(activeAccount, MenuPilihTask());
                        MenuKonfirmasiKembali();
                        break;
                    case 5:
                        CRUDAccount.PrintAllDataAkun(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 6:
                        MenuUpdateProfile();
                        break;
                    case 7:
                        CRUDAccount.DeleteAccount(activeAccount);
                        Thread.Sleep(2000);
                        activeAccount = null;
                        MenuMasuk();
                        break;
                    case 8:
                        CRUDAccount.SignOutAccount(activeAccount);
                        MenuMasuk();
                        break;
                    default:
                        Console.WriteLine("Opsi tidak Valid. Harus antara 1-7");
                        break;
                }
            } while (pilihan > 8);
        }
        public static void MenuLihatTugas()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("              LIHAT TUGAS                 ");
            Console.WriteLine("==========================================");
            Console.WriteLine("| 1. Lihat Seluruh Tugas                 |");
            Console.WriteLine("| 2. Lihat Berdasarkan Judul             |");
            Console.WriteLine("| 3. Lihat Berdasarkan Tanggal Mulai     |");
            Console.WriteLine("| 4. Lihat Berdasarkan Tanggal Selesai   |");
            Console.WriteLine("| 5. Lihat Berdasarkan Jenis Tugas       |");
            Console.WriteLine("| 6. Lihat Berdasarkan Prioritas         |");
            Console.WriteLine("| 7. Lihat Berdasarkan Status            |");
            Console.WriteLine("| 8. Kembali                             |");
            Console.WriteLine("==========================================");
            Console.Write("Pilih opsi (1-8): ");
            int pilihan;
            do
            {
                pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        CRUDTask.PrintAllTask(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 2:
                        CRUDTask.PrintAllTaskSortedJudul(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 3:
                        CRUDTask.PrintAllTaskSortedTanggalMulai(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 4:
                        CRUDTask.PrintAllTaskSortedTanggalSelesai(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 5:
                        CRUDTask.PrintAllTaskSortedJenisTugas(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 6:
                        CRUDTask.PrintAllTaskSortedPrioritas(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 7:
                        CRUDTask.PrintAllTaskSortedState(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 8:
                        MenuUtama();
                        break;
                    default:
                        Console.WriteLine("Opsi tidak Valid. Harus antara 1-8");
                        break;
                }
            } while (pilihan > 8);
        }
        public static Task MenuPilihTask()
        {
            Console.Clear();
            CRUDTask.PrintAllTask(activeAccount);
            Console.WriteLine("================================");
            Console.Write("Masukkan JUDUL TUGAS yang ingin diperbarui: ");
            string judulPilihan;
            do
            {
                judulPilihan = Console.ReadLine();
                if (CRUDTask.FindTask(activeAccount, judulPilihan) == null)
                {
                    Console.WriteLine("Tugas TIDAK DITEMUKAN!");
                }
            } while (CRUDTask.FindTask(activeAccount, judulPilihan) == null);
            
            return CRUDTask.FindTask(activeAccount, judulPilihan);
        }
        public static void MenuUpdateTugas()
        {
            Task taskPilihan = MenuPilihTask();
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("          UPDATE TUGAS           ");
            Console.WriteLine("=================================");
            Console.WriteLine("| 1. Judul                      |");
            Console.WriteLine("| 2. Deskripsi                  |");
            Console.WriteLine("| 3. Tanggal Mulai              |");
            Console.WriteLine("| 4. Tanggal Selesai            |");
            Console.WriteLine("| 5. Jenis Tugas                |");
            Console.WriteLine("| 6. Prioritas                  |");
            Console.WriteLine("| 7. Status                     |");
            Console.WriteLine("| 8. Kembali                    |");
            Console.WriteLine("=================================");
            Console.WriteLine("Tugas Terpilih : " + taskPilihan.judul);
            Console.Write("Pilih opsi (1-8): ");
            int pilihan;
            do
            {
                pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        Console.Write("Judul Lama: " + taskPilihan.judul);
                        Console.WriteLine();
                        CRUDTask.UpdateJudulTask(activeAccount, taskPilihan);
                        MenuKonfirmasiKembali();
                        break;
                    case 2:
                        Console.Write("Deskripsi Lama: " + taskPilihan.deskripsi);
                        Console.WriteLine();
                        CRUDTask.UpdateDeskripsiTask(activeAccount, taskPilihan);
                        MenuKonfirmasiKembali();
                        break;
                    case 3:
                        Console.Write("Tanggal Mulai Lama: " + taskPilihan.tanggalMulai);
                        Console.Write("\nTanggal Selesai Lama: " + taskPilihan.tanggalSelesai);
                        Console.WriteLine();
                        CRUDTask.UpdateTanggalMulaiTask(activeAccount, taskPilihan);
                        MenuKonfirmasiKembali();
                        break;
                    case 4:
                        Console.Write("Tanggal Mulai Lama: " + taskPilihan.tanggalMulai);
                        Console.Write("\nTanggal Selesai Lama: " + taskPilihan.tanggalSelesai);
                        Console.WriteLine();
                        CRUDTask.UpdateTanggalSelesaiTask(activeAccount, taskPilihan);
                        MenuKonfirmasiKembali();
                        break;
                    case 5:
                        Console.Write("Jenis Tugas Lama: " + taskPilihan.jenisTugas);
                        Console.WriteLine();
                        CRUDTask.UpdateJenisTugasTask(activeAccount, taskPilihan);
                        MenuKonfirmasiKembali();
                        break;
                    case 6:
                        Console.Write("Prioritas Lama: " + taskPilihan.namaPrioritas);
                        Console.WriteLine();
                        CRUDTask.UpdatePrioritasTask(activeAccount, taskPilihan);
                        MenuKonfirmasiKembali();
                        break;
                    case 7:
                        Console.Write("Status Lama: " + taskPilihan.taskState);
                        Console.WriteLine();
                        CRUDTask.UpdateStateTask(activeAccount, taskPilihan);
                        MenuKonfirmasiKembali();
                        break;
                    case 8:
                        MenuUtama();
                        break;
                    default:
                        Console.WriteLine("Opsi tidak Valid. Harus antara 1-8");
                        break;
                }
            } while (pilihan > 8);
        }
        public static void MenuUpdateProfile()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("          UPDATE PROFILE         ");
            Console.WriteLine("=================================");
            Console.WriteLine("| 1. Nama                       |");
            Console.WriteLine("| 2. Email                      |");
            Console.WriteLine("| 3. Password                   |");
            Console.WriteLine("| 4. Kembali                    |");
            Console.WriteLine("=================================");
            Console.Write("Pilih opsi (1-4): ");
            int pilihan;
            do
            {
                pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        Console.Write("Nama Lama: " + activeAccount.name);
                        Console.WriteLine();
                        CRUDAccount.UpdateAccountName(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 2:
                        Console.Write("Email Lama: " + activeAccount.email);
                        Console.WriteLine();
                        CRUDAccount.UpdateAccountEmail(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 3:
                        CRUDAccount.UpdateAccountPassword(activeAccount);
                        MenuKonfirmasiKembali();
                        break;
                    case 4:
                        MenuUtama();
                        break;
                    default:
                        Console.WriteLine("Opsi tidak Valid. Harus antara 1-4");
                        break;
                }
            } while (pilihan > 4);
        }
        public static void MenuKonfirmasiKembali()
        {
            Console.WriteLine("----------Kembali Ke Menu?----------");
            Console.WriteLine("1. Ya (Jika sudah selesai)");
            Console.Write("Pilih Opsi: ");
            int pilihan;
            do
            {
                pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        MenuUtama();
                        break;
                    default:
                        Console.WriteLine("Opsi tidak Valid. Harus antara 1");
                        break;
                }
            } while (pilihan > 1);
        }
        
    }
}
