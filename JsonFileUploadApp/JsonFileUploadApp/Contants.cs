using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFileUploadApp
{
    public class Output
    {
        public const int FAILED = 0;
        public const int SUCCESSFUL = 1;
        public const int OTHER = 2;
    }
    public class ActionResult
    {
        public const string ACTION_FAILED = "Failed";
        public const string ACTION_FAILED_OTHER = "Other";
        public const string EXCEPTION_ENCOUNTERED = "Exception";
        public const string ACTION_SUCCESSFUL = "Success";
    }

}
