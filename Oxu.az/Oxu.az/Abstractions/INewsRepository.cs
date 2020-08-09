using Oxu.az.Areas.Admin.Models;
using Oxu.az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oxu.az.Abstractions
{
    public interface INewsRepository
    {
        public bool CreatePost(NewsViewModel news);

        public List<News> GetAllPosts();

        public News GetPost(int id);

        public bool DeletePost(int id);

        public bool EditPost(EditNewsViewModel news);

        public News IncreasePostAffect(PostAffect postAffect);
    }
}
