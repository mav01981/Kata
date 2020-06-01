
using Bowling.Library;
using Xunit;

namespace Bowling.Tests
{
    public class BowlingTests
    {
        [Fact(DisplayName = "Frame 1/Attempt 1 : no strike : 2 bowls allowed")]
        [Trait("Bowling", "Players")]
        public void Frame1_Scores7_TwoBowlsAllowed()
        {
            var player = new Player("James");

            player.Bowl(1, 1, 7);

            Assert.True(player.Attempts == 2);
        }

        [Fact(DisplayName = "Frame 1/Attempt 2: 6 and 4 for SPARE : 0 No extra bowl allowed.")]
        [Trait("Bowling", "Players")]
        public void Frame1_SPARE_ScoresTen()
        {
            var player = new Player("James");

            player.Bowl(1, 1, 6);
            player.Bowl(1, 2, 4);

            Assert.True(player.TotalScore == 10);
            Assert.True(player.Attempts == 0);
        }

        [Fact(DisplayName = "Frame 10/Attempt 1 : STRIKE : Three bowls allowed")]
        [Trait("Bowling", "Players")]
        public void FrameTen_Strike_AllowedThreeBowls()
        {
            var player = new Player("James");

            player.Bowl(10, 1, 10);

            Assert.True(player.TotalScore == 10);
            Assert.True(player.Attempts == 3);
        }

        [Fact(DisplayName = "Frame 10/Attempt2 SPARE with 1 bowl remaining")]
        [Trait("Bowling", "Players")]
        public void FrameTen_SPARE_3BowlsRequired()
        {
            var player = new Player("James");

            player.Bowl(10, 1, 9);
            player.Bowl(10, 2, 1);

            Assert.True(player.TotalScore == 10);
            Assert.True(player.Attempts == 3);
        }

        [Fact(DisplayName = "Frame 10 : STRIKE STRIKE STRIKE : scores 30")]
        [Trait("Bowling", "Players")]
        public void FrameTen_STRIKESTRIKESTRIKE_returnsTotalScore30()
        {
            var player = new Player("James");
 
            player.Bowl(10, 1, 10);
            player.Bowl(10, 2, 10);
            player.Bowl(10, 3, 10);

            Assert.True(player.TotalScore == 30);
            Assert.True(player.Attempts ==3);
        }

        [Fact(DisplayName = "Frame 10: 9,1,Strike for SPARE with score of 20 with 0 bowls remaining")]
        [Trait("Bowling", "Players")]
        public void FrameTen_SPARE_STRIKE_0BowlRemaining()
        {
            var player = new Player("James");

            player.Bowl(10, 1, 9);
            player.Bowl(10, 2, 1);
            player.Bowl(10, 3, 10);

            Assert.True(player.TotalScore == 20);
            Assert.True(player.Attempts == 3);
        }

        [Fact(DisplayName = "Frame 10: STRIKE,9,1 for SPARE with score of 20 with 0 bowls remaining")]
        [Trait("Bowling", "Players")]
        public void FrameTen_STRIKESPARE_ThreeBowls()
        {
            var player = new Player("James");

            player.Bowl(10, 1, 10);
            player.Bowl(10, 2, 1);
            player.Bowl(10, 3, 9);

            Assert.True(player.TotalScore == 20);
            Assert.True(player.Attempts == 3);
        }
    }
}
