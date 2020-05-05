using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер катетов треугольника: ");

            int size = int.Parse(Console.ReadLine() ?? "0");

            for (var h = 0; h <= 1; h++) // цикл по горизонтальной ориентации: 0 - направо, 1 - налево
            {
                for (var v = 0; v <= 1; v++) // цикл по вертикальной ориентации: 0 - прямая, 1 - перевёрнутая
                {
                    var vc = Math.Abs(v - 1); // ориентация, обратная вертикальной

                    for (var i = 0; i < size; i++) // цикл по строчкам рисунка
                    {
                        var sharps = vc * (i + 1) + v * (size - i); // количество решёток в строчке
                        var spaces = (size - sharps) * h; // количество пробелов в строчке

                        for (var x = 0; x < spaces; x++) // цикл рисования пробелов
                            Console.Write(" ");

                        for (var y = 0; y < sharps; y++) // цикл рисования решёток
                            Console.Write("#");

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Press ENTER to quit...");
            Console.ReadLine();
        }
    }
}
