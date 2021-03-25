using System;

namespace morpion
{
    class Grille
    {
        private static int[,] table = new int[3,3];
        private static int[] cord = new int[2];
        public int tour;
        public bool finished = false;

        
        public Grille()
        {
            print();
        }

        public void ask()
        {
            Console.WriteLine("Ligne :");
            int x = Convert.ToInt32(Console.ReadLine());
            while(!(x>0 && x<4))
            {
                Console.WriteLine("Ce n'est pas dans la grille, entrez une autre valeur de la ligne :");
                x = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Colone :");
            int y = Convert.ToInt32(Console.ReadLine());
            
            while(!(y>0 && y<4))
            {
                Console.WriteLine("Ce n'est pas dans la grille, entrez une autre valeur de la colonne :");
                y = Convert.ToInt32(Console.ReadLine());
            }
            cord[0] = y-1;
            cord[1] = x-1;
            if(finished == false)
            {
                plot();
                print();
            }
            won();
        }

        private void won()
        {
            bool noz = true;
            for(int a = 0; a<3; a++)
            {
                for(int b = 0; b<3; b++)
                {
                    if(table[a,b] == 0)
                    {
                        noz = false;
                    }
                }
            }
            if(noz)
            {
                finished = true;
            }
            //horizontale
            int count = 0;
            for(int ligne = 0;ligne<3;ligne++)
            {
                int aligne = table[ligne,0]; 
                if(aligne != 0)
                {
                    count = 0;
                    for(int index = 1; index < 3; index++)
                    {
                        if(table[ligne,index] == aligne)
                            {
                                count++;
                            }
                    }
                    if(count == 2)
                    {
                        finished = true;
                        Console.WriteLine($"Le joueur {aligne} gagne");
                        Console.ReadLine();
                    }
                }
            }
            //verticale
            count = 0;
            for(int colone = 0;colone<3;colone++)
            {
                int aligne = table[0,colone]; 
                if(aligne != 0)
                {
                    count = 0;
                    for(int index = 1; index < 3; index++)
                    {
                        if(table[index,colone] == aligne)
                            {
                                count++;
                            }
                    }
                    if(count == 2)
                    {
                        finished = true;
                        Console.WriteLine($"Le joueur {aligne} gagne");
                        Console.ReadLine();
                    }
                }
            }
            //diagonale
            count = 0;
            int color = table[1,1];
            if((color != 0) && ((table[0,0] == color && table[2,2] == color) | (table[2,0] == color && table[2,0] == color)))
            {
                finished = true;
                Console.WriteLine($"Le joueur {color} gagne");
                Console.ReadLine();
            }
        }
        private void plot()
        {
            int posx = cord[0];
            int posy = cord[1];
            
            if (table[posy,posx] == 0)
            {
                table[posy,posx] = tour;
            }
            else
            {
                Console.WriteLine("Case déja prise");
                ask();
            }
        }
        
        private void print()
        {
            Console.Clear();
            Console.WriteLine("+---+---+---+");
            for(int i = 0; i < 3 ; i++)
            {
                string[] value = new string[3];
                for(int y = 0; y < 3; y++)
                {
                    if(table[i,y] == 0)
                    {
                        value[y] = " ";
                    }
                    else
                    {
                        if((table[i,y]) % 2 == 1)
                        {
                            value[y] = "X";
                        }
                        else
                        {
                            value[y] = "O";
                        }
                    }
                }
            Console.WriteLine($"| {value[0]} | {value[1]} | {value[2]} |");
            Console.WriteLine("+---+---+---+");
            }
        }
    }
}
