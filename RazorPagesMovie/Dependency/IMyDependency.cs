﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Dependency
{
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
}
