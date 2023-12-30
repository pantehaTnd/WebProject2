using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Department")]
        public string DepName { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
