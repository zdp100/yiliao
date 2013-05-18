using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class HospitalImagesModels
    {
        [Key]
        public int ImageID { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage="必填")]
        [Display(Name="标题")]
        public string Title { get; set; }

        [MaxLength(500)]
        [Display(Name="说明")]
        public string Illustrate { get; set; }

        [MaxLength(200)]
        [Display(Name="路径")]
        public string ImageUrl { get; set; }

        public virtual ICollection<ImageUrlModels> imageUrlModels { get; set; }
    }
}