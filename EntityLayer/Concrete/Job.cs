using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public bool Status { get; set; } = true; // Varsayılan değer true.

        [NotMapped] // Veritabanına yansımaması için sadece geçici hesaplamalar için..
        public int ApplicationCount { get; set; }

        [ForeignKey("Employer")]
        public int EmployerID { get; set; }
        public Employer Employer { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
