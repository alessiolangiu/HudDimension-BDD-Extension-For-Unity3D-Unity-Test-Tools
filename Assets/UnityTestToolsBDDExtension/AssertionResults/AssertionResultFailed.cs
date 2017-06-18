namespace HudDimension.UnityTestBDD
{
    public class AssertionResultFailed : IAssertionResult
    {
        public AssertionResultFailed(string text)
        {
            this.Text = text;
        }

        internal string Text { get; set; }
    }
}
