namespace HudDimension.UnityTestBDD
{
    public class MethodParameters
    {
        public MethodParameter[] Parameters { get; set; }

        public override int GetHashCode()
        {
            if (this.Parameters == null)
            {
                return 0;
            }

            int result = 0;
            for (int index = 0; index < this.Parameters.Length; index++)
            {
                result += this.Parameters[index] == null ? 0 : this.Parameters[index].GetHashCode();
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MethodParameters methodParameters = (MethodParameters)obj;
            if (this.Parameters == null && methodParameters.Parameters == null)
            {
                return true;
            }

            if ((this.Parameters != null && methodParameters.Parameters == null)
                ||
              (this.Parameters == null && methodParameters.Parameters != null))
            {
                return false;
            }

            if (this.Parameters.Length != methodParameters.Parameters.Length)
            {
                return false;
            }

            foreach (MethodParameter methodParmeter in this.Parameters)
            {
                bool cycleResult = false;
                foreach (MethodParameter innerMethodParameter in methodParameters.Parameters)
                {
                    if (methodParmeter.Equals(innerMethodParameter))
                    {
                        cycleResult = true;
                    }
                }

                if (cycleResult == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
