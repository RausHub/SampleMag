using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        SampleMagContext dbContext;

        public SampleMagContext Init()
        {
            return dbContext ?? (dbContext = new SampleMagContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
