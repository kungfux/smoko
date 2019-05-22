using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Smoko.Service
{
    internal class Communication : ICommunication
    {
        public event EventHandler<string> DataReceived;

        private const string FOOTPRINT = "Smoko:";

        private readonly int _port;
        private readonly IPEndPoint _address;

        public Communication()
        {
            _port = AppSettings.GetPort();
            _address = new IPEndPoint(IPAddress.Broadcast, _port);
        }

        public async void StartListening()
        {
            using (var server = new UdpClient(_port, AddressFamily.InterNetwork))
            {
                while (true)
                {
                    var data = await server.ReceiveAsync();
                    var message = Encoding.Default.GetString(data.Buffer);
                    if (message.StartsWith(FOOTPRINT))
                    {
                        DataReceived?.Invoke(this, message.Substring(FOOTPRINT.Length, message.Length - FOOTPRINT.Length));
                    }
                }
            }
        }

        public async Task<bool> SendMessage(string message)
        {
            using (var client = new UdpClient(AddressFamily.InterNetwork))
            {
                client.Connect(_address);
                var bytes = Encoding.Default.GetBytes(FOOTPRINT + message);
                var byteSent = await client.SendAsync(bytes, bytes.Length);
                return true;
            }
        }
    }
}
