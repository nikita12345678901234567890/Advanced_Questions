namespace ADV_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MagicList<int> magic = new MagicList<int>();

            for (int i = 0; i < 18; i++)
            {
                magic.Add(i);
            }

            var fish = magic.Contains(12);

            var yeet = magic.Index(12);
            ;
        }
    }
}