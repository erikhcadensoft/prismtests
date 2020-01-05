using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace PrismTests.Helpers
{
    /// <summary>
	/// Observable object with INotifyPropertyChanged implemented
	/// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
		/// Occurs when property changed.
		/// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T backingStore, T value, Expression<Func<T>> p)
        {
            //if value didn't change
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            RaisePropertyChanged(p);

            return true;
        }

        /// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
        protected virtual void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> p)
        {
            var memberExpression = (MemberExpression)p.Body;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }
    }
}
