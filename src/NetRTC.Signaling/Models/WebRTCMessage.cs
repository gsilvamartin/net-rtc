namespace NetRTC.Signaling.Models;

public class WebRTCMessage
{
    public string Type { get; set; }
    public string SDP { get; set; }
    public string ICE { get; set; }
}