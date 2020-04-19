using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GymVod.Battleships.Common;

namespace RadikovaskaJarrahova
{
    public class EliAVercaImplementace : IBattleshipsGame
    {
        private byte sirka;
        private byte vyska;
        private static Random rnd = new Random();
        // private System.Security.Cryptography.RandomNumberGenerator gen = System.Security.Cryptography.RandomNumberGenerator.Create();
        private List<Position> vystrely = new List<Position>();
        private ShotResult lastResult;
        private bool inShip = false;
        private bool tryUp;
        private bool tryDown;
        private bool tryRight;
        private bool tryLeft;
        private byte indexUp;
        private byte indexDown;
        private byte indexRight;
        private byte indexLeft;
        private Position firstPosition;
        private int potopenych;
        private int vytvorenych;
        private bool zobrazitVystrely;

        public Position GetNextShotPosition()
        {
            // první tah
            if (lastResult == null)
            {
                return NextRandomPosition();
            }

            // netrefili
            if (!lastResult.Hit)
            {
                if (inShip)
                {
                    return NextShipPosition();
                }
                return NextRandomPosition();
            }

            // je potopena
            if (lastResult.ShipSunken)
            {
                // ZobrazitVystrely();

                // strelim kolem zasahu
                StrilejKolem(lastResult.Position.X, lastResult.Position.Y);

                // pokud to melo vic nez jednu kosticku
                if (inShip)
                {
                    for (byte i = 0; i < indexDown; i++)
                    {
                        StrilejKolem(firstPosition.X, (byte)(firstPosition.Y + i));
                    }
                    for (byte i = 0; i < indexRight; i++)
                    {
                        StrilejKolem((byte)(firstPosition.X + i), firstPosition.Y);
                    }
                    for (byte i = 0; i < indexLeft; i++)
                    {
                        StrilejKolem((byte)(firstPosition.X - i), firstPosition.Y);
                    }
                    for (byte i = 0; i < indexUp; i++)
                    {
                        StrilejKolem(firstPosition.X, (byte)(firstPosition.Y - i));
                    }
                }

                // ZobrazitVystrely();
                inShip = false;
                return NextRandomPosition();
            }

            // střílíme kolem
            return NextShipPosition();
        }

        // střelba kolem lodi
        public Position NextShipPosition()
        {
            if (!inShip)
            {
                // TODO vynulovat
                tryDown = true;
                tryLeft = true;
                tryUp = true;
                tryRight = true;
                indexDown = 0;
                indexLeft = 0;
                indexRight = 0;
                indexUp = 0;
                firstPosition = lastResult.Position;
            }

            inShip = true;
            Position position;
            if (tryDown)
            {
                if (!lastResult.Hit)
                {
                    tryDown = false;
                }
                else
                {
                    if (indexDown > 0)
                    {
                        tryLeft = false;
                        tryRight = false;
                    }
                    indexDown++;
                    position = new Position(firstPosition.X, (byte)(firstPosition.Y + indexDown));
                    PridatVystrel(position);
                    return position;
                }
            }

            if (tryRight)
            {
                if (!lastResult.Hit && indexRight > 0)
                {
                    tryRight = false;
                }
                else
                {
                    if (indexRight > 0)
                    {
                        tryUp = false;
                    }
                    indexRight++;
                    position = new Position((byte)(firstPosition.X + indexRight), firstPosition.Y);
                    PridatVystrel(position);
                    return position;
                }
            }
            if (tryUp)
            {
                if (!lastResult.Hit && indexUp > 0)
                {
                    tryUp = false;
                }
                else
                {
                    indexUp++;
                    position = new Position(firstPosition.X, (byte)(firstPosition.Y - indexUp));
                    PridatVystrel(position);
                    return position;
                }
            }
            if (tryLeft)
            {
                if (!lastResult.Hit && indexLeft > 0)
                {
                    tryLeft = false;
                }
                else
                {
                    indexLeft++;
                    position = new Position((byte)(firstPosition.X - indexLeft), firstPosition.Y);
                    PridatVystrel(position);
                    return position;
                }
            }
            throw new NotImplementedException();
        }

        public void StrilejKolem(byte x, byte y)
        {
            PridatVystrel(new Position(x, (byte)(y - 1)));
            PridatVystrel(new Position(x, (byte)(y + 1)));
            PridatVystrel(new Position((byte)(x - 1), y));
            PridatVystrel(new Position((byte)(x + 1), y));
        }

        public bool JeVeVystrelech(Position position)
        {
            bool nalezeno = false;
            foreach (var p in vystrely)
            {
                if (p.X == position.X && p.Y == position.Y)
                {
                    nalezeno = true;
                    break;
                }
            }

            return nalezeno;
        }

        public void PridatVystrel(Position position)
        {
            if (!JeVeVystrelech(position))
            {
                vystrely.Add(position);
            }
        }

        public void ZobrazitVystrely()
        {
            System.Diagnostics.Debug.WriteLine("");
            for (byte y = 0; y < vyska; y++)
            {
                string radek = "";

                for (byte x = 0; x < sirka; x++)
                {
                    if (JeVeVystrelech(new Position(x, y)))
                    {
                        radek += "X";
                    }
                    else
                    {
                        radek += "O";
                    }
                }

                System.Diagnostics.Debug.WriteLine(radek);
            }
            System.Diagnostics.Debug.WriteLine("");
        }

