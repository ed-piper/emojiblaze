using System.Collections.Generic;
using EmojiBlaze.Models.Board;
using EmojiBlaze.Models.Store.Game;
using EmojiBlaze.Models.Store.Game.Actions;
using EmojiBlaze.Models.Store.Game.Reducers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace EmojiBlaze.Models.Tests.Store.Game.Reducers
{
    [TestClass]
    public class StartGameReducerTests
    {
        private Mock<ICardGenerator> _cardGeneratorMock;
        private StartGameReducer _sut;

        [TestInitialize]
        public void Init()
        {
            _cardGeneratorMock = new Mock<ICardGenerator>();
            _sut = new StartGameReducer(_cardGeneratorMock.Object);
        }

        [TestMethod]
        public void Reduce_SetsGameStateToCorrectValues()
        {
            var originalGameState = new GameState();
            originalGameState.Players.Add(new Player("Suzie Sheep"));
            originalGameState.Players.Add(new Player("Peppa Pig"));

            var gameState = _sut.Reduce(originalGameState, new StartGameAction());
            gameState.GameStage.ShouldBe(GameStage.InProgress);
            gameState.Players[0].HasCurrentTurn.ShouldBe(true);
            gameState.Players[1].HasCurrentTurn.ShouldBe(false);
        }

        [TestMethod]
        public void Reduce_SetsCardsToGeneratorValue()
        {
            var originalGameState = new GameState();
            originalGameState.Players.Add(new Player("Suzie Sheep"));
            var cards = new List<Card> {new Card("A"), new Card("A"), new Card("A"), new Card("A")};
            _cardGeneratorMock.Setup(x => x.GenerateCards(4)).Returns(cards);

            var gameState = _sut.Reduce(originalGameState, new StartGameAction());
            gameState.Cards.ShouldBe(cards);
        }
    }
}
