using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vsk_betacent.Models.DataEntities;
namespace vsk_betacent.Models
{
    public class vsk_dbcontext: DbContext
    {
        public vsk_dbcontext(DbContextOptions<vsk_dbcontext> options)
            : base(options)
        {

        }
        //public DbSet<tbl_demo> tbl_demo { get; set; }
        public DbSet<tbl_alumini_details> tbl_alumini_details { get; set; }
        public DbSet<tbl_inquary> tbl_inquary { get; set; }
        public DbSet<tbl_qualification> tbl_qualification { get; set; }
        public DbSet<tbl_desig_type> tbl_desig_type { get; set; }
        public DbSet<tbl_sub_area_type> tbl_sub_area_type { get; set; }
        public DbSet<tbl_profesn> tbl_profesn { get; set; }
        public DbSet<tbl_blood_gr> tbl_blood_gr { get; set; }
        public DbSet<tbl_staff_profile> tbl_staff_profile { get; set; }
        public DbSet<tbl_notice> tbl_notice { get; set; }
        public DbSet<tbl_gallery> tbl_gallery { get; set; }
    }
}
