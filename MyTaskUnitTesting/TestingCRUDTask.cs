using CRUDTaskLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTaskData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskUnitTesting
{
    [TestClass()]
    public class TestingCRUDTask
    {
        [TestMethod]
        public void TestGetInputTaskData_ValidInput()
        {
            var validator = new TaskValidator();
            var account = new Account(); 

            string[] inputLines = {
                "Judul Task",
                "Deskripsi Task",
                "2024-06-20",
                "2024-06-22",
                "1", 
                "1"  
            };

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Join(Environment.NewLine, inputLines)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    MyTaskData.Task result = CRUDTask.GetInputTaskData(validator, account);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.AreEqual("Judul Task", result.judul);
                    Assert.AreEqual("Deskripsi Task", result.deskripsi);
                    Assert.AreEqual(new DateTime(2024, 06, 20), result.tanggalMulai);
                    Assert.AreEqual(new DateTime(2024, 06, 22), result.tanggalSelesai);
                    Assert.AreEqual(MyTaskData.Task.JenisTugas.Video, result.jenisTugas);
                    Assert.AreEqual(MyTaskData.Task.Prioritas.Highest, result.namaPrioritas);
                }
            }
        }

        [TestMethod]
        public void TestGetInputTaskData_InvalidInput()
        {
            var validator = new TaskValidator(); 
            var account = new Account(); 

            string[] inputLines = {
                "Judul Task",
                "", // Deskripsi kosong
                "2024-06-20",
                "2024-06-22",
                "10", // Pilihan Jenis Tugas di luar range
                "1"   // Pilih Highest
            };

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(string.Join(Environment.NewLine, inputLines)))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act & Assert
                    Assert.ThrowsException<FormatException>(() => CRUDTask.GetInputTaskData(validator, account));
                }
            }
        }
    }
    
}
