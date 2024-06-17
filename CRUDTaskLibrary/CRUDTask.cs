using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTaskData;
using Task = MyTaskData.Task;
using FluentValidation;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Tools;
using System.Security.Principal;

namespace CRUDTaskLibrary
{
    public static class CRUDTask
    {
        // mencari suatu object task didalam attribute list task di object account, dicari berdasarkan judulnya
        public static Task FindTask(Account account, string judulTask)
        {
            List<Task> listTasks = account.listTask;
            Task resultTask = new Task();
            resultTask = CollectionTools.Search(listTasks, judulTask, Task => Task.judul);
            return resultTask;
        }

        // mencari suatu object task didalam attribute list task di object account, dicari berdasarkan object secara spesifiknya
        public static Task FindTask(Account account, Task task)
        {
            List<Task> listTasks = account.listTask;
            Task resultTask = new Task();
            resultTask = CollectionTools.Search(listTasks, task);
            return resultTask;
        }

        // function yang berguna untuk menerima input data tentang Task melalui console
        public static Task GetInputTaskData(TaskValidator validator, Account account)
        {
            Task newTask = new Task();
            ValidationResult validationResult;
            do
            {
                do
                {
                    Console.Write("Judul: ");
                    newTask.judul = Console.ReadLine();
                    validationResult = validator.Validate(newTask, ruleSet: "Judul");

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                } while (!validationResult.IsValid && !FindTask(account, newTask.judul).Equals(null));

                do
                {
                    Console.Write("Deskripsi: ");
                    newTask.deskripsi = Console.ReadLine();
                    validationResult = validator.Validate(newTask, ruleSet: "Deskripsi");

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                } while (!validationResult.IsValid);

                do
                {
                    Console.Write("Tanggal Mulai (YYYY-MM-DD): ");
                    newTask.tanggalMulai = DateTime.Parse(Console.ReadLine());
                    Console.Write("Tanggal Selesai (YYYY-MM-DD): ");
                    newTask.tanggalSelesai = DateTime.Parse(Console.ReadLine());
                    validationResult = validator.Validate(newTask, ruleSet: "Tanggal");

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                } while(!validationResult.IsValid);

                do
                {
                    Console.WriteLine("Jenis Tugas: ");
                    Console.WriteLine("1. Video");
                    Console.WriteLine("2. Laporan");
                    Console.WriteLine("3. Project");
                    Console.WriteLine("4. Desain");
                    Console.WriteLine("5. Proposal");
                    Console.WriteLine("6. Slide Presentasi");
                    Console.WriteLine("7. Observasi");
                    Console.WriteLine("8. Quiz");
                    Console.WriteLine("9. Forum Diskusi");
                    Console.Write("Pilih: ");
                    int pilihan = int.Parse(Console.ReadLine());
                    switch (pilihan)
                    {
                        case 1:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.Video;
                            break;
                        case 2:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.Laporan;
                            break;
                        case 3:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.Project;
                            break;
                        case 4:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.Desain;
                            break;
                        case 5:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.Proposal;
                            break; 
                        case 6:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.SlidePresentasi;
                            break;
                        case 7:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.Observasi;
                            break;
                        case 8:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.Quiz;
                            break;
                        case 9:
                            newTask.jenisTugas = MyTaskData.Task.JenisTugas.ForumDiskusi;
                            break;
                        default:
                            Console.WriteLine("Pilihan Harus diantara 1-9");
                            break;
                    }
                    validationResult = validator.Validate(newTask, ruleSet: "JenisTugas");
                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid);

                do
                {
                    Console.WriteLine("Prioritas Task:");
                    Console.WriteLine("1. Highest");
                    Console.WriteLine("2. High");
                    Console.WriteLine("3. Medium");
                    Console.WriteLine("4. Low");
                    Console.WriteLine("5. Lowest");
                    Console.Write("Pilih: ");

                    int pilihan = int.Parse(Console.ReadLine());
                    switch (pilihan)
                    {
                        case 1:
                            newTask.namaPrioritas = MyTaskData.Task.Prioritas.Highest;
                            break;
                        case 2:
                            newTask.namaPrioritas = MyTaskData.Task.Prioritas.High;
                            break;
                        case 3:
                            newTask.namaPrioritas = MyTaskData.Task.Prioritas.Medium;
                            break;
                        case 4:
                            newTask.namaPrioritas = MyTaskData.Task.Prioritas.Low;
                            break;
                        case 5:
                            newTask.namaPrioritas = MyTaskData.Task.Prioritas.Lowest;
                            break;
                        default:
                            Console.WriteLine("Pilihan harus diantara 1-5");
                            break;
                    }

                    validationResult = validator.Validate(newTask, ruleSet: "Prioritas");
                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }

                } while (!validationResult.IsValid);

            } while (!validationResult.IsValid);

