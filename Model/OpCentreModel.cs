using System;

namespace MyAntDesignApp.Model;

public class OpCentreModel
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string BRegNo { get; set; }
    public string GSTNo { get; set; }
    public string CompCode { get; set; }
    public string Addr1 { get; set; }
    public string Addr2 { get; set; }
    public string Addr3 { get; set; }
    public string TaxRefNo { get; set; }
    public string EPFRefNo { get; set; }
    public string SocRefNo { get; set; }
    public string TelNo { get; set; }
    public string Category { get; set; }
    public bool InpDiv { get; set; }
    public bool IsActive { get; set; }
    public string RegionCode { get; set; }
    public string GMCode { get; set; }
    public string AddToOC { get; set; }
    public bool Acc { get; set; }
    public string Location { get; set; }
    public int MthFinStart { get; set; }

    public string SearchText
    {
        get
        {
            return Code + " " + Name;
        }
    }

    public string States { get; set; }

    public bool IsEstate
    {
        get
        {
            return Category == "E" || Category == "W";
        }
    }

    public bool IsIndonesiaOc
    {
        get
        {
            return Location == "I";
        }
    }
}
