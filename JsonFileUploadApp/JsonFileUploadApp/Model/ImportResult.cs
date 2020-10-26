using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFileUploadApp.Model
{
    public class ImportResult
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public Exception ObjectException { get; set; }
    }
}
