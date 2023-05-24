using System.ComponentModel.DataAnnotations;

namespace CompanyManagerC.Models
{
    public class BaseModel
    {
        public int id { get; set; }
        [MaxLength(18)]
        public string name { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime removedOn { get; set; }
    }
}
