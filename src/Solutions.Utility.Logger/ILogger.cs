namespace Solutions.Utility.AppLogger
{

    public interface ILogger
    {
        void AddFile(string file);
        void AddPath(string path);
        void DateFormatLog(string format);

        void Info(string message);
        void Debug(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);

        void InfoFormat(string message, params object[] args);
        void DebugFormat(string message, params object[] args);
        void WarnFormat(string message, params object[] args);
        void ErrorFormat(string message, params object[] args);
        void FatalFormat(string message, params object[] args);
    }

}
