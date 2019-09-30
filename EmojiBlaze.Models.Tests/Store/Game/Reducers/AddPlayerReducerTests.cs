using System.Linq;
using EmojiBlaze.Models.Store.Game;
using EmojiBlaze.Models.Store.Game.Actions;
using EmojiBlaze.Models.Store.Game.Reducers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EmojiBlaze.Models.Tests.Store.Game.Reducers
{
    [TestClass]
    public class AddPlayerReducerTests
    {
        private AddPlayerReducer _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new AddPlayerReducer();
        }

        [TestMethod]
        public void Reduce_WithUniquePlayerName_AddsPlayer()
        {
            const string playerName = "Peppa Pig";

            var gameState = new GameState();
            var updatedState = _sut.Reduce(gameState, new AddPlayerAction(playerName));
            updatedState.Players.Count.ShouldBe(1);
            updatedState.Players.Single().Name.ShouldBe(playerName);
        }

        [TestMethod]
        public void Reduce_WithPreviouslyUserPlayerName_DoesNotAddPlayer()
        {
            const string playerName = "Peppa Pig";
            var gameState = new GameState();
            gameState.Players.Add(new Player(playerName));

            var updatedState = _sut.Reduce(gameState, new AddPlayerAction(playerName));
            updatedState.Players.Count.ShouldBe(1);
            updatedState.Players.Single().Name.ShouldBe(playerName);
        }
    }
}