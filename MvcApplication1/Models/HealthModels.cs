using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class HealthModels 
    {
        [Key]
        public int HealthID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "必填")]
        [Display(Name="健康标题")]
        public string HealthHead { get; set; }

        [MaxLength(10)]
        [Display(Name="健康类型")]
        [Required(ErrorMessage="必填！")]
        public string HealthTypeName { get; set; }

        [MaxLength(5000)]
        [Display(Name="内容")]
        [Required(ErrorMessage = "必填")]
        public string Content { get; set; }

        [Display(Name="发布日期")]
        [Required(ErrorMessage = "必填")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime? PubDate { get; set; }

        [Display(Name = "阅读量")]
        public int? Count { get; set; }

        [MaxLength(10)]
        [Display(Name="作者")]
        public string UserName { get; set; }

        [MaxLength(100)]
        [Display(Name="备注")]
        public string Remark { get; set; }



    }

}