using System;
using System.Collections.Generic;
using System.Linq;
using GymVod.Battleships.Common;


namespace Myl
{
    public class AlgoritmusLode : GymVod.Battleships.Common.IBattleshipsGame
    {
        public byte width;
        public byte height;
        byte x;
        byte y;
        bool lodPotopena;
        bool zmenasmeru = false;
        Position position = new Position(0, 0);

        List<Position> listPozice = new List<Position>();
        List<int> listVysledek = new List<int>();
        List<int> listPrepinac = new List<int>();
        List<Position> listZasah = new List<Position>();

        Position zasahStrela;
        Random random = new Random();

        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            width = gameSettings.BoardWidth;
            height = gameSettings.BoardHeight;
            listPozice.Add(new Position(0, 0));

            listVysledek.Clear();
            listPrepinac.Clear();
            listZasah.Clear();
            listZasah.Clear();

            listVysledek.Add(0);
            listVysledek.Add(0);
            listVysledek.Add(0);
            listVysledek.Add(0);
            listVysledek.Add(0);
            listVysledek.Add(0);

            listPrepinac.Add(1);


            listZasah.Add(new Position(0, 0));
            listZasah.Add(new Position(0, 0));

            List<ShipPosition> shipPositions = new List<ShipPosition>();

            shipPositions.Add(new ShipPosition(ShipType.Submarine, new Position(3, 2), Orientation.Left));
            shipPositions.Add(new ShipPosition(ShipType.Submarine, new Position(13, 11), Orientation.Left));
            shipPositions.Add(new ShipPosition(ShipType.Destroyer, new Position(6, 4), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Destroyer, new Position(1, 18), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Cruiser, new Position(12, 4), Orientation.Right));
            shipPositions.Add(new ShipPosition(ShipType.Cruiser, new Position(15, 15), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Carrier, new Position(18, 2), Orientation.Down));
            shipPositions.Add(new ShipPosition(ShipType.Battleship, new Position(5, 14), Orientation.Right));

            return shipPositions.ToArray();

        }

