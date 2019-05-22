using System;
using System.Threading;
using System.Threading.Tasks;

namespace Smoko.Service
{
    internal interface ICommunication
    {
        event EventHandler<string> DataReceived;
        void StartListening();
        Task<bool> SendMessage(string message);
        
    }
}