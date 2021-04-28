using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Win32.SafeHandles;

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


        static (int,int) GetMinAndMax(IEnumerable<int> talen)
        {
            int min = talen.First();
            int max = talen.First();
            foreach (var tal in talen)
            {
                if (tal > max)
                    max =  tal;
                if (tal < min)
                    min = tal;
            }

            return (min,max);
        }



        class Account
        {
            public enum WithdrawalStatus
            {
                Ok,
                CantWithdrawNegativeAmount,
                SaldoTooLow
            }

            private int saldo;

            public Account(int startSaldo)
            {
                saldo = startSaldo;
            }

            public int GetSaldo()
            {
                //Nätverksanrop
                return saldo;
            }

            public (WithdrawalStatus,int) Withdraw(int amount)
            {
                //Nätverksanrop
                if (amount < 0)
                    return (WithdrawalStatus.CantWithdrawNegativeAmount,saldo);
                if (saldo >= amount)
                {
                    saldo -= amount;
                    return (WithdrawalStatus.Ok,saldo);
                }

                return (WithdrawalStatus.SaldoTooLow,saldo);
            }

        }

        class Bankomat
        {
            public void Run()
            {
                var account = new Account(100);
                var (status, saldo) = account.Withdraw(20);
                if (status == Account.WithdrawalStatus.Ok)
                {
                    var nyttSaldo = saldo;
                    Console.WriteLine($"Nytt saldo: {nyttSaldo}");
                }

            }
        }


        static void Main(string[] args)
        {

            var bankomat = new Bankomat();
            bankomat.Run();

            var l = new List<int>()
            {
                12,11,33,56,1
            };
            var q = GetMinAndMax(l);
            var (min,max) = GetMinAndMax(l);
            //int min = l.Min();
            //int max = l.Max();


            Records();
            Indicies();

            Test2();
            Test1();

            var p = GetPlayer(21);
            Console.WriteLine($"Hello World! {p.Item1}");

            var (namn, team, age) = GetPlayer(21);
            Console.WriteLine($"Hello World! {namn}");


            var (namn2, _, age2) = GetPlayer(13);
            Console.WriteLine($"Hello World! {namn2} {age2}");

        }


        public record Person(string FirstName, string LastName);


        private static void Records()
        {
            var person = new Person("Mats", "Sundin");
            var person2 = new Person("Mats", "Sundin");

            Console.WriteLine(person.FirstName);
//            person.FirstName = "dasdasadsdas";
            if (person == person2)
            {
                Console.WriteLine("saadsd");
            }

        }

        private static void Indicies()
        {
            var p = new Person("Mats", "Sundin");


            var months = new[]
            {
                "Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli",
                "Augusti", "September", "Oktober", "November", "December"
            };

            var first = months[0];

            var last = months[^1];
            var firstthree = months[0..3];
            var lastStartingFrom7 = months[7..];

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
