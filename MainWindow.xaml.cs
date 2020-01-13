using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Ellipse ellipse = sender as Ellipse;
			Border border = ExtElem;

			//DoubleAnimation marAnimation = new DoubleAnimation();

			//перемещение круга
			ThicknessAnimation ellipseMargin = new ThicknessAnimation();
			ellipseMargin.From = ellipse.Margin;
			ellipseMargin.To = new Thickness(55, 0, 0, 0);
			ellipseMargin.Duration = TimeSpan.FromSeconds(1.5);
			ellipse.BeginAnimation(Ellipse.MarginProperty, ellipseMargin);


		}
	}
}
