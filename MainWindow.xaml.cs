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
			double circleTransformTime = 0.1;
			double circleMovingTime = 0.25;
			Color coolColor = Color.FromRgb(87, 219, 131);
			Color coolGreyColor = Colors.WhiteSmoke;

			//Changing ellipse size
			DoubleAnimationUsingKeyFrames ellipseRadius = new DoubleAnimationUsingKeyFrames();
			ellipseRadius.KeyFrames = new DoubleKeyFrameCollection()
			{
				new LinearDoubleKeyFrame(42, TimeSpan.FromSeconds(0)),
				new LinearDoubleKeyFrame(35, TimeSpan.FromSeconds(circleTransformTime)),
				new LinearDoubleKeyFrame(35, TimeSpan.FromSeconds(circleTransformTime + circleMovingTime)),
				new LinearDoubleKeyFrame(40, TimeSpan.FromSeconds(circleTransformTime + circleMovingTime + circleTransformTime))
			};
			InnElem.BeginAnimation(Ellipse.HeightProperty, ellipseRadius);
			InnElem.BeginAnimation(Ellipse.WidthProperty, ellipseRadius);

			//Changing Ellipse position
			ThicknessAnimation ellipsePos = new ThicknessAnimation();
			ellipsePos.AccelerationRatio = 0.95;
			ellipsePos.From = InnElem.Margin;
			ellipsePos.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
			ellipsePos.Duration = TimeSpan.FromSeconds(circleMovingTime);

			//Animation for set backGround of Border
			ColorAnimation bordColor = new ColorAnimation();
			bordColor.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
			bordColor.Duration = TimeSpan.FromSeconds(circleMovingTime);

			//chech is ellipse on start position
			if (InnElem.Margin.Left == 0)
			{
				ellipsePos.To = new Thickness(55, 0, 0, 0);

				ExtElem.Background = new SolidColorBrush(coolGreyColor);
				bordColor.From = coolGreyColor;
				bordColor.To = coolColor;
			}
			else
			{
				ellipsePos.To = new Thickness(0, 0, 55, 0);

				ExtElem.Background = new SolidColorBrush(coolColor);
				bordColor.From = coolColor;
				bordColor.To = coolGreyColor;
			}
			InnElem.BeginAnimation(Ellipse.MarginProperty, ellipsePos);
			ExtElem.Background.BeginAnimation(SolidColorBrush.ColorProperty, bordColor);
		}
		//private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		//{
		//	double circleTransformTime = 0.3;
		//	double circleMovingTime = 0.5;


		//	//Animation for minimize radius of ellipse
		//	DoubleAnimation heightAnim = new DoubleAnimation();
		//	heightAnim.From = 40;
		//	heightAnim.To = 10;
		//	heightAnim.Duration = TimeSpan.FromSeconds(circleTransformTime);

		//	//it's need for storyboard
		//	Storyboard.SetTargetName(heightAnim, InnElem.Name);
		//	Storyboard widthStoryBoard = new Storyboard();

		//	//for width
		//	Storyboard.SetTargetProperty(heightAnim, new PropertyPath(Ellipse.WidthProperty));
		//	widthStoryBoard.Children.Add(heightAnim);
		//	//widthStoryBoard.Begin(InnElem);

		//	//for height
		//	Storyboard.SetTargetProperty(heightAnim, new PropertyPath(Ellipse.HeightProperty));
		//	widthStoryBoard.Children.Add(heightAnim);
		//	//widthStoryBoard.Begin(InnElem);

		//	//Animation for Move the Ellipse
		//	ThicknessAnimation ellipseMargin = new ThicknessAnimation();
		//	ellipseMargin.From = InnElem.Margin;
		//	ellipseMargin.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
		//	ellipseMargin.Duration = TimeSpan.FromSeconds(circleMovingTime);

		//	//Animation for set backGround of Border
		//	ColorAnimation bordColor = new ColorAnimation();
		//	bordColor.BeginTime = TimeSpan.FromSeconds(circleTransformTime);
		//	bordColor.Duration = TimeSpan.FromSeconds(circleMovingTime);
		//	//ExtElem.Background.BeginAnimation(SolidColorBrush.ColorProperty, bordColor);

		//	//chech is ellipse on start position
		//	if (InnElem.Margin.Left == 0)
		//	{
		//		ellipseMargin.To = new Thickness(55, 0, 0, 0);

		//		ExtElem.Background = new SolidColorBrush(Colors.LightGray);
		//		bordColor.From = Colors.LightGray;
		//		bordColor.To = Colors.LightGreen;

		//	}
		//	else
		//	{
		//		ellipseMargin.To = new Thickness(0, 0, 55, 0);

		//		ExtElem.Background = new SolidColorBrush(Colors.LightGreen);
		//		bordColor.From = Colors.LightGreen;
		//		bordColor.To = Colors.LightGray;
		//	}

		//	//Moving the ellipse
		//	Storyboard.SetTargetName(ellipseMargin, InnElem.Name);
		//	Storyboard.SetTargetProperty(ellipseMargin, new PropertyPath(Ellipse.MarginProperty));
		//	widthStoryBoard.Children.Add(ellipseMargin);
		//	//widthStoryBoard.Begin(InnElem);

		//	//Changing border color
		//	Storyboard.SetTargetName(bordColor, ExtElem.Name);
		//	Storyboard.SetTargetProperty(bordColor, new PropertyPath(SolidColorBrush.ColorProperty));
		//	widthStoryBoard.Children.Add(bordColor);
		//	widthStoryBoard.Begin(ExtElem);

		//	//Animation for minimize radius of ellipse
		//	DoubleAnimation heightNewAnim = new DoubleAnimation();
		//	heightNewAnim.From = 10;
		//	heightNewAnim.To = 40;
		//	heightNewAnim.BeginTime = TimeSpan.FromSeconds(circleTransformTime + circleMovingTime);
		//	heightNewAnim.Duration = TimeSpan.FromSeconds(circleTransformTime);

		//	//it's need for storyboard
		//	Storyboard.SetTargetName(heightNewAnim, InnElem.Name);

		//	//for width
		//	Storyboard.SetTargetProperty(heightNewAnim, new PropertyPath(Ellipse.WidthProperty));
		//	widthStoryBoard.Children.Add(heightNewAnim);
		//	//widthStoryBoard.Begin(InnElem);

		//	//for height
		//	Storyboard.SetTargetProperty(heightNewAnim, new PropertyPath(Ellipse.HeightProperty));
		//	widthStoryBoard.Children.Add(heightNewAnim);
		//	//widthStoryBoard.Begin(InnElem);

		//}
		private void NewMy()
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
