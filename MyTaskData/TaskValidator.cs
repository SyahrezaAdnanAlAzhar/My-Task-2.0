using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace MyTaskData
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleSet("Judul", () =>
            {
                RuleFor(x => x.judul).NotEmpty().WithMessage("Judul is required.");
            });

            RuleSet("Deskripsi", () =>
            {
                RuleFor(x => x.deskripsi).NotEmpty().WithMessage("Deskripsi is required.");
            });

            RuleSet("Tanggal", () =>
            {
                RuleFor(x => x.tanggalMulai).NotEmpty().WithMessage("Tanggal Mulai is required.");
                RuleFor(x => x.tanggalSelesai).NotEmpty().WithMessage("Tanggal Selesai is required.");
                RuleFor(x => x.tanggalSelesai).GreaterThan(x => x.tanggalMulai).WithMessage("Tanggal Selesai harus lebih dari Tanggal Mulai.");
            });

            RuleSet("JenisTugas", () =>
            {
                RuleFor(x => x.jenisTugas).IsInEnum().WithMessage("Invalid Kode Jenis Tugas.");
            });

            RuleSet("Prioritas", () =>
            {
                RuleFor(x => x.namaPrioritas).IsInEnum().WithMessage("Invalid Urutan Prioritas.");
            });
        }

        public ValidationResult Validate(Task newTask, string ruleSet)
        {
            return base.Validate(new ValidationContext<Task>(newTask, null, new FluentValidation.Internal.RulesetValidatorSelector(ruleSet.Split(','))));
        }
    }
}
