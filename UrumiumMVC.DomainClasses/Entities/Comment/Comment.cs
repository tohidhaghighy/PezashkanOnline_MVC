using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Comment
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Boolean Active { get; set; }
        public string Text { get; set; }
        public int ParentCommentId { get; set; }
        //learn==0  && package==1 to typecomment
        public int TypeComment { get; set; }
        public int PackageLearnId { get; set; }
        //ask==0  && answer==1 to askanswer comment
        public int AskAnswerComment { get; set; }
    }
}
