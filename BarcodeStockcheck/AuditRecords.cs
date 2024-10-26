using JsonFlatFileDataStore;

namespace BarcodeStocktake
{
    public class AuditRecords
    {
        private DataStore _store = new DataStore("Alpha_StoreStockAuditRecords.json");
        private DataStore _log = new DataStore("Alpha_StoreStockAuditLog.json");

        public class UpdateItemDetails
        {
            public AuditItem Item { get; private set; }
            public string Location { get; private set; }
            public int QuantityToAdd { get; private set; }

            public UpdateItemDetails(AuditItem auditItemToUpdate, string location, int quantityToAdd)
            {
                this.Item = auditItemToUpdate;
                this.Location = location;
                this.QuantityToAdd = quantityToAdd;
            }
        }

        public AuditLog UpdateItem(UpdateItemDetails updateItem)
        {
            var collection = _store.GetCollection<AuditItem>("stock");
            Func<dynamic, bool> matchCode = e => e.Code == updateItem.Item.Code;
            Func<dynamic, bool> matchLocation = e => e.StorageLocation == updateItem.Item.StorageLocation;
            Func<dynamic, bool> matchBoth = e => matchCode(e) && matchLocation(e);

            var results = collection.AsQueryable().Where(matchBoth).ToList();
            if (results.Any())
            {
                var resultToUpdate = (AuditItem) results.First();
                resultToUpdate.Quantity += updateItem.QuantityToAdd;
                resultToUpdate.LastUpdateTimestamp = DateTime.Now;
                if (!collection.UpdateOne(resultToUpdate.id, resultToUpdate))
                    throw new InvalidOperationException("Failed to update audit stock item.");
            }
            else
            {
                updateItem.Item.Quantity += updateItem.QuantityToAdd;
                updateItem.Item.StorageLocation = updateItem.Location;
                updateItem.Item.InsertTimestamp = DateTime.Now;
                collection.InsertOne(updateItem.Item);
            }

            var logCollection = _log.GetCollection<AuditLog>("log");
            var auditItem = new AuditLog
            {
                Code = updateItem.Item.Code,
                Increment = updateItem.QuantityToAdd,
                Title = updateItem.Item?.Title ?? "",
                Location = updateItem.Item?.StorageLocation ?? "",
                AuditLogTimestamp = DateTime.Now,
            };
            logCollection.InsertOne(auditItem);
            return auditItem;
        }
    }
}