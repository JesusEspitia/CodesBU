using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using Monotoring.Context;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monotoring.Models
{
    public class Users
    {
        [DisplayName("Usuario")]
        public int UsersId { get; set; }
        [DisplayName("Nombre de usuario")]
        public string username { get; set; }
        //[RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")]
        [DisplayName("Nombre completo")]
        public string fullname { get; set; }
        [DisplayName("Cargo")]
        public int TypeId { get; set; }
        [DisplayName("Área")]
        public int? AreaId { get; set; }

        [ForeignKey("TypeId")]
        public Employee_type Type { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        //public ICollection<Area> Area { get; set; }
        public ICollection<DelayWork> DelayWork { get; set; }
        public ICollection<Area_Orden> Area_Orden { get; set; }
        public ICollection<DelayComment> DelayComment { get; set; }

        private TrackContext context = new TrackContext();

        //public string login()
        //{
            
        //    var query = from u in context.Users
        //                where u.userEmail == userEmail 
        //                select u;
        //    if (query.Count() > 0)
        //    {
        //        this.userEmail = userEmail;
        //        var query2 = from u in context.Users where u.userEmail == userEmail where u.userPass==userPass select u;
        //        var datos= query2.ToList();
        //        if (datos.Count > 0)
        //        {
        //            foreach (var d in datos)
        //            {
        //                username = d.username;
        //                UsersId = d.UsersId;
        //                TypeId = d.TypeId;
        //                AreaId = d.AreaId;
        //            }
        //            return "in";
        //        }
        //        else
        //        {
        //            return "pass";
        //        }
                
        //    }
        //    else
        //    {
                
        //        return "user";
        //    }
        //}
    }
}