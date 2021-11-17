using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskHospital.Models
{
    public class Patient
    {
        [Key]
        public int PatientCode { get; set; }

        [Required, Display(Name = "اسم المريض بالعربي")]
        public string PatientNameArabic { get; set; }

        [Required, Display(Name = "اسم المريض بالانجليزية")]
        public string PatientNameEnglish { get; set; }

        [Required, Display(Name = "نوع المريض ")]
        public string Gender { get; set; }

        [Display(Name = "صورة المريض")]
        public string PatientImage { get; set; }

        [Display(Name = "رقم الهاتف الشخصي")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "لوسمحت ادخل رقم الهاتف  الشخصي")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "الرقم غير صحيح ")]
        public string PhoneNumber { get; set; }

        [Display(Name = "رقم الهاتف المنزلي ")]
        public string HomePhone { get; set; }

        //ther R==>1 ---->M
        [Display(Name = "نوع المرض  ")]
        public int TypePatients_ID { get; set; }
        public TypePatient TypePatients { get; set; }


    }
}