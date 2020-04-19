using System;
using System.Collections.Generic;
using System.Linq;
using GymVod.Battleships.Common;

namespace Provaznik
{
    public class LodeAI : IBattleshipsGame
    {
        private Dictionary<Position, int> boardPriorities;
        private Dictionary<Position, BoardState> boardStates;
        private Dictionary<ShipType, int> shipCounts;
        byte h = 0;
        byte w = 0;
        int totalSunken = 0;
        int totalShips = 0;
        // variable to select which diagonals are prioritized, extensible for more heuristics
        int diagonalIncrement = 1;

        //shoot random field with greatest probability
        public Position GetNextShotPosition()
        {
            var random = new Random();
            int i = 0;
            var orderedPriorities = boardPriorities.ToList()
                                    .OrderBy(bp => bp.Value)
                                    .Reverse()
                                    .ToList();
            while (orderedPriorities[i].Value == orderedPriorities[0].Value)
            {
                i++;
                if (i >= orderedPriorities.Count)
                {
                    break;
                }
            }
            var generatedIndex = random.Next(0, i);
            var selected = orderedPriorities[generatedIndex].Key;
            return selected;
        }
        // isn't really general but usually close to optimal
        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            boardPriorities = new Dictionary<Position, int>();
            boardStates = new Dictionary<Position, BoardState>();
            shipCounts = new Dictionary<ShipType, int>();
            totalSunken = 0;
            var random = new Random();
            if (random.NextDouble() > 0.5)
                diagonalIncrement *= -1;
            foreach (ShipType st in Enum.GetValues(typeof(ShipType)))
            {
                shipCounts.Add(st, 0);
            }
            boardPriorities = new Dictionary<Position, int>();
            var ships = gameSettings.ShipTypes;
            h = gameSettings.BoardHeight;
            w = gameSettings.BoardWidth;
            totalShips = gameSettings.ShipTypes.Length;
            //initialize board states
            for (byte n = 0; n < w; n++)
            {
                for (byte m = 0; m < h; m++)
                {
                    var pos = new Position(n, m);
                    boardStates.Add(pos, BoardState.None);
                    boardPriorities.Add(pos, 0);
                    //ship cannot be on edge
                    if (n == 0 || m == 0 || n == w - 1 || m == h - 1)
                    {
                        boardStates[pos] = BoardState.Impossible;
                        boardPriorities[pos] = -10000;
                    }
                }
            }
            var shipsOut = new ShipPosition[totalShips];
            byte shipY = 1;
            byte shipX = 1;
            byte subX = (byte)(h - 2);
            byte subY = 2;
            subY += (byte)random.Next(0, 2);
            int i = 0;
            foreach (var ship in ships)
            {
                ShipPosition sp;
                shipCounts[ship]++;
                if (ship == ShipType.Submarine)
                {
                    sp = new ShipPosition(ship, new Position(subX, subY), Orientation.Right);

                    //so submarines are in different diagonals
                    subY += 3;
                    if (subY > h - 2)
                    {
                        subX -= 2;
                        subY = 2;
                    }
                }
                else
                {
                    sp = new ShipPosition(ship, new Position(shipX, shipY), Orientation.Right);
                    shipY += 2;
                    if (shipY > h - 2)
                    {
                        shipY = 1;
                        shipX += 6;
                    }
                }
                shipsOut[i] = sp;
                i++;
            }
            return shipsOut;
        }
        public void ShotResult(ShotResult shotResult)
        {
            if (shotResult.Hit && !shotResult.ShipSunken)
            {
                boardStates[shotResult.Position] = BoardState.Hit;
            }
            else if (!shotResult.Hit)
            {
                boardStates[shotResult.Position] = BoardState.Miss;
            }
            if (shotResult.ShipSunken)
            {
                Sink(shotResult.Position);
                totalSunken++;
            }
            Recalculate();
        }
        //recursively sinks neighboring fields
        private void Sink(Position pos)
        {
            boardStates[pos] = BoardState.Sunken;
            var x = pos.X;
            var y = pos.Y;
            var p1 = new Position((byte)(x + 1), (byte)(y));
            var p2 = new Position((byte)(x - 1), (byte)(y));
            var p3 = new Position((byte)(x), (byte)(y + 1));
            var p4 = new Position((byte)(x), (byte)(y - 1));
            if (boardStates[p1] == BoardState.Hit) { Sink(p1); }
            if (boardStates[p2] == BoardState.Hit) { Sink(p2); }
            if (boardStates[p3] == BoardState.Hit) { Sink(p3); }
            if (boardStates[p4] == BoardState.Hit) { Sink(p4); }

            // track submarines
            if (!(boardStates[p1] == BoardState.Sunken ||
                boardStates[p1] == BoardState.Sunken ||
                boardStates[p1] == BoardState.Sunken ||
                boardStates[p1] == BoardState.Sunken))
                shipCounts[ShipType.Submarine]--;

        }

