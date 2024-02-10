namespace NetRTC.Signaling.Models;

public class MediaDescription
{
    public string MediaName { get; set; } = string.Empty;
    public string? MediaInformation { get; set; }
    public string? Connection { get; set; }
    public List<string>? Bandwidths { get; set; } = new();
    public string? EncryptionKey { get; set; }
    public List<string>? MediaAttributes { get; set; } = new();
}