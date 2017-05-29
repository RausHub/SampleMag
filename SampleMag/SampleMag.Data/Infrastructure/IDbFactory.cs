using System;

namespace SampleMag.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SampleMagContext Init();
    }
}
