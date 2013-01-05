/******************************
 * Created with SharpDevelop 3.
 * User: F. Phoenix
 * Date: 05.01.2013 14:57
 ******************************/

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Macro_Browser
{
	public static class Settings
	{
		public static string Ini, GameDir, MacroDir;
		
		public static bool Load()
		{
			try
			{
				var config = ParseIni(Ini);
				config.TryGetValue("GamePath", out GameDir);
				if (!GameDir.EndsWith("\\")) GameDir += "\\";
				MacroDir = GameDir + @"data\core\macros\";
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		public static bool Save()
		{
			return false;
		}
		
		public static Dictionary<string, string> ParseIni(string file)
		{
			var result = new Dictionary<string, string>();
			var data = File.ReadAllLines(Ini);
			var cat = string.Empty;
			var rx_category = new Regex(@"^\[(?<name>[a-z_0-9]+)\]\s*$", RegexOptions.IgnoreCase);
			var rx_param = new Regex(@"^(?<key>[a-z_]+)=(?<value>.*)$", RegexOptions.IgnoreCase);
			Match m;
			foreach (string str in data)
			{
				if ((m = rx_category.Match(str)).Success)
					cat = m.Groups["name"].Value + ":";
				else if ((m = rx_param.Match(str)).Success)
					result.Add(cat + m.Groups["key"].Value, m.Groups["value"].Value);
			}
			return result;
		}
	}
}
