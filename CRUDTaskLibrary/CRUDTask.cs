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
            return null;
        }

        // function yang berguna untuk menerima input data tentang Task melalui console
        public static Task GetInputTaskData(TaskValidator validator)
        {
            // dapat implementasi serupa dengan GetInputAccountData
            return null;
        }

        // menambahkan task baru di suatu account
        public static void CreateTask(Account account)
        {
            // melakukan pemanggilan method GetInputTaskData untuk mendapatkan data dari object Task
            // melakukan pemeriksaan apakah ada judul task yang sama atau tidak menggunakan FindTask
            // perbarui judulnya dengan menggunakan method UpdateJudulTask
            // tambahkan task terbaru menggunakan method generic tools yang append pada listTask di object account
        }

        // menampilkan seluruh data task dari suatu account
        public static void PrintAllTask(Account account)
        {

        }

        // menampilkan seluruh data task dari suatu account yang di sorting judulnya
        public static void PrintAllTaskSortedJudul(Account account)
        {

        }

        // lakukan hal yang serupa hingga attribute state

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

            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan Tanggal selesai nya
        public static List<Task> SortTanggalTanggalSelesaiTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;

            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan jenis tugas nya
        public static List<Task> SortJenisTugasTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;

            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan prioritas nya
        public static List<Task> SortPrioritasTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;

            return sortedListTask;
        }

        // function yang akan return suatu list task yang telah terurut berdasarkan statse nya
        public static List<Task> SortStateTask(List<Task> listTasks)
        {
            List<Task> sortedListTask = listTasks;

            return sortedListTask;
        }

        // memperbarui attribute judul dari object task
        public static void UpdateJudulTask(Task task)
        {
            // menerima input judul task baru dari console
            // jika ada judul yang sama, maka lakukan looping untuk menerima judul task terbaru sampai judul task tersebut unik
            // looping juga hingga judul baru bersifat valid menggunakan fluent validator
        }

        // memperbarui attribute deskripsi dari object task
        public static void UpdateDeskripsiTask(Task task)
        {

        }

        // memperbarui attribute tanggal mulai dari object task
        public static void UpdateTanggalMulaiTask(Task task)
        {

        }

        // memperbarui attribute tanggal selesai dari object task
        public static void UpdateTanggalSelesaiTask(Task task)
        {

        }

        // memperbarui attribute JenisTugas dari object task
        public static void UpdateJenisTugasTask(Task task)
        {

        }

        // memperbarui attribute prioritas dari object task
        public static void UpdatePrioritasTask(Task task)
        {

        }

        // memperbarui attribute state dari object task
        public static void UpdateStateTask(Task task)
        {
            // gunakan UpdateState dari object Task
        }

        //
        public static void DeleteTask(Account account, Task task)
        {
            // melakukan penghapusan Task dari listTask attribute account menggunakan method Remove dari generic
        }
    }
}
