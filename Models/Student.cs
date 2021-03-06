using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your firstname")]
        [StringLength(15, MinimumLength = 3)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter your lastname")]
        [StringLength(15, MinimumLength = 3)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [RegularExpression(@"^[a-z0-9](\.?[a-z0-9]){5,}@gmail\.com$", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Age")]
        [Range(18, 30, ErrorMessage = "Age should be between 18 and 30")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter Country")]
        public string CountryName { get; set; }
        [Required(ErrorMessage = "Please enter State")]
        public string StateName { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        public string CityName { get; set; }
    }
}
