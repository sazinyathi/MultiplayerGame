
namespace Winner.Models
{
    public static class Suit
    {
        public static int S = 4;
        public static int H = 3;
        public static int D = 2;
        public static int C = 1;

        public static int GetSuit(string suit)
        {
            switch (suit)
            {
                case "S":
                    return Suit.S;
                case "H":
                    return Suit.H;

                case "D":
                    return Suit.D;

                case "C":
                    return Suit.C;
                default:
                    return 0;
            }
        }
    }
}