            newTask.taskState = TaskState.ToDo;

            return newTask;
        }

        // menambahkan task baru di suatu account
        public static void CreateTask(Account account)
        {
            // melakukan pemanggilan method GetInputTaskData untuk mendapatkan data dari object Task
            // melakukan pemeriksaan apakah ada judul task yang sama atau tidak menggunakan FindTask
            // perbarui judulnya dengan menggunakan method UpdateJudulTask
            
            TaskValidator validator = new TaskValidator();
            Task newTask = GetInputTaskData(validator, account);

            while (FindTask(account, newTask.judul) != null)
            {
                UpdateJudulTask(account, newTask);
            }

            // tambahkan task terbaru menggunakan method generic tools yang append pada listTask di object account
            CollectionTools.Append(account.listTask, newTask);
        }

        // menampilkan seluruh data task dari suatu account
        public static void PrintAllTask(Account account)
        {
            int i = 1;
            foreach (var task in account.listTask)
            {
                Console.WriteLine("==--==--==--==--==--==--==");
                Console.WriteLine("         Task " + i);
                Console.WriteLine("Judul            : " + task.judul);
                Console.WriteLine("Deskripsi        : " + task.deskripsi);
                Console.WriteLine("Tanggal Mulai    : " + task.tanggalMulai);
                Console.WriteLine("Tanggal Selesai  : " + task.tanggalSelesai);
                Console.WriteLine("Jenis Tugas      : " + task.jenisTugas);
                Console.WriteLine("Prioritas        : " + task.namaPrioritas);
                Console.WriteLine("Status           : " + task.taskState);
                i++;
            }
        }

        // menampilkan seluruh data task dari suatu account yang di sorting judulnya
        public static void PrintAllTaskSortedJudul(Account account)
        {
            List<Task> sortedList = SortJudulTask(account.listTask);
            int i = 1;
            foreach (var task in sortedList)
            {
                Console.WriteLine("==--==--==--==--==--==--==");
                Console.WriteLine("         Task " + i);
                Console.WriteLine("Judul            : " + task.judul);
                Console.WriteLine("Deskripsi        : " + task.deskripsi);
                Console.WriteLine("Tanggal Mulai    : " + task.tanggalMulai);
                Console.WriteLine("Tanggal Selesai  : " + task.tanggalSelesai);
                Console.WriteLine("Jenis Tugas      : " + task.jenisTugas);
                Console.WriteLine("Prioritas        : " + task.namaPrioritas);
                Console.WriteLine("Status           : " + task.taskState);
                i++;
            }
        }

        // menampilkan seluruh data task dari suatu account yang di sorting tgl mulai
        public static void PrintAllTaskSortedTanggalMulai(Account account)
        {
            List<Task> sortedList = SortTanggalMulaiTask(account.listTask);
            int i = 1;
            foreach (var task in sortedList)
            {
                Console.WriteLine("==--==--==--==--==--==--==");
                Console.WriteLine("         Task " + i);
                Console.WriteLine("Judul            : " + task.judul);
                Console.WriteLine("Deskripsi        : " + task.deskripsi);
                Console.WriteLine("Tanggal Mulai    : " + task.tanggalMulai);
                Console.WriteLine("Tanggal Selesai  : " + task.tanggalSelesai);
                Console.WriteLine("Jenis Tugas      : " + task.jenisTugas);
                Console.WriteLine("Prioritas        : " + task.namaPrioritas);
                Console.WriteLine("Status           : " + task.taskState);
                i++;
            }
        }

