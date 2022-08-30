using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CQRSSAmple.ActionLog
{
     public class MongoDbEntryPoint : IActionLogDbEntryPoint
    {
        private readonly IMongoCollection<ActionLog> _logs;

        public MongoDbEntryPoint ()
        {
            //TODO: GESTIRE DA FILE DI CONFIGURAZIONE
            var mongoClient = new MongoClient ("mongodb://mongodb:secret@localhost:27017/logs?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&ssl=false");

            var db = mongoClient.GetDatabase ("CQRSSample");

            _logs = db.GetCollection<ActionLog> ("actionlog");

            
            
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

        public List<ActionLog> Get() => _logs.Find(l => l.PerformingUser == "paologregorat").ToList();

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