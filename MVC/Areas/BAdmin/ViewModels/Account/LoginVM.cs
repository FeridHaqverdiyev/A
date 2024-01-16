using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace MVC.Areas.BAdmin.ViewModels
{
    public class LoginVM
    {
        [Required]
        [MinLength(7)]
        [MaxLength(40)]
        public string UsernameOrEmail{ get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(40)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public  bool isRemembered { get; set; }
    }
}
