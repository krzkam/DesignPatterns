﻿using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
 

namespace DesignPatterns.Observer
{
    public class Product : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (value == name) return; // critical
                name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(
          [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Product: {Name}";
        }
    }

    public class Window2 : INotifyPropertyChanged
    {
        private string productName;

        public string ProductName
        {
            get => productName;
            set
            {
                if (value == productName) return; // critical
                productName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Window2(Product product)
        {
            ProductName = product.Name;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(
          [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Window: {ProductName}";
        }
    }

    public sealed class BidirectionalBinding : IDisposable
    {
        private bool disposed;

        public BidirectionalBinding(
          INotifyPropertyChanged first,
          Expression<Func<object>> firstProperty,
          INotifyPropertyChanged second,
          Expression<Func<object>> secondProperty)
        {
            if (firstProperty.Body is MemberExpression firstExpr
                && secondProperty.Body is MemberExpression secondExpr)
            {
                if (firstExpr.Member is PropertyInfo firstProp
                    && secondExpr.Member is PropertyInfo secondProp)
                {
                    first.PropertyChanged += (sender, args) =>
                    {
                        if (!disposed)
                        {
                            secondProp.SetValue(second, firstProp.GetValue(first));
                        }
                    };
                    second.PropertyChanged += (sender, args) =>
                    {
                        if (!disposed)
                        {
                            firstProp.SetValue(first, secondProp.GetValue(second));
                        }
                    };
                }
            }
        }

        public void Dispose()
        {
            disposed = true;
        }
    }

}
