using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskUnitTesting
{
    internal class TestingCRUDTask
    {
    }
    /*[TestClass()]
    public class CRUDTaskTests
    {
        [TestMethod()]
        public void updatePrioritasTest_judul()
        {

            try
            {
                CRUDTask.updatePrioritas(null, 5, "Bagas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ada Null Judul");
            }
        }

        [TestMethod()]
        public void updatePrioritasTest_username()
        {
            try
            {
                CRUDTask.updatePrioritas("Tubes", 5, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ada Null Username");
            }
        }
        [TestMethod()]
        public void updatePrioritasTest_prioritas1()
        {
            try
            {
                CRUDTask.updatePrioritas("Tubes", 0, "Bagas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Angka < 0");
            }
        }
        [TestMethod()]
        public void updatePrioritasTest_prioritas2()
        {
            try
            {
                CRUDTask.updatePrioritas("Tubes", 6, "Bagas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Angka < 0");
            }
        }

        [TestMethod()]
        public void updateJenisTugasTest_judul()
        {
            try
            {
                CRUDTask.updateJenisTugas(null, 3, "Reza");
            }
            catch
            {
                Console.WriteLine("Judul tidak boleh null");
            }
        }

        [TestMethod()]
        public void updateJenisTugasTest_username()
        {
            try
            {
                CRUDTask.updateJenisTugas("KPL", 2, null);
            }
            catch
            {
                Console.WriteLine("Username tidak boleh null");
            }
        }

        [TestMethod()]
        public void updateJenisTugasTest_jenisTugas()
        {
            try
            {
                CRUDTask.updateJenisTugas("KPL", 20, "Reza");
            }
            catch
            {
                Console.WriteLine("No urut jenis tugas harus kurang dari 10");
            }
        }
    }*/
}
