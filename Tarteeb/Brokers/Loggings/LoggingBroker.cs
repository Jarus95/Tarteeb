//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

namespace Tarteeb.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger logger;
        public LoggingBroker(ILogger logger) =>
            this.logger = logger;
        public void LogError(Exception exception) =>
            this.logger.LogError(exception.Message, exception);

        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception.Message, exception);

    }
}
