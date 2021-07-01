using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConASCII
{
	class ConvertColor
	{
		public static ConsoleColor ConvertColorToConsoleColor(System.Windows.Media.Color Color)
		{
			double DistanceToColor = double.MaxValue;
			KeyValuePair<ConsoleColor, double> NearColor = new KeyValuePair<ConsoleColor, double>(ConsoleColor.Black, double.MaxValue);

			foreach (ConsoleColorInfluence consoleColor in AdvancedConsoleColor.ConsoleColorDictonary)
			{
				DistanceToColor = Math.Pow(Math.Pow(Color.R - consoleColor.Color.R, 2) + Math.Pow(Color.G - consoleColor.Color.G, 2) + Math.Pow(Color.B - consoleColor.Color.B, 2), 0.5);

				if (( DistanceToColor < NearColor.Value ) && ( DistanceToColor < consoleColor.Range ))
					NearColor = new KeyValuePair<ConsoleColor, double>(consoleColor.ConsoleColor, DistanceToColor);
			}
			return NearColor.Key;
		}
	}
}
