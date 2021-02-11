using System;

namespace MemoConsole
{
    public static class Utility
    {
        public static void Randomize(char[] items)
        {
            Random rand = new Random();
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                var temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
}