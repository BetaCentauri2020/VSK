using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models.DataEntities
{
    public class tbl_sub_area_type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int int_id { get; set; }
        
        [Display(Name = "Subject Area")]
        public string txt_sub { get; set; }
    }
}
