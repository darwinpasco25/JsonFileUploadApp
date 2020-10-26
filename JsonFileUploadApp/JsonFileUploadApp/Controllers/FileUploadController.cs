using JsonFileUploadApp.DataAccessLayer.DAO;
using JsonFileUploadApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFileUploadApp.Controllers
{
    public class FileUploadController
    {
        public FileUploadController() { }
        SalesDAO dao = new SalesDAO();
        public void SetMaxAllowedPackets()
        {
            dao.SetMaxAllowedPacket();
        }

        public ImportResult ImportSalesFile(string JSONString)
        {
            ImportResult result = new ImportResult();
            try
            {
                dao.ImportSalesFile(JSONString, out int outResult);

                if (outResult == Output.SUCCESSFUL)
                {
                    result.Result = ActionResult.ACTION_SUCCESSFUL;
                }
                else
                {
                    result.Result = ActionResult.ACTION_FAILED;
                    result.Message = string.Concat("File not imported! - DAO returned ", outResult);
                }
            }
            catch (Exception ex)
            {
                result.Result = ActionResult.EXCEPTION_ENCOUNTERED;
                result.Message = ex.Message;
                result.ObjectException = ex;
            }
            return result;
        }

    }
}
