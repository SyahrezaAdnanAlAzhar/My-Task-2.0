using MyTaskData;
using Task = MyTaskData.Task;
using Account = MyTaskData.Account;
using CRUDTaskLibrary;
using CRUDAccountLibrary;
using Microsoft.VisualBasic;
using Tools;

public class Program
{
    public static void Main(string[] args)
    {
        //Buat ngetes TASK CRUD
        Account account = new Account();
        Task task1 = new Task();
        Task task2 = new Task();
        Task task3 = new Task();

        account.userName = "test";
        account.password = "123";

        task1.judul = "tubes alpro";
        task1.deskripsi = "awkdoawk enak";
        task1.tanggalMulai = DateTime.Parse("2023-05-03");
        task1.tanggalSelesai = DateTime.Parse("2023-06-03");
        task1.jenisTugas = MyTaskData.Task.JenisTugas.Video;
        task1.namaPrioritas = MyTaskData.Task.Prioritas.Medium;
        task1.taskState = TaskState.ToDo;

        task2.judul = "presentasi alpro";
        task2.deskripsi = "awkdoawk gila";
        task2.tanggalMulai = DateTime.Parse("2023-06-04");
        task2.tanggalSelesai = DateTime.Parse("2023-06-10");
        task2.jenisTugas = MyTaskData.Task.JenisTugas.SlidePresentasi;
        task2.namaPrioritas = MyTaskData.Task.Prioritas.High;
        task2.taskState = TaskState.ToDo;

        task3.judul = "BERMAIN";
        task3.deskripsi = "YAHAHAHAH";
        task3.tanggalMulai = DateTime.Parse("2024-09-03");
        task3.tanggalSelesai = DateTime.Parse("2023-10-03");
        task3.jenisTugas = MyTaskData.Task.JenisTugas.Project;
        task3.namaPrioritas = MyTaskData.Task.Prioritas.Highest;
        task3.taskState = TaskState.ToDo;

        account.listTask.Add(task1);
        account.listTask.Add(task2);
        account.listTask.Add(task3);

        CRUDTask.PrintAllTask(account);

        CRUDTask.UpdateJudulTask(account, task3);

        CRUDTask.PrintAllTask(account);

      /*  CRUDTask.UpdateDeskripsiTask(task1);

        CRUDTask.UpdateTanggalMulaiTask(task1);

        CRUDTask.UpdateTanggalSelesaiTask(task1);

        CRUDTask.UpdateJenisTugasTask(task1);

        CRUDTask.UpdatePrioritasTask(task1);

        CRUDTask.UpdateStateTask(task1);*/

       /* Task testing = CRUDTask.FindTask(account, task1.judul);

        Console.WriteLine(testing.judul);
        Console.WriteLine(testing.deskripsi);
        Console.WriteLine(testing.tanggalMulai);
        Console.WriteLine(testing.tanggalSelesai);
        Console.WriteLine(testing.jenisTugas);
        Console.WriteLine(testing.namaPrioritas);*/

       /* CRUDTask.CreateTask(account);
        
        TaskValidator validator = new TaskValidator();
        Task testing = CRUDTask.GetInputTaskData(validator, account);
        account.listTask.Add(testing);
        testing = CRUDTask.GetInputTaskData(validator, account);
        account.listTask.Add(testing);
        testing = CRUDTask.GetInputTaskData(validator, account);
        account.listTask.Add(testing);
        testing = CRUDTask.GetInputTaskData(validator, account);
        account.listTask.Add(testing);
        CRUDTask.PrintAllTask(account);

        Console.WriteLine("         UPDATED");

        CRUDTask.UpdateJudulTask(account, testing);

        CRUDTask.PrintAllTask(account);*/
    }
}