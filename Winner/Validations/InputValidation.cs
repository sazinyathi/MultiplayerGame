namespace Winner
{
    public  class InputValidation
    {
       
        public static string ValidateInputs(string[] playingCards)
        {
            var result = string.Empty;
            
            if (IsPlayCardEmptyOrNull(playingCards))
            {
                result = "Please ensure that playCards are captured";
            }
            

            return result;
        }
        private static bool IsPlayCardEmptyOrNull(string [] playingCards)
        {
            return (playingCards == null && playingCards.Length == 0)  ? true : false;
        }

        
    }
}
