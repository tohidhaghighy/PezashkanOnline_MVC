using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.Common.Massage
{
    public class ErrorMsg
    {
        public const string MaxLenghtMsg = "{0} نباید بیشتر از {1} کاراکتر باشد";
        public const string MinLenghtMsg = "{0} نباید کمتر از {1} کاراکتر باشد";
        public const string RegeMsg = "قالب {0} اشتباه است";
        public const string RequierdMsg = "{0} را وارد نمایید";
        public const string MaxMinLenghMsg = " باشد {2} طول {0} نباید کمتر از {1} کاراکتر و بیشتر از";
        public const string Compare = " {0} وارد شده یکسان نمی باشد.";
    }
}
