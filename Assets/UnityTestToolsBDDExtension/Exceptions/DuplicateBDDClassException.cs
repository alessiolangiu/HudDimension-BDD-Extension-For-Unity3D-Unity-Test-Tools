//-----------------------------------------------------------------------
// <copyright file="DuplicateBDDClassException.cs" company="Hud Dimesion">
//     Copyright (c) Hud Dimension. All rights reserved.
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
using System;
using System.Runtime.Serialization;

namespace HudDimension.UnityTestBDD
{
    /// <summary>
    /// This exception is raised when the same class is attached more than once as component to the same Integration Test.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class DuplicateBDDComponentException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateBDDComponentException" /> class.
        /// </summary>
        public DuplicateBDDComponentException() : base()
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="DuplicateBDDComponentException" /> class with the description of the exception.
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        public DuplicateBDDComponentException(string message) : base(message)
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="DuplicateBDDComponentException" /> class with the description of the exception and the inner exception.
        /// </summary>
        /// <param name="message">This is the description of the exception</param>
        /// <param name="innerException">Inner exception</param>
        public DuplicateBDDComponentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="DuplicateBDDComponentException" /> class with serialization support.
        /// </summary>
        /// <param name="info">Instance of SerializationInfo</param>
        /// <param name="context">Instance of StreamingContext</param>
        protected DuplicateBDDComponentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}