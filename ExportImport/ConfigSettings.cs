namespace ExportImport
{
    //// directives
    using System;
    using System.Configuration;

    /// <summary>
    /// Reads information from App.config
    /// </summary>
    public struct ConfigSettings
    {
        #region Fields

        /// <summary>
        /// AppSettingsReader used through class to set the private fields
        /// </summary>
        private static AppSettingsReader appsettings = new AppSettingsReader();

        /// <summary>
        /// Username to log into the ExactTarget account
        /// </summary>
        private static string etUsername = Get_etUsername();

        /// <summary>
        /// Password to log into the ExactTarget account
        /// </summary>
        private static string etPassword = Get_etPassword();

        /// <summary>
        /// Username to log into the ExactTarget account
        /// </summary>
        private static string etUsernameSbx = Get_etUsernameSbx();

        /// <summary>
        /// Password to log into the ExactTarget account
        /// </summary>
        private static string etPasswordSbx = Get_etPasswordSbx();

        /// <summary>
        /// MID of the ExactTarget account
        /// </summary>
        private static int mid = Get_mid();

        /// <summary>
        /// MID of the ExactTarget account
        /// </summary>
        private static int midSbx = Get_midSbx();

        /// <summary>
        /// FTP Username to log into the ExactTarget FTP account
        /// </summary>
        private static string etFTPUsername = Get_etFTPUsername();

        /// <summary>
        /// FTP Password to log into the ExactTarget FTP account
        /// </summary>
        private static string etFTPPassword = Get_etFTPPassword();

        private static string etListID = Get_etListID();

        private static string etProgramID = Get_etProgramID();

        private static string etSecondaryProgramID = Get_etSecondaryProgramID();

        private static string etFTPArchivePath = Get_etFTPArchivePath();

        private static string etFTPBasePath = Get_etFTPBasePath();

        private static string etFTPHostName = Get_etFTPHostName();

        private static string etFTPUsePassiveMode = Get_etFTPUsePassiveMode();

        private static string messageBody = Get_messageBody();

        private static string distributionList = Get_distributionList();


        #endregion // Fields

        #region Properties

        /// <summary>
        /// Gets Username to log into the ExactTarget account
        /// </summary>
        public static string ETUsername
        {
            get
            {
                return etUsername;
            }
        }

        /// <summary>
        /// Gets Password to log into the ExactTarget account
        /// </summary>
        public static string ETPassword
        {
            get
            {
                return etPassword;
            }
        }

        /// <summary>
        /// Gets Username to log into the ExactTarget account
        /// </summary>
        public static string ETUsernameSbx
        {
            get
            {
                return etUsernameSbx;
            }
        }

        /// <summary>
        /// Gets Password to log into the ExactTarget account
        /// </summary>
        public static string ETPasswordSbx
        {
            get
            {
                return etPasswordSbx;
            }
        }

        /// <summary>
        /// Gets MID of the ExactTarget account
        /// </summary>
        public static int MID
        {
            get
            {
                return mid;
            }
        }

        /// <summary>
        /// Gets MID of the ExactTarget account
        /// </summary>
        public static int MIDSbx
        {
            get
            {
                return midSbx;
            }
        }

        /// <summary>
        /// Gets FTP Username to log into the ExactTarget FTP account
        /// </summary>
        public static string ETFTPUsername
        {
            get
            {
                return etFTPUsername;
            }
        }

        /// <summary>
        /// Gets FTP Password to log into the ExactTarget FTP account
        /// </summary>
        public static string ETFTPPassword
        {
            get
            {
                return etFTPPassword;
            }
        }

        public static string ETListID
        {
            get
            {
                return etListID;
            }
        }

        public static string ETProgramID
        {
            get
            {
                return etProgramID;
            }
        }

        public static string ETSecondaryProgramID
        {
            get
            {
                return etSecondaryProgramID;
            }
        }

        public static string ETFTPBasePath
        {
            get
            {
                return etFTPBasePath;
            }
        }

        public static string ETFTPArchivePath
        {
            get
            {
                return etFTPArchivePath;
            }
        }

        public static string ETFTPHostName
        {
            get
            {
                return etFTPHostName;
            }
        }

        public static string MessageBody
        {
            get
            {
                return messageBody;
            }
        }

        public static string DistributionList
        {
            get
            {
                return distributionList;
            }
        }

        #endregion // Properties

        #region Methods

        #region Private methods to set private fields

        /// <summary>
        /// Reads ETUsername from App.config
        /// </summary>
        /// <returns>The method returns a string</returns>
        private static string Get_etUsername()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ETUsername", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etUsername

        /// <summary>
        /// Reads ETPassword from App.config
        /// </summary>
        /// <returns>The method returns a string</returns>
        private static string Get_etPassword()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ETPassword", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etPassword

        /// <summary>
        /// Reads ETUsername from App.config
        /// </summary>
        /// <returns>The method returns a string</returns>
        private static string Get_etUsernameSbx()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ETUsernameSbx", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etUsername

        /// <summary>
        /// Reads ETPassword from App.config
        /// </summary>
        /// <returns>The method returns a string</returns>
        private static string Get_etPasswordSbx()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ETPasswordSbx", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etPassword

        /// <summary>
        /// Reads MID from App.config
        /// </summary>
        /// <returns>The method returns an integer</returns>
        private static int Get_mid()
        {
            int z = 0;

            try
            {
                z = (int)appsettings.GetValue("MID", typeof(int));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = 0;
            }

            return z;
        } // Get_mid

        /// <summary>
        /// Reads MID from App.config
        /// </summary>
        /// <returns>The method returns an integer</returns>
        private static int Get_midSbx()
        {
            int z = 0;

            try
            {
                z = (int)appsettings.GetValue("MIDSbx", typeof(int));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = 0;
            }

            return z;
        } // Get_midSbx

        /// <summary>
        /// Reads ETFTPUsername from App.config
        /// </summary>
        /// <returns>The method returns a string</returns>
        private static string Get_etFTPUsername()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ftpUsername", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etFTPUsername

        /// <summary>
        /// Reads ETFTPPassword from App.config
        /// </summary>
        /// <returns>The method returns a string</returns>
        private static string Get_etFTPPassword()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ftpPassword", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etFTPPassword

        private static string Get_etListID()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ETListID", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etListID

        private static string Get_etProgramID()
        {
            string z = string.Empty;

            try
            {
                //z = (string)appsettings.GetValue("InboundInitialProgram", typeof(string));
                z = (string)appsettings.GetValue("TestAutomation", typeof(string));
            }
            catch (Exception ex)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etProgramID

        private static string Get_etSecondaryProgramID()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("InboundSecondaryProgram", typeof(string));
            }
            catch (Exception ex)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_etPr

        private static string Get_smtpClient()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("SMTPClient", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_smtpClient

        private static string Get_fileName()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("FileName", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_fileName

        private static string Get_sysSource()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("SysSource", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        } // Get_sysSource

        private static string Get_etFTPBasePath()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ftpBasePath", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        }

        private static string Get_etFTPArchivePath()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ftpArchivePath", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        }

        private static string Get_etFTPHostName()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("ftpHostName", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        }

        private static string Get_etFTPUsePassiveMode()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("UsePassiveMode", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        }

        private static string Get_messageBody()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("MessageBody", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        }

        private static string Get_distributionList()
        {
            string z = string.Empty;

            try
            {
                z = (string)appsettings.GetValue("DistributionList", typeof(string));
            }
            catch (Exception)
            {
                //// IDEA: log event
                z = string.Empty;
            }

            return z;
        }

        #endregion // Private methods to set private fields

        #endregion // Methods
    }
}
