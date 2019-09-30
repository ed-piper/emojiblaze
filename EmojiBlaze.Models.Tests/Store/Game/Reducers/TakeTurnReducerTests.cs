using System.Collections.Generic;
using System.Linq;
using EmojiBlaze.Models.Store.Game;
using EmojiBlaze.Models.Store.Game.Actions;
using EmojiBlaze.Models.Store.Game.Reducers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EmojiBlaze.Models.Tests.Store.Game.Reducers
{
    [TestClass]
    public class TakeTurnReducerTests
    {
        private TakeTurnReducer _sut;
        private List<Card> _cards;

        [TestInitialize]
        public void Init()
        {
            _sut = new TakeTurnReducer();
            _cards = new List<Card>
            {
                new Card("A"),
                new Card("B"),
                new Card("A"),
                new Card("B"),
            };
        }

        [TestMethod]
        public void Reduce_ZeroCardsTurnedTakeTurn_ReturnsCorrectState()
        {
            var gameState = new GameState {Cards = _cards };
            var result = _sut.Reduce(gameState, new TakeTurnAction(_cards[0]));
            result.Cards[0].IsFaceDown.ShouldBeFalse();
            result.Cards[1].IsFaceDown.ShouldBeTrue();
            result.Cards[2].IsFaceDown.ShouldBeTrue();
            result.Cards[3].IsFaceDown.ShouldBeTrue();
        }

        [TestMethod]
        public void Reduce_OneCardTurnedTakeTurnNoMatch_ReturnsCorrectState()
        {
            _cards[0].IsFaceDown = false;
            var gameState = new GameState { Cards = _cards };
            gameState.Players.Add(new Player("Suzie Sheep") { HasCurrentTurn = true, Score = 0});
            gameState.Players.Add(new Player("Peppa Pig") { HasCurrentTurn = false, Score = 0 });

            var result = _sut.Reduce(gameState, new TakeTurnAction(_cards[1]));
            result.Cards[0].IsFaceDown.ShouldBeFalse();
            result.Cards[1].IsFaceDown.ShouldBeFalse();
            result.Cards[2].IsFaceDown.ShouldBeTrue();
            result.Cards[3].IsFaceDown.ShouldBeTrue();

            result.Players[0].HasCurrentTurn.ShouldBeFalse();
            result.Players[0].Score.ShouldBe(0);
            result.Players[1].HasCurrentTurn.ShouldBeTrue();
            result.Players[1].Score.ShouldBe(0);
        }

        [TestMethod]
        public void Reduce_OneCardTurnedTakeTurnMatch_ReturnsCorrectState()
        {
            _cards[0].IsFaceDown = false;
            var gameState = new GameState { Cards = _cards };
            gameState.Players.Add(new Player("Suzie Sheep") { HasCurrentTurn = true, Score = 0 });
            gameState.Players.Add(new Player("Peppa Pig") { HasCurrentTurn = false, Score = 0 });

            var result = _sut.Reduce(gameState, new TakeTurnAction(_cards[2]));
            result.Cards[0].IsFaceDown.ShouldBeFalse();
            result.Cards[1].IsFaceDown.ShouldBeTrue();
            result.Cards[2].IsFaceDown.ShouldBeFalse();
            result.Cards[3].IsFaceDown.ShouldBeTrue();

            result.Players[0].HasCurrentTurn.ShouldBeFalse();
            result.Players[0].Score.ShouldBe(1);
            result.Players[1].HasCurrentTurn.ShouldBeTrue();
            result.Players[1].Score.ShouldBe(0);
        }


        [TestMethod]
        public void Reduce_OneCardTurnedTakeTurnMatchAndAllCardsTurned_ReturnsCorrectState()
        {
            _cards[0].IsFaceDown = false;
            _cards[1].IsInPlay = false;
            _cards[3].IsInPlay = false;

            var gameState = new GameState { Cards = _cards };
            gameState.Players.Add(new Player("Suzie Sheep") { HasCurrentTurn = true, Score = 1 });
            gameState.Players.Add(new Player("Peppa Pig") { HasCurrentTurn = false, Score = 0 });

            var result = _sut.Reduce(gameState, new TakeTurnAction(_cards[2]));

            result.Cards.Any(x => x.IsInPlay).ShouldBeFalse();
            
            result.Players[0].HasCurrentTurn.ShouldBeFalse();
            result.Players[0].Score.ShouldBe(2);
            result.Players[1].HasCurrentTurn.ShouldBeTrue();
            result.Players[1].Score.ShouldBe(0);

            result.GameStage.ShouldBe(GameStage.Completed);
        }

        [TestMethod]
        public void Reduce_TwoCardsTurnedTakeTurn_ReturnsCorrectState()
        {
            _cards[0].IsFaceDown = false;
            _cards[1].IsFaceDown = false;

            var gameState = new GameState { Cards = _cards };
            var result = _sut.Reduce(gameState, new TakeTurnAction(_cards[2]));
            result.Cards[0].IsFaceDown.ShouldBeTrue();
            result.Cards[1].IsFaceDown.ShouldBeTrue();
            result.Cards[2].IsFaceDown.ShouldBeFalse();
            result.Cards[3].IsFaceDown.ShouldBeTrue();
        }
    }
}