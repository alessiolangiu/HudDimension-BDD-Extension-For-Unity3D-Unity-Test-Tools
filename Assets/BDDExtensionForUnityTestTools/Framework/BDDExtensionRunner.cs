//-----------------------------------------------------------------------
// <copyright file="BDDExtensionRunner.cs" company="Hud Dimension">
//     Copyright (c) Hud Dimension. All rights reserved.
//     http://www.HudDimension.co.uk
// </copyright>
//
// <disclaimer>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </disclaimer>
//
// <author>Alessio Langiu</author>
// <email>alessio.langiu@huddimension.co.uk</email>
//-----------------------------------------------------------------------
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class BDDExtensionRunner : MonoBehaviour
    {
        [SerializeField]
        private bool useFixedUpdate = false;
        [SerializeField]
        private string[] given = new string[] { string.Empty };
        [SerializeField]
        private string[] when = new string[] { string.Empty };
        [SerializeField]
        private string[] then = new string[] { string.Empty };
        [SerializeField]
        private string[] givenParametersIndex = new string[] { string.Empty };
        [SerializeField]
        private string[] whenParametersIndex = new string[] { string.Empty };
        [SerializeField]
        private string[] thenParametersIndex = new string[] { string.Empty };

        public string[] Given
        {
            get
            {
                return this.given;
            }

            set
            {
                this.given = value;
            }
        }

        public string[] When
        {
            get
            {
                return this.when;
            }

            set
            {
                this.when = value;
            }
        }

        public string[] Then
        {
            get
            {
                return this.then;
            }

            set
            {
                this.then = value;
            }
        }

        public string[] GivenParametersIndex
        {
            get
            {
                return this.givenParametersIndex;
            }

            set
            {
                this.givenParametersIndex = value;
            }
        }

        public string[] WhenParametersIndex
        {
            get
            {
                return this.whenParametersIndex;
            }

            set
            {
                this.whenParametersIndex = value;
            }
        }

        public string[] ThenParametersIndex
        {
            get
            {
                return this.thenParametersIndex;
            }

            set
            {
                this.thenParametersIndex = value;
            }
        }

        public ExtensionRunnerBusinessLogic BusinessLogic { get; private set; }

        public bool UseFixedUpdate
        {
            get
            {
                return this.useFixedUpdate;
            }

            set
            {
                this.useFixedUpdate = value;
            }
        }

        private void Start()
        {
            this.BusinessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            this.BusinessLogic.AreThereErrors = this.BusinessLogic.CheckForErrors(gameObject.GetComponents<Component>(), this.Given, this.GivenParametersIndex, this.When, this.WhenParametersIndex, this.Then, this.ThenParametersIndex);
            if (!this.BusinessLogic.AreThereErrors)
            {
                this.BusinessLogic.SetSucceedOnAssertions();
                this.BusinessLogic.MethodsDescription = this.BusinessLogic.GetAllMethodsDescriptions(gameObject.GetComponents<Component>(), this.Given, this.GivenParametersIndex, this.When, this.WhenParametersIndex, this.Then, this.ThenParametersIndex);
            }
        }

        private void Update()
        {
            if (!this.BusinessLogic.AreThereErrors && !this.useFixedUpdate)
            {
                this.BusinessLogic.IndexToRun = this.BusinessLogic.RunCycle(this.BusinessLogic, this.BusinessLogic.MethodsDescription, this.BusinessLogic.IndexToRun);
            }
        }

        private void FixedUpdate()
        {
            if (!this.BusinessLogic.AreThereErrors && this.useFixedUpdate)
            {
                this.BusinessLogic.IndexToRun = this.BusinessLogic.RunCycle(this.BusinessLogic, this.BusinessLogic.MethodsDescription, this.BusinessLogic.IndexToRun);
            }
        }
    }
}