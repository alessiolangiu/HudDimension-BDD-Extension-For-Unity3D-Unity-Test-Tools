using UnityTest;

namespace HudDimension.UnityTestBDD
{
    public class AssertionSuccessful : ActionBase
    {
        public override string GetFailureMessage()
        {
            return GetType().Name + ": assertion success.\n";
        }

        protected override bool Compare(object objVal)
        {
            return true;
        }
    }
}
