using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace BinanceNFT.Helpers
{
	public static class AncestorHelper
	{
		public static T FindAncestor<T>(this DependencyObject current)
			where T : DependencyObject
		{
			if (current == null)
				return null;
			do
			{
				var ancestor = current as T;
				if (ancestor != null)
					return ancestor;
				current = VisualTreeHelper.GetParent(current);
			}
			while (current != null);
			return null;
		}

		public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
		{
			// get parent item
			DependencyObject parentObject = VisualTreeHelper.GetParent(child);

			// we’ve reached the end of the tree
			if (parentObject == null) return null;

			// check if the parent matches the type we’re looking for
			T parent = parentObject as T;
			if (parent != null)
			{
				return parent;
			}

			// use recursion to proceed with next level
			return FindVisualParent<T>(parentObject);
		}

		public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
		{
			if (depObj == null) return null;

			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
			{
				var child = VisualTreeHelper.GetChild(depObj, i);

				var result = (child as T) ?? GetChildOfType<T>(child);
				if (result != null) return result;
			}
			return null;
		}

		public static Window FindActiveWindow()
		{
			if (!Invoking.IsMainThread)
				throw new InvalidOperationException("attempt to access window not from main thread");

			return Application.Current?.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
		}

		public static Window GetMainWindow()
		{
			if (!Invoking.IsMainThread)
				throw new InvalidOperationException("attempt to access window not from main thread");

			var mainWindow = Application.Current?.MainWindow;
			return mainWindow;
		}

		public static bool BringWindowToForeground(Window window)
		{
			try
			{
				if (window == null)
					return false;

				var wih = new WindowInteropHelper(window);
				var mainHwnd = wih.Handle;

				return SetForegroundWindow(mainHwnd) != 0;
			}
			catch (Exception ex)
			{
				throw new Exception("Error while bring windows to foreground for message box", ex);
			}
		}

		[DllImport("user32.dll")]
		static extern int SetForegroundWindow(IntPtr hWnd);
	}
}
