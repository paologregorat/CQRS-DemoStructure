using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CQRSSAmple.ActionLog
{
    public enum LogActionType
    {
        //Generic actions
        Add,
        Update,
        Delete,
        //User related actions
        Logon = 100,
        Logoff,
        LogAccess,
        Registration,
        ConfirmRegistration,
        SetPassword,
        RecoverPassword,
        ResetPassword,
        SetEmail,
        ConfirmEmail,
        //Actions done by the operator on the end user
        SetDisabled = 150,
        SetEnabled,
        ForcePasswordChange,
        SetBlocked,
        SetNotBlocked,
        OverriddenSystemBlockStatus,
        //Authenticated sessions related actions
        SessionExpiration = 200,
        SessionRevoke,
        //License Document related actions
        LicenseDocumentValidation = 300,
    }
    
    public enum LogEntityType
    {
        // Core module entities
        EndUser,
        Operator,
        AuthenticatedSession
    }
    public class ActionLog
    {
        [BsonId] public Guid Id { get; set; }
        public LogActionType ActionType { get; set; }
        public string PerformingUser { get; set; }
        public string PerformingGuid { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
        public LogEntityType EntityType { get; set; }
        

        public string EntityName { get; set; }
        public string EntityGuid { get; set; }
        public object Data { get; set; }
    }
    
    

}