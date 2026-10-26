namespace Sentinel.Domain;

public class Service
{
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
    public string ServiceConnection { get; set; }
    public int CheckServiceInterval { get; set; }
    public bool IsActive { get; set; }
}
