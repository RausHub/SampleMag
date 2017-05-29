using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMag.Entity
{
    public class Sample : IEntityBase
    {
        public Sample()
        {
            Genres = new List<Music_Genre>();
        }
        public long ID { get; set; }

        public long UserID { get; set; }

        public User User { get; set; }
        
        public ICollection<Music_Genre> Genres { get; set; }

        public DateTime Posted_On { get; set; }

        public long LifeTimeID { get; set; }

        public Lifetime Lifetime_Duration { get; set; }

        public DateTime Last_Update { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Content_Path { get; set; }

        public string Url { get; set; }

        public string Location { get; set; }

        public string Meta_Value { get; set; }

        public long Mother_ID { get; set; }

        public Sample Mother_Sample { get; set; }

        public int Count_Up { get; set; }

        public int Count_Down { get; set; }



        //    SampleID bigint NOT NULL PRIMARY KEY AUTOINCREMENT,
        //UserID bigint FOREIGN KEY REFERENCES Users(UserID),
        //Post_Category_Main varchar(200),
        //Post_Category_Sub varchar(200),
        //Post_Category_Specific varchar(200),
        //Post_Date timestamp,
        //Post_Date_Countdown date,
        //Post_Update_Date timestamp,
        //Post_Title ntext,
        //Post_Text text,
        //Post_Content text,
        //Post_Content_Type varchar(40),
        //Post_Content_Path nvarchar(255),
        //Post_Url nvarchar(100),
        //Post_Location varchar(100),
        //Post_Meta_Value ntext,
        //Post_Comment boolean,
        //Vote_Count_Up int (20),
        //Vote_Count_Down int (20)

    }
}
