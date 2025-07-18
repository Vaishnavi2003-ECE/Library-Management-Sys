// LoginModel.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class LoginModel
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }

    public class bookmasterModel
    {
        [Key]
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

    }

    public class usermasterModel
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public decimal? Contact { get; set; }
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

    [Table("Return")]
    public class returnModel
    {
        [Key]
        public int BorrowID { get; set; }  

        public int BookID { get; set; }

        [NotMapped]
        public string? BookName { get; set; }

        public int UserID { get; set; }

        [NotMapped]
        public string? UserName { get; set; }

        public int Quantity { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }

    }
}
