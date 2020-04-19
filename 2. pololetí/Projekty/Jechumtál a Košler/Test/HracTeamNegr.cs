﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymVod.Battleships.Common;

namespace Test
{
    public enum GameState
    {
        Seek,
        Destroy
    }
    public class HracTeamNegr : IBattleshipsGame
    {
        Random rnd = new Random();

        private GameState gameState = GameState.Seek;
        private Orientation orientation = Orientation.Right;

        private int height = 0, width = 0;

        private bool horizontal = true;
        private Position firstShot = null;

        private HashSet<Position> _misses = new HashSet<Position>();
        private HashSet<Position> _hits = new HashSet<Position>();

        private int _pocetPoli;
        private int _pocetExludovanych;
        private void Reset()
        {
            gameState = GameState.Seek;
            orientation = Orientation.Right;
            horizontal = true;
            firstShot = null;
            _misses.Clear();
            _hits.Clear();
            _pocetPoli = 0;
            _pocetExludovanych = 0;
        }
        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            Reset();
            height = gameSettings.BoardHeight;
            width = gameSettings.BoardWidth;
            _pocetExludovanych = 0; 
            foreach (var shipType in gameSettings.ShipTypes)
            {
                _pocetExludovanych += PocetPoliExludovani(shipType);
            }
            Debug.WriteLine("Exludované: " + _pocetExludovanych);

            _pocetPoli = ((width - 2) * (height - 2) / 2) - _pocetExludovanych;

            Debug.WriteLine("Možné pole šachovnice: " + _pocetPoli);

            var shipPositions = new List<ShipPosition>();

            ExludePositions(_misses, width, height);
            shipPositions.Add(new ShipPosition(ShipType.Submarine, new Position(1, 2), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Submarine, new Position(12, 8), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Destroyer, new Position(12, 4), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Destroyer, new Position(6, 1), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Cruiser, new Position(4, 5), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Cruiser, new Position(10, 1), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Battleship, new Position(8, 10), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Carrier, new Position(1, 12), Orientation.Right));
            return shipPositions.ToArray();
        }
        //probehne na startu
        private void ExludePositions(HashSet<Position> exlude, int width, int height)
        {
            for (int i = 0; i <= width; i++)
            {
                exlude.Add(new Position(0, (byte)i));
                exlude.Add(new Position((byte)(height - 1), (byte)i));
                exlude.Add(new Position((byte)i, 0));
                exlude.Add(new Position((byte)i, (byte)(width - 1)));
            }
        }
        private HashSet<Position> ExludeAdjancentPositionsToSunkenShip(HashSet<Position> hits, Orientation orientation)
        {
            int pocetPrvku = hits.Count;
            var positions = new HashSet<Position>();
            positions.UnionWith(hits);
            //pokud je lod 1 pole
            if (pocetPrvku == 1)
            {
                var pos = positions.First();
                hits.Add(new Position((byte)(pos.X + 1), (byte)(pos.Y)));
                hits.Add(new Position((byte)(pos.X - 1), (byte)(pos.Y)));
                hits.Add(new Position((byte)(pos.X), (byte)(pos.Y + 1)));
                hits.Add(new Position((byte)(pos.X), (byte)(pos.Y - 1)));
            }
            //horizontalni lod
            if (orientation == Orientation.Left || orientation == Orientation.Right)
            {
                byte minX = 0, maxX = 0;
                foreach (Position pos in positions)
                {
                    if (minX == 0 || minX > pos.X)
                    {
                        minX = pos.X;
                    }
                    if (maxX == 0 || maxX < pos.X)
                    {
                        maxX = pos.X;
                    }
                    //prida okolni policka u kazde X souradnice
                    hits.Add(new Position(pos.X, (byte)(pos.Y - 1)));
                    hits.Add(new Position(pos.X, (byte)(pos.Y + 1)));
                }
                //prida limitni policka lodi
                hits.Add(new Position((byte)(minX - 1), positions.First().Y));
                hits.Add(new Position((byte)(maxX + 1), positions.First().Y));
            }
            //vertikalni lod
            if (orientation == Orientation.Down || orientation == Orientation.Up)
            {
                byte minY = 0, maxY = 0;
                foreach (Position pos in positions)
                {
                    if (minY == 0 || minY > pos.Y)
                    {
                        minY = pos.Y;
                    }
                    if (maxY == 0 || maxY < pos.Y)
                    {
                        maxY = pos.Y;
                    }
                    //prida okolni policka u kazde Y souradnice
                    hits.Add(new Position((byte)(pos.X - 1), pos.Y));
                    hits.Add(new Position((byte)(pos.X + 1), pos.Y));
                }
                //prida limitni policka lodi
                hits.Add(new Position(positions.First().X, (byte)(minY - 1)));
                hits.Add(new Position(positions.First().X, (byte)(maxY + 1)));
            }
            return hits;
        }
        private int PocetPoliExludovani(ShipType lod)
        {
            int pocetPoli = 0;
                switch (lod)
                {
                    case ShipType.Submarine:
                        pocetPoli += 5;
                        break;
                    case ShipType.Destroyer:
                        pocetPoli += 8;
                        break;
                    case ShipType.Cruiser:
                        pocetPoli += 11;
                        break;
                    case ShipType.Battleship:
                        pocetPoli += 14;
                        break;
                    case ShipType.Carrier:
                        pocetPoli += 17;
                        break;
                }
            return pocetPoli;
        }
        public Position GetNextShotPosition()
        {
            if (gameState == GameState.Seek)
            {
                if (_pocetPoli != 0)
                {
                    _pocetPoli--;
                    Debug.WriteLine("V sachovnici zbyva {0} poli", _pocetPoli);
                    return GetRandomSachovnicePosition(_misses);
                }          
                else
                    return GetRandomPosition(_misses);
            }
            else
            {
                if (horizontal == true)
                {
                    return ModeDamageHorizontal(firstShot.X, firstShot.Y, _hits, _misses);
                }
                else
                {
                    return ModeDamageVertical(firstShot.X, firstShot.Y, _hits, _misses);
                }
            }  
        }
        int pocetTahu = 0;
        int pocetPotopenych = 0;
        public void ShotResult(ShotResult shotResult)
        {
            pocetTahu++;
            if (shotResult.Hit)
            {
                gameState = GameState.Destroy;
                _hits.Add(shotResult.Position);
                if (firstShot == null)
                {
                    firstShot = shotResult.Position;
                }
                if (shotResult.ShipSunken)
                {
                    pocetPotopenych++;   
                    Debug.WriteLine(orientation);
                    var debugHash = new HashSet<Position>();
                    var pocetPoliLodi = _hits.Count;
                    Debug.WriteLine("Počet polí lodi: {0}", pocetPoliLodi);
                    _misses.UnionWith(ExludeAdjancentPositionsToSunkenShip(_hits, orientation));
                    debugHash.UnionWith(_misses);
                    debugHash.IntersectWith(_hits);
                    foreach (Position vec in debugHash)
                    {
                        Debug.WriteLine("[{0}, {1}]", vec.X, vec.Y);

                    }
                    Debug.WriteLine("Počet exludovaných polí kolem: {0}", debugHash.Count - pocetPoliLodi);

                    _misses.UnionWith(_hits);//presune policka s trefenou lodi do misses
                    gameState = GameState.Seek;
                    horizontal = true;
                    firstShot = null; //Za předpokladu že tohle bude fungovat, by to mělo jít 
                    orientation = Orientation.Right;    
                    _hits.Clear(); //uvolni hits pro dalsi lod
                    if (pocetPotopenych == 6)
                    {
                        Debug.WriteLine("Pocet tahu na vetsinu: " + pocetTahu);
                    }
                    if (pocetPotopenych == 8)
                    {
                        Debug.WriteLine("Pocet tahu: " + pocetTahu);
                    }
                }
            }
            else
            {
                _misses.Add(shotResult.Position);
            }
        }
        private Position GetRandomPosition(HashSet<Position> used)
        {
            byte x = (byte)rnd.Next(1, width - 1);
            byte y = (byte)rnd.Next(1, height - 1);
            Position position = new Position(x, y);
            while (used.Contains(position))
            {
                x = (byte)rnd.Next(1, width - 1);
                y = (byte)rnd.Next(1, height - 1);
                position = new Position(x, y);
            }
            used.Add(position);
            return position;
        }
        private Position GetRandomSachovnicePosition(HashSet<Position> used)
        {
            byte x = (byte)rnd.Next(1, width - 1);
            byte y = (byte)rnd.Next(1, height - 1);
            if (x % 2 != 0)//suda
            {
                while (y % 2 != 0)//suda
                {
                    y = (byte)rnd.Next(1, height - 1);
                }
            }
            else
            {
                while (y % 2 != 1)//licha
                {
                    y = (byte)rnd.Next(1, height - 1);
                }
            }
            Position position = new Position(x, y);
            while (used.Contains(position))
            {
                x = (byte)rnd.Next(1, width - 1);
                y = (byte)rnd.Next(1, height - 1);
                if (x % 2 != 0)//suda
                {
                    while (y % 2 != 0)//suda
                    {
                        y = (byte)rnd.Next(1, height - 1);
                    }
                }
                else
                {
                    while (y % 2 != 1)//licha
                    {
                        y = (byte)rnd.Next(1, height - 1);
                    }
                }
                position = new Position(x, y);
            }
            used.Add(position);
            return position;
        }

