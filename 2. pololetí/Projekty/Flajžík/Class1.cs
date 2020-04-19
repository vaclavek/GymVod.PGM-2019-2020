using System;
using System.Collections.Generic;
using GymVod.Battleships.Common;

namespace Flajzik
{

    public class Class1 : IBattleshipsGame
    {
        // pro pole 20x20
        byte width;
        byte height;
        byte nextPosX = 10;
        byte nextPosY = 10;
        private static byte WIDTH_CENTER;
        private static byte HEIGHT_CENTER;

        Random rnd = new Random();

        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            width = gameSettings.BoardWidth;
            height = gameSettings.BoardHeight;

            int WIDTH_CENTER1 = width / 2;
            WIDTH_CENTER = (byte)WIDTH_CENTER1;
            int HEIGHT_CENTER1 = height / 2;
            HEIGHT_CENTER = (byte)HEIGHT_CENTER1;


            var shipPosition = new List<ShipPosition>();
            var position = new Position(2, 11);
            var position2 = new Position(17, 9);
            var position3 = new Position(12, 1);
            var position4 = new Position(3, 2);
            var position5 = new Position(4, 18);
            var position6 = new Position(11, 15);
            var position7 = new Position(15, 5);
            var position8 = new Position(18, 17);

            shipPosition.Add(new ShipPosition(ShipType.Carrier, position, Orientation.Right));
            shipPosition.Add(new ShipPosition(ShipType.Battleship, position2, Orientation.Up));
            shipPosition.Add(new ShipPosition(ShipType.Cruiser, position3, Orientation.Down));
            shipPosition.Add(new ShipPosition(ShipType.Cruiser, position4, Orientation.Down));
            shipPosition.Add(new ShipPosition(ShipType.Destroyer, position5, Orientation.Left));
            shipPosition.Add(new ShipPosition(ShipType.Destroyer, position6, Orientation.Left));
            shipPosition.Add(new ShipPosition(ShipType.Submarine, position7, Orientation.Right));
            shipPosition.Add(new ShipPosition(ShipType.Submarine, position8, Orientation.Right));
            return shipPosition.ToArray();



        }
        int[,] battleMap = new int[20, 20];
        /* hodnota 0 = nevystřeleno
         * hodnota 1 = vystřeleno
         * hodnota 2 = zasáhnuto
         * hodnota 3 = zasáhnuto, loď potopena
         */

        public Position GetNextShotPosition()
        {

            var nextPosition = new Position(nextPosX, nextPosY);
            try
            {
                nextPosX += 0;
                nextPosY += 0;
                battleMap[nextPosX, nextPosY] = 1;
                return nextPosition;
            }
            catch (IndexOutOfRangeException)
            {
                battleMap[nextPosX, nextPosY] = 1;
                return nextPosition;
            }

        }





