using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace URE6XP_HFT_2021221.Models
{
    public class Presentation
    {
        [Key]
        public string PresentationName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey(nameof(Instructor))]
        public string InstrctoreNeptunId { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual LectureHall LectureHall { get; set; }

        [ForeignKey(nameof(LectureHall))]
        public string RoomNumber { get; set; }

        public override string ToString()
        {
            return "Presentation name = " + this.PresentationName+ "\t Instructor neptun id = " + this.InstrctoreNeptunId + "\t Room number = " + this.RoomNumber;
        }

    }
}
