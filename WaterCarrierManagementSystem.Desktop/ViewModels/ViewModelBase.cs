﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WaterCarrierManagementSystem.Desktop.ViewModels;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null!)
    {
        if (Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(PropertyName);
        return true;
    }
}
