using System;
using System.Collections.Generic;
using System.Linq;
using GymVod.Battleships.Common;

namespace Reichl
{
    class Shooter
    {
        private BattlefieldMap _map;

        // private bool _waitingForResults = false; shouldn't be necessary if engine works how it should
        private (int x, int y) _lastShotAt;

        /* 0 = not assigned
         * 100...1 = normal priority
         * 1000 = potential location for ship tiles
         * -500 = tiles surrounding sunken ships
         * -1000 = shot at, water
         * -2000 = shot at, ship tile
         * -3000 = shot at, ship tile, ship sunken
         */
        // "heat map" of tiles - used to determine where to shoot next
        private Dictionary<(int x, int y), int> _heatMap = new Dictionary<(int x, int y), int>();

        private List<(int x, int y)> _currentShip = new List<(int x, int y)>();

        private RandomGaussian _rnd = new RandomGaussian();

        private bool _optimize, _haveAlreadyOptimizedLines = true;

        public Shooter(GameSettings gs, HeatMapGenerator hm, bool opt)
        {
            _map = new BattlefieldMap(gs);
            switch (hm)
            {
                case HeatMapGenerator.Conquer:
                    GenerateHeatMap();
                    break;
                case HeatMapGenerator.Grid:
                    GenerateGridHeatMap();
                    _haveAlreadyOptimizedLines = false;
                    break;
                case HeatMapGenerator.Random:
                    GenerateRandomHeatMap();
                    break;
            }
            _optimize = opt;
            // test
            OutputHeatMapToConsole();
        }

        // shoots at (random) tiles with highest score on the heatmap
        public Position Shoot()
        {
            int highestScore = 0;
            List<(int x, int y)> tiles = new List<(int, int)>();

            if (_optimize && (_map.ShipTypes.TrueForAll(s => s == ShipType.Submarine) || (_rnd.Next(10) % 10) == 1)) // 1 in 10 chance of breaking the pattern to enhance chances of randomly hitting single tile ships
            {
                foreach ((int x, int y) p in _heatMap.Keys)
                {
                    if (_heatMap[p] > 100 && _heatMap[p] > highestScore)
                    {
                        highestScore = _heatMap[p];
                        tiles.Clear();
                        tiles.Add(p);
                    }
                    else if (_heatMap[p] > 100 && _heatMap[p] == highestScore)
                        tiles.Add(p);
                    else if (Math.Ceiling(_heatMap[p] / 100.0) == 1 && highestScore <= 100) // (0; 100> - ignores heatmap score for normal priority tiles, when there is no ship in the progress of being destroyed
                        tiles.Add(p);
                }
            }
            else
            {
                foreach ((int x, int y) p in _heatMap.Keys)
                {
                    if (_heatMap[p] > highestScore)
                    {
                        highestScore = _heatMap[p];
                        tiles.Clear();
                    }

                    if (_heatMap[p] == highestScore)
                    {
                        for (int i = 0; i < ShootWeight(p); i++)
                            tiles.Add(p);
                    }
                }
            }

            try
            {
                _lastShotAt = tiles[_rnd.Next(0, tiles.Count)];
            }
            catch (System.ArgumentOutOfRangeException) // it threw this exception when all heatmap values were less than zero
            {
                Console.WriteLine("Nowhere else to shoot!");
            }
            return ConvertPositionForEngine(_lastShotAt);
        }

        private int ShootWeight((int x, int y) p) // weighted random number generation - punishes lazy approuch of putting ships in the upper left corner (or anywhere along the edge of the board)
        {
            if (DistanceToClosestEdge(p) < 3)
            {
                if (DistanceToEdge(Orientation.Left, p) < 2)
                    return 8;
                else
                    return 7;
            }
            else
                return 6;
        }

