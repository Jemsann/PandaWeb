using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PandaWeb.Models
{
    // C# entity framework class models.

    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    [Table("UL")]
    public class UL : Person
    {
        [Key]
        public int ULId { get; set; }
    }

    [Table("Student")]
    public class Student : Person
    {
        [Key]
        public int StudentId { get; set; }
        public List<string> Grades { get; set; }
    }

    [Table("LG")]
    public class LG : Person
    {
        [Key]
        public int LGId { get; set; }
    }
}