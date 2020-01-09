using SmsIrRestful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrumiumWithIdentity.SmsPanelList;

namespace UrumiumWithIdentity.Models
{
    public class SendSms
    {
        public Boolean SendSmsFunction(string to,string text)
        {
            var token = new Token().GetToken("c7b17989dff70224b6b57e4e", "!@#%qwer5321");

            var restVerificationCode = new RestVerificationCode()
            {
                Code = text,
                MobileNumber = to
            };

            var restVerificationCodeRespone = new VerificationCode().Send(token, restVerificationCode);

            if (restVerificationCodeRespone.IsSuccessful)
            {
                return true;
            }
            else
            {

            }
            return false;
        }
    }
}