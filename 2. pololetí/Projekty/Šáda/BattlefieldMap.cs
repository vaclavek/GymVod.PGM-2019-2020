using System;
using System.Collections.Generic;
using System.Linq;
using GymVod.Battleships.Common;
using GymVod.Battleships.Services.GameServer;

namespace DumbLodiiis
{
	// Token: 0x02000002 RID: 2
	internal class BattlefieldMap
	{
		public int Width { get; }

		public int Height { get; }

		public List<ShipPosition> Ships { get; }
		
		public List<ShipType> ShipTypes { get; }

		public BattlefieldMap(GameSettings gs)
		{
			this.Width = gs.BoardWidth - 2;
			this.Height = gs.BoardHeight - 2;
			this.ShipTypes = gs.ShipTypes.OrderByDescending(t => (int)t).ToList<ShipType>();
			this.Ships = new List<ShipPosition>();
		}

		public ShipPosition[] ConvertShipPositionsForEngine()
		{
			ShipPosition[] array = new ShipPosition[this.Ships.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ShipPosition(this.Ships[i].ShipType, new Position((byte)(this.Ships[i].Position.X + 1), (byte)(this.Ships[i].Position.Y + 1)), this.Ships[i].Orientation);
			}
			return array;
		}

		public static ShipPosition[] GenerateInitialShipPositions(GameSettings gs)
		{
			BattlefieldMap battlefieldMap = new BattlefieldMap(gs);
			Random random = new Random();
			foreach (ShipType shipType in battlefieldMap.ShipTypes)
			{
				bool flag;
				do
				{
					battlefieldMap.Ships.Add(new ShipPosition(shipType, new Position((byte)random.Next(0, battlefieldMap.Width), (byte)random.Next(0, battlefieldMap.Height)), (Orientation) random.Next(0, 4)));
					flag = BattlefieldMap.PlacingSuccessful(battlefieldMap);
					bool flag2 = !flag;
					if (flag2)
					{
						battlefieldMap.Ships.RemoveAt(battlefieldMap.Ships.Count - 1);
					}
				}
				while (!flag);
			}
			return battlefieldMap.ConvertShipPositionsForEngine();
		}

		private static bool PlacingSuccessful(BattlefieldMap map)
		{
			Gameboard gameboard = new Gameboard((byte)map.Width, (byte)map.Height);
			try
			{
				gameboard.PlaceShips(map.ConvertShipPositionsForEngine());
			}
			catch (GameOverException)
			{
				return false;
			}
			return true;
		}
	}
}
