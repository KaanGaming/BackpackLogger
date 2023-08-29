using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace BackpackLogger
{
	public class ConsoleMenu
	{
		public ConsoleMenu(string title, Color titleColor, MenuOption[] options)
		{
			this.options = options;
			this.title = title;
			this.titleColor = titleColor;
		}

		public MenuOption[] options;
		public string title;
		public Color titleColor;

		private enum Command
		{
			None,
			Up,
			Down,
			Select
		}

		private string Whitespace(int width)
		{
			char[] chars = new char[width];
			for (int i = 0; i < chars.Length; i++)
			{
				chars[i] = ' ';
			}
			return new string(chars);
		}

		public object DisplayMenu()
		{
			Console.BackgroundColor = Program.colors["_back"];
			int ypos = Console.CursorTop;
			Console.WriteLine(title, titleColor);
			Console.WriteLine();
			bool selected = false;
			int option = 0;
			while (!selected)
			{
				Console.CursorTop = ypos + 2;
				Console.CursorLeft = 0;
				for (int i = 0; i < options.Length; i++)
				{
					if (i == option)
					{
						Console.ForegroundColor = options[i].color.GetBrightness() > 0.5f ? Program.colors["_back"] : Color.White;
						Console.BackgroundColor = options[i].color;
						Console.Write(options[i].name);
						Console.BackgroundColor = Program.colors["_back"];
						Console.WriteLine();
					}
					else
					{
						Console.WriteLine(options[i].name, options[i].color);
					}
				}
				Console.WriteLine();
				Console.WriteLine(Whitespace(Console.BufferWidth));
				Console.CursorTop--;
				Console.WriteLine(options[option].description, options[option].color);
				Console.WriteLine("Use your UP and DOWN arrow keys to navigate. Press ENTER to select.", Program.colors["normal"]);

				ConsoleKeyInfo cki = Console.ReadKey(true);
				Command cmd = cki.Key switch
				{
					ConsoleKey.UpArrow => Command.Up,
					ConsoleKey.DownArrow => Command.Down,
					ConsoleKey.Enter => Command.Select,
					_ => Command.None
				};

				if (cmd == Command.None)
					continue;
				if (cmd == Command.Up)
				{
					option--;
					if (option < 0)
						option = options.Length - 1;
				}
				if (cmd == Command.Down)
				{
					option++;
					if (option >= options.Length)
						option = 0;
				}
				if (cmd == Command.Select)
				{
					selected = true;
					Console.CursorTop = ypos + 2;
					Console.CursorLeft = 0;
					for (int i = 0; i < options.Length; i++)
					{
						Console.WriteLine(Whitespace(options[i].name.Length));
					}
					Console.WriteLine();
					Console.WriteLine(Whitespace(Console.BufferWidth));
					Console.WriteLine(Whitespace(Console.BufferWidth));
				}
			}

			Console.CursorLeft = 0;
			Console.CursorTop = ypos;
			Console.WriteLine(Whitespace(Console.BufferWidth));
			return option;
		}
	}
}
