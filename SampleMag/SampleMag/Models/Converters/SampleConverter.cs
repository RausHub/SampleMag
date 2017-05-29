using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMag.Models.Converters
{
    public class SampleConverter
    {
        public static void CloneSample(ref Sample s, Sample t)
        {
            s.Content_Path = t.Content_Path;
            s.Count_Down = t.Count_Down;
            s.Count_Up = t.Count_Up;
            s.Last_Update = t.Last_Update;
            s.Lifetime = t.Lifetime;
            s.Location = t.Location;
            s.Meta_Value = t.Meta_Value;
            s.Posted_on = t.Posted_on;
            s.Text = t.Text;
            s.Title = t.Title;
            s.Url = t.Url;
            s.UserID = t.UserID;
        }
    }
}