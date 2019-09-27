using System.Linq;
using EmojiBlaze.Models.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EmojiBlaze.Models.Tests.Board
{
    [TestClass]
    public class CardGeneratorTests
    {
        private CardGenerator _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new CardGenerator();
        }

        [TestMethod]
        public void GenerateCards_WithWidthOf8_Generates64Cards()
        {
            var result = _sut.GenerateCards(8);
            result.Count.ShouldBe(64);
        }

        [TestMethod]
        public void GenerateCards_WithWidthOf8_GeneratesEvenNumberOfEachCard()
        {
            var result = _sut.GenerateCards(8);
            var groups = result.GroupBy(x => x.Symbol);
            foreach (var group in groups)
            {
                (group.Count() % 2 == 0).ShouldBeTrue();
            }

        }
    }
}