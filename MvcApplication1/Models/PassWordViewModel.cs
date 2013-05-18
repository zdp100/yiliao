using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class PassWordViewModel
    {
        [Required(ErrorMessage = "必填")]
        [Display(Name = "旧密码")]
        [Remote("IsPwdExists","qiantai","admin",ErrorMessage = "密码不正确",HttpMethod = "Post")]
        public string OldPassWord { get; set; }

        [Display(Name = "新密码")]
        [MaxLength(20)]
        [Required(ErrorMessage = "必填")]
        public string NewPassWord { get; set; }

        [Display(Name = "确认新密码")]
        [Compare("NewPassWord",ErrorMessage = "密码必须一致")]
        public string RePassWord { get; set; }
 
        
    }
}