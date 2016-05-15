﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 5/15/2016 5:53:09 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MtcModel
{

    /// <summary>
    /// There are no comments for MtcModel.TASK in the schema.
    /// </summary>
    public partial class TASK    {

        public TASK()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        public virtual int Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Title in the schema.
        /// </summary>
        public virtual string Title
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AssignTo in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AssignTo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaskState in the schema.
        /// </summary>
        public virtual int TaskState
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Deadline in the schema.
        /// </summary>
        public virtual global::System.DateTime Deadline
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DocumentId in the schema.
        /// </summary>
        public virtual int DocumentId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Order in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> Order
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaskType in the schema.
        /// </summary>
        public virtual TaskType TaskType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsLocked in the schema.
        /// </summary>
        public virtual sbyte IsLocked
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StrucktureContentId in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StrucktureContentId
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DOCUMENT in the schema.
        /// </summary>
        public virtual DOCUMENT DOCUMENT
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for STRUCTURECONTENT in the schema.
        /// </summary>
        public virtual STRUCTURECONTENT STRUCTURECONTENT
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for USER in the schema.
        /// </summary>
        public virtual USER USER
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
