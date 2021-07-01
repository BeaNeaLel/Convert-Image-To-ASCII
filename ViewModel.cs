using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ConASCII
{
	public class ViewModel : INotifyPropertyChanged
	{
		private string dictonaryS = "█▓▒░";
		private InfoStorage infoStorage = new InfoStorage(System.Windows.Forms.Application.StartupPath + "\\default.bmp");
		private RelayCommand openFile;
		private RelayCommand runImageProcessing;

		public string DictonaryS
		{
			get { return dictonaryS; }
			set
			{
				dictonaryS = value;
				InfoStorage.Dictonary = dictonaryS.ToList();
				OnPropertyChanged("DictonaryS");
			}
		}
		public InfoStorage InfoStorage
		{
			get { return infoStorage; }
			set
			{
				infoStorage = value;
				OnPropertyChanged("Model");
			}
		}
		public RelayCommand OpenFile
		{
			get
			{
				return openFile ??
				( openFile = new RelayCommand(obj =>
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						InfoStorage.ImagePath = openFileDialog.FileName;
					}
				}) );
			}
		}
		public RelayCommand RunImageProcessing
		{
			get
			{
				return runImageProcessing ??
				( runImageProcessing = new RelayCommand(obj =>
				{
					InfoStorage.Dictonary = dictonaryS.ToList();
					InfoStorage.ScreenShot = ImageProcessing.StartProcessing(InfoStorage.Dictonary, InfoStorage.ImagePath);
					Random randName = new Random();
					string newPath = Convert.ToString(randName.Next(999999));
					InfoStorage.ScreenShot.Save(newPath+".png");
					string path = System.Windows.Forms.Application.StartupPath;
					InfoStorage.ImagePath = path + "\\"+ newPath+".png";
				}) );
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
