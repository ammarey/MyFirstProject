using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFirstProject.Models
{
    public class school
    {
        [Key]
        public int schoolid { get; set; }


        [DisplayName("اسم المدرسة")]
        [MaxLength(100, ErrorMessage = "عفوا عدد الحروف أطول من اللازم")]
        [Required(ErrorMessage = "الحقل مطلوب")]
        public string Name { get; set; }
    }
}
