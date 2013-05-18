using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class SinglePageModels
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "*")]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [MaxLength(10)]
        [Display(Name="类型")]
        public string Type { get; set; }

        [MaxLength(5000)]
        [Required(ErrorMessage = "*")]
        [Display(Name = "内容")]
        public string Content { get; set; }

        [Display(Name="发布时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PubDate { get; set; }

        
        [Display(Name = "阅读量")]
        public int? Count { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}