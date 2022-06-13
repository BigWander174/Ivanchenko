using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ivanchenko.Model
{
    [Table("IssuedBooks")]
    public class IssueBook
    {
        [Key] public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public string IssueDate { get; set; }
    }
}
