using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConASCII
{
	readonly struct ConsoleColorInfluence
	{
		public ConsoleColor ConsoleColor { get; }
		public Color Color { get; }
		public int Range { get; }

		public ConsoleColorInfluence(ConsoleColor consoleColor, Color color, int range)
		{
			ConsoleColor = consoleColor;
			Color = color;
			Range = range;
		}
	}

}
