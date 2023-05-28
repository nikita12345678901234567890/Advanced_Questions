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
            List<(string, string)> text = new List<(string, string)>();
            text.Add(("Hello", "word"));
            text.Add((", ", "separator"));
            text.Add(("this", "word"));
            text.Add((" ", "separator"));
            text.Add(("is", "word"));
            text.Add((" ", "separator"));
            text.Add(("some", "word"));
            text.Add((" ", "separator"));
            text.Add(("sample", "word"));
            text.Add((" ", "separator"));
            text.Add(("text.", "word"));

            Rope rope = new Rope();

            rope.BuildRope(text);

            Console.WriteLine(rope.justify(15));
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