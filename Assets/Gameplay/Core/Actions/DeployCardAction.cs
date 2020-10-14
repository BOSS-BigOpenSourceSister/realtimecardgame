using Gameplay.Core.Cards;

namespace Gameplay.Core.Actions
{
    public class DeployCardAction : GameAction<DeployCardActionData>
    {
        public override bool Validate()
        {
            return true;
        }

        public override void Execute()
        {
            var deployer = Data.Deployer;
            deployer.DeployCard(Data.CardType, Data.Team, Data.LaneIdx, Data.Player);
        }
    }

    public struct DeployCardActionData
    {
        public Deployer Deployer;

        public CardType CardType;

        public Team Team;

        public int LaneIdx;

        public IPlayer Player;
    }
}
