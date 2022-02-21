﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerQueryNet.Client
{
    /// <summary>
    /// Enumerates the different output formats allowed in the ExecutionResponse.
    /// </summary>
    [Flags]
    public enum ExecuteOutputFlags
    {

        /// <summary>
        /// Outputs result to comma-separated values (CSV)
        /// </summary>
        Csv = 1,

        /// <summary>
        /// Outputs result to DataTable
        /// </summary>
        DataTable = 2,

        /// <summary>
        /// Outputs result to HTML
        /// </summary>
        Html = 4,

        /// <summary>
        /// Outputs result to JSON
        /// </summary>
        Json = 8,

        /// <summary>
        /// Outputs result to a SQL Server Table
        /// </summary>
        Sql = 16,

        /// <summary>
        /// Outputs result to Xml
        /// </summary>
        Xml = 32
    }
}