        private void Recalculate()
        {
            // disqualifies fields based on their neighbors
            // a b c
            // d e f
            // g h i

            foreach (var field in boardStates.ToList())
            {
                //we don't care about hit or impossible fields
                if (!(field.Value == BoardState.None ||
                    field.Value == BoardState.Suspect))
                    continue;
                var x = field.Key.X;
                var y = field.Key.Y;
                var a = boardStates[new Position((byte)(x - 1), (byte)(y + 1))];
                var b = boardStates[new Position((byte)(x), (byte)(y + 1))];
                var c = boardStates[new Position((byte)(x + 1), (byte)(y + 1))];
                var d = boardStates[new Position((byte)(x - 1), (byte)(y))];
                var e = field.Value;
                var f = boardStates[new Position((byte)(x + 1), (byte)(y))];
                var g = boardStates[new Position((byte)(x - 1), (byte)(y - 1))];
                var h = boardStates[new Position((byte)(x), (byte)(y - 1))];
                var i = boardStates[new Position((byte)(x + 1), (byte)(y - 1))];
                // ships cant be direct neighbors
                if ((a == BoardState.Hit && b == BoardState.Hit) ||
                    (b == BoardState.Hit && c == BoardState.Hit) ||
                    (c == BoardState.Hit && f == BoardState.Hit) ||
                    (f == BoardState.Hit && i == BoardState.Hit) ||
                    (i == BoardState.Hit && h == BoardState.Hit) ||
                    (h == BoardState.Hit && g == BoardState.Hit) ||
                    (g == BoardState.Hit && d == BoardState.Hit) ||
                    (d == BoardState.Hit && a == BoardState.Hit) ||
                    (b == BoardState.Hit && f == BoardState.Hit) ||
                    (f == BoardState.Hit && h == BoardState.Hit) ||
                    (h == BoardState.Hit && d == BoardState.Hit) ||
                    (d == BoardState.Hit && b == BoardState.Hit))
                {
                    boardStates[field.Key] = BoardState.Impossible;
                }
                else if (b == BoardState.Sunken ||
                         f == BoardState.Sunken ||
                         h == BoardState.Sunken ||
                         d == BoardState.Sunken)
                {
                    boardStates[field.Key] = BoardState.Impossible;
                }
                // fields next to hit fields are suspicious
                else if (b == BoardState.Hit ||
                   f == BoardState.Hit ||
                   h == BoardState.Hit ||
                   d == BoardState.Hit)
                {
                    if (e == BoardState.None)
                    {
                        boardStates[field.Key] = BoardState.Suspect;
                    }
                }
            }
            //represent states numerically
            foreach (var field in boardStates.ToList())
            {
                if (field.Value == BoardState.Suspect)
                {
                    boardPriorities[field.Key] = 100;
                }
                else if (field.Value == BoardState.None)
                {
                    boardPriorities[field.Key] = 0;
                }
                else
                {
                    boardPriorities[field.Key] = -10000;
                }
            }
            //shooting diagonals until there are only submarines is better 
            if (shipCounts[ShipType.Submarine] == 0 || totalShips - totalSunken >= 3)
                incrementDiagonals(diagonalIncrement);

        }
        private void incrementDiagonals(int number)
        {
            foreach (var field in boardPriorities.ToList())
            {
                int x = field.Key.X;
                int y = field.Key.Y;
                if ((x + y) % 2 == 0)
                {
                    boardPriorities[field.Key] += number;
                }
            }
        }

    }

    public enum BoardState { None, Hit, Sunken, Miss, Suspect, Impossible }
}
