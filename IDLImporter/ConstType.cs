using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIL.FieldWorks.Tools
{
	[Serializable]
	public class ConstType
	{
		public ConstType(string type, string label, string value, string comment)
		{
			Type = type;
			Label = label;
			Value = value;
			Comment = comment;
		}

		public string Type;
		public string Label;
		public string Value;
		public string Comment;
	}
}
