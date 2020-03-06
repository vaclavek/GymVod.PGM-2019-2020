using GymVod.Battleships.Common;
using System;

namespace Lode.Vaclavek.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var algoritmus = new SuperLodniAlgoritmus();
            var typyLodi = new ShipType[]
            {
                ShipType.Submarine,
                ShipType.Submarine,
                ShipType.Destroyer,
                ShipType.Destroyer,
                ShipType.Cruiser,
                ShipType.Cruiser,
                ShipType.Battleship,
                ShipType.Carrier,
            };
            
            var pozice = algoritmus.NewGame(new GameSettings(15, 15, typyLodi));

        }
    }
}
