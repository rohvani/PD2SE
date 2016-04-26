using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PD2.GameSave
{
	public class UnencodedString
	{
		public String Value { get; set; }
		public UnencodedString(String value) { this.Value = value; }
		public override String ToString() { return Value; }
	}
}
