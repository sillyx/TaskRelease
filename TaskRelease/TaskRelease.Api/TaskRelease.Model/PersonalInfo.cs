using System;

namespace TaskRelease.Model
{
    [Serializable]
    public class PersonalInfo
    {
        public string Id { get; set; }

        public Member Member { get; set; }

        public PersonCategory Category { get; set; }

        public string City { get; set; }

        public string Salary { get; set; }

        public string JobCategory { get; set; }

        public string Remark { get; set; }

        public int CurrentState { get; set; }

        public string IsDisplay { get; set; }

        public string CreateDate { get; set; }

        public string AuditState { get; set; }

        public int Sort { get; set; }

    }
}