        // menampilkan seluruh data task dari suatu account yang di sorting tgl selesai
        public static void PrintAllTaskSortedTanggalSelesai(Account account)
        {
            List<Task> sortedList = SortTanggalSelesaiTask(account.listTask);
            int i = 1;
            foreach (var task in sortedList)
            {
                Console.WriteLine("==--==--==--==--==--==--==");
                Console.WriteLine("         Task " + i);
                Console.WriteLine("Judul            : " + task.judul);
                Console.WriteLine("Deskripsi        : " + task.deskripsi);
                Console.WriteLine("Tanggal Mulai    : " + task.tanggalMulai);
                Console.WriteLine("Tanggal Selesai  : " + task.tanggalSelesai);
                Console.WriteLine("Jenis Tugas      : " + task.jenisTugas);
                Console.WriteLine("Prioritas        : " + task.namaPrioritas);
                Console.WriteLine("Status           : " + task.taskState);
                i++;
            }
        }

        // menampilkan seluruh data task dari suatu account yang di sorting jenis tugas
        public static void PrintAllTaskSortedJenisTugas(Account account)
        {
            List<Task> sortedList = SortJenisTugasTask(account.listTask);
            int i = 1;
            foreach (var task in sortedList)
            {
                Console.WriteLine("==--==--==--==--==--==--==");
                Console.WriteLine("         Task " + i);
                Console.WriteLine("Judul            : " + task.judul);
                Console.WriteLine("Deskripsi        : " + task.deskripsi);
                Console.WriteLine("Tanggal Mulai    : " + task.tanggalMulai);
                Console.WriteLine("Tanggal Selesai  : " + task.tanggalSelesai);
                Console.WriteLine("Jenis Tugas      : " + task.jenisTugas);
                Console.WriteLine("Prioritas        : " + task.namaPrioritas);
                Console.WriteLine("Status           : " + task.taskState);
                i++;
            }
        }

        // menampilkan seluruh data task dari suatu account yang di sorting prioritas
        public static void PrintAllTaskSortedPrioritas(Account account)
        {
            List<Task> sortedList = SortPrioritasTask(account.listTask);
            int i = 1;
            foreach (var task in sortedList)
            {
                Console.WriteLine("==--==--==--==--==--==--==");
                Console.WriteLine("         Task " + i);
                Console.WriteLine("Judul            : " + task.judul);
                Console.WriteLine("Deskripsi        : " + task.deskripsi);
                Console.WriteLine("Tanggal Mulai    : " + task.tanggalMulai);
                Console.WriteLine("Tanggal Selesai  : " + task.tanggalSelesai);
                Console.WriteLine("Jenis Tugas      : " + task.jenisTugas);
                Console.WriteLine("Prioritas        : " + task.namaPrioritas);
                Console.WriteLine("Status           : " + task.taskState);
                i++;
            }
        }

