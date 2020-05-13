using BowlingLibrary;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Bowling
{
    public class GameTests
    {
        [Fact(DisplayName = "Frame 1 Bowler bowls STRIKE 1 Bowl")]
        [Trait("Bowling", "Game")]
        public void PlayerFirstFrame_Strike_ReturnsOneBowl()
        {
            //Arrange
            var player = new Player("Jon"); ;
            var game = new Game(new List<Player> { player });
            //Act 
            game.Play(10);
            //Assert
            Assert.True(game.scores.Where(x => x.Frame == 1).Count() == 1);
            Assert.True(game.scores.FirstOrDefault(x => x.Frame == 1).Value == 10);
        }

        [Fact(DisplayName = "Frame 1 Bowler bowls STRIKE STRIKE STRIKE Frame Score 30.")]
        [Trait("Bowling", "Game")]
        public void PlayerLastFrame_Strike_ReturnsThreeBowls()
        {
            //Arrange
            var player = new Player("Jon"); ;
            var game = new Game(new List<Player> { player }, 10);
            //Act 
            game.Play(1, 10);
            //Assert
            Assert.True(game.scores.Where(x => x.Frame == 10).Count() == 3);
        }

        [Fact(DisplayName = "Frame 10 Bowler bowls SPARE and has 3 bowls.")]
        [Trait("Bowling", "Game")]
        public void PlayerLastFrame_SPARE_ReturnsThreeBowls()
        {
            //Arrange
            var player = new Player("Jon"); ;
            var game = new Game(new List<Player> { player }, 10);
            //Act 
            game.Play(1, 9);
            //Assert
            Assert.True(game.scores.Where(x => x.Frame == 10).Count() == 3);
        }

        [Fact(DisplayName = "Frame 10 Bowler bowls NO STRIKE, NO SPARE and has 2 bowls.")]
        [Trait("Bowling", "Game")]
        public void PlayerLastFrame_NoStrikeNoSpare_ReturnsTwoBowls()
        {
            //Arrange
            var player = new Player("Jon"); ;
            var game = new Game(new List<Player> { player }, 10);
            //Act 
            game.Play(1, 1);
            //Assert
            Assert.True(game.scores.Where(x => x.Frame == 1).Count() == 2);
        }
    }
}
