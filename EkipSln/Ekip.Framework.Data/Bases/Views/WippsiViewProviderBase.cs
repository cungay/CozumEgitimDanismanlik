#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Ekip.Framework.Entities;
using Ekip.Framework.Data;

#endregion

namespace Ekip.Framework.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="WippsiViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class WippsiViewProviderBase : WippsiViewProviderBaseCore
	{
	} // end class
} // end namespace
