using Scrum.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrum.Infrastructure.Database
{
    public static class ScrumInitializationHandler
    {
        /// <summary>
        /// Database initialization
        /// </summary>
        public static void Initialize()
        {
            System.Data.Entity.Database.SetInitializer(new ScrumDBInitializer());
            using (var db = new ScrumContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
}