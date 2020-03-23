using System;
using System.Threading;

namespace PapaMamaCSharp
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Сколько сообщений вы хотите вывести?");
            Message.TotalMessages = int.Parse(Console.ReadLine());
            Console.WriteLine("Сколько потоков вы хотите создать?");
            int n = int.Parse(Console.ReadLine());
            Thread[] threads = new Thread[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Что вы хотите вывести в " + (i+1).ToString() +" потоке?");
                string message = Console.ReadLine();
                Console.WriteLine("Введите величину задержки данного потока в миллисекундах ");
                int mSec = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите количество повторов ");
                int countOfRepeats = int.Parse(Console.ReadLine());
                Message text = new Message(message,mSec,countOfRepeats);
                threads[i] = new Thread(new ThreadStart(text.Write));
                
            }

            foreach (var th in threads)
            {
                
                th.Start();
            }
            foreach (var th in threads)
            {
                
                th.Join();
            }

            
            
        }
    }
}
