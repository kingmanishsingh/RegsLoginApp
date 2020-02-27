﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Regs_Login_App.ViewModels
{
    
     public class ListViewSelectedItemBehavior : Behavior<Xamarin.Forms.ListView>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ListViewSelectedItemBehavior));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public Xamarin.Forms.ListView AssociatedObject { get; private set; }

        protected override void OnAttachedTo(Xamarin.Forms.ListView bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.ItemSelected += OnListViewItemSelected;
        }

        protected override void OnDetachingFrom(Xamarin.Forms.ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.ItemSelected -= OnListViewItemSelected;
            AssociatedObject = null;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Command == null)
                return;

            if (Command.CanExecute(e.SelectedItem))
                Command.Execute(e.SelectedItem);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}