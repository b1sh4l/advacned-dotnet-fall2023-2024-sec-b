using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask_8Oct.Models
{
    public class SignUp
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 50 characters")]
        [RegularExpression(@"^[A-Za-z\s.\-]*$", ErrorMessage = "Name can only contain letters, spaces, dots, and dashes and cannot contain numbers")]
        public string Name { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "User Id must be between 4 and 12 characters")]
        [RegularExpression(@"^[A-Za-z0-9\-_]*$", ErrorMessage = "User Id can only contain letters, numbers, hyphens, and underscores and cannot contain spaces or dots")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z].*[a-z])(?=.*[0-9\W]).*$", ErrorMessage = "Password must have at least 1 uppercase, 2 lowercase, and a combination of special characters and numbers")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Id is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Id must match the pattern 'XX-XXXXX-X', where X=numbers")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}@student\.aiub\.edu$", ErrorMessage = "Email must match the pattern 'XX-XXXXX-X@student.aiub.edu', where X=numbers")]
        [MatchingIdEmail("Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Dob is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [AgeGreaterThan(18, ErrorMessage = "Age must be greater than 18")]
        public DateTime Dob { get; set; }
    }
}
