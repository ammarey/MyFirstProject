using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstProject.Models
{
    public class student
    {
        public int Id { get; set; }

        [DisplayName("اسم الطالب")]
        [MaxLength(100, ErrorMessage = "عفوا عدد الحروف أطول من اللازم")]
        public string Name { get; set; }

        [DisplayName("اسم المدرسة")]
        [ForeignKey("school")]
        public int schoolid { get; set; }


        public school School { get; set; }

        [DisplayName("التقيم")]
        public double score { get; set; }

    }
}
