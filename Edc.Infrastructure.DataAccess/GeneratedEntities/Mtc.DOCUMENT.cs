﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 7/10/2016 2:46:02 PM
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
    /// There are no comments for MtcModel.DOCUMENT in the schema.
    /// </summary>
    public partial class DOCUMENT    {

        public DOCUMENT()
        {
          this.CurrentProgress = 0;
          this.MaxCycle = 1;
          this.CurrentCycle = 1;
          this.ActiveTasksCount = 1;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        public virtual int ID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserId in the schema.
        /// </summary>
        public virtual int UserId
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
        /// There are no comments for Title in the schema.
        /// </summary>
        public virtual string Title
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentProgress in the schema.
        /// </summary>
        public virtual int CurrentProgress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MentorId in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> MentorId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DocumentTemplateId in the schema.
        /// </summary>
        public virtual int DocumentTemplateId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DocumentState in the schema.
        /// </summary>
        public virtual DocumentState DocumentState
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MaxCycle in the schema.
        /// </summary>
        public virtual int MaxCycle
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentCycle in the schema.
        /// </summary>
        public virtual int CurrentCycle
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActiveTasksCount in the schema.
        /// </summary>
        public virtual int ActiveTasksCount
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DOCUMENTTEMPLATE in the schema.
        /// </summary>
        public virtual DOCUMENTTEMPLATE DOCUMENTTEMPLATE
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for USER_MentorId in the schema.
        /// </summary>
        public virtual USER USER_MentorId
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for USER_UserId in the schema.
        /// </summary>
        public virtual USER USER_UserId
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for STRUCTURECONTENTs in the schema.
        /// </summary>
        public virtual ICollection<STRUCTURECONTENT> STRUCTURECONTENTs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TASKs in the schema.
        /// </summary>
        public virtual ICollection<TASK> TASKs
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