        public Position NextRandomPosition()
        {
            int i1 = 0;

            while (true)
            {
                var x = (byte)rnd.Next(1, sirka - 1);
                var y = (byte)rnd.Next(1, vyska - 1);
                var position = new Position(x, y);

                bool nalezeno = JeVeVystrelech(position);

                i1++;

                if (!nalezeno)
                {
                    PridatVystrel(position);

                    // System.Diagnostics.Debug.WriteLine($"NextRandom vystely.count:{vystrely.Count} iteraci:{i1}");

                    return position;
                }

                // je to nejak moc iteraci
                if (i1 > 10000)
                {
                    System.Diagnostics.Debug.WriteLine($"NextRandom moc iteraci, vystely.count:{vystrely.Count}");
                    if (zobrazitVystrely)
                    {
                        ZobrazitVystrely();
                        zobrazitVystrely = false;
                    }
                    return position;
                }

            }

        }
        public void ShotResult(ShotResult shotResult)
        {
            lastResult = shotResult;

            if (shotResult.Hit)
            {
                if (shotResult.ShipSunken)
                {
                    potopenych++;
                    System.Diagnostics.Debug.WriteLine($"Potopena({potopenych}/{vytvorenych}): {shotResult.Position.X} {shotResult.Position.Y}");
                    // ZobrazitVystrely();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Zasah: {shotResult.Position.X} {shotResult.Position.Y}");
                }
            }
        }

        public bool LodeKoliduji(ShipPosition lod1, ShipPosition lod2)
        {
            int l1p1x = lod1.Position.X - 1;
            int l1p1y = lod1.Position.Y - 1;
            int l2p1x = lod2.Position.X - 1;
            int l2p1y = lod2.Position.Y - 1;
            int l1p2x;
            int l1p2y;
            int l2p2x;
            int l2p2y;
            if (lod1.Orientation == Orientation.Right)
            {
                l1p2x = l1p1x + 1 + (int)lod1.ShipType;
                l1p2y = l1p1y + 2;
            }
            else
            {
                l1p2x = l1p1x + 2;
                l1p2y = l1p1y + 1 + (int)lod1.ShipType;
            }
            if (lod2.Orientation == Orientation.Right)
            {
                l2p2x = l2p1x + 1 + (int)lod2.ShipType;
                l2p2y = l2p1y + 2;
            }
            else
            {
                l2p2x = l2p1x + 2;
                l2p2y = l2p1y + 1 + (int)lod2.ShipType;
            }

            Rectangle r1 = new Rectangle(l1p1x, l1p1y, l1p2x - l1p1x, l1p2y - l1p1y);
            Rectangle r2 = new Rectangle(l2p1x, l2p1y, l2p2x - l2p1x, l2p2y - l2p1y);

            if (r1.IntersectsWith(r2))
            {
                return true;
            }

            return false;
        }

        public ShipPosition VytvorLod(ShipType shipType)
        {
            bool a = rnd.NextDouble() <= 0.5;
            Orientation o = Orientation.Right;
            if (a)
            {
                o = Orientation.Down;
            }

            var sirkaLodi = (int)shipType;
            byte x;
            byte y;
            if (o == Orientation.Right)
            {
                y = (byte)rnd.Next(1, vyska - 2);
                x = (byte)rnd.Next(1, sirka - 1 - sirkaLodi);
                return new ShipPosition(shipType, new Position(x, y), o);
            }
            else
            {
                x = (byte)rnd.Next(1, sirka - 2);
                y = (byte)rnd.Next(1, vyska - 1 - sirkaLodi);
                return new ShipPosition(shipType, new Position(x, y), o);
            }
        }

        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            inShip = false;
            lastResult = null;
            vystrely.Clear();
            potopenych = 0;
            vytvorenych = gameSettings.ShipTypes.Length;
            zobrazitVystrely = true;

            sirka = gameSettings.BoardWidth;
            vyska = gameSettings.BoardHeight;
            System.Diagnostics.Debug.WriteLine($"NEW GAME {sirka} {vyska} {gameSettings.ShipTypes.Length}");

            var shipPositions = new List<ShipPosition>();

            int pocetKolizi = 0;

            foreach (var shipType in gameSettings.ShipTypes.OrderByDescending(x => (int)x))
            {
                while (true)
                {
                    ShipPosition s = VytvorLod(shipType);
                    bool koliduji = false;
                    foreach (var lod in shipPositions)
                    {
                        if (LodeKoliduji(s, lod))
                        {
                            koliduji = true;
                            break;
                        }
                    }
                    if (!koliduji)
                    {
                        shipPositions.Add(s);
                        break;
                    }
                    else
                    {
                        // System.Diagnostics.Debug.WriteLine("Kolize");
                        pocetKolizi++;
                    }
                }

            }

            System.Diagnostics.Debug.WriteLine($"Pocet kolizi {pocetKolizi}");

            return shipPositions.ToArray();
        }


    }
}
