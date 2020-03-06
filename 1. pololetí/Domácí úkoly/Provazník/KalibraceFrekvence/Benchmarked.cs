using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace KalibraceFrekvence
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    [RPlotExporter]
    public class Benchmarked
    {
        [Benchmark]
        public void Vaclavek()
        {
            var data = LoadData();
            var sum = Sum(data);
            var duplicate = GetDuplicte(data);
            // Console.WriteLine(sum);
            // Console.WriteLine(duplicate);
        }

        static string[] LoadData()
        {
            var text = System.IO.File.ReadAllText("data.txt");
            return text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }

        static int Sum(string[] data)
        {
            int sum = 0;
            foreach (var item in data)
            {
                bool plus = item[0] == '+';
                int number = Convert.ToInt32(item.Substring(1));
                if (plus)
                {
                    sum += number;
                }
                else
                {
                    sum -= number;
                }
            }
            return sum;
        }

        static int GetDuplicte(string[] data)
        {
            int sum = 0;
            var signs = new HashSet<int>();
            while (true)
            {
                foreach (var item in data)
                {
                    bool plus = item[0] == '+';
                    int number = Convert.ToInt32(item.Substring(1));
                    if (plus)
                    {
                        sum += number;
                    }
                    else
                    {
                        sum -= number;
                    }

                    if (signs.Contains(sum))
                    {
                        return sum;
                    }
                    else
                    {
                        signs.Add(sum);
                    }
                }
            }
        }


        [Benchmark]
        public void Provaznik()
        {
            StreamReader file;
            string line;
            //var path = "C:/Users/janpr/Downloads/kalibrace_frekvence_data.txt";
            var path = "data.txt";
            // hashset poskytuje dobrou prumernou casovou slozitost na pridani prvku a test zda je prvek pritomen Theta(1)
            System.Collections.Generic.HashSet<int> frequencies = new System.Collections.Generic.HashSet<int>();
            int currentFrequency = 0;
            int? doubleFrequency = null;
            try
            {
                file = new StreamReader(path); //neni nutne mit cely soubor v RAM 
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Soubor neexistuje.");
            }
            frequencies.Add(currentFrequency); //pocatecni frekvence se take muze zopakovat
            while ((line = file.ReadLine()) != null)
            {
                int change;
                if (!int.TryParse(line, out change))
                {
                    throw new Exception("Chyba ve vstupnim souboru.");
                }
                currentFrequency += change;
                if (doubleFrequency == null)
                {
                    if (frequencies.Contains(currentFrequency))
                    {
                        doubleFrequency = currentFrequency;
                    }
                    else
                    {
                        frequencies.Add(currentFrequency);
                    }
                }
            }
            if (doubleFrequency != null)
            {
                // Console.WriteLine($"Vysledna frekvence je {currentFrequency}, prvni frekvence ktera se zopakovala je {doubleFrequency}");
            }
            else
            {
                int fullLoop = currentFrequency;
                int[] frequenciesArray = new int[frequencies.Count];
                frequencies.CopyTo(frequenciesArray);
                int i = 1;
                while (doubleFrequency == null && i < 1000) // aby to nebezelo vecne (neprisel jsem na jednoznacnou podminku, ktera vyhodnoti nekonecny beh)
                {
                    foreach (var f in frequenciesArray)
                    {
                        if (f == 0) // vzorec nize nepocita s pocatecni frekvenci
                        {
                            continue;
                        }
                        int newFrequency = f + i * fullLoop; // kazda dosazena frekvence je zmenena o vysledek po cele kalibraci

                        if (frequencies.Contains(newFrequency))
                        {
                            doubleFrequency = newFrequency;
                            break;
                        }
                        else
                        {
                            frequencies.Add(newFrequency);
                        }

                    }
                    i++;
                }

                if (doubleFrequency != null)
                {
                    // Console.WriteLine($"Vysledna frekvence je {currentFrequency}, prvni frekvence ktera se zopakovala je {doubleFrequency}");
                }
                else
                {
                    // Console.WriteLine($"Vysledna frekvence je {currentFrequency}, zadna frekvence se nezopakuje (nebo to nelze spocitat v rozumnem case).");
                }

            }
        }

    }
}
