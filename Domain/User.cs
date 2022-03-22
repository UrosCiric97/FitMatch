using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public List<Package> Packages { get; set; }
        public List<Review> ClientReviews { get; set; }
        public List<Review> TrainerReviews { get; set; }
        public List<UserSkill> Skills { get; set; }
        public List<UserSkill> Users { get; set; }
        public List<UserCategory> Categories { get; set; }
        public List<Mentorship> Clients { get; set; }
        public List<Mentorship> Trainers { get; set; }
        public List<Mentorship> Mentorships { get; set; }
        public List<Post> Posts { get; set; }
        public List<Message> ClientMessages { get; set; }
        public List<Message> TrainerMessages { get; set; }
        public List<UserFollowing> ClientFollowings { get; set; }
        public List<UserFollowing> TrainerFollowings { get; set; }


    }
}
