	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using Ekip.Framework.Entities;
using Ekip.Framework.Entities.Validation;

using Ekip.Framework.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace Ekip.Framework.Services
{		
	/// <summary>
	/// An component type implementation of the 'Client' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ClientService : Ekip.Framework.Services.ClientServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ClientService class.
		/// </summary>
		public ClientService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
