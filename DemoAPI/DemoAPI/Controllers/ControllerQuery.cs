using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DemoAPI.Controllers
{
    public class ControllerQuery : ControllerBase
    {
        private readonly ILogger<ControllerQuery> _logger;
        private readonly IConfiguration _config;

        public ControllerQuery(IConfiguration config, ILogger<ControllerQuery> logger)
        {
            _logger = logger;
            _config = config;
        }

        protected List<String> GetEmployeeList()
        {
            List<String> columnData = new List<String>();

            var connectionStringName = "sqldb";
            var query = "select name from [demoapi].employee;";

            using (var conn = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
            };

            return columnData;
        }
    }
}
