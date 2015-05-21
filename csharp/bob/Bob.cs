using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercism.Bob
{
    public static class Bob
    {
        static Dictionary<MessageType, string> bobsReponses = new Dictionary<MessageType, string>();

        public static string Hey(string message)
        {
            loadResponses();

            string response = null;

            bobsReponses.TryGetValue(MessageParser.Parse(message), out response);

            return (response == null) ? bobsReponses[MessageType.Generic] : response;
        }

        private static void loadResponses()
        {
            if (bobsReponses.Count < 4)
            {
                bobsReponses.Add(MessageType.Generic, "Whatever.");
                bobsReponses.Add(MessageType.Question, "Sure.");
                bobsReponses.Add(MessageType.Shouting, "Whoa, chill out!");
                bobsReponses.Add(MessageType.Silence, "Fine. Be that way!");
            }
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
