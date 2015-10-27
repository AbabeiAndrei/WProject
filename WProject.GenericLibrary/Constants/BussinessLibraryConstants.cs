using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Constants
{
    public enum DictItemType
    {
        TaskType,
        TaskState,
        TaskActivity,
        Unknow
    }

    public enum AccessObjectType
    {
        AccessProject,
        AccessProjectSettings,
        AccessProjectSettingsUser,
        AccessProjectSettingsGroup,
        AccessProjectSettingsAccess,
        AccessProjectSettingsDictItem,
        AccessBacklog,
        AccessTask,
        Unknow
    }

    public class Constants
    {
        public static IDictionary<DictItemType, string> DictItemCodes;
        public static IDictionary<AccessObjectType, string> AccessObjectCodes;

        static Constants()
        {
            DictItemCodes = new Dictionary<DictItemType, string>
            {
                {DictItemType.TaskType, "TSK_TYPE" },
                {DictItemType.TaskState, "TSK_STATE" },
                {DictItemType.TaskActivity, "TSK_ACTIVITY" }
            };

            AccessObjectCodes = new Dictionary<AccessObjectType, string>
            {
                {AccessObjectType.AccessProject, "WProject.Access.Project" },
                {AccessObjectType.AccessProjectSettings, "WProject.Access.Project.Settings" },
                {AccessObjectType.AccessProjectSettingsUser, "WProject.Access.Project.Settings.User" },
                {AccessObjectType.AccessProjectSettingsGroup, "WProject.Access.Project.Settings.Group" },
                {AccessObjectType.AccessProjectSettingsAccess, "WProject.Access.Project.Settings.Access" },
                {AccessObjectType.AccessProjectSettingsDictItem, "WProject.Access.Project.Settings.DictItem" },
                {AccessObjectType.AccessBacklog, "WProject.Access.Backlog" },
                {AccessObjectType.AccessTask, "WProject.Access.Project.Task" }
            };
        }
    }
}
