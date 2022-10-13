﻿using System;
using System.CodeDom;
using System.Windows.Forms;

namespace ScreensaverEngine
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ModuleInfoAttribute : Attribute 
    {
        public string ModuleName { get; private set; }
        public string ModuleAuthor { get; private set; }
        public Type ConfigForm { get; private set; }

        public ModuleInfoAttribute(string moduleName, string moduleAuthor, Type configForm = null)
        {
            ModuleName = moduleName;
            ModuleAuthor = moduleAuthor;
            if(configForm == null)
            {
                ConfigForm = null;
            }
            else if (configForm.IsSubclassOf(typeof(Form)))
            {
                ConfigForm = configForm;
            }
            else
            {
                Debug.LogError($"{ModuleName}'s config form is not a Form or null. Ignoring.");
            }
        }
    }
}
