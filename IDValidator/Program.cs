using System;

namespace IDValidator
{
    public static class Program
    {
        public static string id = default(string);
        public static int sN = default(int);
        public static int eN = default(int); 
        public static int modRes = default(int);
        public static int res = default(int);
        public static string tempRes = default(string);

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
/$$$$$$ /$$$$$$$        /$$    /$$          /$$ /$$       /$$             /$$                        
|_  $$_/| $$__  $$      | $$   | $$         | $$|__/      | $$            | $$                        
| $$  | $$  \ $$      | $$   | $$ /$$$$$$ | $$ /$$  /$$$$$$$  /$$$$$$  /$$$$$$    /$$$$$$   /$$$$$$ 
| $$  | $$  | $$      |  $$ / $$/|____  $$| $$| $$ /$$__  $$ |____  $$|_  $$_/   /$$__  $$ /$$__  $$
| $$  | $$  | $$       \  $$ $$/  /$$$$$$$| $$| $$| $$  | $$  /$$$$$$$  | $$    | $$  \ $$| $$  \__/
| $$  | $$  | $$        \  $$$/  /$$__  $$| $$| $$| $$  | $$ /$$__  $$  | $$ /$$| $$  | $$| $$      
/$$$$$$| $$$$$$$/         \  $/  |  $$$$$$$| $$| $$|  $$$$$$$|  $$$$$$$  |  $$$$/|  $$$$$$/| $$      
|______/|_______/           \_/    \_______/|__/|__/ \_______/ \_______/   \___/   \______/ |__/      

                    Republic of Turkey ID number probability calculator | github.com/omerhuseyingul
            ");

            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.Write("[ > ] Please key in an identification number: ");
            id = Console.ReadLine();
            if (id[0] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The first digit of the national number cannot be zero.");
                Console.ForegroundColor= ConsoleColor.Cyan;
            }

            if (IdentityValidator(id) == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Republic of Turkey authentication algorithm result: true");
            }

            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Republic of Turkey authentication algorithm result: false");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static bool IdentityValidator(string param)
        {
            try
            {
                for (int i = 0; i <= param.Length - 3; i = i + 1)
                {
                    if (i % 2 == 0)
                    {
                        sN = sN + Convert.ToInt32(param[i].ToString());
                    } 

                    else if (i % 2 != 0)
                    {
                        eN = eN + Convert.ToInt32(param[i].ToString());
                    }
                }

                modRes = ((sN * 7) - eN) % 10;

                if (modRes == Convert.ToInt16(param[9].ToString()))
                {
                    for (int g = 0; g < id.Length - 1; g++)
                    {
                        res = res + Convert.ToInt32(param[g].ToString());
                        tempRes = Convert.ToString(res);
                    }

                    if (tempRes[1].ToString() == param[10].ToString())
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.");
                Console.ForegroundColor= ConsoleColor.Cyan;

                return false;
            }

            return default;
        }
    }
}