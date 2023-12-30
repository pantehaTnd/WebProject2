namespace HospitalAppointmentAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Speciality { get; set; }

        public string Clinic { get; set; }

        public IEnumerable<string> WorkingDays { get; set; }

        public TimeSpan WorkingStartTime { get; set; }

        public TimeSpan WorkingEndTime { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
