using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models.DataEntities
{
    public class tbl_notice
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int int_id { get; set; }
        [Display(Name = "Title")]
        public string txt_title{ get; set; }
        [Display(Name = "proiority")]
        public int int_proiority{ get; set; }
        [Display(Name ="Description")]
        public string txt_description { get; set; }
        [Display(Name = "File")]
        public string txt_file { get; set; } 
        [Display(Name = "Date Of Upload")]
        public DateTime dt_dou { get; set; }
        [Display(Name = "Status")]
        public int int_status { get; set; }
        
    }
}