using Mega_Technical_Test_2024.Models;
using Mega_Technical_Test_BE_2024.Contexts;
using Mega_Technical_Test_BE_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpGet]
        [Route("List")]
        public IActionResult ListBPKB()
        {
            return Json(this.megaDbContext.TrBpkbs.ToList());
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult GetBPKB(string agreementNumber)
        {
            return Json(this.megaDbContext.TrBpkbs.Where(x => x.AgreementNumber == agreementNumber).FirstOrDefault());
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateBPKB([FromBody] BPKBViewModel dataBPKB)
        {
            // Cari entitas yang ada berdasarkan BPKB number
            var existingBPKB = this.megaDbContext.TrBpkbs.Find(dataBPKB.AgreementNumber);

            if (existingBPKB == null)
            {
                // Jika entitas tidak ditemukan, kembalikan status not found
                return NotFound(new { Message = "BPKB not found" });
            }

            // Perbarui properti dari entitas yang ada
            existingBPKB.BpkbNo = dataBPKB.BpkbNo;
            existingBPKB.BpkbDate = dataBPKB.BpkbDate;
            existingBPKB.BpkbDateIn = dataBPKB.BpkbDateIn;
            existingBPKB.BranchId = dataBPKB.BranchId;
            existingBPKB.FakturDate = dataBPKB.FakturDate;
            existingBPKB.FakturNo = dataBPKB.FakturNo;
            existingBPKB.PoliceNo = dataBPKB.PoliceNo;
            existingBPKB.LocationId = dataBPKB.LocationId;
            existingBPKB.CreatedBy = dataBPKB.User.UserName; // Misalkan Anda ingin memperbarui CreatedBy
            existingBPKB.CreatedOn = DateTime.Now; // Misalkan Anda ingin memperbarui CreatedOn

            // Simpan perubahan ke basis data
            this.megaDbContext.SaveChanges();

            // Kembalikan entitas yang diperbarui
            return Json(existingBPKB);
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult DeleteBPKB([FromBody] string agreementNumber)
        {
            // Cari entitas berdasarkan BPKB number
            var existingBPKB = this.megaDbContext.TrBpkbs.Find(agreementNumber);

            if (existingBPKB == null)
            {
                // Jika entitas tidak ditemukan, kembalikan status not found
                return NotFound(new { Message = "BPKB not found" });
            }

            // Hapus entitas dari konteks
            this.megaDbContext.TrBpkbs.Remove(existingBPKB);

            // Simpan perubahan ke basis data
            this.megaDbContext.SaveChanges();

            // Kembalikan respons sukses
            return Ok(new { Message = "BPKB successfully deleted" });
        }
    }
}
