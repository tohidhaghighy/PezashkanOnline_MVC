using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.CommentViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Boolean Active { get; set; }
        public string Text { get; set; }
        public int ParentCommentId { get; set; }
    }
}
