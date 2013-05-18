using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class MessageInfoModels
    {
        [Key]
        public int MessageID { get; set; }

        [MaxLength(50)]
        [Display(Name="标题")]
        [Required(ErrorMessage = "必填")]
        public string Title { get; set; }

        [MaxLength(5000)]
        [Display(Name="内容")]
        [Required(ErrorMessage = "必填")]
        public string Content { get; set; }

        [Display(Name="发布日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? PubDate { get; set; }


        public int? userId { get; set; }

        //[ForeignKey("userId")]
        public UsersModels Users { get; set; }

        public virtual ICollection<ReplyModel> Reply { get; set; }

        [MaxLength(50)]
        [Display(Name = "作者")]
        public string UserName { get; set; }

        //回复数
        [Display(Name = "回复数")]
        public int ReplyNum { get; set; }

        //查看数
        [Display(Name = "查看数")]
        public int ViewNum { get; set; }

        public int? ReplyLastId { get; set; }

        public ReplyModel ReplyLast { get; set; }


        //[MaxLength(100)]
        //[Display(Name="备注")]
        //public string Remark { get; set; }
    }
}