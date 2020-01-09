using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.AutoMapper
{
    public class ArticleAutoMapper:Profile
    {
        public ArticleAutoMapper()
        {
            //CreateMap<Article, LimitedArticleViewModel>().ForMember(d => d.Datetime, m => m.MapFrom(s => s.Datetime.ToString()))
            //    .ForMember(d => d.ArticleGroupid, m => m.MapFrom(s => s.GroupItem))
            //    .ForMember(d => d.ArticleGroupname, m => m.MapFrom(s => s.GroupItems.Name));
            
        }
    }
}