        public void ShotResult(ShotResult shotResult)
        {
            Random rnd = new Random();

            int a;
            int b;



            try
            {

                if (shotResult.Hit)
                {
                    battleMap[nextPosX, nextPosY] = 2;


                    if (shotResult.ShipSunken)
                    {
                        battleMap[nextPosX, nextPosY] = 3;

                        Randomposition();
                    }
                    else
                    {
                        battleMap[nextPosX, nextPosY] = 2;
                        /* System.Diagnostics.Debug.Write("X: " + nextPosX);
                         System.Diagnostics.Debug.Write("Y: " + nextPosY);*/
                        if ((width - nextPosX) > 4 && nextPosX > 4 && (height - nextPosY) > 4 && nextPosY > 4)
                        {
                            if (Overeni(nextPosX, nextPosY, out a, out b))
                            {
                                if (Math.Abs(a - nextPosX) > 1 || Math.Abs(b - nextPosY) > 1)
                                {
                                    if (battleMap[a + 1, b] == 0)
                                    {
                                        a++;
                                        nextPosX = (byte)a;
                                    }
                                    else if (battleMap[a - 1, b] == 0)
                                    {
                                        a--;
                                        nextPosX = (byte)a;
                                    }
                                    else if (battleMap[a, b + 1] == 0)
                                    {
                                        b++;
                                        nextPosY = (byte)b;
                                    }
                                    else if (battleMap[a, b - 1] == 0)
                                    {
                                        b--;
                                        nextPosY = (byte)b;
                                    }
                                    else
                                    {
                                        Randomposition();
                                    }
                                }
                                else if (nextPosX == a - 1 && nextPosY == b)
                                {
                                    nextPosX += 2;
                                    if (battleMap[nextPosX, nextPosY] == 0)
                                    {

                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 2)
                                    {
                                        if (battleMap[nextPosX + 1, nextPosY] == 0)
                                        {
                                            nextPosX++;
                                        }
                                        else if (battleMap[nextPosX + 1, nextPosY] == 1)
                                        {
                                            nextPosX -= 3;
                                            if (battleMap[nextPosX, nextPosY] == 0)
                                            {

                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 1)
                                            {
                                                Randomposition();
                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 2)
                                            {
                                                nextPosX--;
                                                if (battleMap[nextPosX, nextPosY] == 0)
                                                {

                                                }
                                                else
                                                {
                                                    Randomposition();

                                                }
                                            }

                                        }
                                        else if (battleMap[nextPosX + 1, nextPosY] == 2)
                                        {
                                            if (battleMap[nextPosX + 2, nextPosY] == 0)
                                            {
                                                nextPosX++;
                                            }
                                            else if (battleMap[nextPosX - 3, nextPosY] == 0)
                                            {
                                                nextPosX -= 3;
                                            }
                                            else
                                                Randomposition();
                                        }
                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 1)
                                    {
                                        nextPosX -= 3;
                                        if (battleMap[nextPosX, nextPosY] == 0)
                                        {

                                        }
                                        else if (battleMap[nextPosX, nextPosY] == 2)
                                        {
                                            if (battleMap[nextPosX - 1, nextPosY] == 0)
                                            {
                                                nextPosX--;
                                            }
                                            else if (battleMap[nextPosX - 2, nextPosY] == 0)
                                            {
                                                nextPosX -= 2;
                                            }
                                            else
                                                Randomposition();
                                        }
                                        else
                                            Randomposition();
                                    }
                                    else
                                    {
                                        Randomposition();

                                    }
                                }
                                else if (nextPosX == a + 1 && nextPosY == b)
                                {
                                    nextPosX -= 2;
                                    if (battleMap[nextPosX, nextPosY] == 0)
                                    {

                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 2)
                                    {
                                        if (battleMap[nextPosX - 1, nextPosY] == 0)
                                        {
                                            nextPosX--;
                                        }
                                        else if (battleMap[nextPosX - 1, nextPosY] == 1)
                                        {
                                            nextPosX += 3;
                                            if (battleMap[nextPosX, nextPosY] == 0)
                                            {

                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 1)
                                            {
                                                Randomposition();
                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 2)
                                            {
                                                nextPosX++;
                                                if (battleMap[nextPosX, nextPosY] == 0)
                                                {

                                                }
                                                else
                                                {
                                                    Randomposition();

                                                }
                                            }

                                        }
                                        else if (battleMap[nextPosX - 1, nextPosY] == 2)
                                        {
                                            if (battleMap[nextPosX - 2, nextPosY] == 0)
                                            {
                                                nextPosX--;
                                            }
                                            else if (battleMap[nextPosX + 3, nextPosY] == 0)
                                            {
                                                nextPosX += 3;
                                            }
                                            else
                                                Randomposition();
                                        }
                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 1)
                                    {
                                        nextPosX += 3;
                                        if (battleMap[nextPosX, nextPosY] == 0)
                                        {

                                        }
                                        else if (battleMap[nextPosX, nextPosY] == 2)
                                        {
                                            if (battleMap[nextPosX + 1, nextPosY] == 0)
                                            {
                                                nextPosX++;
                                            }
                                            else if (battleMap[nextPosX + 2, nextPosY] == 0)
                                            {
                                                nextPosX += 2;
                                            }
                                            else
                                                Randomposition();
                                        }
                                        else
                                            Randomposition();
                                    }
                                    else
                                    {
                                        Randomposition();

                                    }
                                }
                                else if (nextPosX == a && nextPosY == b - 1)
                                {
                                    nextPosY += 2;
                                    if (battleMap[nextPosX, nextPosY] == 0)
                                    {

                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 2)
                                    {
                                        if (battleMap[nextPosX, nextPosY + 1] == 0)
                                        {
                                            nextPosY++;
                                        }
                                        else if (battleMap[nextPosX, nextPosY + 1] == 1)
                                        {
                                            nextPosY -= 3;
                                            if (battleMap[nextPosX, nextPosY] == 0)
                                            {

                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 1)
                                            {
                                                Randomposition();
                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 2)
                                            {
                                                nextPosY--;
                                                if (battleMap[nextPosX, nextPosY] == 0)
                                                {

                                                }
                                                else
                                                {
                                                    Randomposition();

                                                }
                                            }

                                        }
                                        else if (battleMap[nextPosX, nextPosY - 1] == 2)
                                        {
                                            if (battleMap[nextPosX, nextPosY + 2] == 0)
                                            {
                                                nextPosY++;
                                            }
                                            else if (battleMap[nextPosX, nextPosY - 3] == 0)
                                            {
                                                nextPosY -= 3;
                                            }
                                            else
                                                Randomposition();
                                        }
                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 1)
                                    {
                                        nextPosY -= 3;
                                        if (battleMap[nextPosX, nextPosY] == 0)
                                        {

                                        }
                                        else if (battleMap[nextPosX, nextPosY] == 2)
                                        {
                                            if (battleMap[nextPosX, nextPosY - 1] == 0)
                                            {
                                                nextPosY--;
                                            }
                                            else if (battleMap[nextPosX, nextPosY - 2] == 0)
                                            {
                                                nextPosY -= 2;
                                            }
                                            else
                                                Randomposition();
                                        }
                                        else
                                            Randomposition();
                                    }
                                    else
                                    {
                                        Randomposition();

                                    }
                                }
                                else if (nextPosX == a && nextPosY == b + 1)
                                {
                                    nextPosY -= 2;
                                    if (battleMap[nextPosX, nextPosY] == 0)
                                    {

                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 2)
                                    {
                                        if (battleMap[nextPosX, nextPosY - 1] == 0)
                                        {
                                            nextPosY--;
                                        }
                                        else if (battleMap[nextPosX, nextPosY - 1] == 1)
                                        {
                                            nextPosY += 3;
                                            if (battleMap[nextPosX, nextPosY] == 0)
                                            {

                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 1)
                                            {
                                                Randomposition();
                                            }
                                            else if (battleMap[nextPosX, nextPosY] == 2)
                                            {
                                                nextPosY++;
                                                if (battleMap[nextPosX, nextPosY] == 0)
                                                {

                                                }
                                                else
                                                {
                                                    Randomposition();

                                                }
                                            }

                                        }
                                        else if (battleMap[nextPosX, nextPosY - 1] == 2)
                                        {
                                            if (battleMap[nextPosX, nextPosY - 2] == 0)
                                            {
                                                nextPosY--;
                                            }
                                            else if (battleMap[nextPosX, nextPosY + 3] == 0)
                                            {
                                                nextPosY += 3;
                                            }
                                            else
                                                Randomposition();
                                        }
                                    }
                                    else if (battleMap[nextPosX, nextPosY] == 1)
                                    {
                                        nextPosY += 3;
                                        if (battleMap[nextPosX, nextPosY] == 0)
                                        {

                                        }
                                        else if (battleMap[nextPosX, nextPosY] == 2)
                                        {
                                            if (battleMap[nextPosX, nextPosY + 1] == 0)
                                            {
                                                nextPosY++;
                                            }
                                            else if (battleMap[nextPosX, nextPosY + 2] == 0)
                                            {
                                                nextPosY += 2;
                                            }
                                            else
                                                Randomposition();
                                        }
                                        else
                                            Randomposition();
                                    }
                                    else
                                    {
                                        Randomposition();

                                    }
                                }

                            }
                            else
                            {
                                if (battleMap[nextPosX + 1, nextPosY] == 0)
                                {
                                    nextPosX++;
                                }
                                else if (battleMap[nextPosX - 1, nextPosY] == 0)
                                {
                                    nextPosX--;

                                }
                                else if (battleMap[nextPosX, nextPosY + 1] == 0)
                                {
                                    nextPosY++;

                                }
                                else if (battleMap[nextPosX, nextPosY - 1] == 0)
                                {
                                    nextPosY--;

                                }
                                else
                                {
                                    Randomposition();

                                }
                            }


                        }

                        else
                        {
                            if (nextPosX != width - 1 || nextPosX != width)
                            {
                                nextPosX++;
                            }
                            else if (nextPosY != height - 1 || nextPosY != height)
                            {
                                nextPosY++;
                            }
                            else
                            {
                                Randomposition();
                            }

                        }


                    }
                }
                else
                {
                    battleMap[nextPosX, nextPosY] = 1;

                    if ((width - nextPosX) > 4 && nextPosX > 4 && (height - nextPosY) > 4 && nextPosY > 4)
                    {
                        if (Overeni(nextPosX, nextPosY, out a, out b))
                        {

                            if (battleMap[a + 1, b] == 0)
                            {
                                a += 1;
                                nextPosX = (byte)a;
                                nextPosY = (byte)b;
                            }
                            else if (battleMap[a - 1, b] == 0)
                            {
                                a -= 1;
                                nextPosX = (byte)a;
                                nextPosY = (byte)b;

                            }
                            else if (battleMap[a, b + 1] == 0)
                            {
                                b += 1;
                                nextPosX = (byte)a;
                                nextPosY = (byte)b;

                            }
                            else if (battleMap[a, b - 1] == 0)
                            {
                                b -= 1;
                                nextPosX = (byte)a;
                                nextPosY = (byte)b;
                            }
                            else
                            {
                                Randomposition();

                            }
                        }
                        else
                        {
                            Randomposition();

                        }
                    }


                    else
                    {
                        Randomposition();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Randomposition();
            }
        }
        bool Overeni(byte nextPosX, byte nextPosY, out int a, out int b)
        {
            bool vypadnout;
            for (int i = nextPosX - 4; i < nextPosX + 4; i++)
            {

                for (int k = nextPosY - 4; k < nextPosY + 4; k++)
                {
                    vypadnout = battleMap[i, k] == 2 && (i != nextPosX || k != nextPosY);
                    /*System.Diagnostics.Debug.WriteLine("i: " + i);
                    System.Diagnostics.Debug.WriteLine("k: " + k);*/
                    if (vypadnout)
                    {

                        a = i;
                        b = k;

                        return true;
                    }


                }


            }
            a = nextPosX;
            b = nextPosY;
            return false;


        }
        public void Randomposition()
        {
            Random rnd = new Random();
            int i = 1;
            while ((battleMap[nextPosX, nextPosY] == 3 || (battleMap[nextPosX, nextPosY] == 1) || battleMap[nextPosX, nextPosY] == 2) && i < 1000)
            {
                nextPosX = (byte)rnd.Next(1, width - 1);
                nextPosY = (byte)rnd.Next(1, height - 1);
                i++;
            }

        }





    }
}












