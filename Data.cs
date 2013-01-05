/******************************
 * Created with SharpDevelop 3.
 * User: F. Phoenix
 * Date: 05.01.2013 11:57
 ******************************/

using System;
using System.Collections.Generic;

namespace Macro_Browser
{
	public class MacroData
	{
		public string Name, Code, File;
		public int Line;
	}
	
	public class MacroDataCollection : List<MacroData>
	{
		public MacroData Add(string name, string code, string file, int line)
		{
			var data = new MacroData() {Name = name, Code = code, File = file, Line = line};
			this.Add(data);
			return data;
		}
	}
}
