using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using yougotjob_server.Data;
using yougotjob_server.Models;

namespace yougotjob_server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthPractitionersController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public HealthPractitionersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [ActionName("GetHealthPractitionerData")]
        public async Task<IEnumerable<HealthPractitioners>> GetHealthPractitionerData()
        {
            return await _appDbContext.HealthPractitionersTable.ToListAsync();
        }

        [HttpGet("{id}")]
        [ActionName("GetaHealthPractitioner")]
        public async Task<ActionResult<HealthPractitioners>> GetaHealthPractitioner(int id)
        {
            try
            {
                var findUser = await _appDbContext.HealthPractitionersTable.FindAsync(id);
                if(findUser == null)
                {
                    return BadRequest();
                }

                return findUser;
            }
            catch(Exception e)
            {
                throw;
            }

        }

        [HttpPost]
        [ActionName("CheckPassword")]
        public async Task<ActionResult<HealthPractitioners>> CheckPassword(HealthPractitioners hp)
        {
            var hashedPassword = HashPassword(hp.UserPassword);
            var loginEmail = await _appDbContext.HealthPractitionersTable.FirstOrDefaultAsync(x => x.EmailAddress == hp.EmailAddress);
            var loginUser = loginEmail.UserPassword == hashedPassword;

            if(loginEmail == null || loginUser == false)
            {
                return NotFound(false);
            }

            return loginEmail;

        }

        [HttpPost]
        [ActionName("AddHealthPractitionerData")]
        public async Task<ActionResult<HealthPractitioners>> AddHealthPractitionerData(HealthPractitioners hp)
        {
            try
            {
                var findExistingEmailUser = await _appDbContext.HealthPractitionersTable.FirstOrDefaultAsync(x => x.EmailAddress == hp.EmailAddress);

                if(findExistingEmailUser != null)
                {
                    return BadRequest(new { error = new { code = "Error 404", message = "Email is already taken" } });
                }
                var hashedPass = HashPassword(hp.UserPassword);

                var newHealthPractitioner = new HealthPractitioners();
                newHealthPractitioner.FullName = hp.FullName;
                newHealthPractitioner.EmailAddress = hp.EmailAddress;
                newHealthPractitioner.Age = hp.Age;
                newHealthPractitioner.Certifications = hp.Certifications;
                newHealthPractitioner.DOB = hp.DOB;
                newHealthPractitioner.EmailRecovery = hp.EmailRecovery;
                newHealthPractitioner.Mobile = hp.Mobile;
                newHealthPractitioner.MobileRecovery = hp.MobileRecovery;
                newHealthPractitioner.UserPassword = hashedPass;

                _appDbContext.HealthPractitionersTable.Add(newHealthPractitioner);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword);
        }
    }
}
