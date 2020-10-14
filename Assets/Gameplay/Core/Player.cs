using Gameplay.Behaviours;

namespace Gameplay.Core
{
    public interface IPlayer : IEntity
    {
        PlayerDeck Deck { get; }
        PlayerHand Hand { get; }
        ManaManager Mana { get; }

        void Setup(PlayerDeck deck);
    }

    public class Player : BaseBehaviour, IPlayer
    {
        public PlayerDeck Deck { get; private set; }

        public PlayerHand Hand { get; } = new PlayerHand();
        public ManaManager Mana { get; } = new ManaManager();

        public Team Team => Entity.Team;

        public void Setup(PlayerDeck deck)
        {
            Deck = deck;
        }
    }
}
