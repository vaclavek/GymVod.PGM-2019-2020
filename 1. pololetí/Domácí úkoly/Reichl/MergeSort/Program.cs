using System;

namespace MergeSort
{
    using System;


    class Sort
    {
        static void Main(string[] args)
        {
            /*string[] textIn = File.ReadAllLines(@"C:\Users\krtek\source\repos\FreqCalib\FreqCalib\data");
            int[] cisla = new int[textIn.Length];*/

            bool bezProblemu = true;

            /* for (int j = 0; j < textIn.Length; j++)
             {
                 bezProblemu &= int.TryParse(textIn[j], out cisla[j]);
             }*/

            Random rnd = new Random();

            int[] cisla = new int[rnd.Next(10, 26)];

            for (int i = 0; i < cisla.Length; i++)
                cisla[i] = rnd.Next(100);

            if (!bezProblemu)
                Console.WriteLine("Chyba - zadaná data nejsou pouze čísla");
            else
            {
                Console.WriteLine("Data:");
                foreach (int i in cisla)
                    Console.Write($"{i} ");
                Console.ReadLine();
                int[] ikdoip = CloneArray(cisla);
                //MergeSortRecursively(ikdoip);
                ikdoip = MergeSort(ikdoip);
                Console.WriteLine("Seřazená čísla:");
                foreach (int i in ikdoip)
                    Console.Write($"{i} ");
                Console.ReadLine();
                Array.Sort(cisla);
                Console.WriteLine("Čísla seřazená pomocí Array.Sort():");
                foreach (int i in cisla)
                    Console.Write($"{i} ");
            }

        }

        static void MergeSortRecursively(int[] a, int[] tmp, int positionStart, int sortRegionLength)
        {
            int sublistALength = (int)Math.Ceiling((double)sortRegionLength / 2);
            int sublistAPosition = positionStart;
            if (sublistALength > 1)
                MergeSortRecursively(a, tmp, sublistAPosition, sublistALength);

            int sublistBLength = sortRegionLength - sublistALength;
            int sublistBPosition = positionStart + sublistALength;
            if (sublistBLength > 1)
                MergeSortRecursively(a, tmp, sublistBPosition, sublistBLength);

            // je zde asi dvakrát tolik proměnných než by bylo třeba, ale usnadnilo mi to přepisování nerekurzivního kódu, aniž bych udělal chybu někde jinde

            int aEnd = sublistBPosition - 1;
            int bEnd = aEnd + sublistBLength;

            for (int i = positionStart; i < positionStart + sortRegionLength; i++)
            {
                if (sublistAPosition > aEnd)
                {
                    tmp[i] = a[sublistBPosition];
                    sublistBPosition++;
                }
                else if (sublistBPosition > bEnd)
                {
                    tmp[i] = a[sublistAPosition];
                    sublistAPosition++;
                }
                else
                {
                    if (a[sublistAPosition] <= a[sublistBPosition])
                    {
                        tmp[i] = a[sublistAPosition];
                        sublistAPosition++;
                    }
                    else
                    {
                        tmp[i] = a[sublistBPosition];
                        sublistBPosition++;
                    }
                }
            }

            Array.Copy(tmp, positionStart, a, positionStart, sortRegionLength);
        }

        static void MergeSortRecursively(int[] a)
        {
            MergeSortRecursively(a, new int[a.Length], 0, a.Length);
        }

        static int[] CloneArray(int[] array)
        {
            int[] a = new int[array.Length];
            Array.Copy(array, 0, a, 0, array.Length);
            return a;
        }

        // TOTO NEFUNGUJE - první pokus - bez rekurze, obsahuje ovšem chybu a vzhledem k tomu, že v něm jsou tři vnořené cykly, takže těžko říct, kde ta chyba je
        static int[] MergeSort(int[] array)
        {
            // pozn. - "skupinka" je část, na kterou rozdělíme pole, tyto skupinky pak navzájem porovnáváme
            int[] a = CloneArray(array); // vytvoření kopie vstupního pole


            int[] tmp = new int[a.Length]; // dočasné odkládací pole - protože nedůvěřuji garbage collectoru, nevytvářím v cyklu nová pole
            int indexA, indexB, maxIndexA, maxIndexB; // určuje "odkaď pokaď" se v poli nachází porovnávané oblasti

            for (int i = 0; Math.Pow(2, i) < a.Length; i++) // bude třídit skupinky po 2, 4, 8, ... - i^2 určuje velikost porovnávaných skupinek (vždy mezi sebou porovnáváme 2 skupinky o této velikosti)
            {
                double pwchk = Math.Pow(2, i);
                int pwchki = (int)pwchk;
                double pwchk2 = Math.Pow(2, i + 1);
                int pwchk2i = (int)pwchk2;
                for (int j = 0; j < a.Length; j += (int)Math.Pow(2, i + 1)) // prochází celé pole a "vybírá z něj" 2 skupinky dané velikosti; j je index 1. prvku
                {
                    indexA = j; // začátek 1. skupinky
                    indexB = j + (int)Math.Pow(2, i); // začátek 2. skupinky
                    if (indexB < a.Length) // je-li B mimo pole, jsou tyto 2 skupinky již setřízené
                    {
                        maxIndexA = indexB - 1; // mezi indexA a maxIndexA je přesně i^2 prvků
                        maxIndexB = maxIndexA + (int)Math.Pow(2, i);
                        if (maxIndexB >= a.Length) // pokud je mimo pole, nastav na poslední prvek pole
                            maxIndexB = a.Length - 1;

                        for (int k = j; k <= maxIndexB; k++)// samotné třízení - běží tak dlouho, dokud se obě skupinky neprojdou až do konce - j je začátek 1. skupinky, maxIndexB konec 2. skupinky
                        {
                            if (indexA > maxIndexA) // pokud už se prošla 1. skupinka, dokopírujeme 2. beze změny
                            {
                                tmp[k] = a[indexB];
                                indexB++;
                            }
                            else if (indexB > maxIndexB) // pokud už se prošla 2. skupinka, dokopírujeme 1. beze změny
                            {
                                tmp[k] = a[indexA];
                                indexA++;
                            }
                            else // normální chování - pokud ještě zbývají prvky v obou skupinkách
                            {
                                if (a[indexA] <= a[indexB]) // je-li číslo z první skupinky menší NEBO ROVNO - kvůli stabilitě
                                {
                                    tmp[k] = a[indexA];
                                    indexA++;
                                }
                                else
                                {
                                    tmp[k] = a[indexB];
                                    indexB++;
                                }
                            }
                        }

                        for (int l = j; l < maxIndexB; l++) // projde opět celý rozsah a nakopíruje ho do původního pole
                            a[l] = tmp[l];
                    }
                }
            }

            return a;
        }


    }
}
