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
		public static string Ini {get; set;}
		public static string MacroDir
		{
			get {return GameDir + @"data\core\macros\";}
		}
		
		public static string GameDir;
		public static int Window_Width, Window_Height, Window_Separator;
		
		
		public static bool Load()
		{
			try
			{
				var config = ParseIni(Ini);
				config.TryGetValue("GamePath", out GameDir);
				if (!GameDir.EndsWith("\\")) GameDir += "\\";
				Window_Width = GetValue(ref config, "Window:Width");
				Window_Height = GetValue(ref config, "Window:Height");
				Window_Separator = GetValue(ref config, "Window:Separator");
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

		
		static int GetValue(ref Dictionary<string, string> config, string key)
		{
			string sval; if (!config.TryGetValue(key, out sval)) return -1;
			int ival; if (!int.TryParse(sval, out ival)) return -1;
			return ival;
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
