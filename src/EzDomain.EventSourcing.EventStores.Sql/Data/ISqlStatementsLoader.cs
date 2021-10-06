namespace EzDomain.EventSourcing.EventStores.Sql.Data
{
    public interface ISqlStatementsLoader
    {
        void LoadScripts();
        
        string this[string key] { get; }
    }
}