using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using vsk_betacent.Models.DataEntities;
namespace vsk_betacent.Models.ViewModels
{
    public class GalleryEntityModel
    {
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
    public class ManageGalleryViewModel
    {
        [Display(Name = "Image")]
        public IFormFile profilePic { get; set; }
        public GalleryEntityModel addImage { get; set; }
        public tbl_gallery editImage { get; set; }
        public List<tbl_gallery> imageList { get; set; }

    }
}