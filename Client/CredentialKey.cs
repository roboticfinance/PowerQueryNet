using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerQueryNet.Client
{
    /// <summary>
    /// Credential to access a web ressource from the Power Query (M) formulas.
    /// </summary>
    public class CredentialKey : Credential
    {
        /// <summary>
        /// URL address of the ressource
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Key value
        /// </summary>
        public string Key { get; set; }
    }
}
