using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class ReplyViewModels
    {
        [Display(Name = "回复")]
        [Required(ErrorMessage = "回复内容不能为空")]
        public string Content { get; set; }

        //public DateTime? PubDate { get; set; }


        //public int? userId { get; set; }
        //public int? MessageId { get; set; }

        ////[ForeignKey("userId")]
        //public virtual UsersModels Users { get; set; }

        ////[ForeignKey("MessageId")]
        //public virtual MessageInfoModels Message { get; set; } 
    }
}