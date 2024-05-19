﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary
{
    public class Task
    {
        public enum JenisTugas { Video, Laporan, Project, Desain, Proposal, SlidePresentasi, Observasi, Quiz, ForumDiskusi };
        public enum Prioritas { Highest, High, Medium, Low, Lowest };

        public static string getKodeJenisTugas(JenisTugas jenisTugas)
        {
            string[] KodeJenisTugas = { "F-1V", "F-2L", "F-3P", "F-4D", "F-5P", "F-6S", "NF-1O", "NF-2Q", "NF-3F" };
            return KodeJenisTugas[(int)jenisTugas];
        }

        public static int getUrutanPrioritas(Prioritas prioritas)
        {
            int[] urutan = { 1, 2, 3, 4, 5 };
            return urutan[(int)prioritas];
        }

        public string judul { get; set; }
        public string username { get; set; }
        public string deskripsi { get; set; }
        public DateTime tanggalMulai { get; set; }
        public DateTime tanggalSelesai { get; set; }
        public JenisTugas jenisTugas { get; set; }
        public Prioritas namaPrioritas { get; set; }
        public TaskState taskState { get; set; }

        public Task()
        {

        }

        public Task(string judul, string username, string deskripsi, string tanggalMulai, string tanggalSelesai, string jenisTugas, string namaPrioritas, string taskState)
        {
            this.judul = judul;
            this.username = username;
            this.deskripsi = deskripsi;
            this.tanggalMulai = DateTime.Parse(tanggalMulai);
            this.tanggalSelesai = DateTime.Parse(tanggalSelesai);
            this.jenisTugas = (JenisTugas)Enum.Parse(typeof(JenisTugas), jenisTugas);
            this.namaPrioritas = (Prioritas)Enum.Parse(typeof(Prioritas), namaPrioritas);
            this.taskState = (TaskState)Enum.Parse(typeof(TaskState), taskState);
        }
    }
}
