using System;

namespace Winner.Models
{
    public static class Face
    {
        public static int J = 11;
        public static int Q = 12;
        public static int K = 13;
        public static int A = 1;


        public static int GetFace(string face)
        {
            switch (face)
            {
                case "J":
                    return Face.J;
                case "Q":
                    return Face.Q;

                case "K":
                    return Face.K;

                case "A":
                    return Face.A;
                default:
                    return Convert.ToInt32(face);
            }
        }

    }
}
