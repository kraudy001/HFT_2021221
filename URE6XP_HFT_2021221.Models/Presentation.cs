using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URE6XP_HFT_2021221.Models
{
    public class Presentation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PresentationName { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual LectureHall LectureHall { get; set; }
        
    }
}
