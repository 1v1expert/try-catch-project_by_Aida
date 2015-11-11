using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try_catch
{
    class Program
    {
        static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void Blue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        static void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        static void Main(string[] args)
        {
            int amount;
            labl2:
            Console.WriteLine("Введите количество студентов ->");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Red();
                Console.WriteLine("Вы ввели не число, повторите !");
                goto labl2;
            }
            string[,] answ = new string[3, amount];
            Console.WriteLine("\tОтветьте на следующий вопрос, студенты: ");
            Console.WriteLine("Как вы собираетесть отвечать на вопросы на предстоящем экзамене ?");
            Console.WriteLine("Варианты ответа: ");
            Console.WriteLine("\t1. Откуда-нибудь списать \n\t2. Получить ответ из интернета \n\t3. Подготовиться к экзамену");
            int k = 0;
            while (k < amount)
            {
            labl1:
                Gray();
                Console.WriteLine("\nВведите номер от 1 до 3 ниже, студент {0} \n", k+1);
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    answ[number-1, k] = "Студент";
                    ++k;
                }
                catch (IndexOutOfRangeException)
                {
                    Red();
                    Console.WriteLine("Вы вели не верный номер, студент {0}, повторите !", k+1);
                    goto labl1;
                }
                catch (FormatException)
                {
                    Red();
                    Console.WriteLine("Студент {0}, вы ввели не число, повторите !", k+1);
                    goto labl1;
                }
            }
            Console.WriteLine("\tСпасибо за понимание, досвидос !\n");
            //-----------------------------------------------------
            Console.WriteLine("\tГистограмма ниже -> \n");
            for (int i = 3; i > 0; --i)
            {
                Red();
                Console.Write("{0}|", i);
                for (int j = 0; j < amount; ++j)
                    if (answ[i - 1, j] == "Студент")
                    {
                        Blue();
                        Console.Write(" - ");
                    }
                    else
                        Console.Write("   ");
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int j = 1; j < amount + 1; ++j)
                Console.Write(" {0} ", j);
            //Console.WriteLine();

            Gray();
            Console.WriteLine("\n     Студенты\n");
            Green();
            Console.WriteLine("\tGoodbye ! !");
            //-----------------------------------------------------
            Console.ReadKey();
        }
    }
}
