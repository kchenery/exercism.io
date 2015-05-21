using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.Bob
{
    public class Bob
    {
        private Dictionary<MessageType, string> bobsReponses = new Dictionary<MessageType, string>();

        public Bob()
        {
            loadResponses();
        }

        public string Hey(string message)
        {
            string response = null;

            bobsReponses.TryGetValue(MessageParser.Parse(message), out response);

            return (response == null) ? bobsReponses[MessageType.Generic] : response;
        }

        private void loadResponses()
        {
            bobsReponses.Add(MessageType.Generic, "Whatever.");
            bobsReponses.Add(MessageType.Question, "Sure.");
            bobsReponses.Add(MessageType.Shouting, "Whoa, chill out!");
            bobsReponses.Add(MessageType.Silence, "Fine. Be that way!");
        }
    }

    public class MessageParser
    {
        public static MessageType Parse(string message)
        {
            MessageType response = MessageType.Generic;

            if (IsSilence(message))
            {
                response = MessageType.Silence;
            }
            else if (IsQuestion(message))
            {
                response = MessageType.Question;
            }
            else if (IsShouting(message))
            {
                response = MessageType.Shouting;
            }

            return response;
        }

        private static bool IsQuestion(string message)
        {
            return message.Trim().EndsWith("?") && (message.Any(Char.IsLower) || message.Any(Char.IsDigit));
        }

        private static bool IsShouting(string message)
        {
            return message.Equals(message.ToUpper()) && message.Any(Char.IsLetter);
        }

        private static bool IsSilence(string message)
        {
            return message.All(Char.IsWhiteSpace);
        }
    }

    public enum MessageType
    {
        Generic,
        Question,
        Shouting,
        Silence
    }
}