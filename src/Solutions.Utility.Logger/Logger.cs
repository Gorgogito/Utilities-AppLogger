namespace Solutions.Utility.AppLogger
{
    public class Logger : ILogger
    {

        private string _path = "C:";
        private string _file = "Log_" + DateTime.Now.ToString("yyyyMMdd");
        private string _dateformat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");

        #region HELPER

        private void Add(string sLog)
        {
            CreateDirectory();
            string cadena = "";

            cadena += sLog + Environment.NewLine;

            StreamWriter sw = new StreamWriter(_path + "\\" + _file, true);
            sw.Write(cadena);
            sw.Close();
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        public void AddFile(string file)
        { this._file = file; }

        public void AddPath(string path)
        { this._path = path; }

        public void DateFormatLog(string format)
        { _dateformat = format; }

        public void Info(string message)
        { Add(_dateformat + " [INFO] " + message); }

        public void Debug(string message)
        { Add(_dateformat + " [DEBUG] " + message); }

        public void Warn(string message)
        { Add(_dateformat + " [WARNNIG] " + message); }

        public void Error(string message)
        { Add(_dateformat + " [ERROR] " + message); }

        public void Fatal(string message)
        { Add(_dateformat + " [FATAL] " + message); }


        public void InfoFormat(string message, params object[] args)
        { Add(_dateformat + " [INFO] " + string.Format(message, args)); }

        public void DebugFormat(string message, params object[] args)
        { Add(_dateformat + " [DEBUG] " + string.Format(message, args)); }

        public void WarnFormat(string message, params object[] args)
        { Add(_dateformat + " [WARNNIG] " + string.Format(message, args)); }

        public void ErrorFormat(string message, params object[] args)
        { Add(_dateformat + " [ERROR] " + string.Format(message, args)); }

        public void FatalFormat(string message, params object[] args)
        { Add(_dateformat + " [FATAL] " + string.Format(message, args)); }

    }
}
