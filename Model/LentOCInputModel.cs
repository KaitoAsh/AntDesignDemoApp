using System;

namespace MyAntDesignApp.Model;

public class LentOCInputModel
{
    public string OcCode { get; set; }
    public string LentOcCode { get; set; }
    public Guid StatusId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string AcknowledgeBy { get; set; }
    public DateTime? AcknowledgeAt { get; set; }
    public Guid? AcknowledgeStatusId { get; set; }
}