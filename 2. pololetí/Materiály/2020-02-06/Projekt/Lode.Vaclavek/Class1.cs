using GymVod.Battleships.Common;
using System;
using System.Collections.Generic;

namespace Lode.Vaclavek
{
    public class SuperLodniAlgoritmus : GymVod.Battleships.Common.IBattleshipsGame
    {
        public Position GetNextShotPosition()
        {
            throw new NotImplementedException();
        }

        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            ShipType[] typyLodi = gameSettings.ShipTypes;

            var list = new List<ShipPosition>();

            foreach (var typLode in typyLodi)
            {
                int delkaLode = (int)typLode;

                var pozice = new ShipPosition(typLode, new Position(3, 4), Orientation.Right);
                list.Add(pozice);
            }

            return list.ToArray();
        }

        public void ShotResult(ShotResult shotResult)
        {
            // shotResult.
        }
    }
}
