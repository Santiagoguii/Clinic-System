using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Clinic_System.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Newtonsoft.Json.JsonIgnore]
        public int RecordId { get; set; }  

        public string FormattedRecordId => RecordId.ToString("D10"); // Formatação do ID com 10 digitos - autoincrementado

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        public DateOnly Dateofbirth { get; set; }

        public string Address { get; set; }
        public string Contact { get; set; }
        public string BloodType { get; set; }
        public string Email { get; set; }
        public string MedicalHistory { get; set; }
        public string Insurance { get; set; }
        public string Notes { get; set; }
    }
}