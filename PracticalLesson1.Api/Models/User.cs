using PracticalLesson1.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace PracticalLesson1.Api.Models
{
    public class User
    {
        public virtual long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public Gender Gender { get; set; }
    
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
