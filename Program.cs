using System;
using System.Text;

namespace W2L8
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(W2L8_1(100));
            Console.WriteLine(W2L8_2(10));
            Console.WriteLine(W2L8_3(10));
            Console.WriteLine(W2L8_4(100));
            Console.WriteLine(W2L8_5(20));
            Console.WriteLine(W2L8_6(20));
            Console.WriteLine(W2L8_7(7));
            Console.WriteLine(W2L8_8("Abcdefg"));

            Console.WriteLine("Podejscie 1 (100)");
            Console.WriteLine(W2L8_9("100"));
            Console.WriteLine("Podejscie 2 (1a0)");
            Console.WriteLine(W2L8_9("1s0"));

            Console.WriteLine(W2L8_10(2, 21));
        }

        //1. Napisz program, który sprawdzi ile jest liczb pierwszych w zakresie 0 – 100.
        //Aby sprawdzić, czy liczba naturalna jest liczbą pierwszą, należy dzielić ją kolejno przez wszystkie liczby większe od 1 i mniejsze równe pierwiastka kwadratowego z tej liczby. 
        //Jeśli przy każdym dzieleniu reszta z dzielenia jest różna od zera, to liczba jest liczbą pierwszą.
        //Natomiast jeżeli choć jedno dzielenie daje resztę równą zero, to sprawdzana liczba naturalna jest liczbą złożoną.
        //Nie jest to więc problem teoretyczny, jednak praktycznie trudny w przypadku bardzo dużych liczb.
        public static int W2L8_1(int input)
        {
            int result = 0;
            if (input <= 1)
            {
                return 0;
            }
            else
            {
                for (int i = 2; i <= input; i++)
                {
                    if (W2L8_1_IsFirst(i) == true)
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        public static bool W2L8_1_IsFirst(int a)
        {
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        //2. Napisz program, w którym za pomocą pętli do…while znajdziesz wszystkie liczby parzyste z
        //zakresu 0 – 1000.

        public static int W2L8_2(int input)
        {
            int result = 0;
            int helper = 1;
            do
            {
                if (helper % 2 == 0)
                {
                    result++;
                }
                helper++;
            }
            while (helper <= input); ;
            return result;
        }


        //3. Napisz program, który zaimplementuje ciąg Fibonacciego i wyświetli go na ekranie.
        public static string W2L8_3(int input)
        {
            StringBuilder sb = new StringBuilder();
            int first = 0, second = 1, helper;
            for (int i = 0; i < input; i++)
            {
                sb.Append((first + second).ToString() + ", ");
                helper = second;
                second = first + second;
                first = helper;
            }

            return sb.ToString();
        }

        //4. Napisz program, który po podaniu liczby całkowitej wyświetli piramidę liczb od 1 do podanej
        //liczby w formie jak poniżej:
        //1
        //2 3
        //4 5 6
        //7 8 9 10

        public static string W2L8_4(int input)
        {
            StringBuilder sb = new StringBuilder();
            int line = 1;
            for (int i = 1, j = 1; j <= input; i++, j++)
            {
                if (i >= line)
                {
                    sb.Append(j + "\n");
                    line++;
                    i = 0;
                }
                else
                {
                    sb.Append(j + " ");
                }
            }
            return sb.ToString();
        }
        //5. Napisz program, który dla liczb od 1 do 20 wyświetli na ekranie ich 3 potęgę.

        public static string W2L8_5(int input)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i <= input)
            {
                sb.Append($"Third power of number {i} is: {Math.Pow(i, 3)}.\n");
                i++;
            }
            return sb.ToString();
        }


        //6. Napisz program, który dla liczb od 0 do 20 obliczy sumę wg wzoru:
        //1 + ½ + 1/3 + ¼ itd.

        public static double W2L8_6(int input)
        {
            double result = 0;
            for (int i = 1; i <= input; i++)
            {
                double divider = Convert.ToDouble(i); // czemu wogóle to musze konwertować? :D w innym wypadku result zawsze jest równy 1?
                result += 1 / divider;
            }
            return result;
        }
        //7. Napisz program, który dla liczby zadanej przez użytkownika narysuje diament o krótszej
        //przekątnej o długości wprowadzonej przez użytkownika i wg wzoru:
        //*
        // ***
        // *****
        //*******
        //*********
        //*******
        // *****
        // ***
        // *
        public static string W2L8_7(int input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= input; i++)
            {
                for (int j = input - i; j > 0; j--)
                    sb.Append(" ");
                for (int j = i; j > 0; j--)
                    sb.Append("* ");
                sb.Append("\n");
            }
            for (int i = input - 1; i > 0; i--)
            {
                for (int j = input - i; j > 0; j--)
                    sb.Append(" ");
                for (int j = i; j > 0; j--)
                    sb.Append("* ");
                sb.Append("\n");
            }

            return sb.ToString();
        }

        //8. Napisz program, który odwróci wprowadzony przez użytkownika ciąg znaków.Np.
        //Testowe dane:
        //Abcdefg
        //Rezultat
        //Gfedcba

        public static string W2L8_8(string input)
        {
            char[] charArr = input.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr);
        }

        //9. Napisz program, który zamieni liczbę dziesiętną na liczbę binarną.
        public static string W2L8_9(string input)
        {
            string output = "";
            if (DecimalValidation(input) == true)
            {
                int i = Convert.ToInt32(input);
                while (i > 0)
                {
                    int digit = i % 2;
                    i /= 2;
                    output += digit.ToString();
                }
                return W2L8_8(output);
            }
            return "Choose correct number!";
        }

        public static bool DecimalValidation(string input)
        {
            foreach (char _char in input.ToCharArray())
            {
                if (char.IsDigit(_char) == false) return false;
            }
            return true;
        }

        //10. Napisz program, który znajdzie najmniejszą wspólną wielokrotność dla zadanych 2 liczb.

        public static int W2L8_10(int input1, int input2)
        {
            if (input1 < input2)
            {
                return W2L8_10(input2, input1);
            }
            int i = input1;
            while (i % input2 != 0)
                i += input1;
            return i;
        }
    }
}
