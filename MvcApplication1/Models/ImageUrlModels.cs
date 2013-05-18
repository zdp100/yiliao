using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class ImageUrlModels
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name="标题")]
        public string Title { get; set; }
        
        [MaxLength(200)]
        [Display(Name="图片")]
        public string ImageUrl { get; set; }

        public int? HImagesId { get; set; }
        public virtual HospitalImagesModels HImages { get; set; }

    }
}