        public void ShotResult(ShotResult sr)
        {
            if (_currentShip.Count == 0 && !sr.ShipSunken)
            {
                if (sr.Hit) // New ship found!
                {
                    _heatMap[_lastShotAt] = -2000;
                    _currentShip.Add(_lastShotAt);
                    for (int i = 0; i < 4; i++)
                    {
                        // marks surrounding tiles as potential locations for ship tiles
                        AssignHeatMapValue(GetPositionRelativeTo(_lastShotAt, (Orientation)i, 1), 1000);
                    }
                }
                else
                    _heatMap[_lastShotAt] = -1000;
            }
            else if (_currentShip.Count >= /*==*/ 1 && !sr.ShipSunken)
            {
                if (sr.Hit)
                {
                    _heatMap[_lastShotAt] = -2000;
                    var orientation = GetPositionOfShipRelativeToShot(_lastShotAt); // orientation of ship
                    /*
                    _currentShip.Add(_lastShotAt);

                    // mark the tile away from the first ship tile as possible ship tile
                    var ot = GetPositionRelativeTo(_lastShotAt, InverseOrientation(p), 1);
                    if (!IsOutside(ot))
                        _heatMap[ot] = 1000;
                        */

                    _currentShip.Add(_lastShotAt);

                    //Console.WriteLine($"{_lastShotAt.x} {_lastShotAt.y} {orientation}");

                    // mark the tiles surrounding the long sides of the ship as "not ship" and, if not already shot at, mark the tiles next to first and last tile as potential ship tiles
                    foreach (var tile in _currentShip)
                    {
                        AssignHeatMapValue(GetPositionRelativeTo(tile, (Orientation)(((int)orientation + 2) % 4), 1), -500, -1000);

                        AssignHeatMapValue(GetPositionRelativeTo(tile, InverseOrientation((Orientation)(((int)orientation + 2) % 4)), 1), -500, -1000);

                        // now searching for potential tiles
                        AssignHeatMapValue(GetPositionRelativeTo(tile, orientation, 1), 1000, -500);

                        AssignHeatMapValue(GetPositionRelativeTo(tile, InverseOrientation(orientation), 1), 1000, -500);

                        //Console.WriteLine($"x {tile.x} {tile.y}");
                    }
                }
                else
                    _heatMap[_lastShotAt] = -1000;
            }
            else if (sr.ShipSunken)
            {
                _currentShip.Add(_lastShotAt);
                foreach (var tile in _currentShip)
                {
                    for (int i = 0; i < 4; i++)
                        AssignHeatMapValue(GetPositionRelativeTo(tile, (Orientation)i, 1), -500, -1000);
                    // marks all surrounding tiles that aren't ship - ships can't be touching, we don't need to shoot there (together with grid pattern it should save quite a bit of time)
                    _heatMap[tile] = -3000; // marks tile as sunken ship
                }

                int size = _currentShip.Count;
                try
                {
                    _map.ShipTypes.Remove(_map.ShipTypes.Find(x => x == (ShipType)size));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not remove ship of size {size} from shiptypes:\n{e.Message}");
                }
                _currentShip.Clear(); // next, please!
            }
            /*else
            {
                if (sr.Hit)
                {
                    var next = GetPositionRelativeTo(_lastShotAt, InverseOrientation(GetPositionOfShipRelativeToShot(_lastShotAt)), 1);
                    if (!IsOutside(next))
                        _heatMap[next] = 1000;
                    _heatMap[_lastShotAt] = -2000;
                    _currentShip.Add(_lastShotAt);

                    var o = (Orientation)(((int)GetPositionOfShipRelativeToShot(_lastShotAt) + 2) % 4); // gets orientation perpendicular to the orientation of ship
                    var st = GetPositionRelativeTo(_lastShotAt, o, 1);
                    if (!IsOutside(st))
                        if (_heatMap[st] > -1000)
                            _heatMap[st] = -500;

                    o = InverseOrientation(o); // also on the other side
                    st = GetPositionRelativeTo(_lastShotAt, o, 1);
                    if (!IsOutside(st))
                        if (_heatMap[st] > -1000)
                            _heatMap[st] = -500;
                }
                else
                    _heatMap[_lastShotAt] = -1000;
            }*/

            // test
            //OutputHeatMapToConsole();

            /*Console.WriteLine();
            Console.WriteLine($"{_lastShotAt.x} {_lastShotAt.y}");
            foreach (var c in _currentShip)
                Console.Write($"{c.x} {c.y},");
            Console.WriteLine();*/


            if (_optimize && !_haveAlreadyOptimizedLines && !(_map.ShipTypes.Contains((ShipType)4) || _map.ShipTypes.Contains((ShipType)5))) // dirty hack to switch from "diagonal lines" to "pure grid" when there are no ships > 3 left
            {
                var keys = _heatMap.Keys.Where(x => _heatMap[x] == 100).ToArray();
                foreach (var key in keys)
                    _heatMap[key] = 90;
                _haveAlreadyOptimizedLines = true;
            }


        }

