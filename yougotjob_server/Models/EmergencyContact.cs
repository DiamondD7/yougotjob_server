using System.ComponentModel.DataAnnotations;

namespace yougotjob_server.Models
{
    public class EmergencyContact
    {
        public int Id { get; set; } 
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Relationship { get; set; }

    }
}
