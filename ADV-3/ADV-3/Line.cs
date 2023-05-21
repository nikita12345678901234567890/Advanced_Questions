using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_3
{
    public class Line
    {
        public List<string> words = new List<string>();
        public List<string> spaces = new List<string>();

        public Line(string line)
        {
            words = line.Split(' ').ToList();
            spaces = new List<string>(new string[words.Count - 1]);
        }

        public string combine()
        {
            string result = "";
            for (int i = 0; i < words.Count - 1; i++)
            {
                result += words[i];
                result += spaces[i];
            }
            result += words[words.Count - 1];

            return result;
        }
    }
}
