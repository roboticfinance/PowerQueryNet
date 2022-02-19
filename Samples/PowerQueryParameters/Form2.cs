using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerQueryNet.Client;
using System.IO;

namespace PowerQuery.Samples2
{
    public partial class Form2 : Form
    {
        private string myQueriesPath = Path.Combine(Environment.CurrentDirectory, @"MyQueries");
        private string myExcelPath = Path.Combine(Environment.CurrentDirectory, @"MyExcel");

        public Form2()
        {
            InitializeComponent();            
        }

        //private void BtnList1and2_Click(object sender, EventArgs e)
        //{
        //    var pq = new PowerQueryCommand
        //    {
        //        Queries = Queries.LoadFromFolder(myQueriesPath), //Load every .pq file found in MyQueries folder
        //    };

        //    //Add parameters to the queries
        //    pq.Queries.Add("List1Xls", string.Format("\"{0}\"", Path.Combine(myExcelPath, "List1.xls")));
        //    pq.Queries.Add("List2Xlsx", string.Format("\"{0}\"", Path.Combine(myExcelPath, "List2.xlsx")));

        //    //Add the required credentials
        //    pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "List1.xls") });
        //    pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "List2.xlsx") });

        //    //Execute List1and2 query. This query combines results from List1 and List2 queries
        //    var result = pq.Execute("List1and2");

        //    DisplayResult(result);
        //}

        //private void BtnList1_Click(object sender, EventArgs e)
        //{
        //    var pq = new PowerQueryCommand
        //    {
        //        Queries = Queries.LoadFromFolder(myQueriesPath), //Load every .pq file found in MyQueries folder
        //    };

        //    //Add parameter to the query
        //    pq.Queries.Add("List1Xls", string.Format("\"{0}\"", Path.Combine(myExcelPath, "List1.xls")));

        //    //Add the required credentials
        //    pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "List1.xls") });

        //    var result = pq.Execute("List1");

        //    DisplayResult(result);
        //}

        private void BtnList2_Click(object sender, EventArgs e)
        {
            
            var pq = new PowerQueryCommand
            {
                Queries = Queries.LoadFromFolder(myQueriesPath), //Load every .pq file found in MyQueries folder
            };

            //var fileURL = "https://synapse4cdm.blob.core.windows.net/excels/4-%E8%B4%A2%E5%8A%A1%E6%8A%A5%E8%A1%A8%E8%A1%A8%E6%A0%B7.xlsx";
            var credentialURL = "https://synapse4cdm.blob.core.windows.net/excels";
            txtPara1.Text = string.Format("\"{0}\"", Path.Combine(credentialURL, "4-财务报表表样.xlsx"));
            //txtPara1.Text = string.Format("\"{0}\"", fileURL);
            txtPara2.Text = string.Format("\"{0}\"", "Table1");
            //Add parameter to the query
            pq.Queries.Add("XlsxFilePath", txtPara1.Text);
            pq.Queries.Add("TableName", txtPara2.Text);
            //Add the required credentials
            //pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "4-财务报表表样.xlsx") });
            //pq.Credentials.Add(new CredentialFile { Path = fileURL });

            pq.Credentials.Add(new CredentialKey { Url = credentialURL, Key = "jzwzk378y/lHaSA4hkyqscgYjBTgqD/tW24pw4rMs9kkwMw2QuqCnb+4X7ax244P66vjVzAiRO1I0ScCkDEepg==" });
            var result = pq.Execute("FinBlob");

            DisplayResult(result);
        }

        private void DisplayResult(PowerQueryResponse result)
        {
            if (result == null)
            {
                MessageBox.Show("Result is null.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result.ExceptionMessage != null)
            {
                MessageBox.Show(result.ExceptionMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvResult2.DataSource = result.DataTable;
            }
        }
        
    }
}
