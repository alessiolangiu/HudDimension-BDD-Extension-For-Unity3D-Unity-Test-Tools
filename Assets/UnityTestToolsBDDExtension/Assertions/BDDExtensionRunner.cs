﻿using UnityEngine;

namespace HudDimension.UnityTestBDD
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