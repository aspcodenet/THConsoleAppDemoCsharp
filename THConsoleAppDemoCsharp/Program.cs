using System;

namespace THConsoleAppDemoCsharp
{
    class Program
    {

        private static (string, string, int) GetPlayer(int jersey)
        {
            if (jersey == 13) return ("Mats Sundin", "Toronto", 49);
            if (jersey == 21) return ("Peter Forsberg", "Colorado", 48);
            return ("", "", 0);
        }


        static void Main(string[] args)
        {
            Test2();
            Test1();

            var p = GetPlayer(21);
            Console.WriteLine($"Hello World! {p.Item1}");

            var (namn, team, age) = GetPlayer(21);
            Console.WriteLine($"Hello World! {namn}");


            var (namn2, _, age2) = GetPlayer(13);
            Console.WriteLine($"Hello World! {namn2} {age2}");

        }

        private static void Test2()
        {
            int result;
            string input = "213";
            if (int.TryParse(input, out result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");

            if (int.TryParse(input, out int result2))
                Console.WriteLine(result2);
            else
                Console.WriteLine("Could not parse input");

            //for(int i =0;)

        }

        private static void Test1()
        {
            var alphabetStart = (Alpha: "a", Beta: "b");
            var alphabetStart111 = (Alpha: "a", Beta: "b");

            var alphabetStart2 = new { Alpha = "a", Beta = "b" };
            var alphabetStart222 = new { Alpha = "a", Beta = "b" };


            if (alphabetStart == alphabetStart111)
            {
                Console.WriteLine("Japp");
            }
            if (alphabetStart2 == alphabetStart222)
            {
                Console.WriteLine("samma");
            }
        }
    }
}
