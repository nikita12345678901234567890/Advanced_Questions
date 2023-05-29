using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_4
{
    public class Envelope
    {
        public int length;
        public int width;

        public List<Envelope> fits;

        public int max = 0;

        public Envelope(int length, int width)
        {
            this.length = length;
            this.width = width;
            fits = new List<Envelope>();
        }

        public bool check(Envelope thing)
        {
            if (length > thing.length && width > thing.width)
            {
                return true;
            }
            /*else if (length > thing.width && width > thing.length) //rotaion
            {
                return true;
            }*/
            return false;
        }
    }
}
