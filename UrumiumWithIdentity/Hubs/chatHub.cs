using DataLayer.Context;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.DayTimeDoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.SearchDayInterface;
using UrumiumWithIdentity.Models;

namespace UrumiumWithIdentity.Hubs
{
    public class chatHub:Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private static readonly List<UserChatroom> Users = new List<UserChatroom>();
        public async Task send(string name, string message,string id)
        {
            Clients.AllExcept(id).addNewItem(name, message);
        }

        public async Task sendgroup(string userid,string message, string group,string sender)
        {
            int groupid = Convert.ToInt32(group);
            if (sender=="U")
            {
                if (AddMassageillness(message, userid, groupid,message,0))
                {
                    this.Clients.OthersInGroup(group).groupmassage(message);
                }
            }
            else if (sender=="D")
            {
                if (AddMassageDoctor(message, userid, groupid,message,0))
                {
                    this.Clients.OthersInGroup(group).groupmassage(message);
                }
            }
        }

        public async Task sendimagegroup(string userid,string image,string group, string sender)
        {
            string i = "<a href=" + image + "><img src=" + image + " style='height:70px;width:70px;' href=" + image + "/></a>";
            int groupid = Convert.ToInt32(group);
            if (sender == "U")
            {
                if (AddMassageillness(image, userid, groupid,i,1))
                {
                    this.Clients.OthersInGroup(group).groupimagemassageothers(image);
                    this.Clients.Caller.groupimagemassageown(image);
                }
            }
            else if (sender == "D")
            {
                if (AddMassageDoctor(image, userid, groupid,i,1))
                {
                    this.Clients.OthersInGroup(group).groupimagemassageothers(image);
                    this.Clients.Caller.groupimagemassageown(image);
                }
            }
        }

        public async Task sendvoicegroup(string userid, string voice, string group, string sender)
        {
            string v = "<audio controls='' src='" + voice + "'></audio>";
            int groupid = Convert.ToInt32(group);
            if (sender=="U")
            {
                if (AddMassageillness(voice, userid, groupid,v,2))
                {
                    this.Clients.OthersInGroup(group).groupvoicemassageothers(voice);
                    this.Clients.Caller.groupvoicemassageown(voice);
                }
            }
            else if (sender=="D")
            {
                if (AddMassageDoctor(voice, userid, groupid,v,2))
                {
                    this.Clients.OthersInGroup(group).groupvoicemassageothers(voice);
                    this.Clients.Caller.groupvoicemassageown(voice);
                }
            }
        }
        

        public async Task adduser(string name, string group)
        {
            Users.Add(new UserChatroom()
            {
                Group=group,
                Username=name,
                ConnectionId=Context.ConnectionId
            });
            this.Groups.Add(Context.ConnectionId, group);
        }

        public async Task adduserjudge(string name, string group)
        {
            //var fomd = await db.Cities.ToListAsync();
            Users.Add(new UserChatroom()
            {
                Group = "judge"+group,
                Username = name,
                ConnectionId = Context.ConnectionId
            });
            this.Groups.Add(Context.ConnectionId, "judge" + group);
           
        }

        public async Task sendgroupjudge(string message, string group,string userid,string sender)
        {
            int groupid = Convert.ToInt32(group);
            if (sender=="U")
            {
                if (AddMassageIllnessJudge(message,userid,groupid,message,0))
                {
                    this.Clients.OthersInGroup("judge" + group).groupmassage(message);
                }
            }
            else if (sender=="J")
            {
                if (AddMassageJudgeIllness(message, userid, groupid,message,0))
                {
                    this.Clients.OthersInGroup("judge" + group).groupmassage(message);
                }
            }
            
        }

        public async Task sendgroupimgjudge(string image, string group, string userid, string sender)
        {
            int groupid = Convert.ToInt32(group);
            string i = "<a href=" + image + "><img src=" + image + " style='height:70px;width:70px;' href=" + image + "/></a>";
            if (sender == "U")
            {
                if (AddMassageIllnessJudge(image, userid, groupid,i,1))
                {
                    this.Clients.OthersInGroup("judge" + group).groupimagemassageothers(image);
                    this.Clients.Caller.groupimagemassageown(image);
                }
            }
            else if (sender == "J")
            {
                if (AddMassageJudgeIllness(image, userid, groupid,i,1))
                {
                    this.Clients.OthersInGroup("judge" + group).groupimagemassageothers(image);
                    this.Clients.Caller.groupimagemassageown(image);
                }
            }

        }

        public Boolean AddMassageillness(string text,string userid,int visitid,string onlytext,int typemassage)
        {
            db.IllnessMassages.Add(new UrumiumMVC.DomainClasses.Entities.Illness.IllnessMassage()
            {
                Date = DateTime.Now,
                Text = text,
                UserDoctor = true,
                UserId = userid,
                VisitId = visitid,
                OnlyUrlText=onlytext,
                TypeMassage=typemassage
            });
            db.SaveChanges();
            return true;

        }

        public Boolean AddMassageDoctor(string text, string userid, int visitid,string onlytext,int typemassage)
        {
            db.IllnessMassages.Add(new UrumiumMVC.DomainClasses.Entities.Illness.IllnessMassage()
            {
                Date = DateTime.Now,
                Text = text,
                UserDoctor = false,
                UserId = userid,
                VisitId = visitid,
                OnlyUrlText=onlytext,
                TypeMassage=typemassage
            });
            db.SaveChanges();
            return true;

        }

        public Boolean AddMassageIllnessJudge(string text, string userid, int visitid,string onlytext,int typemassage)
        {
            db.JudgeIllnesses.Add(new UrumiumMVC.DomainClasses.Entities.judge.JudgeIllness()
            {
               AnswerDatetime=DateTime.Now,
               AnswerUserId=userid,
               JudgeIllnessPaymentId=visitid,
               Text=text,
               UserJudge=true,
               OnlyUrlText=onlytext,
               TypeMassage=typemassage
            });
            db.SaveChanges();
            return true;

        }

        public Boolean AddMassageJudgeIllness(string text, string userid, int visitid,string onlytext,int typemassage)
        {
            db.JudgeIllnesses.Add(new UrumiumMVC.DomainClasses.Entities.judge.JudgeIllness()
            {
                AnswerDatetime = DateTime.Now,
                AnswerUserId = userid,
                JudgeIllnessPaymentId = visitid,
                Text = text,
                UserJudge = false,
                OnlyUrlText=onlytext,
                TypeMassage=typemassage
            });
            db.SaveChanges();
            return true;

        }
    }
}