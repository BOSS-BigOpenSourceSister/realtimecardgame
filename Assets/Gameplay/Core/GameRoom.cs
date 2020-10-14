using Gameplay.Behaviours.UI;
using Gameplay.Core.Actions;
using Gameplay.Core.Cards;
using UnityEngine;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Behaviours;
using UnityEngine.SceneManagement;


namespace Gameplay.Core
{
    public class GameRoom : MonoBehaviour
    {
        [SerializeField] Arena arena;
        [SerializeField] MatchReferee matchReferee;
        [SerializeField] CardPrefabMap cardPrefabMap;
        [SerializeField] GameplayHUD gameplayHUD;
        [SerializeField] GameObject playerPrefab;
        [SerializeField] GestureRecognizer gestureRecognizer;

        [SerializeField] DamageableBehaviour castleBlue;
        [SerializeField] DamageableBehaviour castleRed;



        IPlayer HomePlayer { get; set; }

        IPlayer VisitorPlayer { get; set; }

        Dealer Dealer { get; } = new Dealer();

        void Start()
        {
            var gameObjectFactory = new GameObjectFactory(cardPrefabMap, playerPrefab);
            var deployer = new Deployer(gameObjectFactory, arena, gameplayHUD);
            var gameActionFactory = new GameActionFactory(deployer);

            gameplayHUD.Setup(gestureRecognizer, arena);
            gameplayHUD.CreateCardSlots(PlayerHand.HandSize);

            HomePlayer = gameObjectFactory.CreatePlayer(Team.Home);
            VisitorPlayer = gameObjectFactory.CreatePlayer(Team.Visitor);

            HomePlayer.Setup(PlayerDeck.GetDummyDeck());
            VisitorPlayer.Setup(PlayerDeck.GetDummyDeck());

            Dealer.DealInitialCards(HomePlayer);
            Dealer.DealInitialCards(VisitorPlayer);

            matchReferee.Setup(gameActionFactory, players: new []{HomePlayer, VisitorPlayer}, castleBlue, castleRed);
        }

        void Awake() => AddObservers();

        void OnDestroy() => RemoveObservers();

        void AddObservers()
        {
            Dealer.OnDealtCard += gameplayHUD.OnCardDealt;
            gameplayHUD.OnUseCard += OnHomePlayerUsedCard;
            matchReferee.OnGameOver += GameOver;
        }

        void RemoveObservers()
        {
            Dealer.OnDealtCard -= gameplayHUD.OnCardDealt;
            gameplayHUD.OnUseCard -= OnHomePlayerUsedCard;
            matchReferee.OnGameOver -= GameOver;
        }
        void GameOver()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        void OnHomePlayerUsedCard(CardType card, int laneIdx)
        {
            matchReferee.OnPlayerUsedCard(card, HomePlayer.Team, laneIdx, HomePlayer);
            Dealer.DealCard(HomePlayer);
        }

        void Update()
        {
            HomePlayer.Mana.AddMana();
        }
    }
}
