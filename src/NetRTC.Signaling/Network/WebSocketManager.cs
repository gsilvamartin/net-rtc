using System.Collections.Concurrent;
using System.Net.WebSockets;
using NetRTC.Signaling.Models;
using NetRTC.Signaling.Network.Interfaces;
using Newtonsoft.Json;

namespace NetRTC.Signaling.Network;

public class WebSocketManager : IWebSocketManager
{
    private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();

    public void AddSocket(string userId, WebSocket socket)
    {
        _sockets.TryAdd(userId, socket);
    }

    public void RemoveSocket(string userId)
    {
        _sockets.TryRemove(userId, out _);
    }

    public async Task SendAsync(string userId, WebRTCMessage message)
    {
        if (_sockets.TryGetValue(userId, out var socket) && socket.State == WebSocketState.Open)
        {
            var messageJson = JsonConvert.SerializeObject(message);
            var buffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(messageJson));
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}