using System.Net.WebSockets;
using NetRTC.Signaling.Models;

namespace NetRTC.Signaling.Network.Interfaces;

public interface IWebSocketManager
{
    void AddSocket(string userId, WebSocket socket);
    void RemoveSocket(string userId);
    Task SendAsync(string userId, WebRTCMessage message);
}