using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vsk_betacent.Models
{
    public class tbl_inquary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int slno { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your Name")]
        public string name { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your course")]
        public string course { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your email")]
        public string email { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please provide your Phone number")]
        public string Contact_no { get; set; }
        public string query { get; set; }
        [Display(Name = "Date Of Inquary")]
        public DateTime dt_doi { get; set; }
    }
}
