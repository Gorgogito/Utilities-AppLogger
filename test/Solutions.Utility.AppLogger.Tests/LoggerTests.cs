using Xunit;

namespace Solutions.Utility.AppLogger.Tests
{

    public class LoggerTests : IDisposable
    {
        private readonly string _logDirectory;
        private readonly string _logFilePath;
        private readonly Logger _logger;

        public LoggerTests()
        {
            _logDirectory = Path.Combine(Path.GetTempPath(), "AppLoggerTests");
            Directory.CreateDirectory(_logDirectory);

            _logFilePath = Path.Combine(_logDirectory, $"TestLog_{DateTime.Now:yyyyMMddHHmmss}.log");

            _logger = new Logger();
            _logger.AddPath(_logDirectory);
            _logger.AddFile(Path.GetFileName(_logFilePath));
        }

        [Fact]
        public void Info_WritesMessageToLogFile()
        {
            // Arrange
            string testMessage = "This is an info log message";

            // Act
            _logger.Info(testMessage);

            // Assert
            Assert.True(File.Exists(_logFilePath));
            string contents = File.ReadAllText(_logFilePath);
            Assert.Contains(testMessage, contents);
        }

        [Fact]
        public void ErrorFormat_WritesFormattedMessage()
        {
            // Arrange
            string format = "Error code: {0}, description: {1}";
            int code = 500;
            string description = "Internal Server Error";

            // Act
            _logger.ErrorFormat(format, code, description);

            // Assert
            string contents = File.ReadAllText(_logFilePath);
            Assert.Contains("Error code: 500, description: Internal Server Error", contents);
        }

        public void Dispose()
        {
            if (File.Exists(_logFilePath))
                File.Delete(_logFilePath);

            if (Directory.Exists(_logDirectory))
                Directory.Delete(_logDirectory, recursive: true);
        }

    }

}