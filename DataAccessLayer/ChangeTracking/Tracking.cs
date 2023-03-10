using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace N_Tier_Architecture_FinalProject.ChangeTracking
{
    public class Tracking:ITracking
    {
        private readonly FlipkartContext _context;
        private readonly ILogger<EntityState> _logger;
        public Tracking(FlipkartContext context, ILogger<EntityState> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AllChanges()
        {
            var entries = _context.ChangeTracker.Entries() 
               .Where(x => x.State != EntityState.Unchanged && x.State != EntityState.Detached).ToList();
            
            if(entries==null)
            {
                return;
            }
            foreach(var entry in entries)
            {
                using (LogContext.PushProperty("LogTrack", value: new { before = entry.OriginalValues.ToObject(), after = entry.CurrentValues.ToObject() }, destructureObjects: true))
                    _logger.LogInformation("Tracker Objects Logged");
            }

        }
    }
}
