using System.ComponentModel.DataAnnotations;
namespace Scm.Controllers.Dtos
{
    public class UserDto
    {
        [Required]
        public string email{get; set;}
        [Required]
        public string password{get; set;}
        [Required]
        public string name{get; set;}
        [Required]
        public string lastName{get; set;}
        [Required]
        public string role{get; set;}
    }
    public class AuthenticateModel
    {
        public string email{get; set;}
        public string password{get; set;}
    }
    public class UserDtoT
    {
        public string email{get; set;}
        public string password{get; set;}
        public string name{get; set;}
        public string lastName{get; set;}
        public string role{get; set;}
    }
    public class token{
        public string access_token{get; set;}
    }
    
}
