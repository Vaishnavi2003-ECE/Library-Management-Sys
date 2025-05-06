// LoginModel.cs
using System.ComponentModel.DataAnnotations;

namespace LabraryManagement.Models
{
    public class LoginModel
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }

    public class bookmasterModel
    {
        public int? BookID { get; set; }

        public string? BookName { get; set; }

        public string? Author { get; set; }

        public int? Quantity { get; set; }
    }

    public class usermasterModel
    {
        public int? UserID { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public int? Contact { get; set; }
    }

    public class searchModel
    {
        public int? BookID { get; set; }

        public string? BookName { get; set; }

        public string? Author { get; set; }

        public int? Quantity { get; set; }
    }

    public class borrowModel
    {
        public int? BookID { get; set; }

        public string? BookName { get; set; }

        public string? Author { get; set; }

        public int? Quantity { get; set; }
    }
}
