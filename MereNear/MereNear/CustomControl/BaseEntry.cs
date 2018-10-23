﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MereNear.CustomControl
{
    public class BaseEntry : Entry
    {
        // Need to overwrite default handler because we cant Invoke otherwise
        public new event EventHandler Completed;

        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
            nameof(ReturnType),
            typeof(ReturnType),
            typeof(BaseEntry),
            ReturnType.Done,
            BindingMode.OneWay
        );

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public void InvokeCompleted()
        {
            if (this.Completed != null)
                this.Completed.Invoke(this, null);
        }
    }
    public enum ReturnType
    {
        Go,
        Next,
        Done,
        Send,
        Search
    }
}
