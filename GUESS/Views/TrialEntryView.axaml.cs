using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using GUESS.Misc;
using GUESS.Models;
using GUESS.ViewModels;

namespace GUESS.Views
{
	public class TrialEntryView : UserControl
	{
		public TrialEntryView()
		{
			this.InitializeComponent();

			this.DataContextChanged += (object sender, EventArgs e) 
				=> ((sender as TrialEntryView).DataContext as TrialEntryViewModel).View 
				= sender as TrialEntryView;
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);

			for (int i = 0; i < GameManager.PEG_COUNTS; i++)
			{
				var peg = _Pegs[i];
				peg = this.FindControl<Border>($"Peg{i}");
				peg.PointerPressed += DoDrag;
				peg.AddHandler(DragDrop.DropEvent, (sender, e) => DropWrapper(sender, e, peg));
				peg.AddHandler(DragDrop.DragOverEvent, DragOver);
			}
		}

		private readonly Border[] _Pegs = new Border[GameManager.PEG_COUNTS];

		private void DoDrag(object sender, PointerPressedEventArgs e)
		{
			BrushDataObject dragData = new BrushDataObject((sender as Border).Background);

			DragDrop.DoDragDrop(e, dragData, DragDropEffects.Move);
		}

		private static void DragOver(object sender, DragEventArgs e)
		{
			e.DragEffects &= (DragDropEffects.Copy | DragDropEffects.Move);
			if (!(e.Data is BrushDataObject))
			{
				e.DragEffects = DragDropEffects.None;
			}
		}

		private static void DropWrapper(object sender, DragEventArgs e, Border border)
		{
			if (e.Data is BrushDataObject b)
			{
				border.Classes.Remove("Empty");
				border.Classes.Add("Filled");
				border.Background = b.Brush;
			}
		}
	}
}
