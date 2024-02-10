namespace NetRTC.Signaling.Models;

public class SessionDescription
{
    public string Version { get; set; }
    public string Originator { get; set; }
    public string SessionName { get; set; }
    public string? SessionInformation { get; set; }
    public string? Uri { get; set; }
    public string? Email { get; set; }
    public string? Connection { get; set; }
    public List<string>? Bandwidths { get; set; } = new();
    public string Time { get; set; }
    public string? TimeZoneAdjustments { get; set; }
    public string? EncryptionKey { get; set; }
    public List<string>? SessionAttributes { get; set; } = new();
    public List<MediaDescription>? MediaDescriptions { get; set; } = new();
}