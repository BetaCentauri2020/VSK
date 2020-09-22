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
    public class ManageAluminiViewModel
    {
        public string password { get; set; }    
        public string confirmPassword { get; set; }    
        public List<tbl_alumini_details> aluminiList { get; set; }
        public tbl_alumini_details alumini { get; set; }
        
    }
}