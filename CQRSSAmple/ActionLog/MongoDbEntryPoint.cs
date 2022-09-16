using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSSAmple.Domain.Infrasctructure.Configuration;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CQRSSAmple.ActionLog
{
     public class MongoDbEntryPoint : IActionLogDbEntryPoint
    {
        private readonly IMongoCollection<ActionLog> _logs;

        public MongoDbEntryPoint ()
        {
            var actionLogMongoConnectionString =(string) AppCQRSSampleConfiguration.GetConfiguration().GetValue(typeof(string),"ActionLogMongoConnectionString");
            var actionLogMongoDataBaseName =(string) AppCQRSSampleConfiguration.GetConfiguration().GetValue(typeof(string),"ActionLogMongoDataBaseName");
            var actionLogCollection =(string) AppCQRSSampleConfiguration.GetConfiguration().GetValue(typeof(string),"ActionLogCollection");
            
            var mongoClient = new MongoClient (actionLogMongoConnectionString);

            var db = mongoClient.GetDatabase (actionLogMongoDataBaseName);

            _logs = db.GetCollection<ActionLog> (actionLogCollection);

            
            
            _logs.Indexes.CreateOne (new CreateIndexModel<ActionLog> (
                                                Builders<ActionLog>.IndexKeys.Descending (ik => ik.CreatedDate),
                                                new CreateIndexOptions
                                                {
                                                    ExpireAfter = TimeSpan.FromDays (5),
                                                    Name = "ActionLogsTTLIndex",
                                                    Background = true
                                                }
                                            ));

            _logs.Indexes.CreateOne (new CreateIndexModel<ActionLog> (
                                        Builders<ActionLog>.IndexKeys.Descending (ik => ik.EntityType)));
            _logs.Indexes.CreateOne (new CreateIndexModel<ActionLog> (
                                        Builders<ActionLog>.IndexKeys.Descending (ik => ik.ActionType)));
            
        }

        public List<ActionLog> Get() => _logs.Find(l => true).ToList();

        public async Task<List<ActionLog>> GetAsync () => await (await _logs.FindAsync (log => true)).ToListAsync ();

        public async Task<ActionLog> GetAsync (Guid id) => await (await _logs.FindAsync (log => log.Id == id)).FirstOrDefaultAsync ();

        public async Task<ActionLog> CreateAsync (ActionLog actionLog)
        {
            await _logs.InsertOneAsync (actionLog);
            return actionLog;
        }

        public ActionLog Create (ActionLog actionLog)
        {
            _logs.InsertOne (actionLog);
            return actionLog;
        }

        public List<ActionLog> InsertMany (List<ActionLog> actionLog)
        {
            _logs.InsertMany (actionLog);
            return actionLog;
        }
    }
}