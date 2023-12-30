﻿namespace HospitalAppointmentAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set;}

        public int DoctorId { get; set;}

        public DateTime AppointmentDate {  get; set; }
    }
}
