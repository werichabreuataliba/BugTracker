﻿using BugTracker.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class MongoDBRepository
    {
        public readonly IMongoDatabase DataBase;

        public MongoDBRepository(IOptions<Settings> settings)
        {
            try
            {
                var mclient = new MongoClient(settings.Value.ConnectionString);
                DataBase = mclient.GetDatabase(settings.Value.Database);
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem connecting to the MongoDB database", ex);
            }
        }
    }
}
