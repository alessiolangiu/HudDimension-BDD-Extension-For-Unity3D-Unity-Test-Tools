namespace HudDimension.UnityTestBDD
{
    public class MethodDescription : BaseMethodDescription
    {
        public string ParametersIndex { get; set; }

        public MethodParameters Parameters { get; set; }

        public string GetDecodifiedText()
        {
            string result = this.Text;
            foreach (MethodParameter parameter in this.Parameters.Parameters)
            {
                result = result.Replace("%" + parameter.ParameterInfoObject.Name + "%", parameter.Value == null ? string.Empty : parameter.Value.ToString());
            }

            return result;
        }

        public override int GetHashCode()
        {
            int result =
                 (this.ComponentObject == null ? 0 : this.ComponentObject.GetHashCode())
                 +
                 (this.Method == null ? 0 : this.Method.GetHashCode())
                 +
                 (this.StepType == null ? 0 : this.StepType.GetHashCode())
                 +
                 (this.Text == null ? 0 : this.Text.GetHashCode())
                 +
                 this.ExecutionOrder.GetHashCode()
                 +
                 (this.ParametersIndex == null ? 0 : this.ParametersIndex.GetHashCode())
                 +
                 (this.Parameters == null ? 0 : this.Parameters.GetHashCode());
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MethodDescription method = (MethodDescription)obj;
            if (((this.ComponentObject == null && method.ComponentObject == null) || object.Equals(this.ComponentObject, method.ComponentObject))
                &&
                ((this.Method == null && method.Method == null) || this.Method.Equals(method.Method))
                &&
                ((this.StepType == null && method.StepType == null) || this.StepType.Equals(method.StepType))
                &&
                ((this.Text == null && method.Text == null) || this.Text.Equals(method.Text))
                 &&
                this.ExecutionOrder.Equals(method.ExecutionOrder)
                &&
                ((this.ParametersIndex == null && method.ParametersIndex == null) || this.ParametersIndex.Equals(method.ParametersIndex))
                &&
                ((this.Parameters == null && method.Parameters == null) || this.Parameters.Equals(method.Parameters)))
            {
                return true;
            }

            return false;
        }
    }
}