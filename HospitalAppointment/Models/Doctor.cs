using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HospitalAppointment.Constants.Enums;

namespace HospitalAppointment.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Doctor Name")]
        public string DoctorName { get; set; }

        public HospitalDepartment department { get; set; }
        
        public IEnumerable<string> WorkingDays { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd,HH:mm}")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime EndTime { get; set; }


    }
}
