using System.ComponentModel.DataAnnotations;

namespace CompanyManagerC.Models
{
    public class Manager : BaseModel
    {
        [MaxLength(18)]
        public string? username { get; set; }
        [MaxLength(18)]
        public string? password { get; set; }
        public int yearsOfExperience { get; set; }
        public decimal salary { get; set; }
    }
}
