﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Core.CrossCuttingConcerns.Autofac.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool isAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string key);
    }
}
