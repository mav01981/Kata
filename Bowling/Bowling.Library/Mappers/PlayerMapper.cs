namespace BowlingLibrary
{
    public static class PlayerMapper
    {
        public static Player MapRules(this Player player, Status status, int attempt)
        {
            player.Status = status;

            if (player.Status != Status.STRIKE && player.Bonus > 0)
            {
                player.TotalScore += player.Bonus;
                player.Bonus = 0;
            }

            bool isLastFrame = player.Frame == 10;

            switch (player.Status)
            {
                case Status.STRIKE:
                    player.Bonus = !isLastFrame ? 10 : 0;
                    player.RemainingBowls = isLastFrame ? (3 - attempt) : 0;
                    break;
                case Status.SPARE:
                    player.RemainingBowls = isLastFrame ? 1 : 0;
                    break;
                default:
                    player.RemainingBowls = isLastFrame ? (3 - attempt) : !isLastFrame ? attempt == 2 ? 0 : 1 : 0;
                    break;
            }

            return player;
        }
    }
}