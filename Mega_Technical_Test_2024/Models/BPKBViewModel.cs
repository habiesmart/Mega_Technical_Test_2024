using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mega_Technical_Test_2024.Models
{
    public class BPKBViewModel
    {
        public BPKBViewModel()
        {
            User = new LoginViewModel();
        }

        public string AgreementNumber { get; set; }

        public string BpkbNo { get; set; }

        public string BranchId { get; set; }

        public DateTime? BpkbDate { get; set; }

        public string FakturNo { get; set; }

        public DateTime? FakturDate { get; set; }

        public string LocationId { get; set; }

        public string PoliceNo { get; set; }

        public DateTime? BpkbDateIn { get; set; }

        public virtual IEnumerable<SelectListItem>? Location { get; set; }

        public LoginViewModel? User { get; set; }

        public class StorageLocationViewModel
        {
            public string LocationId { get; set; }

            public string LocationName { get; set; }
        }
    }
}
