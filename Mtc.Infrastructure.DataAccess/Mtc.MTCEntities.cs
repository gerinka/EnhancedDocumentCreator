﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework EntityObject template.
// Code is generated on: 5/11/2016 4:31:32 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;
using System.Linq.Expressions;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("MtcModel", "FK_DocumentMentor_ID", "USER_MentorId", RelationshipMultiplicity.ZeroOrOne, typeof(MtcModel.USER), "DOCUMENTs_MentorId", RelationshipMultiplicity.Many, typeof(MtcModel.DOCUMENT), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_DocumentUser_ID", "USER_UserId", RelationshipMultiplicity.One, typeof(MtcModel.USER), "DOCUMENTs_UserId", RelationshipMultiplicity.Many, typeof(MtcModel.DOCUMENT), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_ReferenceDocument_Id", "DOCUMENT", RelationshipMultiplicity.One, typeof(MtcModel.DOCUMENT), "REFERENCEs", RelationshipMultiplicity.Many, typeof(MtcModel.REFERENCE), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_StructureContentDocument_Id", "DOCUMENT", RelationshipMultiplicity.One, typeof(MtcModel.DOCUMENT), "STRUCTURECONTENTs", RelationshipMultiplicity.Many, typeof(MtcModel.STRUCTURECONTENT), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_StructureElementDocument_Id", "STRUCTUREELEMENT", RelationshipMultiplicity.One, typeof(MtcModel.STRUCTUREELEMENT), "STRUCTURECONTENTs", RelationshipMultiplicity.Many, typeof(MtcModel.STRUCTURECONTENT), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_TaskDocument_Id", "DOCUMENT", RelationshipMultiplicity.One, typeof(MtcModel.DOCUMENT), "TASKs", RelationshipMultiplicity.Many, typeof(MtcModel.TASK), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_TaskStructureContent_Id", "STRUCTURECONTENT", RelationshipMultiplicity.ZeroOrOne, typeof(MtcModel.STRUCTURECONTENT), "TASKs", RelationshipMultiplicity.Many, typeof(MtcModel.TASK), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_TaskUser_Id", "USER", RelationshipMultiplicity.ZeroOrOne, typeof(MtcModel.USER), "TASKs", RelationshipMultiplicity.Many, typeof(MtcModel.TASK), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "STRUCTUREELEMENT_STRUCTUREELEMENT", "STRUCTUREELEMENTs1", RelationshipMultiplicity.Many, typeof(MtcModel.STRUCTUREELEMENT), "STRUCTUREELEMENTs", RelationshipMultiplicity.Many, typeof(MtcModel.STRUCTUREELEMENT))]
[assembly: EdmRelationshipAttribute("MtcModel", "FK_DocumentDocumentTemplate_ID", "DOCUMENTTEMPLATE", RelationshipMultiplicity.One, typeof(MtcModel.DOCUMENTTEMPLATE), "DOCUMENTs", RelationshipMultiplicity.Many, typeof(MtcModel.DOCUMENT), true)]
[assembly: EdmRelationshipAttribute("MtcModel", "DOCUMENTTEMPLATE_STRUCTUREELEMENT", "DOCUMENTTEMPLATEs", RelationshipMultiplicity.Many, typeof(MtcModel.DOCUMENTTEMPLATE), "STRUCTUREELEMENTs", RelationshipMultiplicity.Many, typeof(MtcModel.STRUCTUREELEMENT))]

#endregion

namespace MtcModel
{

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class MtcEntities : ObjectContext
    {
        #region Constructors

        /// <summary>
        /// Initialize a new MtcEntities object.
        /// </summary>
        public MtcEntities() : 
                base(@"name=MTCEntitiesConnectionString", "MtcEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        /// <summary>
        /// Initializes a new MtcEntities object using the connection string found in the 'MtcEntities' section of the application configuration file.
        /// </summary>
        public MtcEntities(string connectionString) : 
                base(connectionString, "MtcEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        /// <summary>
        /// Initialize a new MtcEntities object.
        /// </summary>
        public MtcEntities(EntityConnection connection) : base(connection, "MtcEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        #endregion

        #region Partial Methods

        partial void OnContextCreated();

        #endregion

        #region ObjectSet Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DOCUMENT> DOCUMENTs
        {
            get
            {
                if ((_DOCUMENTs == null))
                {
                    _DOCUMENTs = base.CreateObjectSet<DOCUMENT>("DOCUMENTs");
                }
                return _DOCUMENTs;
            }
        }
        private ObjectSet<DOCUMENT> _DOCUMENTs;

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<REFERENCE> REFERENCEs
        {
            get
            {
                if ((_REFERENCEs == null))
                {
                    _REFERENCEs = base.CreateObjectSet<REFERENCE>("REFERENCEs");
                }
                return _REFERENCEs;
            }
        }
        private ObjectSet<REFERENCE> _REFERENCEs;

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<STRUCTURECONTENT> STRUCTURECONTENTs
        {
            get
            {
                if ((_STRUCTURECONTENTs == null))
                {
                    _STRUCTURECONTENTs = base.CreateObjectSet<STRUCTURECONTENT>("STRUCTURECONTENTs");
                }
                return _STRUCTURECONTENTs;
            }
        }
        private ObjectSet<STRUCTURECONTENT> _STRUCTURECONTENTs;

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<STRUCTUREELEMENT> STRUCTUREELEMENTs
        {
            get
            {
                if ((_STRUCTUREELEMENTs == null))
                {
                    _STRUCTUREELEMENTs = base.CreateObjectSet<STRUCTUREELEMENT>("STRUCTUREELEMENTs");
                }
                return _STRUCTUREELEMENTs;
            }
        }
        private ObjectSet<STRUCTUREELEMENT> _STRUCTUREELEMENTs;

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TASK> TASKs
        {
            get
            {
                if ((_TASKs == null))
                {
                    _TASKs = base.CreateObjectSet<TASK>("TASKs");
                }
                return _TASKs;
            }
        }
        private ObjectSet<TASK> _TASKs;

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<USER> USERs
        {
            get
            {
                if ((_USERs == null))
                {
                    _USERs = base.CreateObjectSet<USER>("USERs");
                }
                return _USERs;
            }
        }
        private ObjectSet<USER> _USERs;

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DOCUMENTTEMPLATE> DOCUMENTTEMPLATEs
        {
            get
            {
                if ((_DOCUMENTTEMPLATEs == null))
                {
                    _DOCUMENTTEMPLATEs = base.CreateObjectSet<DOCUMENTTEMPLATE>("DOCUMENTTEMPLATEs");
                }
                return _DOCUMENTTEMPLATEs;
            }
        }
        private ObjectSet<DOCUMENTTEMPLATE> _DOCUMENTTEMPLATEs;

        #endregion
        #region AddTo Methods

        /// <summary>
        /// Deprecated Method for adding a new object to the DOCUMENTs EntitySet.
        /// </summary>
        public void AddToDOCUMENTs(DOCUMENT dOCUMENT)
        {
            base.AddObject("DOCUMENTs", dOCUMENT);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the REFERENCEs EntitySet.
        /// </summary>
        public void AddToREFERENCEs(REFERENCE rEFERENCE)
        {
            base.AddObject("REFERENCEs", rEFERENCE);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the STRUCTURECONTENTs EntitySet.
        /// </summary>
        public void AddToSTRUCTURECONTENTs(STRUCTURECONTENT sTRUCTURECONTENT)
        {
            base.AddObject("STRUCTURECONTENTs", sTRUCTURECONTENT);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the STRUCTUREELEMENTs EntitySet.
        /// </summary>
        public void AddToSTRUCTUREELEMENTs(STRUCTUREELEMENT sTRUCTUREELEMENT)
        {
            base.AddObject("STRUCTUREELEMENTs", sTRUCTUREELEMENT);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the TASKs EntitySet.
        /// </summary>
        public void AddToTASKs(TASK tASK)
        {
            base.AddObject("TASKs", tASK);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the USERs EntitySet.
        /// </summary>
        public void AddToUSERs(USER uSER)
        {
            base.AddObject("USERs", uSER);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the DOCUMENTTEMPLATEs EntitySet.
        /// </summary>
        public void AddToDOCUMENTTEMPLATEs(DOCUMENTTEMPLATE dOCUMENTTEMPLATE)
        {
            base.AddObject("DOCUMENTTEMPLATEs", dOCUMENTTEMPLATE);
        }

        #endregion
    }
}
