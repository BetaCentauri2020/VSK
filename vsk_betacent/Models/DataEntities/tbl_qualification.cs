using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models.DataEntities
{

    public class tbl_qualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int int_id { get; set; }
        [Display(Name = "Qualification")]
        public string txt_qua { get; set; }

    }
}
