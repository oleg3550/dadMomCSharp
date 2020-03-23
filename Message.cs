using System;
using System.Threading;
namespace PapaMamaCSharp
{
    public class Message
    {
        private string _message;
        private static int _writtenMessages = 0;
        public static int TotalMessages;

        private int _duration;
        private int _repeats;

        public Message(string message, int duration, int repeats)
        {
            this._duration = duration;
            this._repeats = repeats;
            this._message = message;
        }

        public void Write()
        {
            int i = 0;
            while (i < _repeats && _writtenMessages < TotalMessages)
            {
                i++;
                _writtenMessages++;
                Console.WriteLine(_message + '\t' + _writtenMessages);
                Thread.Sleep(_duration);
            }
        }
    }
}
