using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URE6XP_HFT_2021221.Models
{
    public class LectureHall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomNumber { get; set; }

        [NotMapped]
        public virtual ICollection<Presentation> Presentations { get; set; }

        public LectureHall()
        {
            Presentations = new HashSet<Presentation>();
        }

    }
}
