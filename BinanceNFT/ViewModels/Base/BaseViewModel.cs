﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace BinanceNFT.ViewModels.Base
{
	/// <summary>
	/// A base view model that fires Property Changed events as needed
	/// </summary>
	public class BaseViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// The event that is fired when any child property changes its value
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private readonly Dictionary<string, object> _notifyPropertyValues;

		protected BaseViewModel()
		{
			_notifyPropertyValues = new Dictionary<string, object>();
		}

		/// <summary>
		/// Call this to a fire a PropertyChanged event by typical method
		/// </summary>
		/// <param name="prop"></param>
		protected virtual void RaisePropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		/// <summary>
		/// Use  NotifyPropertySet(() => [PropertyName], value)
		/// </summary>
		protected void NotifyPropertySet<T>(Expression<Func<T>> notifyProperty, T newValue)
		{
			var propertyName = GetPropertyName(notifyProperty);

			if (!_notifyPropertyValues.ContainsKey(propertyName))
				_notifyPropertyValues.Add(propertyName, default(T));

			var lastValue = (T)_notifyPropertyValues[propertyName];
			if (IsEquals(lastValue, newValue))
				return;

			_notifyPropertyValues.Remove(propertyName);
			_notifyPropertyValues.Add(propertyName, newValue);
			OnPropertyChanged(propertyName);
		}

		/// <summary>
		/// Use  NotifyPropertyGet(() => [PropertyName])
		/// </summary>
		protected T NotifyPropertyGet<T>(Expression<Func<T>> notifyProperty)
		{
			var propertyName = GetPropertyName(notifyProperty);

			if (!_notifyPropertyValues.ContainsKey(propertyName))
				_notifyPropertyValues.Add(propertyName, default(T));

			return (T)_notifyPropertyValues[propertyName];
		}

		public string GetPropertyName<T>(Expression<Func<T>> expr)
		{
			var member = (MemberExpression)expr.Body;
			return member.Member.Name;
		}

		private bool IsEquals<T>(T obj1, T obj2)
		{
			if (obj1 == null)
				return obj2 == null;

			return obj1.Equals(obj2);
		}

	}
}
