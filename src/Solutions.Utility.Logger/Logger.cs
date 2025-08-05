namespace Solutions.Utility.AppLogger
{
    public class Logger : ILogger
    {
        private string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        private string _path = "C:";
        private string _file = "Log_" + DateTime.Now.ToString("yyyyMMdd");
        private string _dateformat = "yyyy-MM-dd HH:mm:ss.fffffff"; // DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");

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
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [INFO] " + message);
        }

        public void Debug(string message)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [DEBUG] " + message);
        }

        public void Warn(string message)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [WARNNIG] " + message);
        }

        public void Error(string message)
        {

            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [ERROR] " + message);
        }

        public void Fatal(string message)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [FATAL] " + message);
        }


        public void InfoFormat(string message, params object[] args)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [INFO] " + string.Format(message, args));
        }

        public void DebugFormat(string message, params object[] args)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [DEBUG] " + string.Format(message, args));
        }

        public void WarnFormat(string message, params object[] args)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [WARNNIG] " + string.Format(message, args));
        }

        public void ErrorFormat(string message, params object[] args)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [ERROR] " + string.Format(message, args));
        }

        public void FatalFormat(string message, params object[] args)
        {
            fecha = DateTime.Now.ToString(_dateformat);
            Add(fecha + " [FATAL] " + string.Format(message, args));
        }

    }
}
