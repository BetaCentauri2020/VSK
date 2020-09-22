using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using vsk_betacent.Models.DataEntities;
namespace vsk_betacent.Models.ViewModels
{
    public class ManageHomeViewModel
    {
        public int totalAlumini { get; set; }
        public int totalInquiry { get; set; }
        public int totalStaff { get; set; }
        public List<tbl_notice> noticeList { get; set; }
        public tbl_inquary inquary { get; set; }
        public List<tbl_alumini_details> aluminiList { get; set; }
    }
}