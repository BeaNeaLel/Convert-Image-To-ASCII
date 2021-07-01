using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace ConASCII
{

	public class InfoStorage : INotifyPropertyChanged
	{
		private string imagePath;
		private Bitmap screenShot;
		private List<char> dictonary;
		private Dictionary<ConsoleColor, Tuple<System.Windows.Media.Color, int>> dictonaryColors;

		public string ImagePath
		{
			get { return imagePath; }
			set
			{
				imagePath = value;
				OnPropertyChanged("ImagePath");
			}
		}
		public List<char> Dictonary
		{
			get { return dictonary; }
			set
			{
				dictonary = value;
				OnPropertyChanged("Dictonary");
			}
		}
		public Bitmap ScreenShot
		{
			get { return screenShot; }
			set
			{
				screenShot = value;
				OnPropertyChanged("ScreenShot");
			}
		}
		public Dictionary<ConsoleColor, Tuple<System.Windows.Media.Color, int>> DictonaryColors
		{
			get { return dictonaryColors; }
			set
			{
				dictonaryColors = value;
				OnPropertyChanged("DictonaryColors");
			}
		}

		public InfoStorage () { }
		public InfoStorage(string ImagePath)
		{
			this.ImagePath = ImagePath;
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}

}
