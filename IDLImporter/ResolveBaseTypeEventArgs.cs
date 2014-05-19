using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIL.FieldWorks.Tools
{
	public class ResolveBaseTypeEventArgs: EventArgs
	{
		public ResolveBaseTypeEventArgs(string typeName, CodeNamespace nameSpace)
		{
			TypeName = typeName;
			NameSpace = nameSpace;
		}

		public string TypeName { get; private set; }
		public CodeNamespace NameSpace { get; set; }
		public string IdhFileName { get; set; }
	}
}
