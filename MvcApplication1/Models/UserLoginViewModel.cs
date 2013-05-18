using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name="密码")]
        public string PassWord { get; set; }
    }
}