using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Table_Tennis_UK.Models
{
    public class TableTennisClub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string YearOfOpening { get; set; }
        public string HeadCoach { get; set; }
        public string JuniorCoach { get; set; }
        public double Square { get; set; }
        public int CoutOfTable { get; set; }
        public string Details { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
