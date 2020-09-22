using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using vsk_betacent.Models.DataEntities;
namespace vsk_betacent.gallery.DataEntities
{
    public class GalleryEntityModel
    {
        [Display(Name = "ID")]
        public int int_id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Title")]
        public string txt_title{ get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Position")]
        public string txt_position{ get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "File")]
        public string txt_file{ get; set; }
        [Display(Name = "Dt_doc")]
        public DateTime dt_doc{ get; set; }
    }
    public class GalleryViewModel
    {
         public GalleryEntityModel addGallery { get; set; }
         public tbl_gallery editGallery { get; set; }
         public List<tbl_gallery> imagesList { get; set; }
    }
}