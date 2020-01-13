using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
			double circleTransformTime = 0.3;
			double circleMovingTime = 0.5;
			DoubleAnimation heightAnim = new DoubleAnimation();
			heightAnim.From = InnElem.ActualHeight;
			heightAnim.To = 10;
			heightAnim.Duration = TimeSpan.FromSeconds(circleTransformTime);
			heightAnim.Completed += delegate
			{
				ThicknessAnimation ellipseMargin = new ThicknessAnimation();
				ellipseMargin.From = InnElem.Margin;
				if (InnElem.Margin == new Thickness(55, 0, 0, 0))
				{
					ellipseMargin.To = new Thickness(0, 0, 55, 0);
					//цвет бордера
					ColorAnimation bordColor = new ColorAnimation();
					ExtElem.Background = new SolidColorBrush(Colors.LightGray);
					bordColor.From = Colors.LightGray;
					bordColor.To = Colors.LightGreen;
					bordColor.Duration = TimeSpan.FromSeconds(circleMovingTime);
					ExtElem.Background.BeginAnimation(SolidColorBrush.ColorProperty, bordColor);
				}
				else
				{
					ellipseMargin.To = new Thickness(55, 0, 0, 0);
					//цвет бордера
					ColorAnimation bordColor = new ColorAnimation();
					ExtElem.Background = new SolidColorBrush(Colors.LightGreen);
					bordColor.From = Colors.LightGreen;
					bordColor.To = Colors.LightGray;
					//bordColor.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
					bordColor.Duration = TimeSpan.FromSeconds(circleMovingTime);
					ExtElem.Background.BeginAnimation(SolidColorBrush.ColorProperty, bordColor);
				}
				//ellipseMargin.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
				ellipseMargin.Duration = TimeSpan.FromSeconds(circleMovingTime);
				ellipseMargin.Completed += delegate
				{
					DoubleAnimation heightUpAnim = new DoubleAnimation();
					heightAnim.From = InnElem.ActualHeight;
					heightAnim.To = 40;
					heightAnim.Duration = TimeSpan.FromSeconds(circleTransformTime);
					InnElem.BeginAnimation(HeightProperty, heightAnim);
					InnElem.BeginAnimation(WidthProperty, heightAnim);
				};
				InnElem.BeginAnimation(MarginProperty, ellipseMargin);
				
			};
			InnElem.BeginAnimation(HeightProperty, heightAnim);
			InnElem.BeginAnimation(WidthProperty, heightAnim);
		}
		//private void EllipseMinimize(double minimizeTime)
		//{
		//	//уменьшение круга
		//	DoubleAnimation heightAnim = new DoubleAnimation();
		//	heightAnim.From = InnElem.ActualHeight;
		//	heightAnim.To = 10;
		//	heightAnim.Duration = TimeSpan.FromSeconds(minimizeTime);
		//	InnElem.BeginAnimation(HeightProperty, heightAnim);
		//	InnElem.BeginAnimation(WidthProperty, heightAnim);
		//}
		//private void EllipseMaximize(double maximizeTime)
		//{
		//	DoubleAnimation heightAnim = new DoubleAnimation();
		//	heightAnim.From = InnElem.ActualHeight;
		//	heightAnim.To = 40;
		//	heightAnim.Duration = TimeSpan.FromSeconds(maximizeTime);
		//	InnElem.BeginAnimation(HeightProperty, heightAnim);
		//	InnElem.BeginAnimation(WidthProperty, heightAnim);
		//}
		//private void EllipseMove(double movingTime)
		//{
		//	//перемещение круга
		//	ThicknessAnimation ellipseMargin = new ThicknessAnimation();
		//	ellipseMargin.From = InnElem.Margin;
		//	if(InnElem.Margin == new Thickness(55, 0, 0, 0))
		//	{
		//		ellipseMargin.To = new Thickness(0, 0, 55, 0);
		//	}
		//	else
		//	{
		//		ellipseMargin.To = new Thickness(55, 0, 0, 0);
		//	}
		//	//ellipseMargin.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
		//	ellipseMargin.Duration = TimeSpan.FromSeconds(movingTime);
		//	InnElem.BeginAnimation(MarginProperty, ellipseMargin);
		//}
		//private void BorderColorToGreen(double ColorChangeTime)
		//{
		//	//цвет бордера
		//	ColorAnimation bordColor = new ColorAnimation();
		//	ExtElem.Background = new SolidColorBrush(Colors.LightGray);
		//	bordColor.From = Colors.LightGray;
		//	bordColor.To = Colors.LightGreen;
		//	//bordColor.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
		//	bordColor.Duration = TimeSpan.FromSeconds(ColorChangeTime);
		//	ExtElem.Background.BeginAnimation(SolidColorBrush.ColorProperty, bordColor);
		//}
		//private void BorderColorToGray(double ColorChangeTime)
		//{
		//	//цвет бордера
		//	ColorAnimation bordColor = new ColorAnimation();
		//	ExtElem.Background = new SolidColorBrush(Colors.LightGreen);
		//	bordColor.From = Colors.LightGreen;
		//	bordColor.To = Colors.LightGray;
		//	//bordColor.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
		//	bordColor.Duration = TimeSpan.FromSeconds(ColorChangeTime);
		//	ExtElem.Background.BeginAnimation(SolidColorBrush.ColorProperty, bordColor);
		//}
	}
}
