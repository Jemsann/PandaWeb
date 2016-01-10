namespace PandaWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    // C# entity framework class model
    [Table("Users")]
    public partial class Users
    {
		[Key]
        public int UserID { get; set; }

		[Requried(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string Username { get; set; }

		[Requried(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be atleast 8 char long.")]
        public string Password { get; set; }

		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password does not match.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string Fullname { get; set; }

		[RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "Please provide valid email id")]
        public string Email { get; set; }

		public string Role { get; set; }

		//public ICollection<EducationPlan> EducationId { get; set; }
	}
}
