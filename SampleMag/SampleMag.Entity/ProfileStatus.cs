﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMag.Entity
{
    public class ProfileStatus : IEntityBase
    {
        public long ID { get; set; }

        public string Name { get; set; }
    }
}