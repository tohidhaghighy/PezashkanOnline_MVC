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
        public Boolean SendSmsFunction(string to, string text)
        {
            var token = new Token().GetToken("ee3ba626f282b38dd6c9a626", "divar123-09");

            var restVerificationCode = new RestVerificationCode()
            {
                Code = text,
                MobileNumber = to,

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

        public Boolean SendSmsCustom(string to, string text)
        {
            var token = new Token().GetToken("ee3ba626f282b38dd6c9a626", "divar123-09");
            long mb = Convert.ToInt32(to);
            var ultraFastSend = new UltraFastSend()
            {
                Mobile = mb,
                TemplateId = 22495,
                ParameterArray = new List<UltraFastParameters>(){
        new UltraFastParameters()
        {
            Parameter = "time" , ParameterValue = "یکشنبه ساعت 4"
        }}.ToArray()
            };

            UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);

            if (ultraFastSendRespone.IsSuccessful)
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