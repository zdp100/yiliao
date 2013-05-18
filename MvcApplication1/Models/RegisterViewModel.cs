using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace MvcApplication1.Models
{
    public class RegisterViewModel
    {
        [MaxLength(20)]
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "必填")]
        [Remote("IsUserExists", "qiantai", "admin", ErrorMessage = "用户已经存在", HttpMethod = "POST")]
        public string UserName { get; set; }

        [MaxLength(50)]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "必填")]
        public string UserPassword { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "密码必须一致")]
        public virtual string RepUserPassword { get; set; } 

        [MaxLength(50)]
        [Display(Name = "电子邮件")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "不是有效的电子邮件格式")]
        [Required(ErrorMessage = "必填")]
        public string Email { get; set; }
    }
}