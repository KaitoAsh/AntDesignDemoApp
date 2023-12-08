namespace MyAntDesignApp.Model
{
    public class ELCodeViewModel
    {
        public string Code { get; set; }
        public string OCCode { get; set; }
        public short FinYear { get; set; }
        public string ExpClass { get; set; }
        public string AreaCode { get; set; }
        public string ItemNum { get; set; }
        public string SubCode { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool AllowInput { get; set; }
        public bool IsActive { get; set; }
        public string ExpGroupCode { get; set; }
        public string SearchText => $"{ExpClass?.ToUpper()}{AreaCode?.ToUpper()}{ItemNum?.ToUpper()}{SubCode?.ToUpper()} {Description?.ToUpper()}";
    }
}
