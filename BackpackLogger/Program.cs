using Colorful;
using System;
using System.Diagnostics;
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
			Console.WriteLine();
			bool loop = true;
			while (loop)
			{
				int choice = (int)new ConsoleMenu("Choose an action", colors["_default"], new MenuOption[]
				{
					new MenuOption("Follow item", "Search for an item to add to the quickview list", Color.Goldenrod, 0),
					new MenuOption("Unfollow item", "Search for an item to add to the quickview list", Color.OrangeRed, 1),
					new MenuOption("Open backpack.tf", "Visit the website for trading goods in Team Fortress 2!", Color.CornflowerBlue, 2),
					new MenuOption("Exit program", "Exit the program.", colors["_default"], 3),
				}).DisplayMenu();

				if (choice == 3)
					loop = false;

				if (choice == 2)
					OpenBackpackTf();
			}
		}

		static void OpenBackpackTf()
		{
			Process.Start(new ProcessStartInfo("https://backpack.tf")
			{
				UseShellExecute = true
			});
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