        // down = ship is below the shot position, left = ship is to the left of the shot, ...
        private Orientation GetPositionOfShipRelativeToShot((int x, int y) coords)
        {
            foreach (var tile in _currentShip)
                if (Distance(tile, coords) == 1)
                {
                    if (coords.x == tile.x - 1)
                        return Orientation.Right;
                    else if (coords.x == tile.x + 1)
                        return Orientation.Left;
                    else if (coords.y == tile.y - 1)
                        return Orientation.Down;
                    else //if (coords.Item2 == tile.Item2 + 1)
                        return Orientation.Up;
                }
            Console.WriteLine("Something bad happened at S.GPOSRTS");
            // somebody probably passed shot position that was not next to the ship!
            Console.WriteLine($"Shot: {coords.x} {coords.y}");
            foreach (var tile in _currentShip)
            {
                Console.WriteLine($"Ship tile: {tile.x} {tile.y}");
            }
            return Orientation.Down;
        }

        private int DistanceToClosestEdge((int x, int y) coords)
        {
            int dist = int.MaxValue; // needed some big number, just shows how lazy I am
            for (int i = 0; i < 4; i++)
                if (dist < DistanceToEdge((Orientation)i, coords))
                    dist = DistanceToEdge((Orientation)i, coords);
            return dist; // if everything works according to plan, I should never see int.MaxValue at the output
        }

        // up = upper edge, left = left edge...
        private int DistanceToEdge(Orientation edge, (int x, int y) coords)
        {
            if (edge == Orientation.Left)
                return coords.x;
            else if (edge == Orientation.Right)
                return _map.Width - 1 - coords.x;
            else if (edge == Orientation.Up)
                return coords.y;
            else //if (edge == Orientation.Down)
                return _map.Height - 1 - coords.y;
        }

        private void AssignHeatMapValue((int x, int y) pos, int val, int ifGreaterThan = int.MinValue)
        {
            if (!IsOutside(pos))
                if (_heatMap[pos] > ifGreaterThan)
                    _heatMap[pos] = val;
            //Console.WriteLine($"{pos.x } {pos.y} {val}");
        }

        public static double Distance((int x, int y) coord1, (int x, int y) coord2) => Math.Sqrt(Math.Pow(coord1.x - coord2.x, 2) + Math.Pow(coord1.y - coord2.y, 2));

        private (int, int) GetPositionRelativeTo((int x, int y) coords, Orientation dir, int dist)
        {
            switch (dir)
            {
                case Orientation.Left:
                    return (coords.x - dist, coords.y);
                case Orientation.Right:
                    return (coords.x + dist, coords.y);
                case Orientation.Up:
                    return (coords.x, coords.y - dist);
                case Orientation.Down:
                    return (coords.x, coords.y + dist);
                default: // this should never happen
                    Console.WriteLine("Something bad happened at S.GPRT");
                    return coords;
            }
        }

        // is tile outside the gameboard?
        private bool IsOutside((int x, int y) coords) => (coords.x < 0) || (coords.y < 0) || (coords.x >= _map.Width) || (coords.y >= _map.Height);

