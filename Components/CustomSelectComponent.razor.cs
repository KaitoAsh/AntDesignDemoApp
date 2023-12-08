using AntDesign;
using Microsoft.AspNetCore.Components;
using MyAntDesignApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAntDesignApp.Components
{
    public partial class CustomSelectComponent : AntInputComponentBase<string>
    {
        [Parameter]
        public IEnumerable<ELCodeViewModel> DataSource { get; set; }

        [Parameter]
        public EventCallback<ELCodeViewModel> OnSelectionChange { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool AllowClear { get; set; }

        private List<ELCodeViewModel> _filteredELCodes = new();

        protected override void OnInitialized()
        {
            SetSelectedELCode(Value);
        }

        /// <summary>
        /// Explicitly set selected Expenditure Ledger Code and insert it into filtered data source.
        /// </summary>
        public void SetSelectedELCode(string value)
        {
            var elCode = DataSource.FirstOrDefault(x => x.Code.Equals(value));
            if (elCode != null)
            {
                _filteredELCodes = new List<ELCodeViewModel> { elCode };
            }
        }

        private void OnSelectionChanged(ELCodeViewModel elCode)
        {
            if (elCode == null) _filteredELCodes = new List<ELCodeViewModel>();

            if (OnSelectionChange.HasDelegate) OnSelectionChange.InvokeAsync(elCode);
            Console.WriteLine("Current bind value On Selecction Changed: " + CurrentValue);
        }

        private void OnSearched(string value)
        {
            if (value?.Length >= 4)
            {
                _filteredELCodes = null;
                _filteredELCodes = DataSource
                                   .Where(x => x.SearchText.Contains(value.ToUpper()))
                                   .ToList();
                //StringComparison.OrdinalIgnoreCase
                foreach (var item in _filteredELCodes)
                    Console.WriteLine(item.SearchText);
            }
            else
            {
                _filteredELCodes = new List<ELCodeViewModel>();
            }

            StateHasChanged();
        }
    }
}
