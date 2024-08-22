using Mega_Technical_Test_2024.Models;
using Mega_Technical_Test_BE_2024.Contexts;
using Mega_Technical_Test_BE_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mega_Technical_Test_BE_2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BPKBController : Controller
    {
        private readonly ILogger<BPKBController> _logger;
        private MegaTechnicalTestDbContext megaDbContext;

        public BPKBController(ILogger<BPKBController> logger, IServiceProvider service)
        {
            _logger = logger;
            this.megaDbContext = new MegaTechnicalTestDbContext(service.GetRequiredService<DbContextOptions<MegaTechnicalTestDbContext>>());
        }

        [HttpGet]
        [Route("GetListStorageLocations")]
        public IActionResult ListStorageLocations()
        {
            return Json(this.megaDbContext.MsStorageLocations.ToList());
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateBPKB([FromBody]BPKBViewModel dataBPKB)
        {
            TrBpkb bpkb = new TrBpkb() {
                AgreementNumber = dataBPKB.AgreementNumber,
                BpkbDate = dataBPKB.BpkbDate,
                BpkbDateIn = dataBPKB.BpkbDateIn,
                BpkbNo = dataBPKB.BpkbNo,
                BranchId = dataBPKB.BranchId,
                FakturDate = dataBPKB.FakturDate,
                FakturNo = dataBPKB.FakturNo,
                PoliceNo = dataBPKB.PoliceNo,
                LocationId = dataBPKB.LocationId,
                CreatedBy = dataBPKB.User.UserName,
                CreatedOn = DateTime.Now
            };

            this.megaDbContext.TrBpkbs.Add(bpkb);
            this.megaDbContext.SaveChanges();

            return Json(bpkb);
        }
    }
}
