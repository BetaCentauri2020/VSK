using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vsk_betacent.Models.DataEntities;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace vsk_betacent.Models.ViewModels
{
    
    public class ManageStaffEntityModel
    {
        [Display(Name = "ID")]
        public int int_id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string txt_nm { get; set; }
        [Required(ErrorMessage = "*")]
        [ForeignKey("qualif_id")]
        [Display(Name = "Qualification")]
        public int int_fk_qua { get; set; }
        public tbl_qualification qualif_id { get; set; }
        [Required(ErrorMessage = "*")]
        [ForeignKey("prof_id")]
        [Display(Name = "Profession")]
        public int int_fk_prof { get; set; }
        public tbl_profesn prof_id { get; set; }
        [Required(ErrorMessage = "*")]
        [ForeignKey("desg_id")]
        [Display(Name = "Designation")]
        public int int_fk_desg { get; set; }
        public tbl_desig_type desg_id { get; set; }
        [Display(Name = "Subject Area")]
        public int[] int_fk_sub_area { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "DOB")]
        public DateTime dt_dob { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Gender")]
        public int int_gen { get; set; }
        [Display(Name = "Contact Number")]
        [MaxLength(10)]
        [MinLength(10)]
        public string txt_mob { get; set; }
        [Required(ErrorMessage = "*")]
        [EmailAddress]
        [Display(Name = "Email/UserId")]
        public string txt_email { get; set; }
        [Required(ErrorMessage = "*")]
        [ForeignKey("bld_id")]
        [Display(Name = "Blood Group")]
        public int int_fk_bld_grp { get; set; }
        public tbl_blood_gr bld_id { get; set; }

        [Display(Name = "Address")]
        public string txt_address { get; set; }
        [Display(Name = "Profile photo")]
        public string txt_img { get; set; }
        [Display(Name = "Status")]
        public int int_status { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of creation")]
        public DateTime dt_doc { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Modification")]
        public DateTime dt_dom { get; set; }
        [Display(Name = "Modified By")]
        public string txt_mod_by { get; set; }
        

    }
    public class ManageStaffViewModel
    {
        public string password { get; set; }    
        public string confirmPassword { get; set; }  
        [Display(Name = "Profile photo")]
        public IFormFile profilePic { get; set; }
        public genderList genList { get; set; }
        public int[] subAreaForStaff { get; set; }
        public ManageStaffEntityModel addStaff { get; set; }
        public tbl_staff_profile editStaff { get; set; }
        public List<tbl_staff_profile> staffList { get; set; }
        public List<tbl_qualification> quaificationList { get; set; }
        public List<tbl_profesn> profesnList { get; set; }
        public List<tbl_desig_type> desigTypeList { get; set; }
        public List<tbl_sub_area_type> subAreaList { get; set; }
        public List<tbl_blood_gr> bloodGroupList { get; set; }
    }
    public enum genderList
    {
        Male = 1,
        Female = 2,
        Others = 3
    }
}
