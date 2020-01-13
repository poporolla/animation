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
			double circleTransformTime = 0.5;
			double circleMovingTime = 1;
			double animDelays = 0.3;

			//уменьшение круга
			DoubleAnimation heightDownAnim = new DoubleAnimation();
			heightDownAnim.From = 40;
			heightDownAnim.To = 10;
			heightDownAnim.Duration = TimeSpan.FromSeconds(circleTransformTime);
			InnElem.BeginAnimation(HeightProperty, heightDownAnim);
			InnElem.BeginAnimation(WidthProperty, heightDownAnim);

			//перемещение круга
			ThicknessAnimation ellipseMargin = new ThicknessAnimation();
			ellipseMargin.From = InnElem.Margin;
			ellipseMargin.To = new Thickness(55, 0, 0, 0);
			ellipseMargin.BeginTime = TimeSpan.FromSeconds(circleTransformTime + animDelays);
			ellipseMargin.Duration = TimeSpan.FromSeconds(circleMovingTime);
			InnElem.BeginAnimation(MarginProperty, ellipseMargin);

			//цвет бордера
			ColorAnimation bordColor = new ColorAnimation();
			ExtElem.Background = new SolidColorBrush(Colors.LightGray);
			bordColor.From = Colors.LightGray;
			bordColor.To = Colors.LightGreen;
			bordColor.BeginTime = TimeSpan.FromSeconds(circleTransformTime + animDelays);
			bordColor.Duration = TimeSpan.FromSeconds(circleMovingTime);
			ExtElem.Background.BeginAnimation(SolidColorBrush.ColorProperty, bordColor);

			//увеличение круга
			DoubleAnimation heightUpAnim = new DoubleAnimation();
			heightUpAnim.From = 10;
			heightUpAnim.To = 40;
			heightUpAnim.BeginTime = TimeSpan.FromSeconds(circleTransformTime + circleMovingTime + animDelays + animDelays);
			heightUpAnim.Duration = TimeSpan.FromSeconds(circleTransformTime);
			InnElem.BeginAnimation(HeightProperty, heightUpAnim);
			InnElem.BeginAnimation(WidthProperty, heightUpAnim);
		}
	}
}
