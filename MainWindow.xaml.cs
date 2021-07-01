using System;
using System.Windows;

namespace ConASCII
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new ViewModel();
			
			Console.WriteLine("ConASCII by Beanealol");
		}
	}
}