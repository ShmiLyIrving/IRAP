using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace IRAP.UFMPS.Library
{
    public enum TObjectCreateType
    {
        [Description("创建新的空对象")]
        octNew = 1,
        [Description("从配置文件中加载对象")]
        octLoad = 2,
        [Description("从配置文件中加载对象，在对象属性被修改后自动保存到配置文件中")]
        octEdit = 3,
        [Description("从配置文件中加载对象，在得到确认后从配置文件中删除该对象")]
        octDelete = 4
    };

}
