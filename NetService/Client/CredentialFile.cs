using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerQueryNet.Client
{
    /// <summary>
    /// Credential to access a file from the Power Query (M) formulas.
    /// </summary>
    public class CredentialFile : Credential
    {
        /// <summary>
        /// Full path of the file
        /// </summary>
        public string Path { get; set; }
    }
}
