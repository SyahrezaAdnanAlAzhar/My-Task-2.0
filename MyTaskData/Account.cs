using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MyTaskData.Task;

namespace MyTaskData
{
    public class Account
    {
        // penamaan file AccountMyTask_<username>.json
        // contoh AccountMyTask_reza29.json
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public AccountState accountState { get; set; }
        public List<Task> listTask { get; set; }
        public void UpdateState(TriggerAccountState trigger)
        {
            this.accountState = AccountTransition.getNextState(this.accountState, trigger);
        }
    }
}
