using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSSAmple.ActionLog
{
    public class MongoDummyEntryPoint : IActionLogDbEntryPoint
    {
        public async Task<List<ActionLog>> GetAsync ()
        {
            return await Task.FromResult<List<ActionLog>> (new List<ActionLog> ());
        }

        public async Task<ActionLog> GetAsync (Guid id)
        {
            return await Task.FromResult<ActionLog> (null);
        }

        public async Task<ActionLog> CreateAsync (ActionLog actionLog)
        {
            return await Task.FromResult<ActionLog> (null);
        }

        public ActionLog Create (ActionLog actionLog)
        {
            return null;
        }

        public List<ActionLog> InsertMany (List<ActionLog> actionLog)
        {
            return new List<ActionLog> ();
        }
    }
}