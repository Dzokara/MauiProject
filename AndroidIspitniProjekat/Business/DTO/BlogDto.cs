using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Business.DTO
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }

        public DateTime Date { get; set; }

        public ICollection<CommentDto> Comments { get; set; }
    }

    public class CommentDto
    {
        public int AuthorId { get; set; }

        public int blogId { get; set; }

        public string Text { get; set; }

        public User User { get; set; }
    }
}
