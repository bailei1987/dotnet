using System.Collections.Generic;

namespace BL.MongoDB
{
    public class NetCoreAppSetting
    {
        public string ReplSetName { get; set; }
        public string Db { get; set; }
        public int? ServerSelectionTimeout { get; set; }
        public List<ServerItem> Servers { get; set; } = new List<ServerItem>();
        public Credential Credential { get; set; }
    }
    public class ServerItem
    {
        public string Host { get; set; }
        public int Port { get; set; }

    }
    public class Credential
    {
        public string User { get; set; }
        public string Pwd { get; set; }
    }
}
