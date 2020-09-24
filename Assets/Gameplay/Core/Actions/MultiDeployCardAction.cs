using Gameplay.Core.Cards;

namespace Gameplay.Core.Actions
{
    public class MultiDeployCardAction : GameAction<MultiDeployCardActionData>
    {
        public override bool Validate()
        {
            return true;
        }

        public override void Execute()
        {
            var deployer = Data.Deployer;

            for (var i = 0; i < Data.Count; i++)
            {
                deployer.DeployCard(Data.CardType, Data.Team, Data.LaneIdx);
            }
        }
    }

    public struct MultiDeployCardActionData
    {
        public Deployer Deployer;

        public CardType CardType;

        public Team Team;

        public int LaneIdx;

        public int Count;
    }
}