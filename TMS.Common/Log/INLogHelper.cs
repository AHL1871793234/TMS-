using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.Log
{
    /// <summary>
    /// NLogHelper接口
    /// </summary>
    public interface INLogHelper
    {
        void LogError(Exception ex);
    }
}
