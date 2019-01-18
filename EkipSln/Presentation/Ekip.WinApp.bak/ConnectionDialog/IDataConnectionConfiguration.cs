using System;
using System.Collections.Generic;
using System.Text;

namespace Ekip.WinApp.ConnectionDialog
{
	public interface IDataConnectionConfiguration
	{
		string GetSelectedSource();
		void SaveSelectedSource(string provider);

		string GetSelectedProvider();
		void SaveSelectedProvider(string provider);
	}
}
