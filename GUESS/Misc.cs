using Avalonia.Input;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUESS.Misc
{
	public class BrushDataObject : DataObject
	{
		public BrushDataObject(IBrush brush) => Brush = brush;
		public IBrush Brush { get; }
	}
}
