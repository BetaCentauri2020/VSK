using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models.DataEntities
{
    public class tbl_gallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int int_id { get; set; }
        [Display(Name = "Title")]
        public string txt_title{ get; set; }
        [Display(Name = "Position")]
        public int? int_position{ get; set; } 
        [Display(Name = "File")]
        public string txt_file{ get; set; }
        [Display(Name = "Date of upload")]
        public DateTime dt_doc{ get; set; }
        [Display(Name = "Status")]
        public int int_status { get; set; }
    }
}
