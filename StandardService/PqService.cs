using System;
using System.Collections.Generic;
using System.Text;
using PowerQueryNet.Client;

namespace PowerQueryNet.Service
{
    class PqService : IPowerQueryService
    {
        private static PowerQueryService powerQueryService = new PowerQueryService();
        public PowerQueryResponse Execute(PowerQueryCommand powerQueryCommand)
        {
            return null;
        }

        public string MashupFromFile(string fileName)
        {
            return null;
        }
    }
