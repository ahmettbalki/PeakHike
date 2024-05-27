using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Domain.Entities;

namespace TradeHike.Application.Interfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLast3BlogsWithAuthors();
        public List<Blog> GetAllBlogsWithAuthors();
        public List<Blog> GetBlogByAuthorId(int id);
    }
}
