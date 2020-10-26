using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JsonFileUploadApp.DataAccessLayer.DBProvider
{
    public class Parameters
    {
        public const string RECORD_ID = "_RecordId";
        public const string USER_CODE = "_UserCode";
        public const string USER_NAME = "_UserName";
        public const string PASSWORD = "_Password";
        public const string LAST_NAME = "_LastName";
        public const string FIRST_NAME = "_FirstName";
        public const string MIDDLE_NAME = "_MiddleName";

        public const string PRINCIPAL_CODE = "_PrincipalCode";
        public const string MANIFEST_CODE = "_ManifestCode";
        public const string ASSET_CODE = "_AssetCode";
        public const string TRANSACTION_STATUS_CODE= "_TransactionStatusCode";
        public const string FIELD_ASSET_CODE = "_FieldAssetCode";
        public const string NEW_FIELD_ASSET_CODE = "_NewFieldAssetCode";
        public const string FIELD_ASSET_NAME = "_FieldAssetName";
        public const string IS_RTM = "_IsRTM";
        public const string FILE_NAME = "_FileName";


        public const string ADDRESS = "_Address";
        public const string TELEPHONE = "_Telephone";
        public const string MOBILE_NUMBER = "_MobileNumber";
        public const string EMAIL_ADDRESS = "_EmailAddress";

        public const string REFERENCE_NUMBER = "_ReferenceNumber";
        public const string ACCOUNT_NUMBER = "_AccountNo";
        public const string CONTROL_NO = "_ControlNo";
        public const string JSON_STRING = "_JSONString";

        public const string TRANSACTION_DATE = "_TransactionDate";
        public const string MANIFEST_DATE = "_ManifestDate";
        public const string PROCESS_DATE = "_ProcessDate";
        public const string VALUE_DATE = "_ValueDate";
        public const string DATE_RECEIVED = "_DateReceived";
        public const string DATE_PICKEDUP = "_DatePickedUp";
        public const string DATE_TIME_CREATED = "_DateTimeCreated";
        public const string DATE_TIME_MODIFIED = "_DateTimeModified";
        public const string DATE_TIME_SEARCHED = "_DateTimeSearched";
        public const string DATE_TIME_ACCESSED = "_DateTimeAccessed";
        public const string RESULT = "_Result";
        public const string PENDING = "_Pending";
        public const string PICKED_UP = "_PickedUp";
        public const string RECEIVED = "_Received";
        public const string KROS = "_KROS";
        public const string TOP1 = "_TOP1";


        public const string CREATED_BY = "_CreatedBy";
        public const string LAST_MODIFIED_BY = "_LastModifiedBy";
        public const string MODIFIED_BY = "_ModifiedBy";
        public const string ACCESSED_BY = "_AccessedBy";
        public const string APPROVED_BY = "_ApprovedBy";
        public const string DISAPPROVED_BY = "_DisapprovedBy";
        public const string UNLOCKED_BY = "_UnlockedBy";
        public const string REMARKS = "_Remarks";

        //ZipCode, province, town
        public const string PROVINCE = "_Province";
        public const string TOWN = "_Town";
        public const string ZIPCODE = "_ZipCode";

        public const string APPROVAL_STATUS = "_ApprovalStatus";

        //Page
        public const string PAGE_SIZE = "_PageSize";
        public const string PAGE_NUMBER = "_PageNumber";

        public const string USER_ROLE = "_UserRole";
        public const string ROLE_NAME = "_RoleName";

        public const string IS_APPROVED = "_IsApproved";
        public const string IS_LOCKED_OUT = "_IsLockedOut";

    }

    public class ActionConstants
    {
        public const string APPROVE = "Approve";
        public const string DISAPPROVE = "Disapprove";
    }
}
