using System;
using GymVod.Battleships.Common;

namespace HolanHalir
{
    public class IDK_how_to_DLL : GymVod.Battleships.Common.IBattleshipsGame
    {
        bool hitResult;
        bool shiptrack = false;

        byte shotPositionX;
        byte shotPositionY;

        int lastFoundShotPosX;
        int lastFoundShotPosY;

        bool onlyX;
        bool onlyY;

        bool[,] whereToShoot;
        int gameLength;
        int gameHeight;

        int xShotPos;
        int yShotPos;

        public bool shipFound;
        Random rand = new Random();

        public Position GetNextShotPosition()
        {
            bool possiblePosition;


            if (shipFound == true)//Predchozi strela se trefila, co mam udelat ted?
            {
                // Teď budeš hledat, jestli ta loď pokračuje dál, popřípadě jakým směrem a jak daleko. Začni hledáním bodů kolem té lodi pomocí x + 1,y ; x-1,y ; x,y - 1 ; x,y+1 ;
                // dále pokročíš tím, že až jeden z těch bodů bude loď (jestli žádný bod není, přesuneš se na else podmínku), střelíš ten nalezený bod a dále budeš střílet +1 do stejného směru, kdes našel ten předchozí bod, dokud tam žádný bod nebude, a tehdy se přesuneš na else podmínku
                /*if (onlyX)
                {
                    if (shotPositionX > lastFoundShotPosX && hitResult == false)
                    {
                        xShotPos = lastFoundShotPosX - 1;
                        yShotPos = lastFoundShotPosY;
                    }
                    else if (shotPositionX < lastFoundShotPosX && hitResult == true)
                    {
                        xShotPos = shotPositionX - 1;
                        yShotPos = lastFoundShotPosY;
                    }
                    else if (shotPositionX < lastFoundShotPosX && hitResult == false)
                    {
                        xShotPos = lastFoundShotPosX + 1;
                        yShotPos = lastFoundShotPosY;
                    }
                    else if (whereToShoot[shotPositionX + 1, lastFoundShotPosY])
                    {
                        xShotPos = shotPositionX + 1;
                        yShotPos = lastFoundShotPosY;
                    }
                    else
                    {
                        shipFound = false;
                        onlyX = false;
                        onlyY = false;
                        shiptrack = false;
                    }

                }
                else if (onlyY)
                {

                    if (shotPositionY > lastFoundShotPosY && hitResult == false)
                    {
                        xShotPos = lastFoundShotPosX;
                        yShotPos = lastFoundShotPosY - 1;
                    }
                    else if (shotPositionY < lastFoundShotPosY && hitResult == true)
                    {
                        xShotPos = lastFoundShotPosX;
                        yShotPos = shotPositionY - 1;
                    }
                    else if (shotPositionY < lastFoundShotPosY && hitResult == false)
                    {
                        xShotPos = lastFoundShotPosX;
                        yShotPos = lastFoundShotPosY + 1;
                    }
                    else if (whereToShoot[lastFoundShotPosX, shotPositionY + 1])
                    {
                        xShotPos = lastFoundShotPosX;
                        yShotPos = shotPositionY + 1;
                    }
                    else
                    {
                        shipFound = false;
                        onlyX = false;
                        onlyY = false;
                        shiptrack = false;
                    }

                }
                else
                {*/
                if (whereToShoot[lastFoundShotPosX - 1, lastFoundShotPosY] == true)
                {
                    xShotPos = lastFoundShotPosX - 1;
                    yShotPos = lastFoundShotPosY;
                }
                else if (whereToShoot[lastFoundShotPosX, lastFoundShotPosY - 1] == true)
                {
                    xShotPos = lastFoundShotPosX;
                    yShotPos = lastFoundShotPosY - 1;
                }
                else if (whereToShoot[lastFoundShotPosX + 1, lastFoundShotPosY] == true)
                {
                    xShotPos = lastFoundShotPosX + 1;
                    yShotPos = lastFoundShotPosY;
                }
                else if (whereToShoot[lastFoundShotPosX, lastFoundShotPosY + 1] == true)
                {
                    xShotPos = lastFoundShotPosX;
                    yShotPos = lastFoundShotPosY + 1;
                }
                else
                {
                    shipFound = false;
                    onlyX = false;
                    onlyY = false;
                    shiptrack = false;
                }
                //}
            }
            if (shipFound == false)
            {
                do
                {
                    xShotPos = rand.Next(0, gameLength - 1);
                    yShotPos = rand.Next(0, gameHeight - 1);
                    if (whereToShoot[xShotPos, yShotPos] == false)
                    {
                        possiblePosition = false;
                    }
                    else
                    {
                        possiblePosition = true;
                    }
                }
                while (possiblePosition == false);
            }
            Position returnPosition = new Position((byte)xShotPos, (byte)yShotPos);
            whereToShoot[xShotPos, yShotPos] = false;
            return returnPosition;
        }

