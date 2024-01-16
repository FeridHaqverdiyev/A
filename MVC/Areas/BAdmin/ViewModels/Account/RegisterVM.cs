using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace MVC.Areas.BAdmin.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string SurName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [Compare(nameof(Password))]

        public string ConfirmPassword{ get; set; }
    }
}
