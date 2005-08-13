// 
// Copyright (c) 2004,2005 Jaroslaw Kowalski <jkowalski@users.sourceforge.net>
// 
// 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer. 
// 
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution. 
// 
// * Neither the name of the Jaroslaw Kowalski nor the names of its 
//   contributors may be used to endorse or promote products derived from this
//   software without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.
// 

#if !NETCF

using System;

namespace NLog.Targets
{
    /// <summary>
    /// Writes logging messages to the console.
    /// </summary>
    /// <example>
    /// To set up the Console target in the configuration file, 
    /// use the following syntax:
    /// <xml src="examples/targets/Console/ConsoleTarget.nlog" />
    /// To set up the log target programmatically use code like this:
    /// <cs src="examples/targets/Console/ConsoleTarget.cs" />
    /// </example>
    [Target("Console")]
    public sealed class ConsoleTarget: Target
    {
        private bool _error = false;

        /// <summary>
        /// Send the logging messages to the standard error instead of the standard output.
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }

        /// <summary>
        /// Writes the specified logging event to the console <see cref="System.Console.Out"/> or
        /// <see cref="System.Console.Error" /> depending on the value of the
        /// <see cref="ConsoleTarget.Error" /> flag.
        /// </summary>
        /// <param name="ev">The logging event.</param>
        protected internal override void Append(LogEventInfo ev)
        {
            if (Error)
            {
                Console.Error.WriteLine(CompiledLayout.GetFormattedMessage(ev));
            }
            else
            {
                Console.Out.WriteLine(CompiledLayout.GetFormattedMessage(ev));
            }
        }
    }
}

#endif
