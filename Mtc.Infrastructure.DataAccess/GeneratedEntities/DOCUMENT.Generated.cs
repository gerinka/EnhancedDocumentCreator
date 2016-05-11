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
    /// There are no comments for MtcModel.DOCUMENT in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ID
    /// </KeyProperties>
    [EdmEntityTypeAttribute(NamespaceName="MtcModel", Name="DOCUMENT")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DOCUMENT : EntityObject    {
        #region Factory Method

        /// <summary>
        /// Create a new DOCUMENT object.
        /// </summary>
        /// <param name="iD">Initial value of ID.</param>
        /// <param name="userId">Initial value of UserId.</param>
        /// <param name="deadline">Initial value of Deadline.</param>
        /// <param name="title">Initial value of Title.</param>
        /// <param name="documentTemplateId">Initial value of DocumentTemplateId.</param>
        public static DOCUMENT CreateDOCUMENT(int iD, int userId, global::System.DateTime deadline, string title, int documentTemplateId)
        {
            DOCUMENT dOCUMENT = new DOCUMENT();
            dOCUMENT.ID = iD;
            dOCUMENT.UserId = userId;
            dOCUMENT.Deadline = deadline;
            dOCUMENT.Title = title;
            dOCUMENT.DocumentTemplateId = documentTemplateId;
            return dOCUMENT;
        }

        #endregion

        #region Properties
    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get
            {
                int value = _ID;
                OnGetID(ref value);
                return value;
            }
            set
            {
                if (_ID != value)
                {
                  OnIDChanging(ref value);
                  ReportPropertyChanging("ID");
                  _ID = StructuralObject.SetValidValue(value);
                  ReportPropertyChanged("ID");
                  OnIDChanged();
              }
            }
        }
        private int _ID;
        partial void OnGetID(ref int value);
        partial void OnIDChanging(ref int value);
        partial void OnIDChanged();
    
        /// <summary>
        /// There are no comments for UserId in the schema.
        /// </summary>
        [EdmScalarPropertyAttribute(IsNullable=false)]
        [DataMemberAttribute()]
        public int UserId
        {
            get
            {
                int value = _UserId;
                OnGetUserId(ref value);
                return value;
            }
            set
            {
                if (_UserId != value)
                {
                  OnUserIdChanging(ref value);
                  ReportPropertyChanging("UserId");
                  _UserId = StructuralObject.SetValidValue(value);
                  ReportPropertyChanged("UserId");
                  OnUserIdChanged();
              }
            }
        }
        private int _UserId;
        partial void OnGetUserId(ref int value);
        partial void OnUserIdChanging(ref int value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// There are no comments for Deadline in the schema.
        /// </summary>
        [EdmScalarPropertyAttribute(IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Deadline
        {
            get
            {
                global::System.DateTime value = _Deadline;
                OnGetDeadline(ref value);
                return value;
            }
            set
            {
                if (_Deadline != value)
                {
                  OnDeadlineChanging(ref value);
                  ReportPropertyChanging("Deadline");
                  _Deadline = StructuralObject.SetValidValue(value);
                  ReportPropertyChanged("Deadline");
                  OnDeadlineChanged();
              }
            }
        }
        private global::System.DateTime _Deadline;
        partial void OnGetDeadline(ref global::System.DateTime value);
        partial void OnDeadlineChanging(ref global::System.DateTime value);
        partial void OnDeadlineChanged();
    
        /// <summary>
        /// There are no comments for Title in the schema.
        /// </summary>
        [EdmScalarPropertyAttribute(IsNullable=false)]
        [DataMemberAttribute()]
        public string Title
        {
            get
            {
                string value = _Title;
                OnGetTitle(ref value);
                return value;
            }
            set
            {
                if (_Title != value)
                {
                  OnTitleChanging(ref value);
                  ReportPropertyChanging("Title");
                  _Title = StructuralObject.SetValidValue(value, false);
                  ReportPropertyChanged("Title");
                  OnTitleChanged();
              }
            }
        }
        private string _Title;
        partial void OnGetTitle(ref string value);
        partial void OnTitleChanging(ref string value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// There are no comments for CurrentProgress in the schema.
        /// </summary>
        [EdmScalarPropertyAttribute()]
        [DataMemberAttribute()]
        public global::System.Nullable<int> CurrentProgress
        {
            get
            {
                global::System.Nullable<int> value = _CurrentProgress;
                OnGetCurrentProgress(ref value);
                return value;
            }
            set
            {
                if (_CurrentProgress != value)
                {
                  OnCurrentProgressChanging(ref value);
                  ReportPropertyChanging("CurrentProgress");
                  _CurrentProgress = StructuralObject.SetValidValue(value);
                  ReportPropertyChanged("CurrentProgress");
                  OnCurrentProgressChanged();
              }
            }
        }
        private global::System.Nullable<int> _CurrentProgress;
        partial void OnGetCurrentProgress(ref global::System.Nullable<int> value);
        partial void OnCurrentProgressChanging(ref global::System.Nullable<int> value);
        partial void OnCurrentProgressChanged();
    
        /// <summary>
        /// There are no comments for MentorId in the schema.
        /// </summary>
        [EdmScalarPropertyAttribute()]
        [DataMemberAttribute()]
        public global::System.Nullable<int> MentorId
        {
            get
            {
                global::System.Nullable<int> value = _MentorId;
                OnGetMentorId(ref value);
                return value;
            }
            set
            {
                if (_MentorId != value)
                {
                  OnMentorIdChanging(ref value);
                  ReportPropertyChanging("MentorId");
                  _MentorId = StructuralObject.SetValidValue(value);
                  ReportPropertyChanged("MentorId");
                  OnMentorIdChanged();
              }
            }
        }
        private global::System.Nullable<int> _MentorId;
        partial void OnGetMentorId(ref global::System.Nullable<int> value);
        partial void OnMentorIdChanging(ref global::System.Nullable<int> value);
        partial void OnMentorIdChanged();
    
        /// <summary>
        /// There are no comments for DocumentTemplateId in the schema.
        /// </summary>
        [EdmScalarPropertyAttribute(IsNullable=false)]
        [DataMemberAttribute()]
        public int DocumentTemplateId
        {
            get
            {
                int value = _DocumentTemplateId;
                OnGetDocumentTemplateId(ref value);
                return value;
            }
            set
            {
                if (_DocumentTemplateId != value)
                {
                  OnDocumentTemplateIdChanging(ref value);
                  ReportPropertyChanging("DocumentTemplateId");
                  _DocumentTemplateId = StructuralObject.SetValidValue(value);
                  ReportPropertyChanged("DocumentTemplateId");
                  OnDocumentTemplateIdChanged();
              }
            }
        }
        private int _DocumentTemplateId;
        partial void OnGetDocumentTemplateId(ref int value);
        partial void OnDocumentTemplateIdChanging(ref int value);
        partial void OnDocumentTemplateIdChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for USER_MentorId in the schema.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MtcModel", "FK_DocumentMentor_ID", "USER_MentorId")]
        public USER USER_MentorId
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentMentor_ID", "USER_MentorId").Value;
            }
            set
            {
                ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentMentor_ID", "USER_MentorId").Value = value;
            }
        }
    
        /// <summary>
        /// There are no comments for USER_MentorId in the schema.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<USER> USER_MentorIdReference
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentMentor_ID", "USER_MentorId");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<USER>("MtcModel.FK_DocumentMentor_ID", "USER_MentorId", value);
                }
                else 
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentMentor_ID", "USER_MentorId").Value = null;
                }
            }
        }
    
        /// <summary>
        /// There are no comments for USER_UserId in the schema.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MtcModel", "FK_DocumentUser_ID", "USER_UserId")]
        public USER USER_UserId
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentUser_ID", "USER_UserId").Value;
            }
            set
            {
                ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentUser_ID", "USER_UserId").Value = value;
            }
        }
    
        /// <summary>
        /// There are no comments for USER_UserId in the schema.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<USER> USER_UserIdReference
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentUser_ID", "USER_UserId");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<USER>("MtcModel.FK_DocumentUser_ID", "USER_UserId", value);
                }
                else 
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<USER>("MtcModel.FK_DocumentUser_ID", "USER_UserId").Value = null;
                }
            }
        }
    
        /// <summary>
        /// There are no comments for REFERENCEs in the schema.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MtcModel", "FK_ReferenceDocument_Id", "REFERENCEs")]
        public EntityCollection<REFERENCE> REFERENCEs
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<REFERENCE>("MtcModel.FK_ReferenceDocument_Id", "REFERENCEs");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<REFERENCE>("MtcModel.FK_ReferenceDocument_Id", "REFERENCEs", value);
                }
            }
        }
    
        /// <summary>
        /// There are no comments for STRUCTURECONTENTs in the schema.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MtcModel", "FK_StructureContentDocument_Id", "STRUCTURECONTENTs")]
        public EntityCollection<STRUCTURECONTENT> STRUCTURECONTENTs
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<STRUCTURECONTENT>("MtcModel.FK_StructureContentDocument_Id", "STRUCTURECONTENTs");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<STRUCTURECONTENT>("MtcModel.FK_StructureContentDocument_Id", "STRUCTURECONTENTs", value);
                }
            }
        }
    
        /// <summary>
        /// There are no comments for TASKs in the schema.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MtcModel", "FK_TaskDocument_Id", "TASKs")]
        public EntityCollection<TASK> TASKs
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<TASK>("MtcModel.FK_TaskDocument_Id", "TASKs");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<TASK>("MtcModel.FK_TaskDocument_Id", "TASKs", value);
                }
            }
        }
    
        /// <summary>
        /// There are no comments for DOCUMENTTEMPLATE in the schema.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MtcModel", "FK_DocumentDocumentTemplate_ID", "DOCUMENTTEMPLATE")]
        public DOCUMENTTEMPLATE DOCUMENTTEMPLATE
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<DOCUMENTTEMPLATE>("MtcModel.FK_DocumentDocumentTemplate_ID", "DOCUMENTTEMPLATE").Value;
            }
            set
            {
                ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<DOCUMENTTEMPLATE>("MtcModel.FK_DocumentDocumentTemplate_ID", "DOCUMENTTEMPLATE").Value = value;
            }
        }
    
        /// <summary>
        /// There are no comments for DOCUMENTTEMPLATE in the schema.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<DOCUMENTTEMPLATE> DOCUMENTTEMPLATEReference
        {
            get
            {
                return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<DOCUMENTTEMPLATE>("MtcModel.FK_DocumentDocumentTemplate_ID", "DOCUMENTTEMPLATE");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<DOCUMENTTEMPLATE>("MtcModel.FK_DocumentDocumentTemplate_ID", "DOCUMENTTEMPLATE", value);
                }
                else 
                {
                    ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<DOCUMENTTEMPLATE>("MtcModel.FK_DocumentDocumentTemplate_ID", "DOCUMENTTEMPLATE").Value = null;
                }
            }
        }

        #endregion
    }

}
