using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Business
{
	public class LoggerManager : ILoggerService
	{
		private ILog logManager;

		public LoggerManager(string getLogger)
		{
			logManager = LogManager.GetLogger(getLogger);
		}
		public void Debug(string message)
		{
			logManager.Debug(message);
		}

		public void Error(string message)
		{
			logManager.Error(message);
		}

		public void Info(string message)
		{
			logManager.Info(message);
		}

		public void Warning(string message)
		{
			logManager.Warn(message);
		}
	}
}
