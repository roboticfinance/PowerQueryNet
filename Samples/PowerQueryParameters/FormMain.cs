﻿using System;
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

namespace PowerQuery.Samples
{
    public partial class FormMain : Form
    {
        private string myQueriesPath = Path.Combine(Environment.CurrentDirectory, @"MyQueries");
        private string myExcelPath = Path.Combine(Environment.CurrentDirectory, @"MyExcel");

        public FormMain()
        {
            InitializeComponent();            
        }

        private void BtnList1and2_Click(object sender, EventArgs e)
        {
            var pq = new PowerQueryCommand
            {
                Queries = Queries.LoadFromFolder(myQueriesPath), //Load every .pq file found in MyQueries folder
            };

            //Add parameters to the queries
            pq.Queries.Add("List1Xls", string.Format("\"{0}\"", Path.Combine(myExcelPath, "List1.xls")));
            pq.Queries.Add("List2Xlsx", string.Format("\"{0}\"", Path.Combine(myExcelPath, "List2.xlsx")));

            //Add the required credentials
            pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "List1.xls") });
            pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "List2.xlsx") });

            //Execute List1and2 query. This query combines results from List1 and List2 queries
            var result = pq.Execute("List1and2");

            DisplayResult(result);
        }

        private void BtnList1_Click(object sender, EventArgs e)
        {
            var pq = new PowerQueryCommand
            {
                Queries = Queries.LoadFromFolder(myQueriesPath), //Load every .pq file found in MyQueries folder
            };

            //Add parameter to the query
            pq.Queries.Add("List1Xls", string.Format("\"{0}\"", Path.Combine(myExcelPath, "List1.xls")));

            //Add the required credentials
            pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "List1.xls") });

            var result = pq.Execute("List1");

            DisplayResult(result);
        }

        private void BtnList2_Click(object sender, EventArgs e)
        {
            var pq = new PowerQueryCommand
            {
                Queries = Queries.LoadFromFolder(myQueriesPath), //Load every .pq file found in MyQueries folder
            };

            //Add parameter to the query
            pq.Queries.Add("FinXlsx", string.Format("\"{0}\"", Path.Combine(myExcelPath, "4-财务报表表样.xlsx")));

            //Add the required credentials
            pq.Credentials.Add(new CredentialFile { Path = Path.Combine(myExcelPath, "4-财务报表表样.xlsx") });

            var result = pq.Execute("Fin");

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
                dgvResult.DataSource = result.DataTable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new PowerQuery.Samples2.Form2();
            form2.ShowDialog();
        }
    }
}
