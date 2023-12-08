using MyAntDesignApp.Model;
using System;
using System.Collections.Generic;

namespace MyAntDesignApp.Pages
{
    public partial class Menu1
    {
        public IEnumerable<ELCodeViewModel> ELCodes { get; set; } = new List<ELCodeViewModel>
        {
            new ELCodeViewModel{ Code = "-IC--01-01-", ExpClass="IC", AreaCode="", ItemNum="01", SubCode="01", Title="AGENCY FEES / INSURANCE / QUIT RENT",  Description = "AGENCY FEES1" },
            new ELCodeViewModel{ Code = "-IC--01-02-", ExpClass="IC", AreaCode="", ItemNum="01", SubCode="02", Title="AGENCY FEES / INSURANCE / QUIT RENT",  Description = "AGENCY FEES2" },
            new ELCodeViewModel{ Code = "-IC--01-03-", ExpClass="IC", AreaCode="", ItemNum="01", SubCode="03", Title="AGENCY FEES / INSURANCE / QUIT RENT",  Description = "AGENCY FEES3" },
            new ELCodeViewModel{ Code = "-IC--01-04-", ExpClass="IC", AreaCode="", ItemNum="01", SubCode="04", Title="AGENCY FEES / INSURANCE / QUIT RENT",  Description = "AGENCY FEES4" },
        };

        private string _selectedELCode = "1234";

        protected override void OnInitialized()
        {
            Console.WriteLine("Current bind value On Initialized: " + _selectedELCode);
        }

        private void OnELCodeChanged(ELCodeViewModel elCode)
        {
            Console.WriteLine("Current bind value On EL Code Changed: " + elCode.Code);
        }
    }
}
