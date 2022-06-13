using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ivanchenko.Model
{
    [Table("Reader")]
    public class Reader
    {
        [Key] public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        internal bool IsEqual(Reader reader)
        {
            return Surname == reader.Surname &&
                    Firstname == reader.Firstname &&
                    Lastname == reader.Lastname;
        }
    }
}
