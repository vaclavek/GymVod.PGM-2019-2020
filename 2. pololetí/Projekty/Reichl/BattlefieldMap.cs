using GymVod.Battleships.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GymVod.Battleships.Services.GameServer;

namespace Reichl
{
    class BattlefieldMap
    {
        // had more plans for this, but didn't need it that much at the end.

        public int Width { get; }
        public int Height { get; }
        public List<ShipPosition> Ships { get; }
        public List<ShipType> ShipTypes { get; }


        public BattlefieldMap(GameSettings gs)
        {
            Width = gs.BoardWidth - 2;
            Height = gs.BoardHeight - 2;
            ShipTypes = gs.ShipTypes.OrderByDescending(a => a).ToList(); // placing goes from largest ship to smallest to reduce overlaping issues on small gameboards
            Ships = new List<ShipPosition>();
        }

        public ShipPosition[] ConvertShipPositionsForEngine()
        {
            // internally, boarder tiles are ignored - convert to format used by game engine
            ShipPosition[] s = new ShipPosition[Ships.Count];
            for (int i = 0; i < s.Length; i++)
                s[i] = new ShipPosition(Ships[i].ShipType, new Position((byte)(Ships[i].Position.X + 1), (byte)(Ships[i].Position.Y + 1)), Ships[i].Orientation);
            return s;
        }

        // randomly places ships according to rules
        public static ShipPosition[] GenerateInitialShipPositions(GameSettings gs)
        {
            BattlefieldMap map = new BattlefieldMap(gs);
            Random rnd = new Random();

            /*
            // "anti grid pattern" hack
            // it didn't really work when we had single tile ships generated first - ommited, implemented correctly in the "big brain" generator
            var singles = map.ShipTypes.FindAll(x => x == ShipType.Submarine);
            map.ShipTypes.RemoveAll(x => x == ShipType.Submarine);
            Console.WriteLine("a");
            int a = (rnd.Next(2) == 1) ? (int)Math.Floor(singles.Count / 2.0) : (int)Math.Ceiling(singles.Count / 2.0); // in case there is odd number of single tile ships, we won't have bias for either odd or even tiles
            Console.WriteLine($"b {a}");
            for (int i = 0; i < a; i++)
                map.Ships.Add(new ShipPosition(ShipType.Submarine, new Position((byte)(2 * rnd.Next(0, (int)Math.Floor(map.Width / 2.0)) + 1), (byte)(2 * rnd.Next(0, (int)Math.Floor(map.Height / 2.0)) + 1)), Orientation.Down));
            Console.WriteLine("c");
            for (int i = 0; i < singles.Count - a; i++)
                map.Ships.Add(new ShipPosition(ShipType.Submarine, new Position((byte)(2 * rnd.Next(0, (int)Math.Floor(map.Width / 2.0))), (byte)(2 * rnd.Next(0, (int)Math.Floor(map.Height / 2.0)))), Orientation.Down));
            Console.WriteLine("d");
            */
            bool success;

            /*
            foreach (var s in map.ShipTypes)
                Console.Write("O");
            foreach (var s in map.Ships)
                Console.Write("S");
                */
            foreach (var ship in map.ShipTypes)
            {
                do
                {
                    map.Ships.Add(new ShipPosition(ship, new Position((byte)rnd.Next(0, map.Width), (byte)rnd.Next(0, map.Height)), (Orientation)rnd.Next(0, 4)));
                    success = PlacingSuccessful(map);
                    if (!success)
                        map.Ships.RemoveAt(map.Ships.Count - 1);
                } while (!success);
                //Console.WriteLine("e");
            }
            return map.ConvertShipPositionsForEngine();
        }

        public static ShipPosition[] GenerateInitialShipPositionsBigBrain(GameSettings gs)
        {
            // expects big brain move from other players - looking for ships more frequently on the edge or in the centre - punishes this approach by placing ships "in between" the edge and the centre
            // using random gaussian generator: https://stackoverflow.com/questions/218060/random-gaussian-variables
            BattlefieldMap map = new BattlefieldMap(gs);

            RandomGaussian rnd = new RandomGaussian();

            bool lastSingleShipPlacement = rnd.NextBool(); // when there is odd count of single tile ships, we don't want to have equal change to select odd or even tiles

            foreach(var ship in map.ShipTypes)
            {
                bool success = false;
                do
                {
                    Position p = new Position(1, 1);
                    if ((int)ship == 1)
                    {
                        // anti grid pattern hack - when someone uses grid (as I do), it makes it harder for them by placing 1/2 of the ships on the odd and 1/2 on the even tiles
                        lastSingleShipPlacement = !lastSingleShipPlacement;
                        do
                        {
                            p = rnd.NextPosition(map.Width, map.Height);
                        } while (((p.X + p.Y) % 2 == 0) ^ lastSingleShipPlacement); // this just works, don't ask me how
                    }
                    else
                        p = rnd.NextPosition(map.Width, map.Height);
                    map.Ships.Add(new ShipPosition(ship, p, (Orientation)rnd.Next(0, 4)));
                    success = PlacingSuccessful(map);
                    if (!success)
                        map.Ships.RemoveAt(map.Ships.Count - 1);
                } while (!success);
            }

            return map.ConvertShipPositionsForEngine();
        }


        // tests if placed ships don't violate rules
        private static bool PlacingSuccessful(BattlefieldMap map)
        {
            var gb = new Gameboard((byte)map.Width, (byte)map.Height);
            try
            {
                gb.PlaceShips(map.ConvertShipPositionsForEngine());
            }
            catch (GameOverException)
            {
                return false;
            }
            return true;
        }

    }

    public class RandomGaussian : Random
    {
         public bool NextBool() => Next(0, 2) == 0; // not really anything to do with gaussian random, but useful none the less :)

        public Position NextPosition(int width, int height)
        {
            // this generates positions in a "ring" between center and edge - which are the more probable positions humans and possibly some "robots" would shoot at

            // divides map into "quadrants" - uses gaussian function, but we don't want to have most of the ships in the centre
            // decides if we sh
            bool xLow = NextBool();
            bool yLow = NextBool();

            // to form a ring, we don't really use these quarters, more like 4 possible halves - 2 vertical and 2 horizontal (if that makes sense) - this decides orientation
            bool xSplit = NextBool();

            double xG, yG;
            do
                xG = NextGaussian(0.5, 0.25);
            while (xG < 0 || xG > 1);

            do
                yG = NextGaussian(0.5, 0.25);
            while (yG < 0 || yG > 1);

            int x = (int)Math.Round(xG * width / (xSplit ? 2 : 1));
            int y = (int)Math.Round(yG * height / (!xSplit ? 2 : 1));

            if (xLow && xSplit)
                x += width / 2;
            if (yLow && !xSplit)
                y += height / 2;
            return new Position((byte)(x + 1), (byte)(y + 1));
        }

        public double NextGaussian(double mean, double stdDev)
        {
            double u1 = 1.0 - NextDouble(); // uniform(0,1] random doubles
            double u2 = 1.0 - NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // random normal(0,1)
            double randNormal = mean + stdDev * randStdNormal; // random normal(mean,stdDev^2)
            return randNormal;
        }
    }
}
