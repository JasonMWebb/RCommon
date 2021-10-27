﻿using Microsoft.Extensions.Configuration;
using RCommon.DataServices.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCommon.Persistance.Dapper.Tests
{
    public class TestDbConnection : RDbConnection
    {

        public TestDbConnection(IConfiguration configuration) : base("Microsoft.Data.SqlClient", configuration.GetConnectionString(@"TestDbConnection"))
        {

        }
    }
}