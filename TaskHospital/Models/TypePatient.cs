using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskHospital.Models
{
    public class TypePatient
    {

        [Key]
        [Required, Display(Name = "رقم التصنيف")]
        public int ID { get; set; }
        [Required, Display(Name = " اسم التصنيف")]
        public string Name { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

    }
}