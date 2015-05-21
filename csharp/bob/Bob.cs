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

            if (TestSilence(message))
            {
                response = MessageType.Silence;
            }
            else if (TestQuestion(StripDigits(message)) && (StripDigits(message).Length == 1))
            {
                response = MessageType.Question;
            }
            else if (TestShouting(StripDigits(message)))
            {
                response = MessageType.Shouting;
            }
            else if (TestQuestion(StripDigits(message)))
            {
                response = MessageType.Question;
            }

            return response;
        }

        private static bool TestQuestion(string message)
        {
            bool isQuestion = false;

            if (message.Length > 0)
            {
                char[] messageArray = message.TrimEnd().ToCharArray();
                Array.Reverse(messageArray);
                isQuestion = messageArray[0] == '?';
            }

            return isQuestion;
        }

        private static bool TestShouting(string message)
        {
            return message.Equals(message.ToUpper()) && message.Length > 0;
        }

        private static bool TestSilence(string message)
        {
            return message.Trim().Length == 0;
        }

        private static string StripDigits(string message)
        {
            return Regex.Replace(message, @"[\d, ]", "");
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
