using System;

namespace StockJournal.Events
{
    enum CrudType
    {
        Created, Updated, Deleted
    }

    abstract class CrudEvent
    {
        protected CrudEvent(CrudType crudType, Guid entityId)
        {
            CrudType = crudType;
            EntityId = entityId;
        }

        public CrudType CrudType { get; set; }
        public Guid EntityId { get; set; }


    }
}