        // menampilkan seluruh data task dari suatu account yang di sorting state
        public static void PrintAllTaskSortedState(Account account)
        {
            List<Task> sortedList = SortStateTask(account.listTask);
            int i = 1;
            foreach (var task in sortedList)
            {
                Console.WriteLine("==--==--==--==--==--==--==");
                Console.WriteLine("         Task " + i);
                Console.WriteLine("Judul            : " + task.judul);
                Console.WriteLine("Deskripsi        : " + task.deskripsi);
                Console.WriteLine("Tanggal Mulai    : " + task.tanggalMulai);
                Console.WriteLine("Tanggal Selesai  : " + task.tanggalSelesai);
                Console.WriteLine("Jenis Tugas      : " + task.jenisTugas);
                Console.WriteLine("Prioritas        : " + task.namaPrioritas);
                Console.WriteLine("Status           : " + task.taskState);
                i++;
            }
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan judulnya
        public static List<Task> SortJudulTask(List<Task> listTasks)
        {
            // jadi function ini tidak akan mengupdate data dari object account hanya akan mengembalikan duplikasi listTask yang sudah terurut
            List<Task> sortedListTask = listTasks;
            CollectionTools.Sorting(sortedListTask, Task => Task.judul);
            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan Tanggal mulai nya
        public static List<Task> SortTanggalMulaiTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;
            CollectionTools.Sorting(sortedListTask, Task => Task.tanggalMulai);
            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan Tanggal selesai nya
        public static List<Task> SortTanggalSelesaiTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;
            CollectionTools.Sorting(sortedListTask, Task => Task.tanggalSelesai);
            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan jenis tugas nya
        public static List<Task> SortJenisTugasTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;
            CollectionTools.Sorting(sortedListTask, Task => Task.jenisTugas);
            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan prioritas nya
        public static List<Task> SortPrioritasTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;
            CollectionTools.Sorting(sortedListTask, Task => Task.namaPrioritas);
            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan statse nya
        public static List<Task> SortStateTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;
            CollectionTools.Sorting(sortedListTask, Task => Task.taskState);
            return sortedListTask;
        }

        // memperbarui attribute judul dari object task
        public static void UpdateJudulTask(Account account, Task task)
        {
            // menerima input judul task baru dari console
            // jika ada judul yang sama, maka lakukan looping untuk menerima judul task terbaru sampai judul task tersebut unik
            // looping juga hingga judul baru bersifat valid menggunakan fluent validator
            TaskValidator validator = new TaskValidator();
            ValidationResult validationResult;
            Task tempTask = task;
           
            do
            {
                Console.Write("Masukkan Judul Baru: ");
                tempTask.judul = Console.ReadLine();
                validationResult = validator.Validate(tempTask, ruleSet: "Judul");

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                Console.WriteLine(tempTask.judul);
                bool tes = FindTask(account, tempTask.judul).Equals(null);
                Console.WriteLine(tes);

            } while (!validationResult.IsValid && !FindTask(account, tempTask.judul).Equals(null));

            task.judul = tempTask.judul;
        }

        // memperbarui attribute deskripsi dari object task
        public static void UpdateDeskripsiTask(Task task)
        {
            TaskValidator validator = new TaskValidator();
            ValidationResult validationResult;
            Task tempTask = task;

            do
            { 
                Console.Write("Masukkan Deskripsi Baru: ");
                tempTask.deskripsi = Console.ReadLine();
                validationResult = validator.Validate(tempTask, ruleSet: "Deskripsi");

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!validationResult.IsValid);

            task.deskripsi = tempTask.deskripsi;
        }

        // memperbarui attribute tanggal mulai dari object task
        public static void UpdateTanggalMulaiTask(Task task)
        {
            TaskValidator validator = new TaskValidator();
            ValidationResult validationResult;
            Task tempTask = task;

            do
            {
                Console.Write("Masukkan Tanggal Mulai Baru (YYYY-MM-DD): ");
                tempTask.tanggalMulai = DateTime.Parse(Console.ReadLine());
                validationResult = validator.Validate(tempTask, ruleSet: "Tanggal");

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!validationResult.IsValid);

            task.tanggalMulai = tempTask.tanggalMulai;
        }

        // memperbarui attribute tanggal selesai dari object task
        public static void UpdateTanggalSelesaiTask(Task task)
        {
            TaskValidator validator = new TaskValidator();
            ValidationResult validationResult;
            Task tempTask = task;

            do
            {
                Console.Write("Masukkan Tanggal Selesai Baru (YYYY-MM-DD): ");
                tempTask.tanggalSelesai = DateTime.Parse(Console.ReadLine());
                validationResult = validator.Validate(tempTask, ruleSet: "Tanggal");

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!validationResult.IsValid);

            task.tanggalSelesai= tempTask.tanggalSelesai;
        }

        // memperbarui attribute JenisTugas dari object task
        public static void UpdateJenisTugasTask(Task task)
        {
            TaskValidator validator = new TaskValidator();
            ValidationResult validationResult;
            Task tempTask = task;

            do
            {
                Console.WriteLine("Jenis Tugas: ");
                Console.WriteLine("1. Video");
                Console.WriteLine("2. Laporan");
                Console.WriteLine("3. Project");
                Console.WriteLine("4. Desain");
                Console.WriteLine("5. Proposal");
                Console.WriteLine("6. Slide Presentasi");
                Console.WriteLine("7. Observasi");
                Console.WriteLine("8. Quiz");
                Console.WriteLine("9. Forum Diskusi");
                Console.Write("Pilih Jenis Tugas Baru: ");
                int pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.Video;
                        break;
                    case 2:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.Laporan;
                        break;
                    case 3:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.Project;
                        break;
                    case 4:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.Desain;
                        break;
                    case 5:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.Proposal;
                        break;
                    case 6:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.SlidePresentasi;
                        break;
                    case 7:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.Observasi;
                        break;
                    case 8:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.Quiz;
                        break;
                    case 9:
                        tempTask.jenisTugas = MyTaskData.Task.JenisTugas.ForumDiskusi;
                        break;
                    default:
                        Console.WriteLine("Pilihan Harus diantara 1-9");
                        break;
                }

                task.jenisTugas = tempTask.jenisTugas;
                validationResult = validator.Validate(tempTask, ruleSet: "JenisTugas");

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!validationResult.IsValid);

        }

