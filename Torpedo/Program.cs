using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazi_2_10_12_labdas
{
    class Program
    {
        static void ShowArray(int[] tm)
        {
            foreach (int j in tm)
            {
                System.Console.Write(j.ToString() + " ");
            }
            System.Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // keret koordinátái
            int x1 = 4, y1 = 4, x2 = 14, y2 = 14;

            // keret aknakeresőhöz
            Keret(x1, x2, y1, y2);

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("A játék kezdéséhez nyomj le kérlek egy billentyűt!");

            // key
            ConsoleKeyInfo billentyu;
            Console.CursorVisible = false;
            billentyu = Console.ReadKey(true);


            // random szám generálás
            Random rnd = new Random();

            int[] akna_x = new int[10];
            int[] akna_y = new int[10];


            // akna koordinátáinak a feltöltése X és Y-ba.
            for (int i = 0; i < 10; i++)
            {
                akna_x[i] = rnd.Next(1, 9);
                akna_y[i] = rnd.Next(1, 9);
            }


            // az aknák elhelyezkedése: ellenőrzés céljából van kiíratva
            Console.WriteLine();
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("x koordináták:");
            ShowArray(akna_x);
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("y koordináták:");
            ShowArray(akna_y);

            bool eltalaltad = false;

            do
            {
                Console.SetCursorPosition(0, 19);
                Console.WriteLine("Kérek egy X koordinátát(1-9-ig):");
                int ux = Int32.Parse(Console.ReadLine());
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 20);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 19);

                Console.SetCursorPosition(0, 19);
                Console.WriteLine("Kérek egy Y koordinátát(1-9-ig):");
                int uy = Int32.Parse(Console.ReadLine());
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 20);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 19);

                for (int i = 0; i < 10; i++)
                {
                    if (ux == akna_x[i] && uy == akna_y[i])
                    {
                        ClearCurrentConsoleLine();
                        Console.SetCursorPosition(0, 20);
                        Console.WriteLine("Aknára léptél! Meghaltál!");
                        eltalaltad = true;
                    }
                }

                Console.SetCursorPosition(ux + x1, uy + y1); Console.Write("█");
                Console.SetCursorPosition(1, 19);

                // szomszédos aknák
                int aknakszama = 0;
                for (int i = 0; i < 10; i++)
                {
                    // bal szomszéd
                    if (ux - 1 == akna_x[i] && uy == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // jobb szomszéd
                    if (ux + 1 == akna_x[i] && uy == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // felső szomszéd
                    if (ux == akna_x[i] && uy - 1 == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // alsó szomszéd
                    if (ux == akna_x[i] && uy + 1 == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // ball felső szomszéd
                    if (ux - 1 == akna_x[i] && uy - 1 == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // ball alsó szomszéd
                    if (ux - 1 == akna_x[i] && uy + 1 == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // jobb felső szomszéd
                    if (ux + 1 == akna_x[i] && uy - 1 == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // jobb alsó szomszéd
                    if (ux + 1 == akna_x[i] && uy + 1 == akna_y[i])
                    {
                        aknakszama++;
                    }
                    // a találatunk kiíratása
                    Console.SetCursorPosition(ux + x1, uy + y1);

                    // ha aknára léptünk kiíratjuk azt egy X karakterrel, ha nem akkor a szomszédos mezőkön lévő aknák számát kiíratjuk
                    if (eltalaltad)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(aknakszama);
                        Console.SetCursorPosition(1, 19);
                    }


                }

                // töröld ki mert csak ellenőrzés, aknák megjelenítése
                /*for (int i = 0; i<10;i++)
                {
                    Console.SetCursorPosition(akna_x[i]+x1, akna_y[i]+y1); Console.Write("■");
                }*/


            } while ((!eltalaltad && billentyu.Key != ConsoleKey.Escape));


            Console.ReadLine();
        }

        // sortörlése
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop; // fentről hanyadik sor
            Console.SetCursorPosition(0, Console.CursorTop); // sor elejére állítja
            Console.Write(new string(' ', Console.WindowWidth)); // szélessége a consolenak
            Console.SetCursorPosition(0, currentLineCursor); // a törölt sor elejére visszaállítja a kurzort
        }



        // --------------------- KERET -------------------------------
        static void Keret(int x1, int x2, int y1, int y2)
        {
            int t, i = 1; // localis változók

            for (t = x1; t <= x2; t++)
            {
                Console.SetCursorPosition(t, y1); Console.Write("─");
                Console.SetCursorPosition(t, y2); Console.Write("─");
                if (t != x1 && t != x2)
                {
                    Console.SetCursorPosition(t, y1 - 1); Console.Write(i++);
                }

            }
            i = 1;
            for (t = y1; t <= y2; t++)
            {
                Console.SetCursorPosition(x1, t); Console.Write("│");
                Console.SetCursorPosition(x2, t); Console.Write("│");
                if (t != y1 && t != y2)
                {
                    Console.SetCursorPosition(x1 - 2, t); Console.Write(i++);
                }

            }

            Console.SetCursorPosition(x1, y1); Console.Write("┌");
            Console.SetCursorPosition(x2, y1); Console.Write("┐");
            Console.SetCursorPosition(x1, y2); Console.Write("└");
            Console.SetCursorPosition(x2, y2); Console.Write("┘");
        }
    }
}
