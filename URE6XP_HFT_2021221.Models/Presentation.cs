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

        [NotMapped]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey(nameof(Instructor))]
        public string InstrctoreName { get; set; }


        [NotMapped]
        public virtual LectureHall LectureHall { get; set; }

        [ForeignKey(nameof(LectureHall))]
        public string RoomNumber { get; set; }

    }
}
