namespace HudDimension.UnityTestBDD
{
    public class AssertionResultRetry : IAssertionResult
    {
        public AssertionResultRetry(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }
    }
}
