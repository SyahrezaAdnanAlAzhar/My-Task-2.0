using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary;

namespace AccountLibrary
{
    public class Account
    {
        // penamaan file AccountMyTask_<username>.json
        // contoh AccountMyTask_reza29.json
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public AccountState state { get; set; }
        public List<TaskLibrary.Task> listTask { get; set; } 
    }
}
