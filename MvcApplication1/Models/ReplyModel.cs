using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class ReplyModel
    {
        [Key]
        public int ReplyId { get; set; }


        [MaxLength(5000)]
        [Display(Name = "内容")]
        [Required(ErrorMessage = "必填")]
        public string Content { get; set; }

        [Display(Name = "发布日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? PubDate { get; set; }


        public int? userId { get; set; }
        public int? MessageId { get; set; }

        //[ForeignKey("userId")]
        public virtual UsersModels Users { get; set; }

        //[ForeignKey("MessageId")]
        public virtual MessageInfoModels Message { get; set; }
    }
}