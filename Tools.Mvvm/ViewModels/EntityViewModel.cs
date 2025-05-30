﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Mvvm.ViewModels
{
    public abstract class EntityViewModel<T> : ObservableObject
    {
        protected T _entity;

        protected T Entity
        {
            get { return _entity; } 
        }

        protected EntityViewModel(T entity)
        {
            _entity = entity;
        }
    }
}
