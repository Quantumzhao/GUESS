using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using GUESS.Misc;
using GUESS.ViewModels;
using System;

namespace GUESS.Views
{
	public class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			_Singleton = this;

			for (int i = 0; i < 6; i++)
			{
				this.FindControl<Border>($"Candidate{i}").PointerPressed += DoDrag;
			}

			Width = 450;
			Height = 800;
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private static MainWindow _Singleton;

		private void DoDrag(object sender, PointerPressedEventArgs e)
		{
			BrushDataObject dragData = new BrushDataObject((sender as Border).Background);

			DragDrop.DoDragDrop(e, dragData, DragDropEffects.Copy);
		}

		public static void CloseWindow() => (_Singleton.VisualRoot as Window).Close();
	}
}
