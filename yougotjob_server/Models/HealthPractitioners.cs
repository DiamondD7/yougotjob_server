using System.ComponentModel.DataAnnotations;

namespace yougotjob_server.Models
{
    public class HealthPractitioners
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string MobileRecovery { get; set; }
        public string EmailAddress { get; set; }
        public string EmailRecovery { get; set; }
        public string UserPassword { get; set; }
        public string Role { get; set; } = "Health Practitioner";
        public List<Certifications> Certifications { get; set; } = new List<Certifications>();
        public DateTime DOB { get; set; }
        public int Age
        {

            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DOB.Year;
                if (today < DOB.AddYears(age))
                {
                    age--;
                }
                return age;
            }
            set { throw new InvalidOperationException("Age property is read-only."); }
        }
    }
}
