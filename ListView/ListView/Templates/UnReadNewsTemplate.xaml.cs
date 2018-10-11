﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListView.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UnReadNewsTemplate : ViewCell
	{
		public UnReadNewsTemplate ()
		{
			InitializeComponent ();
		}

	    public static readonly BindableProperty BaseContextProperty =
	        BindableProperty.Create("BaseContext", typeof(object), typeof(UnReadNewsTemplate), null, propertyChanged: OnParentContextPropertyChanged);

	    public object BaseContext
	    {
	        get { return GetValue(BaseContextProperty); }
	        set { SetValue(BaseContextProperty, value); }
	    }
	    private static void OnParentContextPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {
	        if (newvalue != oldvalue && newvalue != null)
	        {
	            (bindable as UnReadNewsTemplate).BaseContext = newvalue;
	        }
	    }
    }
}