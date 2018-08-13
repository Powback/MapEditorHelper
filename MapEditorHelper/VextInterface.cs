using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditorHelper
{
    class VextInterface
    {
        public void LoadLevel(string levelName)
        {
            Globals.levels.TryGetValue(levelName, out Globals.currentLevel);
        }


        public void LoadProject(string projectName)
        {
            Globals.currentLevel.projects.TryGetValue(projectName, out Globals.currentProject);

        }

        public void LoadSave(string saveName)
        {
            Globals.currentProject.saves.TryGetValue(saveName, out Globals.currentSaveFile);

        }

    }
}
