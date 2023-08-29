using System.ComponentModel.DataAnnotations;

namespace Table_Tennis_UK.Models.Dto
{
    public class TableTennisClubUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]

        public string Name { get; set; }
        public string YearOfOpening { get; set; }
        public string HeadCoach { get; set; }
        public string JuniorCoach { get; set; }
        public double Square { get; set; }
        public int CoutOfTable { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
