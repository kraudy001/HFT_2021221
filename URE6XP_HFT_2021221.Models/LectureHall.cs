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
    public class LectureHall
    {
        [Key]
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Presentation> Presentations { get; set; }

        public LectureHall()
        {
            Presentations = new HashSet<Presentation>();
        }

        public override string ToString()
        {
            return "Room number = " + this.RoomNumber + "\t Room capacity = "+ this.Capacity ;
        }
    }
}
