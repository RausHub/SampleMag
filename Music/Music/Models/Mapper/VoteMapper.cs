using Music.EF;

namespace Music.Models.Mapper
{
    public class VoteMapper
    {
        public static void CloneVote(ref Vote v, Vote t)
        {
            v.Remark = t.Remark;
            v.SampleId = t.SampleId;
            v.Time_Of_Vote = t.Time_Of_Vote;
            v.UserId = t.UserId;
            v.Vote_Value = t.Vote_Value;
        }
    }
}