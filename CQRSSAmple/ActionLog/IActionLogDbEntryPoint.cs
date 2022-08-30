using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSSAmple.ActionLog
{
    public interface IActionLogDbEntryPoint 
    {
        Task<List<ActionLog>> GetAsync ();
        Task<ActionLog> GetAsync (Guid id);
        Task<ActionLog> CreateAsync (ActionLog actionLog);
        ActionLog Create (ActionLog actionLog);
        List<ActionLog> InsertMany (List<ActionLog> actionLog);
    }
}