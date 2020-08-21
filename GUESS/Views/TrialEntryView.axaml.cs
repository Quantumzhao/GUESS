using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GUESS.Views
{
	public class TrialEntryView : UserControl
	{
		public TrialEntryView()
		{
			this.InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
