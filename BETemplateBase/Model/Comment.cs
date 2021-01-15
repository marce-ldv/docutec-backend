using Helper;
using System;

namespace Model
{
    public class Comment
    {
        public int IdComentario { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }
    }
}
