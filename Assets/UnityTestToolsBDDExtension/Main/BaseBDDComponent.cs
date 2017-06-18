using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]

namespace HudDimension.UnityTestBDD
{
    public class BaseBDDComponent : MonoBehaviour
    {
        [HideInInspector]
        public List<UnityTestBDDError> Errors = new List<UnityTestBDDError>();
        [HideInInspector]
        public bool Checking = true;
    }
}
