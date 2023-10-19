using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectD.Data.Models
{
    public class User
    { 
        public int Id { get; set; }
        public string Name { get; set; }
         public string surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
