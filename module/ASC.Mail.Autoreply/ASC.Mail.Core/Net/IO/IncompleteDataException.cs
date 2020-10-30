/*
 *
 * (c) Copyright Ascensio System Limited 2010-2020
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/


namespace ASC.Mail.Net.IO
{
    #region usings

    using System;

    #endregion

    /// <summary>
    /// The exception that is thrown when incomplete data received.
    /// For example for ReadPeriodTerminated() method reaches end of stream before getting period terminator.
    /// </summary>
    public class IncompleteDataException : Exception
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IncompleteDataException() {}

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="message">Exception message text.</param>
        public IncompleteDataException(string message) : base(message) {}

        #endregion
    }
}