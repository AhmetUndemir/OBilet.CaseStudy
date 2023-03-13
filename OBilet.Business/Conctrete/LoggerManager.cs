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
		private ILog _logManager;

		public LoggerManager(string getLogger)
		{
			_logManager = LogManager.GetLogger(getLogger);
		}
		public void Debug(string message)
		{
			_logManager.Debug(message);
		}

		public void Error(string message)
		{
			_logManager.Error(message);
		}

		public void Info(string message)
		{
			_logManager.Info(message);
		}

		public void Warning(string message)
		{
			_logManager.Warn(message);
		}
	}
}
