using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class DoctorsModels
    {
        [Key]
        public int DoctorID { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "必填")]
        [Display(Name="名字")]
        public string DoctorName { get; set; }

        [MaxLength(2)]
        [Required(ErrorMessage = "必填")]
        [Display(Name="性别")]
        public string sex { get; set; }

        [Display(Name="生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [MaxLength(200)]
        [Display(Name="头像")]
        public string Images { get; set; }

        [MaxLength(20)]
        [Display(Name="籍贯")]
        public string NativePlace { get; set; }

        [MaxLength(20)]
        [Display(Name="国籍")]
        public string Nationality { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "必填")]
        [Display(Name="主治")]
        public string KeySkill{ get; set; }

        [MaxLength(10)]
        [RegularExpression(@"^\d{5,12}$",ErrorMessage="不是有效的QQ号")]
        public string QQ { get; set; }

        [MaxLength(11)]
        [Display(Name="电话号码")]
        [RegularExpression(@"^[0-9]*$",ErrorMessage = "不是有效的电话号码")]
        public string Phone { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "必填")]
        [Display(Name = "电子邮件")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage = "不是有效的电子邮件格式")]
        public string Email { get; set; }

        [MaxLength(100)]
        [Display(Name="备注")]
        public string Remark { get; set; }
    }
}