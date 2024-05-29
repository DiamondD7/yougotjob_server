using System.ComponentModel.DataAnnotations;

namespace yougotjob_server.Models
{
    public class PatientUsers
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NHI { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string EmailRecovery { get; set; }
        public string UserPassword { get; set; }
        public string Mobile { get; set; }
        public string MobileRecovery { get; set; }
        public string Role { get; set; } = "Patient";
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public List<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BMI { 
            get
            {
                int heightToMeters = Height / 100;
                int BMI = Weight / (heightToMeters * heightToMeters); //  weight / height^2
                return BMI;

            }
            set { throw new InvalidOperationException("Age property is read-only."); } 
        
        }
        public DateTime DOB { get; set; }
        public int Age
        {

            get {
                DateTime today = DateTime.Today;
                int age = today.Year - DOB.Year;
                    if(today < DOB.AddYears(age))
                    {
                        age--;
                    }
                return age;
            }
            set { throw new InvalidOperationException("Age property is read-only."); }
        }

    }
}
