﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SampleMagContext Init();
    }
}