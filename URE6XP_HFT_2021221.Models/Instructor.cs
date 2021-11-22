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
    public class Instructor
    {
        [Key]
        public string Name { get; set; }

        public string NeptunId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Presentation> Presentations { get; set; }

        public Instructor()
        {
            Presentations = new HashSet<Presentation>();
        }


        public override string ToString()
        {
            return " Name = "+this.Name + "\t NeptunId = " + this.NeptunId;
        }

    }
}
