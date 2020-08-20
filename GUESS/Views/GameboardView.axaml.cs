using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GUESS.Views
{
	public class GameboardView : UserControl
	{
		public GameboardView()
		{
			this.InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
