using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Objects;

namespace PlataformaComercio.Web.Admin
{
    public partial class PlataformaComercioEntities
    {
        partial void OnContextCreated()
        {
            
            this.SavingChanges += new EventHandler(PlataformaComercioEntities_SavingChanges);

        }

        void PlataformaComercioEntities_SavingChanges(object sender, EventArgs e)
        {
            var stateManager =
                ((PlataformaComercioEntities)sender).ObjectStateManager;
            var newEntities =
                ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified);

            foreach (ObjectStateEntry stateEntryEntity in
                    newEntities)
            {
                if (stateEntryEntity.Entity is Trade)
                {
                    ((Trade)stateEntryEntity.Entity).LastMod = DateTime.Now;
                }
                else if (stateEntryEntity.Entity is Product)
                {
                    ((Product)stateEntryEntity.Entity).LastMod = DateTime.Now;
                }
            }
        }

        
    }
}