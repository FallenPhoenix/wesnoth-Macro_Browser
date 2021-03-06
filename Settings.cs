﻿/******************************
 * Created with SharpDevelop 3.
 * User: F. Phoenix
 * Date: 05.01.2013 14:57
 ******************************/

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Macro_Browser
{
	public static class Settings
	{
		#region Данные программы
		public static string GamePath = "";
		public static string Viewer = "";
		public static string ViewerArgs = "";
		public static string[] DisabledFiles = new string[0];
		public static int Window_Width = -1;
		public static int Window_Height = -1;
		public static int Window_Separator = -1;
		public static bool Window_Maximized = false;
		
		public static string MacroPath
		{
			get {return GamePath + @"\data\core\macros\";}
		}
		#endregion
		
		
		public static string Ini {get; set;}
		
		public static bool Load()
		{
			try
			{
				var config = ParseIni(Ini, "_");
				var fields = typeof(Settings).GetFields();
				string val; int ival; bool bval;
				foreach (FieldInfo field in fields)
				{
					var type = field.FieldType.ToString();
					if (!config.TryGetValue(field.Name.ToUpper(), out val)) val = string.Empty;
					switch (type)
					{
						case "System.String":
							field.SetValue(null, val);
							break;
						case "System.String[]":
							field.SetValue(null, val.Split(','));
							break;
						case "System.Int32":
							if (!int.TryParse(val, out ival)) ival = -1;
							field.SetValue(null, ival);
							break;
						case "System.Boolean":
							if (bool.TryParse(val, out bval))
								field.SetValue(null, bval);
							break;
					}
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		public static bool Save()
		{
			try
			{
				var fields = typeof(Settings).GetFields();
				var rx_split = new Regex("((?<category>[^_]*)_)?(?<key>[^_]*)");
				var data = new List<string>();
				var category = string.Empty;
				foreach (FieldInfo field in fields)
				{
					var m = rx_split.Match(field.Name);
					if (category != m.Groups["category"].Value)
					{
						category = m.Groups["category"].Value;
						data.Add(""); data.Add("[" + category + "]");
					}
					object val = field.GetValue(null);
					if (val is string[]) val = string.Join(",", val as string[]);
					data.Add(m.Groups["key"].Value + "=" + val);
				}
				File.WriteAllLines(Ini, data.ToArray());
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		
		
		static Dictionary<string, string> ParseIni(string file, string section_separator)
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
					cat = m.Groups["name"].Value + section_separator;
				else if ((m = rx_param.Match(str)).Success)
					result.Add((cat + m.Groups["key"].Value).ToUpper(), m.Groups["value"].Value);
			}
			return result;
		}
	}
}