        // memperbarui attribute prioritas dari object task
        public static void UpdatePrioritasTask(Task task)
        {
            TaskValidator validator = new TaskValidator();
            ValidationResult validationResult;
            Task tempTask = task;

            do
            {
                Console.WriteLine("Prioritas Task:");
                Console.WriteLine("1. Highest");
                Console.WriteLine("2. High");
                Console.WriteLine("3. Medium");
                Console.WriteLine("4. Low");
                Console.WriteLine("5. Lowest");
                Console.Write("Pilih: ");

                int pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        tempTask.namaPrioritas = MyTaskData.Task.Prioritas.Highest;
                        break;
                    case 2:
                        tempTask.namaPrioritas = MyTaskData.Task.Prioritas.High;
                        break;
                    case 3:
                        tempTask.namaPrioritas = MyTaskData.Task.Prioritas.Medium;
                        break;
                    case 4:
                        tempTask.namaPrioritas = MyTaskData.Task.Prioritas.Low;
                        break;
                    case 5:
                        tempTask.namaPrioritas = MyTaskData.Task.Prioritas.Lowest;
                        break;
                    default:
                        Console.WriteLine("Pilihan harus diantara 1-5");
                        break;
                }

                validationResult = validator.Validate(tempTask, ruleSet: "Prioritas");
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!validationResult.IsValid);
        }

        // memperbarui attribute state dari object task
        public static void UpdateStateTask(Task task)
        {
            // gunakan UpdateState dari object Task
            Console.WriteLine("Status Task: " + task.taskState);
            Console.WriteLine("1. Done");
            Console.WriteLine("2. In Progress");
            Console.WriteLine("3. Post Pone");
            Console.WriteLine("Jika batal, maka pilih 4");
            Console.Write("Pilih Update status: ");
            int pilihan = int.Parse(Console.ReadLine());
            switch (pilihan)
            {
                case 1:
                    task.UpdateState(TriggerTaskState.Menyelesaikan); 
                    break;
                case 2:
                    task.UpdateState(TriggerTaskState.Mengerjakan);
                    break;
                case 3:
                    task.UpdateState(TriggerTaskState.Menunda);
                    break;
                case 4:
                    Console.WriteLine("Tidak melakukan update task");
                    break;
                default:
                    Console.WriteLine("Harus diantara 1-4");
                    break;
            }
        }

        public static void DeleteTask(Account account, Task task)
        {
            // melakukan penghapusan Task dari listTask attribute account menggunakan method Remove dari generic
            // Memeriksa apakah task yang akan dihapus ada di dalam listTask
            if (account.listTask.Contains(task))
            {
                // Menghapus task dari listTask
                account.listTask.Remove(task);
            }
            else
            {
                Console.WriteLine("Task tidak ditemukan di dalam daftar tugas.");
            }
        }
    }
}
