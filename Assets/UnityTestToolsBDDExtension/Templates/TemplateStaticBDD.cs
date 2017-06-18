using HudDimension.UnityTestBDD;

public class TemplateStaticBDDComponent : StaticBDDComponent
{
    [Given(1, "given text", Delay = 1000f)]
    public IAssertionResult GivenMethod()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        return result;
    }

    [When(1, "when text")]
    public IAssertionResult WhenMethod()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        return result;
    }

    [Then(1, "then text")]
    public IAssertionResult ThenMethod()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        return result;
    }
}