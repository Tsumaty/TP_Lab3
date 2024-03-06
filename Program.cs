// var 3
// sin(−x^2) | −\/(1/x^3−1) | exp(−sin(5/ln(x))) | foreach

using System.Globalization;

namespace TP_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // массив параметров функции - целые числа, которые
            // впоследситвии будут поделены на 1000.0,
            // чтобы уменьшить погрешность чисел типа double
            int[] array = new int[1001];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i - 5;
            }

            List<string> calcResults = new List<string>();

            // текст предыдущего исключения для вывода
            // только первого уникального исключения
            string exPrevMessage = "";

            // просим пользователя подождать
            Console.Write("Please, wait several seconds..");
            // вывод в консоль и заполнение списка
            // циклом foreach (по заданию)
            foreach (double num in array)
            {
                // парметр n - это число из массива array, делённое
                // на 1000.0 для максимальной точности вычислений
                double n = num / 1000.0;
                // переводим n в строку для ровного вывода с привязкой к правому краю
                string x = n.ToString("f3", CultureInfo.InvariantCulture).PadLeft(6);
                // создаём новую строку вида "x: y(x)"
                string xy = x + ": ";

                try
                {
                    // функция вычсиляется с параметром n
                    double f = Calculations.Func(n);
                    // перевод в строку для более красивого формата
                    string y = f.ToString("0.000000E+00", CultureInfo.InvariantCulture);

                    xy += y;

                    // текст прошлого исключения обнуляется,
                    // если вычисления прошли успешно
                    exPrevMessage = "";

                    // добавляем аргумент и значение функции
                    // в список для занесения его в файл
                    calcResults.Add(xy);

                    // выводим результаты в консоль
                    // Console.WriteLine($"{xy}");
                }
                catch (Exception ex)
                {
                    // вывод исключения только если текст исключения
                    // отличается от предыдущего
                    if (ex.Message != exPrevMessage)
                    {
                        xy += ex.Message;
                        calcResults.Add(xy);
                        // Console.WriteLine($"{x}: {ex.Message}");
                        exPrevMessage = ex.Message;
                    }
                }
            }

            // запись аргументов и значений функции в файл
            try
            {
                File.WriteAllLines("calcResults.txt", calcResults);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}