using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EzDomain.EventSourcing.EventStores.Sql.Data
{
    public sealed class SqlStatementsLoader
        : ISqlStatementsLoader
    {
        private IReadOnlyDictionary<string, string> _sqlStatements;

        public void LoadScripts()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var executingAssemblyFileInfo = new FileInfo(executingAssembly.Location);
            
            var currentDirPath = executingAssemblyFileInfo.DirectoryName;

            var sqlFilesPath = Path.Combine(currentDirPath, "Data\\SqlScripts");

            var sqlFilesDir = new DirectoryInfo(sqlFilesPath);
            if (!sqlFilesDir.Exists)
            {
                return;
            }

            _sqlStatements = sqlFilesDir
                .GetFiles()
                .Where(file => file.Extension.Equals(".sql"))
                .ToDictionary(
                    key => key.Name.Split('.')[0],
                    value => File.ReadAllText(value.FullName));
        }

        public string this[string key] => key.ToLower().Contains("async")
            ? _sqlStatements[key.Substring(0, key.Length - 5)]
            : _sqlStatements[key];
    }
}