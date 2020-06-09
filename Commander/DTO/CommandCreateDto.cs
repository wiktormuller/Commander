using System.ComponentModel.DataAnnotations;
namespace Commander.DTO
{
    public class CommandCreateDto
    {
        [Required]  //Validation in create dtos is very important because if use will create anappropriate object then we will have error 4xx instead of 5xx
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
