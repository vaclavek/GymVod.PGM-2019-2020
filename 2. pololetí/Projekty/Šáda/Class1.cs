using System;
using System.Collections.Generic;
using System.Linq;
using DumbLodiiis;
using GymVod.Battleships.Common;

namespace Sada
{
    public class LodeBot : IBattleshipsGame
    {
        private int _width;

        private int _height;

        private Random _rnd = new Random();

        private bool[,] _shotmap;

        private bool[,] _hitMap;

        private bool _searching;

        private List<Position> _shots = new List<Position>();

        private ShotResult _lastShot;
        private ShotResult _firstShotOfSeries;

        public Position GetNextShotPosition()
        {
            int y;
            int x;

            if (!_searching)
            {
                do
                {
                    y = this._rnd.Next(1, this._width - 1);
                    x = this._rnd.Next(1, this._height - 1);
                } while (_shotmap[x, y]);
            }
            else if (_shots.Count == 0) // end of ship but not sunken
            {
                if (_lastShot.Position.X > _firstShotOfSeries.Position.X)
                    (x, y) = (_firstShotOfSeries.Position.X - 1, _firstShotOfSeries.Position.Y);
                else if (_lastShot.Position.X < _firstShotOfSeries.Position.X)
                    (x, y) = (_firstShotOfSeries.Position.X + 1, _firstShotOfSeries.Position.Y);
                else if (_lastShot.Position.Y > _firstShotOfSeries.Position.Y)
                    (x, y) = (_firstShotOfSeries.Position.X, _firstShotOfSeries.Position.Y - 1);
                else // if (_lastShot.Position.Y < _firstShotOfSeries.Position.Y)
                    (x, y) = (_firstShotOfSeries.Position.X, _firstShotOfSeries.Position.Y + 1);
            }
            else // if its not null we hit and need to search
            {
                var pos = _shots[0];
                _shots.RemoveAt(0);

                (x, y) = (pos.X, pos.Y);
            }

            _shotmap[x, y] = true;

            return new Position((byte)x, (byte)y);
        }

        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            this._width = (int)gameSettings.BoardWidth;
            this._height = (int)gameSettings.BoardHeight;

            _shotmap = new bool[_width, _height];
            _hitMap = new bool[_width, _height];

            return BattlefieldMap.GenerateInitialShipPositions(gameSettings);
        }

        public void ShotResult(ShotResult shotResult)
        {
            if (shotResult.Hit)
            {
                _hitMap[shotResult.Position.X, shotResult.Position.Y] = true;

                // first hit -> generate all directions
                if (!_searching)
                {
                    _shots.AddRange(new[]{
                        new Position((byte)(shotResult.Position.X+1), shotResult.Position.Y),
                        new Position((byte)(shotResult.Position.X-1), shotResult.Position.Y),
                        new Position(shotResult.Position.X, (byte)(shotResult.Position.Y+1)),
                        new Position(shotResult.Position.X, (byte)(shotResult.Position.Y-1))
                    }.Where(pos => !_shotmap[pos.X, pos.Y])
                    );


                    _searching = true;
                    _firstShotOfSeries = shotResult;
                }
                else
                {
                    // use lastHit and current hit to determine next pos
                    _shots.Clear();

                    Position shot = null;

                    if (_lastShot.Position.X > shotResult.Position.X)
                        shot = new Position((byte)(shotResult.Position.X - 1), shotResult.Position.Y);
                    else if (_lastShot.Position.X < shotResult.Position.X)
                        shot = new Position((byte)(shotResult.Position.X + 1), shotResult.Position.Y);
                    else if (_lastShot.Position.Y > shotResult.Position.Y)
                        shot = new Position(shotResult.Position.X, (byte)(shotResult.Position.Y - 1));
                    else if (_lastShot.Position.Y < shotResult.Position.Y)
                        shot = new Position(shotResult.Position.X, (byte)(shotResult.Position.Y + 1));

                    if (!_shotmap[shot.X, shot.Y])
                        _shots.Add(shot); // if the shot is not added the middle case in getshotposition will run
                }

                _lastShot = shotResult;
            }

            if (shotResult.ShipSunken)
            {
                var (lowest, highest) = GetContnuousShip(shotResult.Position);

                if (lowest.X == highest.X) // liší se Y => vertikální
                {
                    for (int i = lowest.Y; i <= highest.Y; i++)
                    {
                        _shotmap[lowest.X + 1, i] = true;
                        _shotmap[lowest.X - 1, i] = true;
                        _shotmap[lowest.X, i + 1] = true;
                        _shotmap[lowest.X, i - 1] = true;
                    }
                }
                else
                {
                    for (int i = lowest.X; i <= highest.X; i++)
                    {
                        _shotmap[i + 1, lowest.Y] = true;
                        _shotmap[i - 1, lowest.Y] = true;
                        _shotmap[i, lowest.Y + 1] = true;
                        _shotmap[i, lowest.Y - 1] = true;
                    }
                }

                _searching = false;
                _shots.Clear();
                _lastShot = null;
            }
        }

        private (Position, Position) GetContnuousShip(Position pointInShip)
        {
            var (x, y) = (pointInShip.X, pointInShip.Y);

            byte lowestY = y, lowestX = x, highestY = y, highestX = x;

            while (true)
            {
                y--;

                if (!_hitMap[x, y])
                    break;
                else
                    lowestY = Math.Min(lowestY, y);
            }
            (x, y) = (pointInShip.X, pointInShip.Y);
            while (true)
            {
                y++;

                if (!_hitMap[x, y])
                    break;
                else
                    highestY = Math.Max(highestY, y);
            }
            (x, y) = (pointInShip.X, pointInShip.Y);
            while (true)
            {
                x--;

                if (!_hitMap[x, y])
                    break;
                else
                    lowestX = Math.Min(lowestX, x);
            }
            (x, y) = (pointInShip.X, pointInShip.Y);
            while (true)
            {
                x++;

                if (!_hitMap[x, y])
                    break;
                else
                    highestX = Math.Max(highestX, x);
            }

            return (new Position(lowestX, lowestY), new Position(highestX, highestY));
        }
    }
}
