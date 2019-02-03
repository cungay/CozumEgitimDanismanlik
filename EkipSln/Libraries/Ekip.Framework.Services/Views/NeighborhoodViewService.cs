
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
	
	///<summary>
	/// An component type implementation of the 'NeighborhoodView' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class NeighborhoodViewService : Ekip.Framework.Services.NeighborhoodViewServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewService class.
		/// </summary>
		public NeighborhoodViewService() : base()
		{
		}
		
	}//End Class


} // end namespace
