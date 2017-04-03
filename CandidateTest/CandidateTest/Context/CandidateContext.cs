using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CandidateTest.Models;
using MySql.Data.Entity;

namespace CandidateTest.Context
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CandidateContext:DbContext
    {
    }
}