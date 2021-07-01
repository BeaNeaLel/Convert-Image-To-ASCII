using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConASCII
{
	class AdvancedConsoleColor
	{
		public static ConsoleColorInfluence[] ConsoleColorDictonary { get; } = new ConsoleColorInfluence[16]
		{
			new ConsoleColorInfluence(ConsoleColor.Black,					Color.FromRgb(0, 0, 0),                 (int)Math.Floor(Math.Pow(Math.Pow(75,2) * 3,0.5))),
			new ConsoleColorInfluence(ConsoleColor.White,				Color.FromRgb(255, 255, 255),		(int)Math.Floor(Math.Pow(Math.Pow(75,2) * 3,0.5))),
			new ConsoleColorInfluence(ConsoleColor.Gray,					Color.FromRgb(255, 255, 255),		(int)Math.Floor(Math.Pow(Math.Pow(256,2) * 3,0.5))),
			new ConsoleColorInfluence(ConsoleColor.DarkGray,			Color.FromRgb(0, 0, 0),					(int)Math.Floor(Math.Pow(Math.Pow(256,2) * 3,0.5))),
			new ConsoleColorInfluence(ConsoleColor.DarkBlue,			Color.FromRgb(0, 54, 215),			100),
			new ConsoleColorInfluence(ConsoleColor.DarkGreen,		Color.FromRgb(19, 161, 14),         100),
			new ConsoleColorInfluence(ConsoleColor.DarkCyan,			Color.FromRgb(54, 151, 219),		100),
			new ConsoleColorInfluence(ConsoleColor.DarkRed,			Color.FromRgb(197, 15, 31),			75),
			new ConsoleColorInfluence(ConsoleColor.DarkMagenta,	Color.FromRgb(134, 22, 150),		75),
			new ConsoleColorInfluence(ConsoleColor.DarkYellow,		Color.FromRgb(193, 156, 0),			100),
			new ConsoleColorInfluence(ConsoleColor.Blue,					Color.FromRgb(59, 118, 254),		75),
			new ConsoleColorInfluence(ConsoleColor.Green,				Color.FromRgb(22, 198, 12),			100),
			new ConsoleColorInfluence(ConsoleColor.Cyan,					Color.FromRgb(92, 215, 213),		75),
			new ConsoleColorInfluence(ConsoleColor.Red,					Color.FromRgb(231, 72, 86),			75),
			new ConsoleColorInfluence(ConsoleColor.Magenta,			Color.FromRgb(180, 0, 158),			75),
			new ConsoleColorInfluence(ConsoleColor.Yellow,				Color.FromRgb(242, 242, 165),		25),
		};
	}
}
