using GymVod.Battleships.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linova_BattleShip //verze předtím, než se mi to vymazalo
{
    public class Class1 : GymVod.Battleships.Common.IBattleshipsGame
    {
        int delkaLode = 0;
        int i = 0; //Právě zapisující loď (souřadnice x, y)
        int j = 0; // Již zapsaná loď (souřadnice x, y)
        int x = 0;
        int y = 0;
        int orientation = 0; //náhodně generovaná orientace lodě
        Random rnd = new Random();

        public GymVod.Battleships.Common.ShipPosition[] NewGame(byte boardWidth, byte boardHeight, GymVod.Battleships.Common.ShipType[] shipTypes) //metoda
        {
            GymVod.Battleships.Common.ShipPosition[] vyslednePozice = new GymVod.Battleships.Common.ShipPosition[shipTypes.Length];
            for (i = 0; i < shipTypes.Length; i++)
            {
                delkaLode = (int)ShipType.shipTypes[i];
                bool hotovo = false;
                while (hotovo = false)
                {
                    orientation = rnd.Next(2);//generace orientace lodě
                    if (orientation == 1)
                    {
                        x = rnd.Next(boardWidth - 2) + 1;
                        y = rnd.Next(boardHeight - 2 - delkaLode) + 1;
                    }
                    else
                    {
                        x = rnd.Next(boardWidth - 2 - delkaLode) + 1;
                        y = rnd.Next(boardHeight - 2) + 1;
                    }
                    hotovo = true;
                    vyslednePozice[j] = vyslednePozice[i];
                }
                for (j = 0; j < i; j++)//kontrola
                {
                    if (x == vyslednePozice.Position.X && y == vyslednePozice.Position.Y)
                    {
                        break;
                    }
                    if (x >= vyslednePozice.Position.X - 1 && y == vyslednePozice.Position.Y)
                    {
                        break;
                    }
                    if (x >= vyslednePozice.Position.X + 1 && y == vyslednePozice.Position.Y)
                    {
                        break;
                    }
                    if (x <= vyslednePozice.Position.X && y == vyslednePozice.Position.Y)
                    {
                        break;
                    }
                    if (x >= vyslednePozice.Position.X && y == vyslednePozice.Position.Y)
                    {
                        break;
                    }
                    if (x == vyslednePozice.Position.X && y <= vyslednePozice.Position.Y)
                    {
                        break;
                    }
                    if (x == vyslednePozice.Position.X && y >= vyslednePozice.Position.Y)
                    {
                        break;
                    }
                    else
                    {
                        hotovo = false;
                        break;
                    }
                }
            }
        }

        public GymVod.Battleships.Common.Position GetNextShotPosition(byte boardWidth, byte boardHeight, GymVod.Battleships.Common.ShipType[] shipTypes)
        {
            GymVod.Battleships.Common.Position[] shotResult = new GymVod.Battleships.Common.Position[];
            for (k = 0; k < Position[]; k++)
            {
                x = rnd.Next(boardWidth + 1) - 2;
                y = rnd.Next(boardHeight + 1) - 2;
            }
            throw new Exception();
        }

        public void ShotResult(GymVod.Battleships.Common.Position position, bool hit, bool shipSunken)
        {
            public GymVod.Battleships.Common.Position
            {
                this.j.hit;
            }
                foreach(int shot in shotResult)
                {
                    if(hit == true)
                    {
                        Console.WriteLine("Zásah");
                        break;
                    }
                    if(shipSunken == true)
                    {
                        Console.WriteLine("Loď potopen");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bohužel nic");
                        delkaLode = (int) ShipType.shipTypes[i];

                                x = rnd.Next(boardWidth + 1) - 2;
                                y = rnd.Next(boardHeight + 1) - 2;
                            shotResult[i] = shotResult[j];
                        }
                    }
                }
            throw new Exception();
        }
    }
}
