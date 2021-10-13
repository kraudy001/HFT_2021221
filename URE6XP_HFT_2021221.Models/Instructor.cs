using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URE6XP_HFT_2021221.Models
{
    class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Name { get; set; }

        public string NeptunId { get; set; }

        [NotMapped]
        public List<Presentations> Presentations { get; set; }



        
    }
}
