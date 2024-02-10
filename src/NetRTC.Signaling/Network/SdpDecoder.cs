using NetRTC.Signaling.Models;

namespace NetRTC.Signaling.Network;

//REF: https://tools.ietf.org/html/rfc4566
public class SdpDecoder
{
    public static SessionDescription DecodeSdp(string sdpString)
    {
        var sessionDescription = new SessionDescription();
        var lines = sdpString.Split([Environment.NewLine], StringSplitOptions.None);

        foreach (var line in lines)
        {
            var parts = line.Split('=');

            if (parts.Length != 2) continue;

            var key = parts[0].Trim();
            var value = parts[1].Trim();

            ProcessSdpLine(key, value, ref sessionDescription);
        }

        return sessionDescription;
    }

    private static void ProcessSdpLine(string key, string value, ref SessionDescription sessionDescription)
    {
        switch (key)
        {
            case "v":
                sessionDescription.Version = value;
                break;
            case "o":
                sessionDescription.Originator = value;
                break;
            case "s":
                sessionDescription.SessionName = value;
                break;
            case "i":
                sessionDescription.SessionInformation = value;
                break;
            case "u":
                sessionDescription.Uri = value;
                break;
            case "e":
                sessionDescription.Email = value;
                break;
            case "c":
                sessionDescription.Connection = value;
                break;
            case "b":
                sessionDescription.Bandwidths?.Add(value);
                break;
            case "t":
                sessionDescription.Time = value;
                break;
            case "z":
                sessionDescription.TimeZoneAdjustments = value;
                break;
            case "k":
                sessionDescription.EncryptionKey = value;
                break;
            case "a":
                sessionDescription.SessionAttributes?.Add(value);
                break;
            case "m":
                var mediaDescription = new MediaDescription { MediaName = value };
                sessionDescription.MediaDescriptions?.Add(mediaDescription);
                break;
        }
    }
}