        public static Orientation InverseOrientation(Orientation o)
        {
            if ((int)o % 2 == 0)
                return (Orientation)(o + 1);
            else
                return (Orientation)(o - 1);
        }

        // heatmap is used to decide where to shoot
        // not sure if it is better than random shooting, but the algorithm shoots in a pattern
        // btw. now I'm quite sure that this patten < random < grid pattern (with a tweak) :)
        private void GenerateHeatMap()
        {
            for (int x = 0; x < _map.Width; x++)
                for (int y = 0; y < _map.Height; y++)
                    _heatMap[(x, y)] = 0;


            // compatible with rectangular gameboards (just trims the edge)
            int size = Math.Max(_map.Height, _map.Width) + 1;

            (int x, int y)[,] centres = new (int, int)[1, 1], tmp;
            centres[0, 0] = (size / 2, size / 2);
            _heatMap[centres[0, 0]] = 100;
            for (int i = 3; i <= 2 * size; i += i + 1)
            {
                tmp = centres;
                centres = new (int x, int y)[i, i];
                for (int x = 0; x < i; x++)
                    for (int y = 0; y < i; y++)
                    {
                        // determines value of x
                        if (x % 2 == 1)
                            centres[x, y].x = tmp[(x - 1) / 2, 0].x;
                        else
                        {
                            if (x == 0)
                                centres[x, y].x = tmp[0, 0].x / 2;
                            else if (x == i - 1)
                                centres[x, y].x = (size - 1 + tmp[tmp.GetLength(0) - 1, 0].x) / 2;
                            else
                                centres[x, y].x = (tmp[x / 2, 0].x + tmp[x / 2 - 1, 0].x) / 2;
                        }

                        // determines value of y
                        if (y % 2 == 1)
                            centres[x, y].y = tmp[0, (y - 1) / 2].y;
                        else
                        {
                            if (y == 0)
                                centres[x, y].y = tmp[0, 0].y / 2;
                            else if (y == i - 1)
                                centres[x, y].y = (size - 1 + tmp[0, tmp.GetLength(1) - 1].y) / 2;
                            else
                                centres[x, y].y = (tmp[0, y / 2].y + tmp[0, y / 2 - 1].y) / 2;
                        }

                        // assigns heatmap value
                        if (centres[x, y].x >= 0 && centres[x, y].x < _map.Width && centres[x, y].y >= 0 && centres[x, y].y < _map.Height)
                            if (_heatMap[centres[x, y]] == 0)
                                _heatMap[centres[x, y]] = 100 - i;
                    }
            }

        }

        // RANDOM!!
        private void GenerateRandomHeatMap()
        {
            for (int x = 0; x < _map.Width; x++)
                for (int y = 0; y < _map.Height; y++)
                    _heatMap[(x, y)] = _rnd.Next(50, 100);
        }

        // this should be the most efficient, I hope
        private void GenerateGridHeatMap()
        {
            int offset = _rnd.Next(4); // brings in a necessary aspect of RANDOMness
            for (int x = 0; x < _map.Width; x++)
                for (int y = 0; y < _map.Height; y++)
                {
                    if ((x + (y + offset) % 4) % 2 == 0)
                    {
                        if ((x + (y + offset) % 4) % 4 == 0)
                            _heatMap[(x, y)] = 100;
                        else
                            _heatMap[(x, y)] = 90;
                    }
                    else
                        _heatMap[(x, y)] = 80;

                }
        }

        // internally working with int tuplets and gameboard trimmed of edge - convert for engine
        private Position ConvertPositionForEngine((int x, int y) p) => new Position((byte)(p.x + 1), (byte)(p.y + 1));

        // TEST CODE
        private void OutputHeatMapToConsole()
        {
            int[,] h = new int[_map.Width, _map.Height];
            foreach (var k in _heatMap.Keys)
            {
                h[k.x, k.y] = _heatMap[k];
            }
            for (int y = 0; y < h.GetLength(1); y++)
            {
                for (int x = 0; x < h.GetLength(0); x++)
                    Console.Write($"{h[x, y]}\t");
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}
