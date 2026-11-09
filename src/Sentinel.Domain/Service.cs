namespace Sentinel.Domain;

public class Service
{
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string ServiceDescription { get; set; } = string.Empty;
    public string ServiceConnection { get; set; } = string.Empty;
    public int CheckServiceInterval { get; set; }
    public bool IsActive { get; set; }
}
