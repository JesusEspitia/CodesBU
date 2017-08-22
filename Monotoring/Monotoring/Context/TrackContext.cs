﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Monotoring.Models;
using MySql.Data.Entity;

namespace Monotoring.Context
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class TrackContext:DbContext
    {
        
        
        public DbSet<Employee_type> Employee_type { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<WorkOrden> WorkOrden { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Area_Orden> Area_Orden { get; set; }
        public DbSet<DelayCode> DelayCode { get; set; }
        public DbSet<DelayWork> DelayWork { get; set; }
        public DbSet<DelayComment> DelayComment { get; set; }
        public DbSet<UserNewRequest> UserNewRequest { get; set; }
        public DbSet<FamilyProduct> FamilyProduct { get; set; }
        public DbSet<SubCodes> SubCodes { get; set; }
        public DbSet<OrdenComment> OrdenComment { get; set; }
        public DbSet<AreaPlus> AreaPlus { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrder { get; set; }
    }
}