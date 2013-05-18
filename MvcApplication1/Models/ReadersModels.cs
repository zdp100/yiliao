using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class ReadersModels
    {
        [Key]
        public int ReaderID { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "必填")]
        [Display(Name="名字")]
        public string ReaderName { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "必填")]
        [Display(Name="职位")]
        public string Position { get; set; }

        [MaxLength(1)]
        [Required(ErrorMessage = "必填")]
        [Display(Name="性别")]
        public string Sex { get; set; }

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

        [MaxLength(50)]
        [Display(Name="职责")]
        [Required(ErrorMessage = "必填")]
        public string Duty { get; set; }

        [MaxLength(10)]
        [Display(Name="QQ")]
        [RegularExpression(@"^\d{5,12}$",ErrorMessage="不是有效的QQ号")]
        public string QQ { get; set; }

        [MaxLength(11)]
        [Display(Name="电话号码")]
        [RegularExpression(@"^[0-9]*$",ErrorMessage = "不是有效的电话号码")]
        public string Phone { get; set; }

        [MaxLength(200)]
        [Display(Name="电子邮件")]
        [Required(ErrorMessage = "必填")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage = "不是有效的电子邮件格式")]
        public string Email { get; set; }

        [MaxLength(100)]
        [Display(Name="备注")]
        public string Remark { get; set; }
    }
}