using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models.DataEntities
{
    public class tbl_staff_profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int int_id { get; set; }
        [Display(Name = "Name")]
        public string txt_nm { get; set; }
        [ForeignKey("qualif_id")]
        [Display(Name = "Qualification")]
        public int int_fk_qua { get; set; }
        public tbl_qualification qualif_id { get; set; }
        [ForeignKey("prof_id")]
        [Display(Name = "Profession")]
        public int int_fk_prof { get; set; }
        public tbl_profesn prof_id { get; set; }
        [ForeignKey("desg_id")]
        [Display(Name = "Designation")]
        public int int_fk_desg  { get; set; }
        public tbl_desig_type desg_id { get; set; }
        [Display(Name = "Subject Area")]
        public string txt_fk_sub_area   { get; set; }
        [Display(Name = "DOB")]
        public DateTime dt_dob  { get; set; }
        [Display(Name = "Gender")]
        public int int_gen { get; set; }
        [Display(Name = "Contact Number")]
        public string txt_mob { get; set; }
        [Display(Name = "Email/UserId")]
        public string txt_email   { get; set; }
        [ForeignKey("bld_id")]
        [Display(Name = "Blood Group")]
        public int int_fk_bld_grp { get; set; }
        public tbl_blood_gr bld_id { get; set; }
       
        [Display(Name = "Address")]
        public string txt_address   { get; set; }
        [Display(Name = "Profile photo")]
        public string txt_img  { get; set; }
        [Display(Name = "Password")]
        public string txt_pwd { get; set; }
        [Display(Name = "Status")]
        public int int_status  { get; set; } 

        [Display(Name = "Date of creation")]
        public DateTime dt_doc { get; set; }
        [Display(Name = "Date of Modification")]
        public DateTime dt_dom   { get; set; }
        [Display(Name = "Modified By")]
        public string txt_mod_by { get; set; }

    }
}
