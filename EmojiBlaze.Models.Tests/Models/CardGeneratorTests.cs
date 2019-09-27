using EmojiBlaze.Models.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EmojiBlaze.Tests.Models
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
    }
}