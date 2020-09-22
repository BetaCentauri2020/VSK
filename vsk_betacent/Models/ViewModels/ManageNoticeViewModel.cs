using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using vsk_betacent.Models.DataEntities;
namespace vsk_betacent.Models.ViewModels
{
    public class NoticeEntityModel
    {
        [Display(Name = "Id")]
        public int int_id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Title")]
        public string txt_title{ get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "proiority")]
        public int int_proiority{ get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name ="Description")]
        public string txt_description { get; set; }
        [Display(Name = "File")]
        public string txt_file { get; set; } 
        [Display(Name = "Dt_dou")]
        public DateTime dt_dou { get; set; }
        
    }
    public class ManageNoticeViewModel
    {
        public NoticeEntityModel addNotice { get; set; }
        public tbl_notice editNotice { get; set; }
        public List<tbl_notice> noticeList { get; set; }

    }
}