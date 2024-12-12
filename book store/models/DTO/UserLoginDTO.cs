using System.ComponentModel.DataAnnotations;

namespace lapAPIshop.Models.DTO
{
    public class UserLoginDTO
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
