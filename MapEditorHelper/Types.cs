using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditorHelper
{
    class Level : IPathInformation
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Dictionary<string, Project> projects;
    }
    class Project : IPathInformation
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Dictionary<string, SaveFile> saves;
    }

    class SaveFile : IPathInformation
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public string saveTime;
    }

    interface IPathInformation
    {
        string Name { get; set; }
        string Path { get; set; }
    }
}
