﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 5/22/2016 12:15:08 PM
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
    /// There are no comments for MtcModel.STRUCTUREELEMENT in the schema.
    /// </summary>
    public partial class STRUCTUREELEMENT    {

        public STRUCTUREELEMENT()
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
        /// There are no comments for StructureTypeId in the schema.
        /// </summary>
        public virtual StructureType StructureTypeId
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
        /// There are no comments for Order in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> Order
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for STRUCTURECONTENTs in the schema.
        /// </summary>
        public virtual ICollection<STRUCTURECONTENT> STRUCTURECONTENTs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DOCUMENTTEMPLATEs in the schema.
        /// </summary>
        public virtual ICollection<DOCUMENTTEMPLATE> DOCUMENTTEMPLATEs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PARENTSTRUCTUREELEMENTS in the schema.
        /// </summary>
        public virtual ICollection<STRUCTUREELEMENT> PARENTSTRUCTUREELEMENTS
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CHILDSTRUCTUREELEMENTS in the schema.
        /// </summary>
        public virtual ICollection<STRUCTUREELEMENT> CHILDSTRUCTUREELEMENTS
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
