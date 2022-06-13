using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ivanchenko.Model
{
    [Table("Books")]
    public class Book
    {
        [Key] public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string SecureLevel { get; set; }
    }
}
