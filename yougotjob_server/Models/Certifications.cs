using System.ComponentModel.DataAnnotations;

namespace yougotjob_server.Models
{
    public class Certifications
    {
        [Key]
        public int Id { get; set; }
        public string CertificationName { get; set; }
        public string IssuingOrganisation { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CertificationId { get; set; }
        public string CertificationLevel { get; set; }
        public byte[] CertificationAttachments { get; set; }
    }
}
