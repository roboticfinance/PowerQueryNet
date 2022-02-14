﻿using Microsoft.Data.Mashup;
using Microsoft.Mashup.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerQueryNet.Engine
{
    public class CommandCredentials
    {
        internal CredentialStore CredentialStore { get; set; }

        public CommandCredentials()
        {
            CredentialStore = new CredentialStore();
        }

        public void SetCredentialFile(string fileName)
        {
            DataSource dataSource = new DataSource("File", fileName);
            DataSourceSetting dataSourceSetting = new DataSourceSetting("Windows");

            CredentialStore.SetCredential(dataSource, dataSourceSetting, null);

            return;
        }

        public void SetCredentialFolder(string folderName)
        {
            DataSource dataSource = new DataSource("Folder", folderName);
            DataSourceSetting dataSourceSetting = new DataSourceSetting("Windows");

            CredentialStore.SetCredential(dataSource, dataSourceSetting, null);

            return;
        }

        public void SetCredentialWeb(string url, string userName, string password)
        {
            DataSource dataSource = new DataSource("Web", url);
            DataSourceSetting dataSourceSetting;
            if (userName == null)
                dataSourceSetting = new DataSourceSetting("Anonymous");
            else
                dataSourceSetting = DataSourceSetting.CreateUsernamePasswordCredential(userName, password);

            CredentialStore.SetCredential(dataSource, dataSourceSetting, null);


            return;
        }

        public void SetCredentialSQL(string sql, string userName, string password)
        {
            DataSource dataSource = new DataSource("SQL", sql);
            DataSourceSetting dataSourceSetting;
            if (userName == null)
                dataSourceSetting = new DataSourceSetting("Windows");
            else
                dataSourceSetting = DataSourceSetting.CreateUsernamePasswordCredential(userName, password);

            CredentialStore.SetCredential(dataSource, dataSourceSetting, null);

            return;
        }

        public void SetCredentialOData(string url, string userName, string password)
        {
            DataSource dataSource = new DataSource("OData", url);
            DataSourceSetting dataSourceSetting;
            if (userName == null)
                dataSourceSetting = new DataSourceSetting("Anonymous");
            else
                dataSourceSetting = DataSourceSetting.CreateUsernamePasswordCredential(userName, password);

            CredentialStore.SetCredential(dataSource, dataSourceSetting, null);


            return;
        }

        public void SetCredentialKey(string url, string key)
        {
            DataSource dataSource = new DataSource("AzureBlobs", url);
            DataSourceSetting dataSourceSetting = DataSourceSetting.CreateKeyCredential(key);

            CredentialStore.SetCredential(dataSource, dataSourceSetting, null);

            return;
        }

        public bool LoadCredentials(string fileName)
        {
            try
            {
                using (FileStream fileStream = File.OpenRead(fileName))
                    CredentialStore.Load((Stream)fileStream);
                return true;
            }
            catch (Exception ex)
            {
                if (!Microsoft.Mashup.Common.SafeExceptions.IsSafeException(ex))
                {
                    throw;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