        public Position GetNextShotPosition()
        {
            //výsledek poslední střely

            int vysledek = listVysledek.Last<int>();
            int vysledek2 = listVysledek.ElementAt<int>(listVysledek.Count - 2);
            int vysledek3 = listVysledek.ElementAt<int>(listVysledek.Count - 3);
            int vysledek4 = listVysledek.ElementAt<int>(listVysledek.Count - 4);
            int vysledek5 = listVysledek.ElementAt<int>(listVysledek.Count - 5);
            int vysledek6 = listVysledek.ElementAt<int>(listVysledek.Count - 6);

            //pozice posledních dvou zásahů
            Position zasah = listZasah.ElementAt<Position>(listZasah.Count - 1);
            Position zasah2 = listZasah.ElementAt<Position>(listZasah.Count - 2);

            int smerLode = listPrepinac.Last<int>();


            // 1.blok: random střílení dokuď není registrován zásah (test)
            if ((vysledek == 0 && vysledek2 == 0 && vysledek3 == 0 && vysledek4 == 0 && vysledek5 == 0) /*|| (vysledek == 2)*/)
            {

                x = Convert.ToByte(random.Next(1, width - 1));
                y = Convert.ToByte(random.Next(1, height - 1));
                position = new Position(x, y);

                //omezeni vystřelu na stejné místo
                if (listPozice.Contains(position))
                {
                    x = Convert.ToByte(random.Next(1, width - 1));
                    y = Convert.ToByte(random.Next(1, height - 1));
                    position = new Position(x, y);

                }
                listPozice.Add(position);
                return position;
            }

            //2.blok: po 1. zásahu - potopení lodi

            else if (vysledek == 1 || (vysledek == 0 && vysledek2 == 1) || (vysledek == 0 && vysledek2 == 0 && vysledek3 == 1) || (vysledek == 0 && vysledek2 == 0 && vysledek3 == 0 && vysledek4 == 1))
            {
                // 2b. szřelba vodorovně nebo svisle v závislosti na pozici posledních dvou zásahů  
                if (listZasah.Count >= 3)
                {
                    //vodorovně
                    if (zasah2.Y == zasah.Y)
                    {
                        //změna směru střelby pokud je zaznamenáno VEDLE a loď je stále nepotopena
                        if (zmenasmeru == true)
                        {
                            x--;
                            return new Position(x, y);
                        }

                        if ((vysledek == 0 && vysledek2 == 1 && vysledek3 == 1) || (vysledek == 1 && vysledek2 == 0 && vysledek3 == 1 && vysledek4 == 1) || (vysledek == 1 && vysledek2 == 1 && vysledek3 == 0 && vysledek4 == 1 && vysledek5 == 1) || (vysledek == 1 && vysledek2 == 1 && vysledek3 == 1 && vysledek4 == 0 && vysledek5 == 1 && vysledek6 == 1))
                        {
                            zasahStrela = listZasah.ElementAt<Position>(2);
                            x = zasahStrela.X;
                            zmenasmeru = true;
                            x--;
                            return new Position(x, y);
                        }
                        x++;
                        return new Position(x, y);

                    }
                    //svisle
                    if (zasah2.X == zasah.X)
                    {
                        //změna směru střelby pokud je zaznamenáno VEDLE a loď je stále nepotopena
                        if (zmenasmeru == true)
                        {
                            y--;
                            return new Position(x, y);
                        }

                        if ((vysledek == 0 && vysledek2 == 1 && vysledek3 == 1) || (vysledek == 1 && vysledek2 == 0 && vysledek3 == 1 && vysledek4 == 1) || (vysledek == 1 && vysledek2 == 1 && vysledek3 == 0 && vysledek4 == 1 && vysledek5 == 1) || (vysledek == 1 && vysledek2 == 1 && vysledek3 == 1 && vysledek4 == 0 && vysledek5 == 1 && vysledek6 == 1) || (vysledek == 0 && vysledek2 == 1 && vysledek3 == 0 && vysledek4 == 0 && vysledek5 == 1))
                        {
                            zasahStrela = listZasah.ElementAt<Position>(2);
                            y = zasahStrela.Y;
                            zmenasmeru = true;
                            y--;
                            return new Position(x, y);
                        }
                        y++;
                        return new Position(x, y);
                    }


                }
                //2a. blok: ostřelování bodu do všech stran 

                // souřadnice ostřelovaného bodu
                x = zasahStrela.X;
                y = zasahStrela.Y;


                // zprava
                if (smerLode == 1)
                {
                    x++;

                    listPrepinac.Add(2);
                    position = new Position(x, y);

                    return position;


                }

                //zleva
                if (smerLode == 2)
                {
                    x--;

                    listPrepinac.Add(3);
                    position = new Position(x, y);


                    return position;
                }
                //zdola
                if (smerLode == 3)
                {
                    y++;

                    listPrepinac.Add(4);
                    position = new Position(x, y);

                    return position;
                }
                //shora
                if (smerLode == 4)
                {
                    y--;

                    listPrepinac.Add(1);
                    position = new Position(x, y);

                    return position;
                }

                return new Position(200, 200);

            }


            // nemelo by se kód neměl nikdy dostat
            else
            {
                return new Position(100, 100);
            }



        }

        public void ShotResult(ShotResult shotResult)
        {
            lodPotopena = shotResult.ShipSunken;

            if (shotResult.Hit == true)
            {
                zasahStrela = shotResult.Position;
                listZasah.Add(zasahStrela);

                listVysledek.Add(1);




            }
            if (shotResult.Hit == false)
            {
                listVysledek.Add(0);

            }

            if (lodPotopena == true)
            {
                zmenasmeru = false;

                listVysledek.Add(0);
                listVysledek.Add(0);
                listVysledek.Add(0);
                listVysledek.Add(0);
                listVysledek.Add(0);
                listVysledek.Add(0);

                listZasah.Clear();

                listPrepinac.Add(1);

                listZasah.Add(new Position(0, 0));
                listZasah.Add(new Position(0, 0));
            }



        }

    }
}