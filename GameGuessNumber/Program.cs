using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int Level = 0;

            while (Level < 1 || Level > 3)
            {
                Console.Write("Введите уровень сложности (от 1 до 3): ");
                Level = int.Parse(Console.ReadLine());
            }

            int LeftBorder = 0;
            int RightBorder;

            if(Level == 1)  { RightBorder = 100; }
            else if (Level == 2) { RightBorder = 500; }
            else { RightBorder = 1000; }

            Random rand = new Random();
            int ComputerNum = rand.Next(RightBorder + 1);

            int UserNum;
            int tries = 0;

            Console.WriteLine($"Угадайте, какое число загадал компьютер.");
            do
            {
                Console.Write($"Введите число от {LeftBorder} до {RightBorder}: ");
                UserNum = int.Parse(Console.ReadLine());


                if(UserNum != ComputerNum && UserNum >= LeftBorder && UserNum <= RightBorder)
                {
                    Console.WriteLine("Неверно, попробуйте еще раз.");
                    if (UserNum < ComputerNum && UserNum > LeftBorder)
                    {
                        LeftBorder = UserNum;
                        tries++;
                    }
                    else if (UserNum > ComputerNum && UserNum < RightBorder)
                    {
                        RightBorder = UserNum;
                        tries++;
                    }
                                    }
                else if(UserNum == -1)
                {
                    Console.WriteLine($"Ладно, хитрец, правильный ответ: {ComputerNum}. Но больше не жульничай.");
                }
                else if (UserNum == ComputerNum)
                {
                    tries++;
                    Console.WriteLine($"Ура, вы угадали! Компьютер загадал число {ComputerNum}!");
                }
                else
                {
                    Console.WriteLine("Число за пределами заданного диапазона!");
                }
                               
            } while (UserNum != ComputerNum);

            if (tries <= 7)
            {
                Console.WriteLine($"Количество ваших попыток: {tries}. Вы потрясающий!");
            }
            else if (tries > 7 && tries <= 15)
            {
                Console.WriteLine($"Количество ваших попыток: {tries}. Вы умнее, чем 5% пользователей.");
            }
            else
            {
                Console.WriteLine($"Количество ваших попыток: {tries}. Гуманитарии тоже люди.");
            }

            Console.ReadKey();
        }
    }
}
