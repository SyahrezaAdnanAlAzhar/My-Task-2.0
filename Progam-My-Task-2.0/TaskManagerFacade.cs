using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAccountLibrary;
using CRUDTaskLibrary;
using Task = MyTaskData.Task;
using MyTaskData;

namespace Progam_My_Task_2._0
{
    public class TaskManagerFacade
    {
        public void SignUp()
        {
            CRUDAccount.SignUpAccount();
        }

        public void SignIn()
        {
            CRUDAccount.SignInAccount();
        }

        public void SignOut(Account account)
        {
            CRUDAccount.SignOutAccount(account);
        }

        public void UpdateAccountName(Account account)
        {
            CRUDAccount.UpdateAccountName(account);
        }

        public void DeleteAccount(Account account)
        {
            CRUDAccount.DeleteAccount(account);
        }

        public void CreateTask(Account account)
        {
            CRUDTask.CreateTask(account);
        }

        public void UpdateJudulTask(Account account, Task task)
        {
            CRUDTask.UpdateJudulTask(account, task);
        }

        public void UpdateDeskripsiTask(Account account, Task task)
        {
            CRUDTask.UpdateDeskripsiTask(account, task);
        }

        public void UpdateTanggalMulaiTask(Account account, Task task)
        {
            CRUDTask.UpdateTanggalMulaiTask(account, task);
        }

        public void UpdateTanggalSelesaiTask(Account account, Task task)
        {
            CRUDTask.UpdateTanggalSelesaiTask(account, task);
        }

        public void UpdateJenisTugasTask(Account account, Task task)
        {
            CRUDTask.UpdateJenisTugasTask(account, task);
        }

        public void UpdatePrioritasTask(Account account, Task task)
        {
            CRUDTask.UpdatePrioritasTask(account, task);
        }

        public void UpdateStateTask(Account account, Task task)
        {
            CRUDTask.UpdateStateTask(account, task);
        }

        public void DeleteTask(Account account, Task task)
        {
            CRUDTask.DeleteTask(account, task);
        }
    }

}
