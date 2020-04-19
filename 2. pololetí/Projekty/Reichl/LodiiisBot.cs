using GymVod.Battleships.Common;
using System;

namespace Reichl
{


    public class LodiiisBot : IBattleshipsGame
    {
        private Shooter _shooter;
        private ShipGenerator _sg = ShipGenerator.BigBrain;
        private HeatMapGenerator _hmg = HeatMapGenerator.Grid;
        private bool _opt = true;

        public LodiiisBot()
        {
        }

        public LodiiisBot(ShipGenerator sg, HeatMapGenerator hmg, bool useOptimalization)
        {
            _sg = sg;
            _hmg = hmg;
            _opt = useOptimalization;
        }

        public ShipPosition[] NewGame(GameSettings gameSettings) 
        {
            _shooter = new Shooter(gameSettings, _hmg, _opt);
            if (_sg == ShipGenerator.BigBrain)
                return BattlefieldMap.GenerateInitialShipPositionsBigBrain(gameSettings);
            else
                return BattlefieldMap.GenerateInitialShipPositions(gameSettings);
        }

        public Position GetNextShotPosition() => _shooter.Shoot();

        public void ShotResult(ShotResult shotResult) => _shooter.ShotResult(shotResult);
    }
    public enum ShipGenerator { Random, BigBrain }
    public enum HeatMapGenerator { Random, Conquer, Grid }
}
