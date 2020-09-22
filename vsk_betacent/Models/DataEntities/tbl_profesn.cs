using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models.DataEntities
{
    public class tbl_profesn
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int int_id { get; set; }
        [Display(Name = "Profession")]
        public string txt_profs{ get; set; }
    }
}
