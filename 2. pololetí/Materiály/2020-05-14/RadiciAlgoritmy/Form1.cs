using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9RadiciAlgoritmy
{
    /*
     1) Připravte winform aplikaci, která bude umět řadit číselné řady několika způsoby. Aplikace by měla mít následující funkce:
        a) pole pro zadání počtu čísel
        b) tlačítko, které vygeneruje daný počet (viz bod a) náhodných čísel a vypíše je uživateli
        c) pole, které uživateli umožní zadat čísla "ručně"
        d) tlačítko, které řadu seřadí a vypíše ji uživateli metodou BubbleSort
        e) tlačítko, které řadu seřadí a vypíše ji uživateli metodou SelectSort
        f) tlačítko, které řadu seřadí a vypíše ji uživateli metodou InsertSort
         
         */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butRndNumGen_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            for (int i = 0; i < nudRndNumCount.Value; i++)
                tbNumbers.Text += $"{rnd.Next(0, 256)} ";
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            if(cbAlgorithm.SelectedIndex == -1)
            {
                tbOutput.Text = "Musíte vybrat algoritmus.";
                return;
            }

            string[] numStr = tbNumbers.Text.Trim().Split(' ');
            List<int> numbers = new List<int>();

            foreach(string s in numStr)
            {
                int n;
                if (int.TryParse(s, out n))
                    numbers.Add(n);
                else
                {
                    tbOutput.Text = "Chyba konverze vstupu: zadávejte pouze čísla oddělená jednou mezerou";
                    return;
                }
            }

            

            switch(cbAlgorithm.SelectedIndex)
            {
                case 0:
                    WriteArray(BubbleSort(numbers.ToArray()));
                    break;
                case 1:
                    WriteArray(InsertSort(numbers.ToArray()));
                    break;
                case 2:
                    WriteArray(SelectSort(numbers.ToArray()));
                    break;
            }
        }

        private void WriteArray(int[] numbers)
        {
            tbOutput.Text = "";
            foreach (int n in numbers)
                tbOutput.Text += $"{n} ";
        }

        // Prochází se postupně prvky, porovnají se 2 vedle sebe. Jsou-li ve špatném pořadí (1. > 2.), prohodí se.
        private int[] BubbleSort(int[] unsorted)
        {
            int[] numbers = new int[unsorted.Length];
            unsorted.CopyTo(numbers, 0);

            for (int i = 0; i < numbers.Length-1; i++) 
            {
                for (int j = 1; j < numbers.Length-i; j++)
                {
                    if(numbers[j] < numbers[j-1])
                    {
                        int tmp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j - 1] = tmp;
                    }
                }
            }

            return numbers;
        }

        // První prvek označíme za sezařený. Vezmeme první nesezařený prvek a procházíme sezařené prvky, umístíme na správné místo
        // (procházíme od největších, prohazujeme, dokuď nejsme na správném místě). Tento prvek je nyní sezařený. Opakujeme pro další nesezařené prvky.
        private int[] InsertSort(int[] unsorted)
        {
            int[] numbers = new int[unsorted.Length];
            unsorted.CopyTo(numbers, 0);

            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        int tmp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j - 1] = tmp;
                    }
                    else
                        break;
                }
            }

            return numbers;
        }
        
        // První prvek označíme jako maximum. Procházíme zbytek neseřazených čísel a pokud narazíme na číslo, které je větší, označíme ho jako nové maximum. Poslední neseřazené číslo prohodíme s maximem.
        private int[] SelectSort(int[] unsorted)
        {
            int[] numbers = new int[unsorted.Length];
            unsorted.CopyTo(numbers, 0);

            for(int i = 0; i < numbers.Length; i++)
            {
                int max = numbers[0];
                int maxPos = 0;

                for (int j = 1; j < numbers.Length - i; j++)
                {
                    if (numbers[j] > max)
                    {
                        max = numbers[j];
                        maxPos = j;
                    }
                }

                int tmp = numbers[numbers.Length - i - 1];
                numbers[numbers.Length - i - 1] = max;
                numbers[maxPos] = tmp;
            }

            return numbers;
        }
    }
}
