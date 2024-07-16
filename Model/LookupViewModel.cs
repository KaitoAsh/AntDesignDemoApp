using System;

namespace MyAntDesignApp.Model;

public class LookupViewModel
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string FromValue { get; set; }
    public string ToValue { get; set; }
    public string Remarks { get; set; }
    public bool? IsActive { get; set; }
    public string Location { get; set; }
    public string OcCategory { get; set; }
    public bool? IsHeader { get; set; }
    public string CodeAndDescription { get { return $"{Code} - {Description}"; } }
}
