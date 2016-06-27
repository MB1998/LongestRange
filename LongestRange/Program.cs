using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LongestRange
{
    class Program//программа для поиска самой длинной цепочки единиц из последовательности единиц и нулей, полученных из файла
    {
        static void RandomInput(string fileWay)//рандомно заполняет последовательностью нулей и единиц входной файл
        {
            StreamWriter sw = new StreamWriter(fileWay);
            Random random = new Random();
            string s = "";
            for(int i = 0; i < 100; i++)
                s += (random.Next() % 2).ToString();
            sw.WriteLine(s);
            sw.Close();
        }

        static string ReadInput(string fileWay)//считывает последовательность знаков из файла
        {
            StreamReader sr = new StreamReader(fileWay);
            string s = sr.ReadLine();
            return s;
        }

        static int LonggestRange(string s)//ищет самую длинную цепочку единиц из последовательности
        {
            int maxCount = 0, count = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                    count++;
                else if (s[i] == '0')
                {
                    maxCount = (count > maxCount) ? count : maxCount;
                    count = 0;
                }
                else
                    return -1;
            }
            return maxCount;
        }

        static void Main(string[] args)
        {
            string s = ReadInput(@"INPUT.txt");
            Console.WriteLine(s);
            Console.WriteLine(LonggestRange(s).ToString());

            StreamWriter sw = new StreamWriter(@"OUTPUT.txt");
            sw.WriteLine(LonggestRange(s).ToString());
            sw.Close();

            Console.ReadLine();
        }
    }
}
