using System.Windows;
using BinanceNFT.ViewModels;

namespace BinanceNFT.Views
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel(this);
		}
	}
}
