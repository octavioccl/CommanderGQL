using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Model
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string LicenseKey { get; set; }

    }
}