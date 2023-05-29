using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;

using static System.Net.Mime.MediaTypeNames;

namespace ADV_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "As the sun dipped below the horizon, casting a warm golden glow across the vast expanse of the ocean, a gentle breeze whispered through the tall swaying palm trees. The air was filled with the sweet scent of tropical flowers, mingling with the salty tang of the sea. The sound of waves crashing against the shore created a soothing symphony that lulled the nearby beachgoers into a state of tranquility. Seagulls soared gracefully overhead, their cries echoing in the distance. It was a moment of perfect serenity, a fleeting glimpse of paradise on Earth.";

            var words = convert(text);

            Rope rope = new Rope();

            rope.BuildRope(words);

            Console.WriteLine(rope.justify(25));
        }

        public static List<(string text, string type)> convert(string words)
        { 
            List<(string text, string type)> result = new List<(string text, string type)>();

            bool isword = false;
            for (int i = 0; i < words.Length; i++)
            {
                if (char.IsLetter(words, i) && !isword)
                {
                    isword = true;
                    result.Add(("", "word"));
                }
                else if (!char.IsLetter(words, i) && isword)
                {
                    isword = false;
                    result.Add(("", "separator"));
                }

                var fish = result[result.Count - 1];
                fish.text += words[i];
                result[result.Count - 1] = fish;
            }

            return result;
        }

        public static string justify(string input, int width)
        {
            List<Line> text = new List<Line>();
            var lines = input.Split('\n').ToList();
            foreach (var line in lines)
            {
                text.Add(new Line(line));
            }

            string result = "";

            for(int i = 0; i < text.Count; i++)
            {
                int wordWidth = 0;
                foreach (string word in text[i].words)
                {
                    wordWidth += word.Length;
                }

                while (wordWidth + text[i].spaces.Count >= width)
                {
                    if (i == text.Count - 1)
                    {
                        text.Add(new Line(text[i].words[text[i].words.Count - 1]));
                        text[i].words.RemoveAt(text[i].words.Count - 1);
                        text[i].spaces.RemoveAt(text[i].spaces.Count - 1);
                    }
                    else
                    {
                        text[i + 1].words.Insert(0, text[i].words[text[i].words.Count - 1]);
                        text[i + 1].spaces.Add("");
                        text[i].words.RemoveAt(text[i].words.Count - 1);
                        text[i].spaces.RemoveAt(text[i].spaces.Count - 1);
                    }

                    wordWidth = 0;
                    foreach (string word in text[i].words)
                    {
                        wordWidth += word.Length;
                    }
                }

                int spacing = width - wordWidth;

                for (int j = 0; j < text[i].spaces.Count; j++)
                {
                    text[i].spaces[j] = "";
                    for (int k = 0; k < spacing / text[i].spaces.Count; k++)
                    {
                        text[i].spaces[j] += " ";
                    }
                }

                for (int j = 0; j < spacing % text[i].spaces.Count; j++)
                {
                    text[i].spaces[j] += " ";
                }

                result += text[i].combine() + "\n";
            }

            return result;
        }
    }
}