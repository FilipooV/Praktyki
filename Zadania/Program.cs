using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;  
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zadania
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            /*Console.WriteLine("Insert ur name:");
            string name = Console.ReadLine();
            Console.WriteLine("Insert ur surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Insert amount in PLN");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            */
            Console.WriteLine("Insert ur name:");
            string name = Console.ReadLine();
            Console.WriteLine("Insert ur surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Insert ur sample text:");
            string context = Console.ReadLine();






            /*StreamReader read = new StreamReader("test_Filip_Trzmiel.txt");*/

            //xxx - name yyy - nazwisko
            /*string path = "test_" + name + "_" + surname + ".txt";*/

            

/*        var path = "test_fil_trz.txt"; // More than 18
*/
        var path2 = "task3.txt"; // More than 18

        ;

        /*

        //CreateFile - Does file exists? If no create if yes give info.
        /*            CreateFile(path);
         *          //WriteFile - create content in file - name & surname given from user.
        /*            WriteFile(path, name, surname);
        *//*          //ReadFile - read content from file.
         *            ReadFile(path);
         *          //Number_A - its counting how many letter 'a' i have in file.
        */
            /*WriteFile(path, name, surname);
            Number_A(path);
            Task3(path2);*/

            /*            Task5_Api(amount);
            */
            /*            Task4(path3, RandNames, RandSurnames, RandomDateBirth);
            */
            /*            Task4(path3);
             *            */
            var path1 = "test_" + name + "_" + surname + ".txt";


            if (path1.Length > 15)
            {
                path1 = "test_" + name.Substring(0, 3) + "_" + surname.Substring(0, 3) + ".txt";
                WriteFile(path1, context);
                Number_A(name, surname);

            }
            else
            {
                path1 = "test_" + name + "_" + surname + ".txt";
                WriteFile(path1, context);
                Number_A(name, surname);
            }
            Task3(path2);
            Task4();

            Console.WriteLine("Insert amount in PLN");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Task5_Api(amount);
            Console.ReadKey();





        }

/*        public static void ReadFile(string path)

        {
            string line;
*//*            Console.WriteLine(path.Length);
*//*
            
            using(StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }*/
/*        public static void CreateFile(string path1)
        {

            if (File.Exists(path1))
            {
                Console.WriteLine("File is existing \n");
            }
            else
            {
                File.Create(path1);
            }
        }*/
        public static void WriteFile(string path1, string context)
        {
            /*            using (StreamWriter writer = new StreamWriter(path))
                        {
                            writer.WriteLine("Agnieszka juz dawno tutaj nie mieszka");
                            writer.WriteLine("Agnieszka juz dawno tutaj nie mieszka");

                        }
            */
            StreamWriter writer = new StreamWriter(path1);
            writer.WriteLine(context);
            //I wrote close here because its close thread then next method like read or write or example like this can work. If u dont wanna use this u should use 'using(Stream xxx = new StreamWriter/Reader').
            writer.Close();
        }
        public static void Number_A(string name, string surname)
        {

            /*string line = File.ReadAllText(path);*/


            /*for (int i = 0; i < line.Length; i++)
            {
                for (int z = 0; z < line[i].Length; z++)
                {
                    Console.WriteLine(i);
                }
            }*/

           
            var path_zad_2 = "test_" + name + "_" + surname + ".txt";
            char a = 'a';
            if (path_zad_2.Length >= 12)
            {
                path_zad_2 = "test_" + name.Substring(0, 3) + "_" + surname.Substring(0, 3) + ".txt";
                string lines = File.ReadAllText(path_zad_2);
                var Number_A = lines.Split(a).Length - 1;
                Console.WriteLine("W pliku jest/są: " + Number_A + " liter/a/y 'a'.");
            }
            else
            {
                path_zad_2 = "test_" + name + "_" + surname + ".txt";
                string lines = File.ReadAllText(path_zad_2);
                var Number_A = lines.Split(a).Length - 1;
                Console.WriteLine("W pliku jest/są: " + Number_A + " liter/a/y 'a'.");

            }



        }

        public static void Task3 (string path2)
        {
            if (!File.Exists(path2))
            {

                var file = File.Create(path2);
                file.Close();
            }
            else
            {
                Console.Write("File is existing");
            }

            using (StreamWriter writer = new StreamWriter(path2))
            {

                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine("praca");
                }
            }
            /*using (StreamReader reader = new StreamReader(path2))
            {
                foreach (string line in reader.)
                {

                }
            }*/
            /*for (int i = 0; i < lines.Length; i++)
            {
                while (lines != null)
                {
                    StreamWriter writer = new StreamWriter(path2);
                    lines[i] = lines[i].Replace("praca", "job");
                    writer.WriteLine(path2, lines[i]);
                }
            }*/

            string text = File.ReadAllText(path2);
            text = text.Replace("praca", "job");
            var date = DateTime.Today;
            var date_no_hours = date.ToString("dd/MM/yyyy");