        private Position ModeDamageHorizontal(byte x, byte y, HashSet<Position> hits, HashSet<Position> misses)
        {
            Position poleVpravo = new Position(x += 1, y);
            Position poleVlevo = new Position(x -= 2, y);

            if (orientation == Orientation.Right)
            {
                if (hits.Contains(poleVpravo))
                {
                    x += 2;
                    return ModeDamageHorizontal(x, y, hits, misses);
                }
                else if (misses.Contains(poleVpravo))
                {
                    orientation = Orientation.Left;
                    return ModeDamageHorizontal(firstShot.X, firstShot.Y, hits, misses);
                }
                else
                {
                    x += 2;
                    return new Position(x, y);
                }
            }
            else
            {
                if (hits.Contains(poleVlevo))
                {
                    return ModeDamageHorizontal(x, y, hits, misses);
                }
                else if (misses.Contains(poleVlevo))
                {
                    orientation = Orientation.Down;
                    horizontal = false;
                    return ModeDamageVertical(firstShot.X, firstShot.Y, hits, misses);
                }
                else
                {
                    return new Position(x, y);
                }
            }
        }
        private Position ModeDamageVertical(byte x, byte y, HashSet<Position> hits, HashSet<Position> misses)
        {
            Position poleDole = new Position(x, y += 1);
            Position poleNahore = new Position(x, y -= 2);

            if (orientation == Orientation.Down)
            {
                if (hits.Contains(poleDole))
                {
                    y += 2;
                    return ModeDamageVertical(x, y, hits, misses);
                }
                else if (misses.Contains(poleDole))
                {
                    orientation = Orientation.Up;
                    return ModeDamageVertical(firstShot.X, firstShot.Y, hits, misses);
                }
                else
                {
                    y += 2;
                    return new Position(x, y);
                }
            }
            else
            {
                if (hits.Contains(poleNahore))
                {
                    return ModeDamageVertical(x, y, hits, misses);
                }
                else
                {
                    return new Position(x, y);
                }
            }
        }
    }
}

