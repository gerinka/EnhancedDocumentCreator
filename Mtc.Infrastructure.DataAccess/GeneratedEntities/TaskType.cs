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
    /// There are no comments for MtcModel.TaskType in the schema.
    /// </summary>
    [EdmEnumTypeAttribute(NamespaceName="MtcModel", Name="TaskType")]
    [DataContract]
    public enum TaskType : int
    {
    
        /// <summary>
        /// There are no comments for TaskType.Task in the schema.
        /// </summary>
        [EnumMember]
        Task = 1,    
        /// <summary>
        /// There are no comments for TaskType.Bug in the schema.
        /// </summary>
        [EnumMember]
        Bug = 2,    
        /// <summary>
        /// There are no comments for TaskType.Feature in the schema.
        /// </summary>
        [EnumMember]
        Feature = 3,    
        /// <summary>
        /// There are no comments for TaskType.NiceToHave in the schema.
        /// </summary>
        [EnumMember]
        NiceToHave = 4
    }

}