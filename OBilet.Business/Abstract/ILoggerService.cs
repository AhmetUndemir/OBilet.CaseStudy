using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Business
{
	public interface ILoggerService
	{
		void Info(string message);
		void Warning(string message);
		void Error(string message);
		void Debug(string message);
	}
}
