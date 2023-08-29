using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackLogger
{
	public class MenuOption
	{
		public MenuOption(string name, string description, Color color, int value)
		{
			this.name = name;
			this.description = description;
			this.color = color;
			this.value = value;
		}

		public string name;
		public string description;
		public Color color;
		public int value;
	}
}
