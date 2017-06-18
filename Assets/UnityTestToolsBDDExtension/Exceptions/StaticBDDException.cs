﻿using System;
using System.Runtime.Serialization;

namespace HudDimension.UnityTestBDD
{
    /// <summary>
    /// It is raised if you are trying to find DynamicBDDMethods inside a StaticBDDComponent.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class StaticBDDException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaticBDDException" /> class.
        /// </summary>
        public StaticBDDException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticBDDException" /> class with the description of the exception.
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        public StaticBDDException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticBDDException" /> class with the description of the exception and the inner exception.
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        /// <param name="innerException">Inner exception</param>
        public StaticBDDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticBDDException" /> class with serialization support.
        /// </summary>
        /// <param name="info">Instance of SerializationInfo</param>
        /// <param name="context">Instance of StreamingContext</param>
        protected StaticBDDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}