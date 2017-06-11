using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMag.Entity
{
    public class User : UserBase
    {
        public User()
        {
            
        }        

        public string Profile_Name { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int Phone { get; set; }

        public long Language_Preference_ID { get; set; }

        public Language Language_Preference { get; set; }

        public string Timezone { get; set; }

        public byte[] Profile_Picture { get; set; }

        public string User_Bio { get; set; }

        public string Url { get; set; }

        public long User_Status_ID { get; set; }

        public ProfileStatus User_Status { get; set; }
        
        public long User_Type_ID { get; set; }

        public User_Type Reference_Type { get; set; }

        public long Vote_Count_Up { get; set; }

        public long Vote_Count_Down { get; set; }        
       

        //    CREATE TABLE Users(
        //UserID bigint NOT NULL PRIMARY KEY AUTOINCREMENT,
        //Username nvarchar(60) NOT NULL,
        //Profile_Name nvarchar(60) NOT NULL,
        //First_Name varchar(60) NOT NULL,
        //Last_Name varchar(100) NOT NULL,
        //City varchar(60),
        //Country varchar(60),
        //Phone int (16),
        //Email nvarchar(100),
        //Password nvarchar(255),
        //Language varchar(60)
        //Timezone nvarchar(60),
        //Profile_Picture varbinary(max),
        //User_Bio nvarchar(100),
        //Url nvarchar(255),
        //User_Status nvarchar(11),
        //User_Registered timestamp NOT NULL,
        //Reference_Type varchar(30),
        //User_Category_Main varchar(200),
        //User_Category_Sub varchar(200),
        //User_Category_Specific varchar(200),
        //Vote_Count_Up int (20),
        //Vote_Count_Down int (20),
        //VoteID bigint(20),
        //Active int (1) DEFAULT '0'

    }
}
