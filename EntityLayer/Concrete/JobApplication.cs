using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationID { get; set; }
        public int JobSeekerID { get; set; }
        public int JobID { get; set; }
        public DateTime ApplicationDate { get; set; }

        public JobSeeker JobSeeker { get; set; }
        public Job Job { get; set; }
    }
}
