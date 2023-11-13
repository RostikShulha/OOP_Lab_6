using System;
using System.Text;

namespace OOP_Lab_6
{
    public class Child
    {
        int nomer;//nomer - номер дитини
        public int Nomer
        {
            get {  return nomer; }
        }
        public Child(int nomer)
        {
            this.nomer = nomer;
        }
    }

    public class PlaySchool
    {
        private int misce;//misce - Кількість місць у дитячому садку

        public delegate void NotPlacesEventHandlaer();
        public static event NotPlacesEventHandlaer NotPlaces;

        public PlaySchool(int misce)
        {
            this.misce = misce;
        }
        public void PushChild(Child child)
        {
            if (child.Nomer <= misce)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Дитина {0} зарахована", child.Nomer);
            }
            else
            {
                NotPlaces();
            }
        }
    }

    public class Manageress
    {
        string name = "Завідувач: ";
        
        public delegate void ZapysEventHandler();
        public static event ZapysEventHandler Zapys;

        public void Queue()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}Місць немає! Пропоную стати в чергу", name);
            Zapys();
        }
    }

    public class Department
    {
        string name = "Районо: ";
        public void Place()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0}Інші діти записуються в чергу", name);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Gray;

            try
            {
                Console.Write("Кількість місць в дитячому садку: ");
                int a = int.Parse(Console.ReadLine());//a - Кількість місць в дитячому садку
                Console.Write("Кількість бажаючих в дитячий садок: ");
                int c = int.Parse(Console.ReadLine());//c - Кількість бажаючих в дитячий садок
                int b = 1;//b - номер дитини

                if (a > 0 && c > 0)
                {
                    PlaySchool ps = new PlaySchool(a);
                    Manageress mg = new Manageress();
                    Department dp = new Department();

                    PlaySchool.NotPlaces += mg.Queue;
                    Manageress.Zapys += dp.Place;

                    for (int i = 0; i < c; i++)
                    {
                        Child ch = new Child(b);
                        ps.PushChild(ch);
                        b++;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Помилка. Введене від'ємне число");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Помилка. Виникла помилка введення");
                Console.ReadKey();
            }
        }
    }
}
