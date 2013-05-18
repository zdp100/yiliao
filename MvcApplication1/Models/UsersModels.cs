using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class UsersModels
    {
        [Key]
        public int UserID { get; set; }

        [MaxLength(20)]
        [Display(Name="用户名")]
        [Required(ErrorMessage = "必填")]
        public string UserName { get; set; }

        [MaxLength(50)]
        [Display(Name="密码")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "必填")]
        public string UserPassword { get; set; }

        [MaxLength(20)]
        [Display(Name="权限")]
        public string Limit { get; set; }
        
        [MaxLength(10)]
        [Display(Name = "真实姓名")]
        public string Name { get; set; }

        [MaxLength(2)]
        [Display(Name="性别")]
        public string Sex { get; set; }

        [Display(Name="生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [MaxLength(250)]
        [Display(Name="头像")]
        public string Images { get; set; }

        [MaxLength(20)]
        [Display(Name="籍贯")]
        public string NativePlace { get; set; }

        [MaxLength(20)]
        [Display(Name="国籍")]
        public string Nationality { get; set; }

        [MaxLength(10)]
        [Display(Name="QQ")]
        [RegularExpression(@"^\d{5,12}$",ErrorMessage="不是有效的QQ号")]
        public string QQ { get; set; }

        [MaxLength(11)]
        [Display(Name="电话号码")]
        [RegularExpression(@"^[0-9]*$",ErrorMessage = "不是有效的电话号码")]
        public string Phone { get; set; }

        [MaxLength(50)]
        [Display(Name="电子邮件")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage = "不是有效的电子邮件格式")]
        [Required(ErrorMessage = "必填")]
        public string Email { get; set; }

        [Display(Name = "注册时间")]
        public DateTime? RegisterDate { get; set; }

        [MaxLength(100)]
        [Display(Name="备注")]
        public string Remark { get; set; }
    }
}