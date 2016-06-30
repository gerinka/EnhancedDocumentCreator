﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 6/30/2016 8:36:32 AM
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
    /// There are no comments for MtcModel.DOCUMENTTEMPLATE in the schema.
    /// </summary>
    public partial class DOCUMENTTEMPLATE    {

        public DOCUMENTTEMPLATE()
        {
          this.MinWordCount = 1;
          this.ActiveTasksCount = 1;
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
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual sbyte IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MinWordCount in the schema.
        /// </summary>
        public virtual int MinWordCount
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
        /// There are no comments for DOCUMENTs in the schema.
        /// </summary>
        public virtual ICollection<DOCUMENT> DOCUMENTs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for STRUCTUREELEMENTs in the schema.
        /// </summary>
        public virtual ICollection<STRUCTUREELEMENT> STRUCTUREELEMENTs
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
