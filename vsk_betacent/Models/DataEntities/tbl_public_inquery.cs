using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models.DataEntities
{
    public class tbl_public_inquery
    {
        [Display(Name ="ID")]
        public int int_id { get; set; }
        [Display(Name = "Email")]
        public string txt_email { get; set; }
        [Display(Name = "Contact No")]
        public int int_mob { get; set; }
        [Display(Name = "Date of inquery")]
        public DateTime dt_doi { get; set; }
        [Display(Name = "inquery Type")]

        public string txt_inq_typ { get; set; }


    }
}
