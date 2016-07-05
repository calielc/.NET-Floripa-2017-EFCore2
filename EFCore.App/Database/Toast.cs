using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.App.Database
{
    public class Toast
    {
        public int ToastId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public Beer Beer { get; set; }

        [Column("Grade")]
        public double Nota { get; set; }

        public string Description { get; set; }
    }
}
