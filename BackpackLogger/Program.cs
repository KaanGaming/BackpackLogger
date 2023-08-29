using Colorful;
using System;
using System.Drawing;
using System.Net;
using Console = Colorful.Console;

namespace BackpackLogger
{
	internal class Program
	{
		static void Main(string[] args)
		{
			colors["_back"] = Color.FromArgb(12, 12, 12);
			Console.Clear();
			DefineColors();
			Console.ForegroundColor = colors["_default"];
			Console.Title = "Backpack Logger";
			Console.WriteLine("Backpack Logger - Quick Showcase and Logger Utility");
			Console.Write("Powered by ");
			Console.Write("backpack", Color.White);
			Console.Write(".tf", Color.CornflowerBlue);
			Console.WriteLine();
			for (int i = 0; i < colors.Count(); i++)
			{
				if (i > 0)
					Console.Write(", ");
				Console.Write(colors.ElementAt(i).Key, colors.ElementAt(i).Value);
			}
			Console.WriteLine();
			new ConsoleMenu("Menu test", Color.White, new MenuOption[]
			{
				new MenuOption("Self-Made Dalokohs Bar", "Item description test 1", colors["community"], 0),
				new MenuOption("Valve Rocket Launcher", "Item description test 2", colors["valve"], 0),
				new MenuOption("Collector's Eyelander", "Item description test 3", colors["collector"], 0),
			}).DisplayMenu();
			Console.ReadLine();
		}

		static void DefineColors()
		{
			colors.Add("normal", Color.FromArgb(178, 178, 178));
			colors.Add("unique", Color.FromArgb(255, 215, 0));
			colors.Add("vintage", Color.FromArgb(71, 98, 145));
			colors.Add("genuine", Color.FromArgb(77, 116, 85));
			colors.Add("strange", Color.FromArgb(207, 106, 50));
			colors.Add("unusual", Color.FromArgb(134, 80, 172));
			colors.Add("haunted", Color.FromArgb(56, 243, 171));
			colors.Add("collector", Color.FromArgb(170, 0, 0));
			colors.Add("decorated", Color.FromArgb(250, 250, 250));
			colors.Add("community", Color.FromArgb(112, 176, 74));
			colors.Add("valve", Color.FromArgb(165, 15, 121));

			colors.Add("_default", Color.FromArgb(204, 204, 204));
		}

		/// <summary>
		/// List of qualities: <br />
		/// normal, unique, vintage, genuine, strange, unusual, haunted, collector, decorated, community, valve <br /><br />
		/// 
		///	community & self-made use the same color
		/// </summary>
		static internal Dictionary<string, Color> colors = new Dictionary<string, Color>();
	}
}