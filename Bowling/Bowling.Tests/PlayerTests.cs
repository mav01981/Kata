
using BowlingLibrary;
using Xunit;

namespace Tests.Bowling
{
    public class PlayerTests
    {
        [Fact(DisplayName = "Frame 1 Bowler bowls twice no strike or spare.")]
        [Trait("Bowling", "Players")]
        public void PlayerOnFirstFrame_NOStrikeNOSpare_NoBowlsRemaining()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(1, 1, 4);
            player.Bowl(1, 2, 5);
            //Assert
            Assert.True(player.FrameScore == 9);
            Assert.True(player.RemainingBowls == 0);
        }

        [Fact(DisplayName = "Frame 1 Bowler bowls 6 and 1 for SPARE.")]
        [Trait("Bowling", "Players")]
        public void PlayerOnFirstFrame_SPARE_NoBowlsRemaining()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(1, 1, 9);
            player.Bowl(1, 2, 1);
            //Assert
            Assert.True(player.TotalScore == 10);
            Assert.True(player.Bonus == 0);
            Assert.True(player.RemainingBowls == 0);
        }
        [Fact(DisplayName = "Frame 1 Bowler bowls STRIKE")]
        [Trait("Bowling", "Players")]
        public void PlayerOnFirstFrame_Strike_NoBowlsRemaining()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(1, 1, 10);
            //Assert
            Assert.True(player.TotalScore == 10);
            Assert.True(player.Bonus == 10);
            Assert.True(player.RemainingBowls == 0);
        }

        [Fact(DisplayName = "Frame 10 Bowler bowls STRIKE with 2 bowls remaining")]
        [Trait("Bowling", "Players")]
        public void PlayerOnLastFrame_Strike_2BowlsRemainingAndNoBonus()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(10, 1, 10);
            //Assert
            Assert.True(player.Bonus == 0);
            Assert.True(player.RemainingBowls == 2);
        }

        [Fact(DisplayName = "Frame 10 Bowler bowls SPARE with 1 bowl remaining")]
        [Trait("Bowling", "Players")]
        public void PlayerOnLastFrame_SPARE_1BowlRemaining()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(10, 1, 9);
            player.Bowl(10, 2, 1);
            //Assert
            Assert.True(player.FrameScore == 10);
            Assert.True(player.TotalScore == 10);
            Assert.True(player.Bonus == 0);
            Assert.True(player.RemainingBowls == 1);
        }

        [Fact(DisplayName = "Frame 10 Bowler bowls STRIKE STRIKE STRIKE with score of 30")]
        [Trait("Bowling", "Players")]
        public void PlayerOnLastFrame_STRIKESTRIKESTRIKE_returnsTotalScore30()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(10, 1, 10);
            player.Bowl(10, 2, 10);
            player.Bowl(10, 3, 10);
            //Assert
            Assert.True(player.FrameScore == 30);
            Assert.True(player.Bonus == 0);
            Assert.True(player.RemainingBowls == 0);
        }

        [Fact(DisplayName = "Frame 10 Bowler bowls 9,1 SPARE ,STRIKE with score of 20")]
        [Trait("Bowling", "Players")]
        public void PlayerOnLastFrame_SPARESTRIKE_0BowlRemaining()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(10, 1, 9);
            player.Bowl(10, 2, 1);
            player.Bowl(10, 3, 10);
            //Assert
            Assert.True(player.FrameScore == 20);
            Assert.True(player.Bonus == 0);
            Assert.True(player.RemainingBowls == 0);
        }

        [Fact(DisplayName = "Frame 10 Bowler bowls STRIKE, 9,1 for SPARE with score of 20 with 0 bowls remaining")]
        [Trait("Bowling", "Players")]
        public void PlayerOnLastFrame_STRIKESPARE_0BowlRemaining()
        {
            //Arrange
            var player = new Player("James");
            //Act 
            player.Bowl(10, 1, 9);
            player.Bowl(10, 2, 1);
            player.Bowl(10, 3, 10);
            //Assert
            Assert.True(player.FrameScore == 20);
            Assert.True(player.Bonus == 0);
            Assert.True(player.RemainingBowls == 0);
        }
    }
}
