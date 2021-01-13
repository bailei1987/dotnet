using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Common
{
    public class ImportResult<T> where T : ImportDataItem
    {
        public List<T> Items { get; set; } = new List<T>();
        public List<T> Errors { get { return Items.FindAll(x => x.Status == ImportDataItemStatus.Error); } }
        public List<T> WaitImports { get; } = new List<T>();
        public List<T> WaitUpdates { get; } = new List<T>();

        public int Total { get { return Items.Count; } }
        public int SuccessCount { get { return Items.Count(x => x.Status == ImportDataItemStatus.Success); } }
        public int ErrorCount { get { return Items.Count(x => x.Status == ImportDataItemStatus.Error); } }
        public int IgnoreCount { get { return Items.Count(x => x.Status == ImportDataItemStatus.Ignore); } }
        public bool HasWaitImportOrUpdate { get { return WaitImports.Count > 0 || WaitUpdates.Count > 0; } }
        public List<string> Msgs { get; set; }

        public bool MatchErrors(Predicate<T> match, string msg = null)
        {
            var items = WaitImports.FindAll(match);
            items.ForEach(x =>
            {
                x.SetStatus(ImportDataItemStatus.Error, msg);
                WaitImports.Remove(x);
            });
            return items.Count > 0;
        }
        public bool MatchIgnores(Predicate<T> match, string msg = null)
        {
            var items = WaitImports.FindAll(match);
            items.ForEach(x =>
            {
                x.SetStatus(ImportDataItemStatus.Ignore, msg);
                WaitImports.Remove(x);
            });
            return items.Count > 0;
        }
        public bool MatchUpdates(Predicate<T> match, string msg = null)
        {
            var items = WaitImports.FindAll(match);
            items.ForEach(x =>
            {
                x.SetStatus(ImportDataItemStatus.WaitUpdate, msg);
                WaitImports.Remove(x);
                WaitUpdates.Add(x);
            });
            return items.Count > 0;
        }

        public bool ValidateItems()
        {
            if (WaitImports.Count != Items.Count) throw new Exception("Validate All Items must only use when all items are WaitImports");
            WaitImports.ForEach(x =>
            {
                x.Validate();
            });
            return WaitImports.RemoveAll(x => x.Status == ImportDataItemStatus.Error || x.Msg != null) == 0;
        }
        /// <summary>
        /// change all items in WaitImports and WaitUpdates to Success,and clear this two collection
        /// </summary>
        public ImportResult<T> ImportSuccess()
        {
            WaitImports.ForEach(x =>
            {
                if (x.Status == ImportDataItemStatus.WaitImport) x.SetStatus(ImportDataItemStatus.Success, "导入成功");
            });
            WaitImports.Clear();
            WaitUpdates.ForEach(x =>
            {
                if (x.Status == ImportDataItemStatus.WaitUpdate) x.SetStatus(ImportDataItemStatus.Success, "更新成功");
            });
            WaitUpdates.Clear();
            Items = Items.OrderBy(x => x.Status).ToList();
            return this;
        }
        public ImportResult<T> ImportClear()
        {
            WaitImports.Clear();
            WaitUpdates.Clear();
            return this;
        }
    }
    public class ImportResult
    {
        public static ImportResult<T> Create<T>(List<T> list) where T : ImportDataItem
        {
            var result = new ImportResult<T>();
            if (list is null || list.Count == 0) throw new Exception("import list cant be null or empty");
            list.ForEach(x => x.SetStatus(ImportDataItemStatus.WaitImport));
            result.Items = list;
            result.WaitImports.AddRange(list);
            return result;
        }
    }
    public class ImportDataItem : IValidate
    {
        public void SetStatus(ImportDataItemStatus status, string msg = null)
        {
            Status = status;
            Msg = msg;
        }

        public virtual string Validate()
        {
            return null;
        }

        public ImportDataItemStatus Status { get; private set; }
        public string Msg { get; set; }
    }
    public enum ImportDataItemStatus
    {
        WaitImport = 0,
        WaitUpdate = 1,
        /// <summary>
        /// use Imported and Override for more detail
        /// </summary>
        Success = 3,
        Error = -1,
        Ignore = 2
    }

}
