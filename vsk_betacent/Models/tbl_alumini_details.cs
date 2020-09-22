using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models
{
    public class tbl_alumini_details
    {
        [Key]
        public string registration_number { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage ="Please provide your Name")]
        public string name { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your Organisation")]
        public string organisation { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your Profession")]
        public string profession { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your passout year")]
        public string passout_year { get; set; }
        [StringLength(10)]
        public string gender { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Please provide marital status")]
        public string marital_status { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please provide your email")]
        public string eamil { get; set; }
        public DateTime? dob { get; set; }
        [StringLength(12)]
        [Required(ErrorMessage = "Please provide your Mobile number")]
        public string mobile { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your address")]
        public string address { get; set; }
        public string file { get; set; }
        public int status { get; set; }
        public string password { get; set; }
    }
}
