namespace HudDimension.UnityTestBDD
{
    public class AssertionResultSuccessful : IAssertionResult
    {
        public AssertionResultSuccessful()
        {
        }

        internal string Text
        {
            get
            {
                return "OK";
            }
        }
    }
}
