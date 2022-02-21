using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PowerQueryNet.Client;
using System.IO;
using PowerQueryNet.Service;
namespace NetAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private static PowerQueryService powerQueryService = new PowerQueryService();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "chris", "han" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody] string value)
        {
            var pq = new PowerQueryCommand();
            pq.ExecuteOutputFlags = ExecuteOutputFlags.Json;
            //pq.ExecuteOutputFlags = ExecuteOutputFlags.Sql;
            //pq.SqlConnectionString = "Server=tcp:data-ops.database.chinacloudapi.cn,1433;Initial Catalog=trial_C;Persist Security Info=False;User ID=linhongming;Password=IbmawvFLSdQg9q2X;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //pq.SqlTableName = "Lake_Test";

            string queryFomula = @"    
                let
                    Source = AzureStorage.Blobs(BlobURL),
                #""Excelbook"" = Source{[#""Folder Path""=BlobURL,Name=XlsxFileName]}[Content],
                #""Imported Excel Workbook"" = Excel.Workbook(#""Excelbook""),
                    Table1_Table = #""Imported Excel Workbook""{[Item=TableName,Kind=""Table""]}[Data],
                    //Table1_Table = Source{[Item=TableName,Kind=""Table""]}[Data] ,
                    #""Changed Type"" = Table.TransformColumnTypes(Table1_Table,{{""资        产asset"", type text}, {""年初数"", type number}, {""期末数"", type number}}),
                    #""Filtered Rows"" = Table.SelectRows(#""Changed Type"", each ([资        产asset] <> null)),
                    #""Added Conditional Column"" = Table.AddColumn(#""Filtered Rows"", ""Custom"", each if not Text.StartsWith([资        产asset], "" "") then [资        产asset] else null),
                    #""Filled Down"" = Table.FillDown(#""Added Conditional Column"",{""Custom""}),
                    #""Renamed Columns"" = Table.RenameColumns(#""Filled Down"",{{""Custom"", ""Level1""}}),
                    #""Added Conditional Column1"" = Table.AddColumn(#""Renamed Columns"", ""Custom"", each if Text.StartsWith([资        产asset], "" "") then [资        产asset] else null),
                    #""Split Column by Delimiter"" = Table.SplitColumn(#""Added Conditional Column1"", ""Custom"", Splitter.SplitTextByEachDelimiter({""    ""}, QuoteStyle.Csv, false), {""Custom.1"", ""Custom.2""}),
                    #""Changed Type1"" = Table.TransformColumnTypes(#""Split Column by Delimiter"",{{""Custom.1"", type text}, {""Custom.2"", type text}}),
                    #""Removed Columns"" = Table.RemoveColumns(#""Changed Type1"",{""Custom.1""}),
                    #""Renamed Columns1"" = Table.RenameColumns(#""Removed Columns"",{{""Custom.2"", ""Level2""}}),
                    #""Filtered Rows1"" = Table.SelectRows(#""Renamed Columns1"", each ([Level2] <> null)),
                    #""Removed Columns1"" = Table.RemoveColumns(#""Filtered Rows1"",{""资        产asset""}),
                    #""Reordered Columns"" = Table.ReorderColumns(#""Removed Columns1"",{""Level1"", ""Level2"", ""年初数"", ""期末数""}),
                    #""Replaced Value"" = Table.ReplaceValue(#""Reordered Columns"",null,0,Replacer.ReplaceValue,{""年初数""}),
                    #""Replaced Value1"" = Table.ReplaceValue(#""Replaced Value"",null,0,Replacer.ReplaceValue,{""期末数""})
                in
                    #""Replaced Value1""
                ";

            pq.Queries.Add("FinBlob", queryFomula);

            var credentialURL = "https://csdlake.blob.core.chinacloudapi.cn/excels";
            string blobURL = string.Format("\"{0}\"", credentialURL);
            string fileName = string.Format("\"{0}\"", "4-财务报表表样.xlsx"); 
            // https://csdlake blob core chinacloudapi cn/excels/_4-财务报表表样 xlsx
            //string excelBooName = Path.Combine(credentialURL.Replace("."," "), "_", fileName);
            //txtPara1.Text = string.Format("\"{0}\"", fileURL);
            string SheetName = string.Format("\"{0}\"", "Table1");
            //Add parameter to the query
            pq.Queries.Add("BlobURL", blobURL);
            pq.Queries.Add("XlsxFileName", fileName);
            // pq.Queries.Add("ExcelBooName", excelBooName);
            pq.Queries.Add("TableName", SheetName);
            //Add the required credentials
            //pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "4-财务报表表样.xlsx") });
            //pq.Credentials.Add(new CredentialFile { Path = fileURL });

            //pq.Credentials.Add(new CredentialKey { Url = credentialURL, Key = "jzwzk378y/lHaSA4hkyqscgYjBTgqD/tW24pw4rMs9kkwMw2QuqCnb+4X7ax244P66vjVzAiRO1I0ScCkDEepg==" });
            pq.Credentials.Add(new CredentialKey { Url = credentialURL, Key = "s4iAtRy12mL2JKV1xZtIMxckhYmD9eemM04UpF2xSof50yWZS4To8iqL6DpmTJBxt1m2Q0zCrp2XcYhutdwILA==" });


            PowerQueryResponse result = pq.Execute("FinBlob");
            //pq.QueryName = "FinBlob";
            //PowerQueryResponse result = powerQueryService.Execute(pq);

            //var msg = result.ExceptionMessage==null? "OK": result.ExceptionMessage;
            //return "SQL OK";
            return result.Json;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
