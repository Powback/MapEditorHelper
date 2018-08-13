using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditorHelper
{
    static class SaveIndexer
    {
        static string basePath = null;
        public static void Index()
        {
            if (!isValidPath())
            {
                return;
            }

            Globals.levels = GetContents<Level>(basePath);
            foreach(Level level in Globals.levels.Values)
            {
                level.projects = GetContents<Project>(level.Path);
                foreach (Project project in level.projects.Values)
                {
                    project.saves = GetContents<SaveFile>(level.Path);
                }
            }
        }

        static Dictionary<string, T> GetContents<T>(string path) where T : IPathInformation, new()
        {
            Dictionary<string, T> items = new Dictionary<string, T>();
            foreach (string itemPath in Searcher.GetDirectories(path))
            {
                T item = new T();
                item.Name = Path.GetFileName(itemPath);
                item.Path = itemPath;
                items.Add(item.Name, item);
            }
            return items;
        }

        static bool isValidPath()
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(documents))
            {
                Console.WriteLine("failed to get documents path");
                return false;
            }
            string BF3directory = Path.Combine(documents, "Battlefield 3");
            if (!Directory.Exists(BF3directory))
            {
                Console.WriteLine(BF3directory + " does not exist.");
                return false;
            }
            string editorDirectory = Path.Combine(BF3directory, "MapEditor");
            if (!Directory.Exists(editorDirectory))
            {
                Console.WriteLine(editorDirectory + " does not exist. Creating.");
                Directory.CreateDirectory(editorDirectory);
            }
            basePath = editorDirectory;
            return true;
        }
    }
}
