
using Bowling.Library;
using Xunit;

namespace Bowling.Tests
{
    public class BowlingTests
    {
        private IFrameFactory frameFactory = new FrameFactory();

        [Fact(DisplayName = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9- (20 rolls: 10 pairs of 9 and miss) = 10 frames * 9 points = 90")]
        [Trait("Bowling", "Players")]
        public void TwentyRolls_NineAndMiss_Scores90()
        {
            var game = new Game(frameFactory);

            for (int i = 1; i <= 10; i++)
            {
                game.Roll(9);
                game.Roll(0); // 0 + 9  =>9
            }

            Assert.True(game.Score() == 90);
        }

        [Fact(DisplayName = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9- (20 rolls: 10 pairs of 9 and miss) = 10 frames * 9 points = 90")]
        [Trait("Bowling", "Players")]
        public void TwentyRolls_MissAndNine_Scores90()
        {
            var game = new Game(frameFactory);

            for (int i = 1; i <= 10; i++)
            {
                game.Roll(0);
                game.Roll(9); // 0 + 9  =>9
            }

            Assert.True(game.Score() == 90);
        }

        [Fact(DisplayName = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5 12 21 rolls: 10 pairs of 5 and spare, with a final 5) = 10 frames * 15 points = 150")]
        [Trait("Bowling", "Players")]
        public void TwentyOneRolls_5ANDSPARE_Scores150()
        {
            var game = new Game(frameFactory);

            for (int i = 1; i <= 10; i++)
            {
                game.Roll(5);
                game.Roll(5);     // 5 +5 +5 =>15
                if (i == 10)
                {
                    game.Roll(5);
                }
            }

            Assert.True(game.Score() == 150);
        }

        [Fact(DisplayName = "X X X X X X X X X X X X 12 rolls: 12 strikes")]
        [Trait("Bowling", "Players")]
        public void TwelveRolls_TwelveStrikes_Scores300()
        {
            var game = new Game(frameFactory);

            for (int i = 1; i <= 10; i++)
            {
                game.Roll(10);   // 10 +10 +10 =>30
                if (i == 10) // 2 more bowls
                {
                    game.Roll(10);
                    game.Roll(10);
                }
            }

            Assert.True(game.Score() == 300);
        }

    }
}
