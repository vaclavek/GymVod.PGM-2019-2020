using System;
using System.Collections.Generic;
using GymVod.Battleships.Common;

namespace Marek
{


    public class MojeImplementaceLode : IBattleshipsGame
    {
        private byte width;
        private byte height;
        private List<Position> nextShots;
        private List<Position> pastShots;

        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            width = gameSettings.BoardWidth;
            height = gameSettings.BoardHeight;
            nextShots = new List<Position>();
            pastShots = new List<Position>();
            List<ShipPosition> shipPositions = new List<ShipPosition>();

            shipPositions.Add(new ShipPosition(ShipType.Battleship, new Position(17, 13), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Carrier, new Position(7, 6), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Cruiser, new Position(9, 18), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Cruiser, new Position(4, 12), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Destroyer, new Position(11, 11), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Destroyer, new Position(17, 3), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Submarine, new Position(17, 8), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Submarine, new Position(5, 3), Orientation.Down));

            return shipPositions.ToArray();
        }
        public Position GetNextShotPosition()
        {
            while (nextShots.Count > 0)
            {
                Position p = nextShots[0];
                nextShots.RemoveAt(0);
                if (!pastShots.Contains(p))
                    return p;
            }
            byte x;
            byte y;
            while (true)
            {
                var rnd = new Random();
                x = (byte)rnd.Next(1, width - 1);
                y = (byte)rnd.Next(1, height - 1);
                if (!pastShots.Contains(new Position(x, y)))
                {
                    return new Position(x, y);
                }
            }

        }

        public void ShotResult(ShotResult shotResult)
        {
            Position pos = shotResult.Position;
            byte x = pos.X;
            byte y = pos.Y;
            pastShots.Add(pos);
            if ((shotResult.Hit) && !(shotResult.ShipSunken))
            {
                nextShots.Add(new Position((byte)(x + 1), y));
                nextShots.Add(new Position((byte)(x - 1), y));
                nextShots.Add(new Position(x, (byte)(y + 1)));
                nextShots.Add(new Position(x, (byte)(y - 1)));
            }
        }
    }

}