        public ShipPosition[] NewGame(GameSettings gameSettings)
        {
            onlyX = false;
            onlyY = false;
            shipFound = false;
            //vracecí pole
            ShipPosition[] returnField = new ShipPosition[gameSettings.ShipTypes.Length];
            //uložení délky a šířky pro střílecí algoritmus
            gameLength = gameSettings.BoardWidth;
            gameHeight = gameSettings.BoardHeight;
            //nastavení pole pro střílecí algoritmus
            whereToShoot = new bool[gameSettings.BoardWidth, gameSettings.BoardHeight];
            //pomocné pole pro kontrolu, zda je možné umístit loď na danou pozici
            bool[,] allowedShipPosition = new bool[gameSettings.BoardWidth, gameSettings.BoardHeight];

            for (int i = 0; i < gameSettings.BoardWidth; i++)
            {
                for (int y = 0; y < gameSettings.BoardHeight; y++)
                {
                    allowedShipPosition[i, y] = true;
                    //zároveň nastavuje i pole whereToShoot
                    whereToShoot[i, y] = true;
                }
            }
            for (int i = 0; i < gameSettings.BoardWidth; i++)
            {
                allowedShipPosition[i, 0] = false;
                allowedShipPosition[i, gameSettings.BoardHeight - 1] = false;
                //zároveň nastavuje i pole whereToShoot
                whereToShoot[i, 0] = false;
                whereToShoot[i, gameSettings.BoardHeight - 1] = false;
            }
            for (int i = 0; i < gameSettings.BoardHeight; i++)
            {
                allowedShipPosition[0, i] = false;
                allowedShipPosition[gameSettings.BoardWidth - 1, i] = false;
                //zároveň nastavuje i pole whereToShoot
                whereToShoot[0, i] = false;
                whereToShoot[gameSettings.BoardWidth - 1, i] = false;
            }
            //hodnoty pro Foreach
            bool horizontal;
            byte shipPosX;
            byte shipPosY;
            bool checker;
            int numeral = 0;
            //foreach cyklus pro samotné rozmístění lodí
            foreach (ShipType shipID in gameSettings.ShipTypes)
            {
                Orientation orientation;
                //do-while cyklus pro vyhledání nové pozice pro postavení lodi: Dokud nenajde pozici, kam loď postavit, tak bude hledat
                do
                {
                    checker = true;
                    horizontal = (rand.Next(0, 5) % 2 == 0);
                    //vertikalni je false a horizontalni true
                    shipPosX = (byte)rand.Next(gameSettings.BoardWidth - 1);
                    shipPosY = (byte)rand.Next(gameSettings.BoardHeight - 1);
                    //checker pro správné umístění: Break nastaven po první špatné pozici
                    if (horizontal == true)
                    {
                        for (int i = 0; i < (int)shipID; i++)
                        {
                            if (allowedShipPosition[shipPosX + i, shipPosY] == false)
                            {
                                checker = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (int)shipID; i++)
                        {
                            if (allowedShipPosition[shipPosX, shipPosY + i] == false)
                            {
                                checker = false;
                                break;
                            }
                        }

                    }

                } while (checker == false);

                //nastavuje kontrolní pole pro pozice lodí
                if (horizontal == true)
                {
                    orientation = Orientation.Right;
                    for (int i = 0; i < (int)shipID; i++)
                    {
                        allowedShipPosition[shipPosX + i, shipPosY] = false;
                        allowedShipPosition[shipPosX + i - 1, shipPosY] = false;
                        allowedShipPosition[shipPosX + i + 1, shipPosY] = false;
                        allowedShipPosition[shipPosX + i, shipPosY - 1] = false;
                        allowedShipPosition[shipPosX + i, shipPosY + 1] = false;
                    }
                }
                else
                {
                    orientation = Orientation.Down;
                    for (int i = 0; i < (int)shipID; i++)
                    {
                        allowedShipPosition[shipPosX, shipPosY + i] = false;
                        allowedShipPosition[shipPosX - 1, shipPosY + i] = false;
                        allowedShipPosition[shipPosX + 1, shipPosY + i] = false;
                        allowedShipPosition[shipPosX, shipPosY - 1 + i] = false;
                        allowedShipPosition[shipPosX, shipPosY + 1 + i] = false;
                    }
                }
                //sestavení datového typu a uložení do příslušné pozice v poli pro vrácení
                ShipPosition temp = new ShipPosition(shipID, new Position(shipPosX, shipPosY), orientation);
                returnField.SetValue(temp, numeral);
                numeral++;
            }
            return returnField;
        }

        public void ShotResult(ShotResult shotResult)
        {
            if (hitResult == true)
            {
                shipFound = true;

            }
            shotPositionX = (byte)xShotPos;
            shotPositionY = (byte)yShotPos;
            if (shipFound && onlyX == false && onlyY == false && shiptrack == false)
            {
                lastFoundShotPosX = shotResult.Position.X;
                lastFoundShotPosY = shotResult.Position.Y;
                shiptrack = true;
            }

            //střela po trefě: Zjistí, zda má střílet na X, nebo Y pozice
            bool shipDown;
            if (shotResult.ShipSunken == true)
            {
                shipDown = true;
            }
            else
            {
                shipDown = false;
            }
            if (shotResult.Hit == true)
            {
                hitResult = true;
            }
            else
            {
                hitResult = false;
            }

            //nastavuje, zda střílet jen podle X
            if (shotPositionX != lastFoundShotPosX)
            {
                if (hitResult && shipFound)
                {
                    onlyX = true;
                }
            }
            else if (shotPositionY != lastFoundShotPosY)
            {
                if (hitResult && shipFound)
                {
                    onlyY = true;
                }
            }

            //hledá, zda našel loď
            if (shipDown == true)
            {
                shipFound = false;
                onlyX = false;
                onlyY = false;
                shiptrack = false;
            }
            //potopil jsem -> nenašel jsem žádnou živou loď a nevím, zda střílet jen dle X, nebo jen dle Y


            return;

        }


    }
}



