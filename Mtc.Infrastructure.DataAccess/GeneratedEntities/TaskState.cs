﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework EntityObject template.
// Code is generated on: 5/11/2016 11:55:44 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

namespace MtcModel
{

    /// <summary>
    /// There are no comments for MtcModel.TaskState in the schema.
    /// </summary>
    [EdmEnumTypeAttribute(NamespaceName="MtcModel", Name="TaskState")]
    [DataContract]
    public enum TaskState : int
    {
    
        /// <summary>
        /// There are no comments for TaskState.Waiting in the schema.
        /// </summary>
        [EnumMember]
        Waiting = 1,    
        /// <summary>
        /// There are no comments for TaskState.InProgress in the schema.
        /// </summary>
        [EnumMember]
        InProgress = 2,    
        /// <summary>
        /// There are no comments for TaskState.Done in the schema.
        /// </summary>
        [EnumMember]
        Done = 3,    
        /// <summary>
        /// There are no comments for TaskState.Resolved in the schema.
        /// </summary>
        [EnumMember]
        Resolved = 4,    
        /// <summary>
        /// There are no comments for TaskState.Denied in the schema.
        /// </summary>
        [EnumMember]
        Denied = 5,    
        /// <summary>
        /// There are no comments for TaskState.Closed in the schema.
        /// </summary>
        [EnumMember]
        Closed = 6
    }

}
