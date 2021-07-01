using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;


namespace ConASCII
{
	class ImageProcessing
	{
		private class NativeMethods
		{
			[DllImport("kernel32.dll")]
			public static extern IntPtr GetStdHandle(int handle);

			[DllImport("kernel32.dll", SetLastError = true)]
			 public static extern bool SetConsoleDisplayMode(IntPtr ConsoleHandle, uint Flags, IntPtr NewScreenBufferDimensions);
		}

		//Уже не помню что тут творится, главное его не трогать
		static public Bitmap StartProcessing(List<char> Dictonary, string ImagePath)
		{
			var hConsole = NativeMethods.GetStdHandle(-11);
			NativeMethods.SetConsoleDisplayMode(hConsole, 1, IntPtr.Zero);
			Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
			Console.WindowHeight = Console.LargestWindowHeight;
			Console.WindowWidth = Console.LargestWindowWidth;

			int Height = Console.LargestWindowHeight;
			int Width = Console.LargestWindowWidth - 4;

			Graphics graph = null;
			Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Bitmap bitmap = new Bitmap(ImagePath);
			graph = Graphics.FromImage(screen);

			float yStep = bitmap.Height / Height;
			float xStep = bitmap.Width / Width;
			
			for (int yc = 0; yc < Height; yc++)
			{
				int y = (int)( yc * yStep );

				for (int xc = 0; xc < Width; xc++)
				{
					int x = (int)( xc * xStep );

					double redAve = 0;
					double greenAve = 0;
					double blueAve = 0;
					
					for (int ybit = 0; ybit < yStep; ybit++) for (int xbit = 0; xbit < xStep; xbit++)
						{
							Color color = bitmap.GetPixel((int)x, (int)y);
							redAve += color.R;
							greenAve += color.G;
							blueAve += color.B;
						}

					redAve /= yStep * xStep;
					greenAve /= yStep * xStep;
					blueAve /= yStep * xStep;

					Console.ForegroundColor = ConvertColor.ConvertColorToConsoleColor(
						System.Windows.Media.Color.FromRgb((byte)redAve, (byte)greenAve, (byte)blueAve));

					for (int i = 1; i <= Dictonary.Count; i++)
					{
						if (Math.Max(redAve, Math.Max(greenAve, blueAve)) <= ( 256.0 / ( (float)Dictonary.Count / i ) ))
						{
							Console.Write(Dictonary[Dictonary.Count - i]);
							break;
						}
					}
				}
				Console.WriteLine();
			}
			graph.CopyFromScreen(0, 0, 0, 0, screen.Size);

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Press Alt+Enter for exit");

			return screen;
		}
	}
}