/*            var date_clear = date_no_hours.Replace(".", "");
*/

            var path2_roz = "task3"+ "_changed" + "-" + date_no_hours + ".txt";
            //date_clear give full date without hours and without dots between date
            //date_no_hours give full date withour hours with dots between
            File.WriteAllText(path2_roz, text);

            /*for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "praca")
                {
                    StreamWriter writer = new StreamWriter(path2);
                    lines[i].Replace("praca", "job");
                    writer.WriteLine(lines[i].Replace("praca", "job"));



                }
            }*/

            /*line.Replace("job", "praca2")*/
            

        }

        public static void Task5_Api(decimal amount)
        {
            WebRequest request = WebRequest.Create("https://www.floatrates.com/daily/pln.json");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string resposneFromServer = reader.ReadToEnd();

            var sRateBegin = "\"rate\":";
            var sRateEnd = ",";
            var sRate = resposneFromServer.Substring(resposneFromServer.IndexOf(sRateBegin) + sRateBegin.Length);
            sRate = sRate.Substring(0, sRate.IndexOf(sRateEnd));

            string decimalRate = sRate.Substring(0, 5);

            //0.23038377921767

            decimal ExchangeValue = decimal.Parse(decimalRate, System.Globalization.CultureInfo.InvariantCulture);

            var ExchangeValueMathRound = Math.Round(ExchangeValue, 2);

            /*Console.WriteLine("main string " + sRate);
            Console.WriteLine("short string " + decimalRate);

            Console.WriteLine("round string " + ExchangeValueMathRound);*/
            var ResulstsExchange = amount * ExchangeValueMathRound;
            var ResulstsExchangeRound = Math.Round(ResulstsExchange, 2);
            Console.WriteLine(amount + " PLN in USD are: " + ResulstsExchangeRound + " USD");
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public static void Task4()
        {
            var DateTimeWithHours = Convert.ToString(DateTime.Now);
            var path3 = "user_" + DateTimeWithHours +".csv";

            path3 = path3.Replace(" ", "");
            path3 = path3.Replace("-", "_");
            path3 = path3.Replace(":", "_");
            if (!File.Exists(path3))
            {
                var CreateFile = File.Create(path3);
                CreateFile.Close();
                Console.WriteLine("File was created.");

            }
            else
            {
                Console.WriteLine("File is existing");
            }
            using (StreamWriter writer = new StreamWriter(path3, false, Encoding.UTF8))
            {

                var lpCol = "LP";
                var nameCol = "Imię";
                var surCol = "Nazwisko";
                var birthCol = "Rok urodzenia";

                var line = String.Format("{0};{1};{2};{3}", lpCol, nameCol, surCol, birthCol);
                writer.WriteLine(line);

                int LP = 1;

                string[] Names = {"Ania", "Kasia", "Basia", "Zosia"};

                string[] Surnames = { "Kowalska", "Nowak"};



                Random rand = new Random();
                var DateBirth = rand.Next(1990, 2000);


                var RandNames = rand.Next(0, 3);
                var RandSurnames = rand.Next(0, 1);





                for (int i = 0; i < 100; i++)
                {
                    writer.WriteLine(String.Format("{0};{1};{2};{3}", LP++, Names[rand.Next(0,4)], Surnames[rand.Next(0,2)], rand.Next(1990,2001)));
                }
            }
        }
    }
}
