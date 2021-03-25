using System;
using morpion;

namespace morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Grille table = new Grille();

            int t = 0;
            while(t <= 9 && !table.finished)
            {
                table.tour = (t % 2)+1;
                table.ask();
                t++;
            }
        }
    }
}