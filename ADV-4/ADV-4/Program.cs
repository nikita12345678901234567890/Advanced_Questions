namespace ADV_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Envelope> envelopes = new List<Envelope>();

            envelopes.Add(new Envelope(50, 50));
            envelopes.Add(new Envelope(25, 50));
            envelopes.Add(new Envelope(20, 18));
            envelopes.Add(new Envelope(15, 5));
            envelopes.Add(new Envelope(12, 4));
            envelopes.Add(new Envelope(10, 3));
            envelopes.Add(new Envelope(16, 5));

            Console.WriteLine(doStuff(envelopes));
        }

        public static int doStuff(List<Envelope> envelopes)
        {
            for (int i = 0; i < envelopes.Count; i++)
            {
                for (int j = 0; j < envelopes.Count; j++)
                {
                    if (envelopes[i].check(envelopes[j])) envelopes[i].fits.Add(envelopes[j]);
                }
            }

            int max = 0;
            foreach (Envelope envelope in envelopes)
            {
                int result = getMax(envelope);
                if (result > max) max = result;
            }

            return max;
        }

        public static int getMax(Envelope envelope)
        {
            int max = 1;
            foreach (Envelope fish in envelope.fits)
            {
                int result = getMax(fish) + 1;
                if (result > max) envelope.max = max = result;
            }
            return max;
        }
    }
}