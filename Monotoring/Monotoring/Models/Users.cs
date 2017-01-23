using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using Monotoring.Context;

namespace Monotoring.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        public string username { get; set; }
        public string userEmail { get; set; }
        public string userPass { get; set; }
        public int TypeId { get; set; }
        public int? AreaId { get; set; }

        [ForeignKey("TypeId")]
        public Employee_type Type { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        //public ICollection<Area> Area { get; set; }
        public ICollection<DelayWork> DelayWork { get; set; }
        public ICollection<Area_Orden> Area_Orden { get; set; }

        private TrackContext context = new TrackContext();

        public bool login()
        {
            var query = from u in context.Users
                        where u.userEmail == userEmail && u.userPass == userPass
                        select u;
            if (query.Count() > 0)
            {
                var query2 = from u in context.Users where u.userEmail == userEmail select u;
                var datos = query2.ToList();
                foreach(var d in datos)
                {
                    username = d.username;

                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}