namespace yougotjob_server.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
        public string AppointmentAgenda { get; set; }
        public int AppointmentDay { get; set; }
        public int AppointmentMonth { get; set; }
        public int AppointmentYear { get; set; }
        public string AppointmentTime { get; set; }
        public bool IsAppointmentComplete { get; set; }


    }
}
