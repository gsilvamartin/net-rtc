using NetRTC.Signaling.Models;
using NetRTC.Signaling.Network;

namespace NetRTC.Signaling.Services;

public class SignalingService
{
    private readonly WebSocketManager _webSocketManager;

    public SignalingService(WebSocketManager webSocketManager)
    {
        _webSocketManager = webSocketManager;
    }

    public async Task HandleMessageAsync(string userId, WebRTCMessage message)
    {
        // Implemente a lógica para manipular SDP, ICE, negociação, etc.
        await _webSocketManager.SendAsync(userId, message);
    }
}