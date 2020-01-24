using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using NsApiModels;

namespace NsApiModels
{
    public class BaseItem<T>
    {
        public T Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }





    public class BaseItemNg<T>
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// Название объекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание объекта
        /// </summary>
        public string Description { get; set; }
    }

    public class BaseItemNg : BaseItemNg<long> { }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ConstraintsEntity
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ConstraintsObjectRoot
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MappedElements
    {
        [JsonProperty("UniqureProperties", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? UniqureProperties { get; set; }

        [JsonProperty("ElementName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ElementName { get; set; }

        [JsonProperty("ClassDescription", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ClassDescription { get; set; }

        [JsonProperty("ClassCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ClassCode { get; set; }

        [JsonProperty("CadSystem", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? CadSystem { get; set; }

        [JsonProperty("ElementType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ElementType { get; set; }

        [JsonProperty("ElementPath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ElementPath { get; set; }

        [JsonProperty("Root", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Root { get; set; }

        [JsonProperty("GeometryHash", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? GeometryHash { get; set; }

        [JsonProperty("WellKnownPropertyId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? WellKnownPropertyId { get; set; }

        [JsonProperty("PolinomId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? PolinomId { get; set; }

        [JsonProperty("SmartPlant3DId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? SmartPlant3DId { get; set; }

        [JsonProperty("AvevaPdmsId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AvevaPdmsId { get; set; }

        [JsonProperty("SmartPlantPidId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? SmartPlantPidId { get; set; }

        [JsonProperty("AutodeskRevitId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AutodeskRevitId { get; set; }

        [JsonProperty("NeosyntezId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? NeosyntezId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ObjectPermissionInfoState
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ObjectPermissionInfoInheritedState
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ObjectPermissionInfoId
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _4 = 4,

        _8 = 8,

        _16 = 16,

        _32 = 32,

        _64 = 64,

        _128 = 128,

        _256 = 256,

        _511 = 511,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum PrincipalType
    {
        _0 = 0,

        _1 = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum PermissionManagementOperationOperation
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum PeriodsTaskState
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ExcelExportSettingsOutputFormat
    {
        _1 = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum NodeDtoEffectivePermissions
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _4 = 4,

        _8 = 8,

        _16 = 16,

        _32 = 32,

        _64 = 64,

        _128 = 128,

        _256 = 256,

        _511 = 511,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum NodeDtoType
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum DynamicLevelType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum DynamicNodeType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum AuditEventEventType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _100 = 100,

        _101 = 101,

        _102 = 102,

        _200 = 200,

        _201 = 201,

        _202 = 202,

        _203 = 203,

        _204 = 204,

        _300 = 300,

        _301 = 301,

        _302 = 302,

        _303 = 303,

        _304 = 304,

        _305 = 305,

        _306 = 306,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum AuditEventEntityType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ModelStateEntryValidationState
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioAttributeType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _15 = 15,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioAttributeLocked
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioAttributeTypeInfoType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _15 = 15,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Constraints
    {
        [JsonProperty("Entity", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ConstraintsEntity? Entity { get; set; }

        [JsonProperty("ObjectRoot", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ConstraintsObjectRoot? ObjectRoot { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioAttributeTypeInfo
    {
        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioAttributeTypeInfoType? Type { get; set; }

        [JsonProperty("Caption", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty("SupportsUnits", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? SupportsUnits { get; set; }

        [JsonProperty("IsScalar", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsScalar { get; set; }

        [JsonProperty("Constraints", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Constraints Constraints { get; set; }


    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Step
    {
        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Step2
    {
        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Type
    {
        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Response
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _4 = 4,

        _8 = 8,

        _16 = 16,

        _32 = 32,

        _64 = 64,

        _128 = 128,

        _256 = 256,

        _511 = 511,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Anonymous
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _15 = 15,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ExcelImportSessionStep
    {
        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ImportSettings_ObsoleteSource
    {
        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ImportSettings_ObsoleteMode
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ProcessMetadata_2OfInt32AndObjectState
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SourceMatch_ObsoleteState
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum AttributeMappingAttributeType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _15 = 15,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ModelImportSessionStep
    {
        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ImportSettingsSource
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ImportSettingsMode
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ModelNgType
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum NodeNgType
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ElementAttributeType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SourceMatchState
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioObjectEffectivePermissions
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _4 = 4,

        _8 = 8,

        _16 = 16,

        _32 = 32,

        _64 = 64,

        _128 = 128,

        _256 = 256,

        _511 = 511,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioEntityLocked
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioObjectAttributeType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _15 = 15,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioObjectAttributeLocked
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Rules
    {
        public WioAttributeValidationRule Required { get; set; }

        public WioAttributeValidationRule Range { get; set; }

        public WioAttributeValidationRule MinLength { get; set; }

        public WioAttributeValidationRule MaxLength { get; set; }

        public WioAttributeValidationRule Warning { get; set; }

        public WioAttributeValidationRule Pattern { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioEntityAttributeType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _15 = 15,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioEntityAttributeLocked
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ConstraintType
    {
        _1 = 1,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioAttributeValidationRuleType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum WioObjectNodeEffectivePermissions
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _4 = 4,

        _8 = 8,

        _16 = 16,

        _32 = 32,

        _64 = 64,

        _128 = 128,

        _256 = 256,

        _511 = 511,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchQueryMode
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchFilterType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _11 = 11,

        _15 = 15,

        _16 = 16,

        _17 = 17,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchConditionDirection
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchConditionOperator
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _11 = 11,

        _12 = 12,

        _13 = 13,

        _14 = 14,

        _15 = 15,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchConditionLogic
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchConditionType
    {
        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

        _6 = 6,

        _7 = 7,

        _8 = 8,

        _9 = 9,

        _10 = 10,

        _11 = 11,

        _15 = 15,

        _16 = 16,

        _17 = 17,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchRelationshipType
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum SearchRelationshipDirection
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ModelPublishSessionStep
    {
        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ProcessMetadata
    {
        _0 = 0,

        _1 = 1,

        _2 = 2,

        _3 = 3,

        _4 = 4,

        _5 = 5,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementsCountByElementType
    {
        [JsonProperty("Graphics", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Graphics { get; set; }

        [JsonProperty("Group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Group { get; set; }

        [JsonProperty("SharedGroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? SharedGroup { get; set; }

        [JsonProperty("Layer", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Layer { get; set; }

        [JsonProperty("Reference", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Reference { get; set; }

        [JsonProperty("File", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? File { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementsCountByCadSystem
    {
        [JsonProperty("Undefined", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Undefined { get; set; }

        [JsonProperty("BentleyMicrostation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? BentleyMicrostation { get; set; }

        [JsonProperty("AutodeskAutocad", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AutodeskAutocad { get; set; }

        [JsonProperty("BentleyTriForma", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? BentleyTriForma { get; set; }

        [JsonProperty("BentleyPlantSpace", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? BentleyPlantSpace { get; set; }

        [JsonProperty("AutodeskArchitecture", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AutodeskArchitecture { get; set; }

        [JsonProperty("AutodeskPlant3D", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AutodeskPlant3D { get; set; }

        [JsonProperty("SmartPlant3D", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? SmartPlant3D { get; set; }

        [JsonProperty("SmartPlantPid", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? SmartPlantPid { get; set; }

        [JsonProperty("IntergraphPds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? IntergraphPds { get; set; }

        [JsonProperty("BentleyAutoPlant", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? BentleyAutoPlant { get; set; }

        [JsonProperty("AvevaPdms", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AvevaPdms { get; set; }

        [JsonProperty("Polinom", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Polinom { get; set; }

        [JsonProperty("AutodeskInventor", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AutodeskInventor { get; set; }

        [JsonProperty("AutodeskRevit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AutodeskRevit { get; set; }

        [JsonProperty("DassaultSystemesCatia", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? DassaultSystemesCatia { get; set; }

        [JsonProperty("PtcCreo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? PtcCreo { get; set; }

        [JsonProperty("IntergraphGeoMedia", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? IntergraphGeoMedia { get; set; }

        [JsonProperty("CeaTechnologyPlant4D", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? CeaTechnologyPlant4D { get; set; }

        [JsonProperty("Kompas", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Kompas { get; set; }

        [JsonProperty("InternalRedline", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? InternalRedline { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TourTimelapse
    {
        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Caption", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty("Order", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Order { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TourResourceInfo
    {
        [JsonProperty("Size", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Point3D
    {
        [JsonProperty("X", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? X { get; set; }

        [JsonProperty("Y", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Y { get; set; }

        [JsonProperty("Z", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Z { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TourSceneTimelapse
    {
        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Base", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Base { get; set; }

        [JsonProperty("Preview", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Preview { get; set; }

        [JsonProperty("Front", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Front { get; set; }

        [JsonProperty("Right", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Right { get; set; }

        [JsonProperty("Back", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Back { get; set; }

        [JsonProperty("Left", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Left { get; set; }

        [JsonProperty("Up", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Up { get; set; }

        [JsonProperty("Down", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Down { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Image
    {
        [JsonProperty("Url", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourInfo
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Scenes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourScene> Scenes { get; set; }

        [JsonProperty("Timelapses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourTimelapse> Timelapses { get; set; }

        [JsonProperty("Resources", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourResource> Resources { get; set; }

        [JsonProperty("SyncModel", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PanoTourSyncModel SyncModel { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourModificationSpecification
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Entry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Entry { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public string Description { get; set; }

        [JsonProperty("PackageToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? PackageToken { get; set; }

        [JsonProperty("Thumbnail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("Timelapses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourTimelapse> Timelapses { get; set; }

        [JsonProperty("Scenes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourScene> Scenes { get; set; }

        [JsonProperty("SyncModel", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PanoTourSyncModel SyncModel { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserProfile
    {
        [JsonProperty("FullName", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(450, MinimumLength = 1)]
        public string FullName { get; set; }

        [JsonProperty("Position", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Position { get; set; }

        [JsonProperty("Email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^__{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^__{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$")]
        public string Email { get; set; }

        [JsonProperty("Phone", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Phone { get; set; }

        [JsonProperty("MobilePhone", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string MobilePhone { get; set; }

        [JsonProperty("Avatar", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Avatar { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserChangePasswordSpecification
    {
        [JsonProperty("CurrentPassword", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string CurrentPassword { get; set; }

        [JsonProperty("Password", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [JsonProperty("ConfirmPassword", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string ConfirmPassword { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioRole
    {
        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(100, MinimumLength = 3)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^[а-яА-Я\w\-\.]+$")]
        public string Name { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioUser
    {
        [JsonProperty("Provider", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Provider { get; set; }

        [JsonProperty("LockoutDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? LockoutDate { get; set; }

        [JsonProperty("LastActivity", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastActivity { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioFullUser
    {
        [JsonProperty("Credentials", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public WioUserCredentials Credentials { get; set; } = new WioUserCredentials();

        [JsonProperty("Provider", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Provider { get; set; }

        [JsonProperty("LockoutDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? LockoutDate { get; set; }

        [JsonProperty("LastActivity", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastActivity { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioUserCredentials
    {
        [JsonProperty("CurrentPassword", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string CurrentPassword { get; set; }

        [JsonProperty("Password", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(100, MinimumLength = 5)]
        public string Password { get; set; }

        [JsonProperty("ConfirmPassword", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ConfirmPassword { get; set; }

        [JsonProperty("Lockout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lockout { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class QueryShapingResult_1OfAuditEvent
    {
        [JsonProperty("Result", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AuditEvent> Result { get; set; }

        [JsonProperty("Total", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AuditEvent
    {
        [JsonProperty("EventType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AuditEventEventType? EventType { get; set; }

        [JsonProperty("EntityType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AuditEventEntityType? EntityType { get; set; }

        [JsonProperty("EntityName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EntityName { get; set; }

        [JsonProperty("EntityGuid", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? EntityGuid { get; set; }

        [JsonProperty("Timestamp", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? Timestamp { get; set; }

        [JsonProperty("UserName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserCredentials
    {
        [JsonProperty("UserName", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string UserName { get; set; }

        [JsonProperty("Password", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Password { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ImportedUser
    {
        [JsonProperty("Email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("Available", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Available { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    /// <summary>Настройки файловых хранилищ и обрабоки загружаемых файлов на сервер</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ContentOptions
    {
        /// <summary>Get or set file storage options.</summary>
        [JsonProperty("FileStorage", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public FileStorageOptions FileStorage { get; set; } = new FileStorageOptions();

        /// <summary>Настройка предварительного просмотра файлов</summary>
        [JsonProperty("Preview", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PreviewOptions Preview { get; set; }

        /// <summary>Настройка OOS</summary>
        [JsonProperty("OOS", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public OosOptions OOS { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class FileStorageOptions
    {
        [JsonProperty("PanoPath", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string PanoPath { get; set; }

        [JsonProperty("TempPath", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string TempPath { get; set; }

        [JsonProperty("UploadPath", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string UploadPath { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PreviewOptions
    {
        [JsonProperty("DefaultAutoLimit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? DefaultAutoLimit { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class OosOptions
    {
        [JsonProperty("Server", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^https?://.+")]
        public string Server { get; set; }

        [JsonProperty("InternalSite", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^https?://.+")]
        public string InternalSite { get; set; }

        [JsonProperty("ForceNativePdf", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? ForceNativePdf { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Plugin3dOptions
    {
        [JsonProperty("Version", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("Debug", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Debug { get; set; }

        [JsonProperty("ContributionCullingThreshold", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 15)]
        public int? ContributionCullingThreshold { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DataOptions
    {
        [JsonProperty("CommandTimeout", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? CommandTimeout { get; set; }

        [JsonProperty("DomainSorting", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DomainSortingOptions DomainSorting { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DomainSortingOptions
    {
        [JsonProperty("SortBy", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid SortBy { get; set; }

        [JsonProperty("Desc", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Desc { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class BrandingOptions
    {
        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Logo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(1048576)]
        public string Logo { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ClientsOptions
    {
        /// <summary>clientId/secret dictionary</summary>
        [JsonProperty("Credentials", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, ClientCredentials> Credentials { get; set; }

        /// <summary>Время жизни токена с момента его получения, в секундах</summary>
        [JsonProperty("TokenLifetime", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? TokenLifetime { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ClientCredentials
    {
        [JsonProperty("Secret", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Secret { get; set; }

        [JsonProperty("RedirectUris", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> RedirectUris { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SecurityOptions
    {
        /// <summary>Имя сервера для доменной аутентификации</summary>
        [JsonProperty("LdapServer", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LdapServer { get; set; }

        /// <summary>Имя windows-домена</summary>
        [JsonProperty("DomainName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DomainName { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AnnotationOptions
    {
        [JsonProperty("ClassId", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid ClassId { get; set; }

        [JsonProperty("RootId", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid RootId { get; set; }

        [JsonProperty("DescAttributeId", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid DescAttributeId { get; set; }

        [JsonProperty("StateAttributeId", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid StateAttributeId { get; set; }

        [JsonProperty("FileAttributeId", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid FileAttributeId { get; set; }

        [JsonProperty("States", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.IDictionary<string, string> States { get; set; } = new System.Collections.Generic.Dictionary<string, string>();


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelStateEntry
    {
        [JsonProperty("RawValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object RawValue { get; set; }

        [JsonProperty("AttemptedValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AttemptedValue { get; set; }

        [JsonProperty("Errors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ModelError> Errors { get; set; }

        [JsonProperty("ValidationState", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelStateEntryValidationState? ValidationState { get; set; }

        [JsonProperty("IsContainerNode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsContainerNode { get; set; }

        [JsonProperty("Children", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ModelStateEntry> Children { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelError
    {
        [JsonProperty("Exception", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Exception { get; set; }

        [JsonProperty("ErrorMessage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class LdapCheckModel
    {
        [JsonProperty("Server", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Server { get; set; }

        [JsonProperty("Domain", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Domain { get; set; }

        [JsonProperty("UserName", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string UserName { get; set; }

        [JsonProperty("Password", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Password { get; set; }


    }

    /// <summary>Результат проверки доступности домена Windows</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class LdapCheckResultModel
    {
        [JsonProperty("Success", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Success { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class LicensingOptions
    {
        [JsonProperty("Server", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Server { get; set; }

        [JsonProperty("Client", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Client { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioAttribute
    {
        [JsonProperty("Type", Required = Required.Always)]
        public WioAttributeType Type { get; set; }

        [JsonProperty("Constraints", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Constraint> Constraints { get; set; }

        [JsonProperty("Unit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<long> Unit { get; set; }

        [JsonProperty("Group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<long> Group { get; set; }

        [JsonProperty("Locked", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioAttributeLocked? Locked { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MonthlyTaskImportMetadata
    {
        [JsonProperty("DateClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DateClass { get; set; }

        [JsonProperty("SmrTaskRoot", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? SmrTaskRoot { get; set; }

        [JsonProperty("SmrTaskClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? SmrTaskClass { get; set; }

        [JsonProperty("DoneSinceBeginningConstructionPlanAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DoneSinceBeginningConstructionPlanAttribute { get; set; }

        [JsonProperty("DoneSinceBeginningConstructionFactAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DoneSinceBeginningConstructionFactAttribute { get; set; }

        [JsonProperty("CompletionFromBeginningMonthAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? CompletionFromBeginningMonthAttribute { get; set; }

        [JsonProperty("CompletionFromBeginningConstructionAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? CompletionFromBeginningConstructionAttribute { get; set; }

        [JsonProperty("DoneSinceBeginningMonthPlanAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DoneSinceBeginningMonthPlanAttribute { get; set; }

        [JsonProperty("DoneSinceBeginningMonthFactAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DoneSinceBeginningMonthFactAttribute { get; set; }

        [JsonProperty("DoneSinceBeginningConstructionConsideringMsgFactAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DoneSinceBeginningConstructionConsideringMsgFactAttribute { get; set; }

        [JsonProperty("SpecificEffortAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? SpecificEffortAttribute { get; set; }

        [JsonProperty("ActivityDaysCountAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActivityDaysCountAttribute { get; set; }

        [JsonProperty("Quantity2PerMonthAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Quantity2PerMonthAttribute { get; set; }

        [JsonProperty("MsgDateAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? MsgDateAttribute { get; set; }

        [JsonProperty("QuantityPerMonthAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? QuantityPerMonthAttribute { get; set; }

        [JsonProperty("WorkByDaysAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? WorkByDaysAttribute { get; set; }

        [JsonProperty("WorkByDaysClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? WorkByDaysClass { get; set; }

        [JsonProperty("WorkByDaysDateAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? WorkByDaysDateAttribute { get; set; }

        [JsonProperty("WorkByDaysAmountAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? WorkByDaysAmountAttribute { get; set; }

        [JsonProperty("WorkByDaysWorkTypeAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? WorkByDaysWorkTypeAttribute { get; set; }

        [JsonProperty("ContractorClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ContractorClass { get; set; }

        [JsonProperty("ContractorHumanResourcesMetadata", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ResourcesMetadata ContractorHumanResourcesMetadata { get; set; }

        [JsonProperty("ContractorTechnicalResourcesMetadata", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ResourcesMetadata ContractorTechnicalResourcesMetadata { get; set; }

        [JsonProperty("ImportFileAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ImportFileAttribute { get; set; }

        [JsonProperty("ActivityStartAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActivityStartAttribute { get; set; }

        [JsonProperty("ActivityEndAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActivityEndAttribute { get; set; }

        [JsonProperty("TaskClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TaskClass { get; set; }

        [JsonProperty("ContractorAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ContractorAttribute { get; set; }

        [JsonProperty("TaskIdAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TaskIdAttribute { get; set; }

        [JsonProperty("TotalQuantityAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TotalQuantityAttribute { get; set; }

        [JsonProperty("LabourCostPerWorkAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? LabourCostPerWorkAttribute { get; set; }

        [JsonProperty("UnitAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? UnitAttribute { get; set; }

        [JsonProperty("RelatedObjectAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? RelatedObjectAttribute { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ResourcesMetadata
    {
        [JsonProperty("Attribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Attribute { get; set; }

        [JsonProperty("Class", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Class { get; set; }

        [JsonProperty("ResourceAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ResourceAttribute { get; set; }

        [JsonProperty("DateAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DateAttribute { get; set; }

        [JsonProperty("AmountAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AmountAttribute { get; set; }

        [JsonProperty("TypeAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TypeAttribute { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExportClass
    {
        [JsonProperty("CollectionClasses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ExportCollectionClass> CollectionClasses { get; set; }

        [JsonProperty("Attributes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> Attributes { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExportCollectionClass
    {
        [JsonProperty("Attribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Attribute { get; set; }

        [JsonProperty("Attributes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> Attributes { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExcelExportSettings
    {
        [JsonProperty("StartRow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? StartRow { get; set; }

        [JsonProperty("StartColumn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? StartColumn { get; set; }

        [JsonProperty("GroupColumnsByClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? GroupColumnsByClass { get; set; }

        [JsonProperty("Roots", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> Roots { get; set; }

        [JsonProperty("Classes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ExportClass> Classes { get; set; }

        [JsonProperty("IncludeRoots", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeRoots { get; set; }

        [JsonProperty("IncludeContent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeContent { get; set; }

        [JsonProperty("FileName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty("OutputFormat", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ExcelExportSettingsOutputFormat? OutputFormat { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExcelExportSession
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Settings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ExcelExportSettings Settings { get; set; }

        [JsonProperty("ProcessId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ProcessId { get; set; }

        [JsonProperty("ProcessMetadata", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessMetadata<int, object> ProcessMetadata { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class NodeDto
    {
        [JsonProperty("EffectivePermissions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public NodeDtoEffectivePermissions? EffectivePermissions { get; set; }

        [JsonProperty("Children", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<IGuidNode> Children { get; set; }

        [JsonProperty("HasChildren", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasChildren { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public NodeDtoType? Type { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class IGuidNode
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class QueryShapingResult_1OfSearchResultObject
    {
        [JsonProperty("Result", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchResultObject> Result { get; set; }

        [JsonProperty("Total", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SearchResultObject
    {
        [JsonProperty("Object", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioObject Object { get; set; }

        [JsonProperty("Parent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioObject Parent { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class QueryShapingResult_1OfGuid
    {
        [JsonProperty("Result", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> Result { get; set; }

        [JsonProperty("Total", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SearchExportModel
    {
        [JsonProperty("Query", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchQuery Query { get; set; }

        [JsonProperty("Properties", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Properties { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SearchExportTaskModel
    {
        [JsonProperty("TaskId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TaskId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SavedSearchQuery
    {
        [JsonProperty("Query", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public SearchQuery Query { get; set; } = new SearchQuery();

        [JsonProperty("Group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }

        [JsonProperty("CanView", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> CanView { get; set; }

        [JsonProperty("CanEdit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> CanEdit { get; set; }

        [JsonProperty("Owner", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<int> Owner { get; set; }

        [JsonProperty("View", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object View { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DynamicTree
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [JsonProperty("RootEntityId", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid RootEntityId { get; set; }

        [JsonProperty("RootNodeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RootNodeId { get; set; }

        [JsonProperty("Levels", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DynamicLevel> Levels { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DynamicLevel
    {
        [JsonProperty("Ordinal", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Ordinal { get; set; }

        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DynamicLevelType? Type { get; set; }

        [JsonProperty("AttributeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AttributeId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DynamicNode
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DynamicNodeType? Type { get; set; }

        [JsonProperty("Entity", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DynamicNodeEntity Entity { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DynamicNodeEntity
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("Class", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DynamicNodeEntityClass Class { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DynamicNodeEntityClass
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTour
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("Entry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Entry { get; set; }

        [JsonProperty("EntryConfig", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EntryConfig { get; set; }

        [JsonProperty("Thumbnail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("PackageToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? PackageToken { get; set; }

        [JsonProperty("Scenes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourScene> Scenes { get; set; }

        [JsonProperty("Timelapses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourTimelapse> Timelapses { get; set; }

        [JsonProperty("Resources", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourResource> Resources { get; set; }

        [JsonProperty("SyncModel", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PanoTourSyncModel SyncModel { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourScene
    {
        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [JsonProperty("PublicName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PublicName { get; set; }

        [JsonProperty("SyncPosition", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public CamPosition SyncPosition { get; set; } = new CamPosition();

        [JsonProperty("Timelapses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PanoTourSceneTimelapse> Timelapses { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourTimelapse
    {
        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [JsonProperty("Caption", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty("Order", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0, int.MaxValue)]
        public int? Order { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourResource
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Size", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourSyncModel
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0, int.MaxValue)]
        public int? Id { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CamPosition
    {
        [JsonProperty("X", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? X { get; set; }

        [JsonProperty("Y", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Y { get; set; }

        [JsonProperty("Z", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Z { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourSceneTimelapse
    {
        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Base", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Base { get; set; }

        [JsonProperty("Preview", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Preview { get; set; }

        [JsonProperty("Front", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Front { get; set; }

        [JsonProperty("Right", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Right { get; set; }

        [JsonProperty("Back", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Back { get; set; }

        [JsonProperty("Left", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Left { get; set; }

        [JsonProperty("Up", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Up { get; set; }

        [JsonProperty("Down", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Down { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PanoTourCreationSpecification
    {
        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [JsonProperty("Entry", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Entry { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public string Description { get; set; }

        [JsonProperty("PackageToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? PackageToken { get; set; }

        [JsonProperty("Thumbnail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TourImportResult
    {
        [JsonProperty("Tour", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Tour Tour { get; set; }

        [JsonProperty("Was", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Was { get; set; }

        [JsonProperty("Became", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Became { get; set; }

        [JsonProperty("Merged", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Merged { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tour
    {
        [JsonProperty("Entry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Entry { get; set; }

        [JsonProperty("EntryConfig", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EntryConfig { get; set; }

        [JsonProperty("Thumbnail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("PackageToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? PackageToken { get; set; }

        [JsonProperty("Scenes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TourScene> Scenes { get; set; }

        [JsonProperty("Timelapses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TourTimelapse> Timelapses { get; set; }

        [JsonProperty("Resources", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TourResourceInfo> Resources { get; set; }

        [JsonProperty("SyncModel", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<int> SyncModel { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TourScene
    {
        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("PublicName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PublicName { get; set; }

        [JsonProperty("SyncPosition", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Point3D SyncPosition { get; set; }

        [JsonProperty("Timelapses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TourSceneTimelapse> Timelapses { get; set; }
    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Principal
    {
        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PrincipalType? Type { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PermissionManagementOperation
    {
        [JsonProperty("Operation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PermissionManagementOperationOperation? Operation { get; set; }

        [JsonProperty("PrincipalPermissionInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PrincipalPermissionInfo_1OfObjectPermissionInfo PrincipalPermissionInfo { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PlanningTasksResult
    {
        [JsonProperty("BadTasksPercentage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? BadTasksPercentage { get; set; }

        [JsonProperty("Tasks", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PlanningTask> Tasks { get; set; }

        [JsonProperty("Models", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BaseItem<long>> Models { get; set; }

        [JsonProperty("Tours", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<VisualPlanningTour>> Tours { get; set; }

        [JsonProperty("Links", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<long>> Links { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PlanningTask
    {
        [JsonProperty("Links", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<long>> Links { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> Type { get; set; }

        [JsonProperty("ScheduledPeriod", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PlanningTaskPeriod ScheduledPeriod { get; set; }

        [JsonProperty("ActualPeriod", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PlanningTaskPeriod ActualPeriod { get; set; }

        [JsonProperty("ScheduledCost", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PlanningTaskCost ScheduledCost { get; set; }

        [JsonProperty("ActualCost", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PlanningTaskCost ActualCost { get; set; }

        [JsonProperty("ParentId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ParentId { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class VisualPlanningTour
    {
        [JsonProperty("Entry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Entry { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PlanningTaskPeriod
    {
        [JsonProperty("Start", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? Start { get; set; }

        [JsonProperty("End", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? End { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PlanningTaskCost
    {
        [JsonProperty("Equipment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Equipment { get; set; }

        [JsonProperty("Supplies", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Supplies { get; set; }

        [JsonProperty("Services", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Services { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PeriodsTasksResult
    {
        [JsonProperty("Lag", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Lag { get; set; }

        [JsonProperty("AlmostPlan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AlmostPlan { get; set; }

        [JsonProperty("Plan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Plan { get; set; }

        [JsonProperty("Advance", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Advance { get; set; }

        [JsonProperty("ScheduledCosts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? ScheduledCosts { get; set; }

        [JsonProperty("ActualCosts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? ActualCosts { get; set; }

        [JsonProperty("Tasks", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PeriodsTask> Tasks { get; set; }

        [JsonProperty("Models", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BaseItem<long>> Models { get; set; }

        [JsonProperty("Tours", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<VisualPlanningTour>> Tours { get; set; }

        [JsonProperty("Links", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<long>> Links { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PeriodsTask
    {
        [JsonProperty("State", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public PeriodsTaskState? State { get; set; }

        [JsonProperty("Unit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("ToDo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? ToDo { get; set; }

        [JsonProperty("Done", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Done { get; set; }

        [JsonProperty("Contractor", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> Contractor { get; set; }

        [JsonProperty("Links", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<long>> Links { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MonthlyTaskExportMetadata
    {
        [JsonProperty("TaskNameAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TaskNameAttribute { get; set; }

        [JsonProperty("AvailabilityPsdAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AvailabilityPsdAttribute { get; set; }

        [JsonProperty("AvailabilityMtoAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AvailabilityMtoAttribute { get; set; }

        [JsonProperty("AvailabilityMtrAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AvailabilityMtrAttribute { get; set; }

        [JsonProperty("AvailabilityMtoMontageAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AvailabilityMtoMontageAttribute { get; set; }

        [JsonProperty("AvailabilityMtoByDateAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AvailabilityMtoByDateAttribute { get; set; }

        [JsonProperty("ActualQuantityAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActualQuantityAttribute { get; set; }

        [JsonProperty("BalanceAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? BalanceAttribute { get; set; }

        [JsonProperty("ActivityExpectedStartAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActivityExpectedStartAttribute { get; set; }

        [JsonProperty("ActivityExpectedEndAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActivityExpectedEndAttribute { get; set; }

        [JsonProperty("RemainingAmountOfResourceAssignmentAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? RemainingAmountOfResourceAssignmentAttribute { get; set; }

        [JsonProperty("ProvisionNameAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ProvisionNameAttribute { get; set; }

        [JsonProperty("SpecificationAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? SpecificationAttribute { get; set; }

        [JsonProperty("SpecificationNumberAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? SpecificationNumberAttribute { get; set; }

        [JsonProperty("DeliveredToCentralWarehouseAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DeliveredToCentralWarehouseAttribute { get; set; }

        [JsonProperty("DeliveredToOnSiteWarehouseAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DeliveredToOnSiteWarehouseAttribute { get; set; }

        [JsonProperty("IssueInInstallationsAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? IssueInInstallationsAttribute { get; set; }

        [JsonProperty("RequiredQuantityAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? RequiredQuantityAttribute { get; set; }

        [JsonProperty("RequiredQuantityUnitAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? RequiredQuantityUnitAttribute { get; set; }

        [JsonProperty("SupplyUnitAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? SupplyUnitAttribute { get; set; }

        [JsonProperty("ProvisionUnitAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ProvisionUnitAttribute { get; set; }

        [JsonProperty("WeightAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? WeightAttribute { get; set; }

        [JsonProperty("AreaAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? AreaAttribute { get; set; }

        [JsonProperty("LengthAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? LengthAttribute { get; set; }

        [JsonProperty("VolumeAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? VolumeAttribute { get; set; }

        [JsonProperty("SupplyDateByContractAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? SupplyDateByContractAttribute { get; set; }

        [JsonProperty("ClassificationSettings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ClassificationSettings ClassificationSettings { get; set; }

        [JsonProperty("ActivityStartAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActivityStartAttribute { get; set; }

        [JsonProperty("ActivityEndAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ActivityEndAttribute { get; set; }

        [JsonProperty("TaskClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TaskClass { get; set; }

        [JsonProperty("ContractorAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ContractorAttribute { get; set; }

        [JsonProperty("TaskIdAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TaskIdAttribute { get; set; }

        [JsonProperty("TotalQuantityAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TotalQuantityAttribute { get; set; }

        [JsonProperty("LabourCostPerWorkAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? LabourCostPerWorkAttribute { get; set; }

        [JsonProperty("UnitAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? UnitAttribute { get; set; }

        [JsonProperty("RelatedObjectAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? RelatedObjectAttribute { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ClassificationSettings
    {
        [JsonProperty("Filters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ClassificationFilter> Filters { get; set; }

        [JsonProperty("ResultDefaultValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? ResultDefaultValue { get; set; }

        [JsonProperty("DefaultValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? DefaultValue { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ClassificationFilter
    {
        [JsonProperty("Class", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Class { get; set; }

        [JsonProperty("AttributeFilter", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AttributeFilter<Guid> AttributeFilter { get; set; }

        [JsonProperty("ResultAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ResultAttribute { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AttributeFilter<T>
    {
        [JsonProperty("Attribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Attribute { get; set; }

        [JsonProperty("Values", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<T> Values { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TaskExportResult
    {
        [JsonProperty("Tasks", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<MonthlyTask> Tasks { get; set; }

        [JsonProperty("Models", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<BaseItem<long>> Models { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MonthlyTask
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("TaskId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TaskId { get; set; }

        [JsonProperty("TaskName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Links", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<int>> Links { get; set; }

        [JsonProperty("Parent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> Parent { get; set; }

        [JsonProperty("AvailabilityPSD", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> AvailabilityPSD { get; set; }

        [JsonProperty("AvailabilityMTO", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> AvailabilityMTO { get; set; }

        [JsonProperty("AvailabilityMTR", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> AvailabilityMTR { get; set; }

        [JsonProperty("AvailabilityMTOMontage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> AvailabilityMTOMontage { get; set; }

        [JsonProperty("AvailabilityMTOByDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> AvailabilityMTOByDate { get; set; }

        [JsonProperty("TotalQuantity", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalQuantity { get; set; }

        [JsonProperty("ActualQuantity", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? ActualQuantity { get; set; }

        [JsonProperty("Balance", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Balance { get; set; }

        [JsonProperty("QuantityPerMonth", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? QuantityPerMonth { get; set; }

        [JsonProperty("LabourCostPerWork", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? LabourCostPerWork { get; set; }

        [JsonProperty("Unit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg<Guid> Unit { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MonthlyTaskExportContainer
    {
        [JsonProperty("Metadata", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public MonthlyTaskExportMetadata Metadata { get; set; }

        [JsonProperty("Settings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public MonthlyTasksExportSettings Settings { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MonthlyTasksExportSettings
    {
        [JsonProperty("ExportDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? ExportDate { get; set; }

        [JsonProperty("Contractor", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Contractor { get; set; }

        [JsonProperty("MonthlyTasks", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> MonthlyTasks { get; set; }

        [JsonProperty("PlanningTasks", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> PlanningTasks { get; set; }

        [JsonProperty("IsShortcut", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsShortcut { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementNode
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("HasChildren", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasChildren { get; set; }

        [JsonProperty("Mapped", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Mapped { get; set; }

        [JsonProperty("Children", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ElementNode> Children { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelFileNg
    {
        [JsonProperty("Inherited", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Inherited { get; set; }

        [JsonProperty("ModelId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? ModelId { get; set; }

        [JsonProperty("Timestamp", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? Timestamp { get; set; }

        [JsonProperty("ContentId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ContentId { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelsAddRequest
    {
        [JsonProperty("ModelIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<long> ModelIds { get; set; }

        [JsonProperty("ModelFileIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> ModelFileIds { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioObject
    {
        [JsonProperty("Entity", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioEntity Entity { get; set; }

        [JsonProperty("Attributes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, WioObjectAttribute> Attributes { get; set; }

        [JsonProperty("ModelLinks", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ElementLinkItem> ModelLinks { get; set; }

        [JsonProperty("CreationDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("ModificationDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? ModificationDate { get; set; }

        [JsonProperty("Owner", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<int> Owner { get; set; }

        [JsonProperty("EffectivePermissions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioObjectEffectivePermissions? EffectivePermissions { get; set; }

        [JsonProperty("IsTemplate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTemplate { get; set; }

        [JsonProperty("HostObjectId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? HostObjectId { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("Version", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; set; }

        [JsonProperty("VersionTimestamp", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? VersionTimestamp { get; set; }

        [JsonProperty("IsActualVersion", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsActualVersion { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioEntity
    {
        [JsonProperty("Parent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioEntity Parent { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("Attributes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, WioEntityAttribute> Attributes { get; set; }

        [JsonProperty("Viewers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ViewerInstance_1OfObject> Viewers { get; set; }

        [JsonProperty("Locked", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioEntityLocked? Locked { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioObjectAttribute
    {
        [JsonProperty("Value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }

        [JsonProperty("Type", Required = Required.Always)]
        public WioObjectAttributeType Type { get; set; }

        [JsonProperty("Constraints", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Constraint> Constraints { get; set; }

        [JsonProperty("Unit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<long> Unit { get; set; }

        [JsonProperty("Group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<long> Group { get; set; }

        [JsonProperty("Locked", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioObjectAttributeLocked? Locked { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementLinkItem
    {
        [JsonProperty("Ids", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<long> Ids { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioEntityAttribute
    {
        [JsonProperty("Inherited", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Inherited { get; set; }

        [JsonProperty("Rules", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Rules Rules { get; set; }

        [JsonProperty("Type", Required = Required.Always)]
        public WioEntityAttributeType Type { get; set; }

        [JsonProperty("Constraints", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Constraint> Constraints { get; set; }

        [JsonProperty("Unit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<int> Unit { get; set; }

        [JsonProperty("Group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<long> Group { get; set; }

        [JsonProperty("Locked", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioEntityAttributeLocked? Locked { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ViewerInstance_1OfObject
    {
        [JsonProperty("Caption", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public string Caption { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("Attributes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> Attributes { get; set; }

        [JsonProperty("Settings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Settings { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Constraint
    {
        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ConstraintType? Type { get; set; }

        [JsonProperty("EntityId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? EntityId { get; set; }

        [JsonProperty("ObjectRootId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ObjectRootId { get; set; }

        [JsonProperty("Regex", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Regex { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class BaseItem
    {
        [JsonProperty("Id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioAttributeValidationRule
    {
        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Type", Required = Required.Always)]
        public WioAttributeValidationRuleType Type { get; set; }

        [JsonProperty("Message", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("Params", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, object> Params { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Model3dAnnotationOptions
    {
        [JsonProperty("RootId", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid RootId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AutoLinkingMapping
    {
        [JsonProperty("Models", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<long> Models { get; set; }

        [JsonProperty("Objects", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> Objects { get; set; }

        [JsonProperty("Classes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Guid> Classes { get; set; }

        [JsonProperty("Conditions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AutoLinkingMappingCondition> Conditions { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AutoLinkingMappingCondition
    {
        [JsonProperty("ElementAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ElementAttribute ElementAttribute { get; set; }

        [JsonProperty("ClassAttributeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ClassAttributeId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class LongRunningTaskInfo
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementLinksContainer
    {
        [JsonProperty("Links", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BaseItemNg<Guid>> Links { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class WioObjectNode
    {
        [JsonProperty("Children", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<WioObjectNode> Children { get; set; }

        [JsonProperty("EffectivePermissions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioObjectNodeEffectivePermissions? EffectivePermissions { get; set; }

        [JsonProperty("HasChildren", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasChildren { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("Entity", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public WioEntity Entity { get; set; } = new WioEntity();

        [JsonProperty("Version", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; set; }

        [JsonProperty("VersionTimestamp", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? VersionTimestamp { get; set; }

        [JsonProperty("IsActualVersion", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsActualVersion { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SearchQuery
    {
        [JsonProperty("Filters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchFilter> Filters { get; set; }

        [JsonProperty("Conditions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchCondition> Conditions { get; set; }

        [JsonProperty("Relationship", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchRelationship Relationship { get; set; }

        [JsonProperty("Queries", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchQuery> Queries { get; set; }

        [JsonProperty("Mode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchQueryMode? Mode { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SearchFilter
    {
        [JsonProperty("Type", Required = Required.Always)]
        public SearchFilterType Type { get; set; }

        [JsonProperty("Value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SearchCondition
    {
        [JsonProperty("Direction", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchConditionDirection? Direction { get; set; } = SearchConditionDirection._0;

        [JsonProperty("Attribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Attribute { get; set; }

        [JsonProperty("Operator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchConditionOperator? Operator { get; set; }

        [JsonProperty("Logic", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchConditionLogic? Logic { get; set; } = SearchConditionLogic._0;

        [JsonProperty("Group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }

        [JsonProperty("Contextual", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Contextual { get; set; } = false;

        [JsonProperty("Conditions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchCondition> Conditions { get; set; }

        [JsonProperty("Type", Required = Required.Always)]
        public SearchConditionType Type { get; set; }

        [JsonProperty("Value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SearchRelationship
    {
        [JsonProperty("Type", Required = Required.Always)]
        public SearchRelationshipType Type { get; set; }

        [JsonProperty("Direction", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchRelationshipDirection? Direction { get; set; } = SearchRelationshipDirection._0;

        [JsonProperty("Attribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Attribute { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelSearchQuery
    {
        [JsonProperty("Query", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SearchQuery Query { get; set; }

        [JsonProperty("RefAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? RefAttribute { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelSearchResultItem
    {
        [JsonProperty("Groups", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<long>> Groups { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelPublishSession
    {
        [JsonProperty("Files", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ModelPublishItem> Files { get; set; }

        [JsonProperty("Model", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItemNg Model { get; set; }

        [JsonProperty("Storage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IFileStorage Storage { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Step", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelPublishSessionStep? Step { get; set; }

        [JsonProperty("Settings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ImportSettings Settings { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelPublishItem
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Analysis", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessMetadata<object, AnalyzeDetails> Analysis { get; set; }

        [JsonProperty("Upload", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessMetadata<int, object> Upload { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class IFileStorage
    {
        [JsonProperty("Length", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Length { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AnalyzeDetails
    {
        [JsonProperty("NewModelSummary", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelSummaryDto NewModelSummary { get; set; }

        [JsonProperty("OldModelSummary", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelSummaryDto OldModelSummary { get; set; }

        [JsonProperty("NormalizationResult", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelNormalizationResultDto NormalizationResult { get; set; }

        [JsonProperty("ComparasionResult", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ComparasionResultDto ComparasionResult { get; set; }

        [JsonProperty("NormalizedModelToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? NormalizedModelToken { get; set; }

        [JsonProperty("OldModelToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? OldModelToken { get; set; }

        [JsonProperty("OldModelId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? OldModelId { get; set; }

        [JsonProperty("ReportsToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ReportsToken { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelSummaryDto
    {
        [JsonProperty("ElementsCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ElementsCount { get; set; }

        [JsonProperty("ElementsWithoutTag", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ElementsWithoutTag { get; set; }

        [JsonProperty("PropertiesCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? PropertiesCount { get; set; }

        [JsonProperty("ElementsCountByElementType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ElementsCountByElementType ElementsCountByElementType { get; set; }

        [JsonProperty("ElementsCountByCadSystem", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ElementsCountByCadSystem ElementsCountByCadSystem { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelNormalizationResultDto
    {
        [JsonProperty("DeletedLayersCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? DeletedLayersCount { get; set; }

        [JsonProperty("DeletedPropertiesCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? DeletedPropertiesCount { get; set; }

        [JsonProperty("RenamedPropertiesCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? RenamedPropertiesCount { get; set; }

        [JsonProperty("TruncatedStringsCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? TruncatedStringsCount { get; set; }

        [JsonProperty("DeletedElementsFullDuplicatesCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? DeletedElementsFullDuplicatesCount { get; set; }

        [JsonProperty("DeletedElementsPartialDuplicatesCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? DeletedElementsPartialDuplicatesCount { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ComparasionResultDto
    {
        [JsonProperty("MappedElements", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public MappedElements MappedElements { get; set; }

        [JsonProperty("MappedElementsCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? MappedElementsCount { get; set; }

        [JsonProperty("NewElementsCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? NewElementsCount { get; set; }

        [JsonProperty("OrphanedElementsCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? OrphanedElementsCount { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class QueryShapingResult_1OfCollectionItem
    {
        [JsonProperty("Result", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CollectionItem> Result { get; set; }

        [JsonProperty("Total", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CollectionItem
    {
        [JsonProperty("Object", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public WioObject Object { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ObjectSecurityInfo
    {
        [JsonProperty("PrincipalObjectPermissions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PrincipalPermissionInfo_1OfObjectPermissionInfo> PrincipalObjectPermissions { get; set; }

        [JsonProperty("EffectivePermissions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PrincipalPermissionInfo_1OfObjectPermissionInfo> EffectivePermissions { get; set; }

        [JsonProperty("DefaultPermissions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ObjectPermissionInfo> DefaultPermissions { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PrincipalPermissionInfo_1OfObjectPermissionInfo
    {
        [JsonProperty("Principal", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Principal Principal { get; set; }

        [JsonProperty("Permissions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ObjectPermissionInfo> Permissions { get; set; }

        [JsonProperty("IsInherited", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInherited { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ObjectPermissionInfo
    {
        [JsonProperty("State", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObjectPermissionInfoState? State { get; set; }

        [JsonProperty("InheritedState", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObjectPermissionInfoInheritedState? InheritedState { get; set; }

        [JsonProperty("IsInherited", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInherited { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public ObjectPermissionInfoId Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ContentValue
    {
        [JsonProperty("MediaType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MediaType { get; set; }

        [JsonProperty("Extension", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Extension { get; set; }

        [JsonProperty("Hash", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        [JsonProperty("Version", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; set; }

        [JsonProperty("Size", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }

        [JsonProperty("TempToken", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? TempToken { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }

        [JsonIgnore()]
        public Stream Stream { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ServiceMethodCall
    {
        [JsonProperty("MethodName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MethodName { get; set; }

        [JsonProperty("UserName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty("InstanceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? InstanceId { get; set; }

        [JsonProperty("StartTime", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? StartTime { get; set; }

        [JsonProperty("Elapsed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Elapsed { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExcelImportSession
    {
        [JsonProperty("Settings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ImportSettings_Obsolete Settings { get; set; }

        [JsonProperty("SourceFile", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceFile { get; set; }

        [JsonProperty("BulkStorage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IBulkStorage BulkStorage { get; set; }

        [JsonProperty("ProcessMetadata", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessMetadata<int, object> ProcessMetadata { get; set; }

        [JsonProperty("ProcessId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? ProcessId { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Step", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ExcelImportSessionStep? Step { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ImportSettings_Obsolete
    {
        [JsonProperty("Source", Required = Required.Always)]
        public ImportSettings_ObsoleteSource Source { get; set; }

        [JsonProperty("SourceFile", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ContentValue SourceFile { get; set; }

        [JsonProperty("Mode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ImportSettings_ObsoleteMode? Mode { get; set; }

        [JsonProperty("Data", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

        [JsonProperty("ContentMapping", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Guid> ContentMapping { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class IBulkStorage
    {
        [JsonProperty("Length", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Length { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ProcessMetadata<T, S>
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public T Id { get; set; }

        [JsonProperty("State", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessMetadata<int, S> State { get; set; }

        [JsonProperty("StartDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? StartDate { get; set; }

        [JsonProperty("EndDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset? EndDate { get; set; }

        [JsonProperty("Progress", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Progress { get; set; }

        [JsonProperty("Result", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }

        [JsonProperty("Error", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object Error { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExcelRange
    {
        [JsonProperty("StartRow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 1048576)]
        public int? StartRow { get; set; }

        [JsonProperty("EndRow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 1048576)]
        public int? EndRow { get; set; }

        [JsonProperty("StartColumn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 16384)]
        public int? StartColumn { get; set; }

        [JsonProperty("EndColumn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 16384)]
        public int? EndColumn { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Filter
    {
        [JsonProperty("Column", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Column { get; set; }

        [JsonProperty("Values", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Values { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SourceMatch_Obsolete
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("State", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SourceMatch_ObsoleteState? State { get; set; }

        [JsonProperty("SourceString", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceString { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExcelImportSettings
    {
        [JsonProperty("WorkSheet", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string WorkSheet { get; set; }

        [JsonProperty("DataRange", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ExcelRange DataRange { get; set; } = new ExcelRange();

        [JsonProperty("HeaderRange", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ExcelRange HeaderRange { get; set; }

        [JsonProperty("Mapping", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ExcelImportMapping Mapping { get; set; } = new ExcelImportMapping();

        [JsonProperty("IncludeEmptyAttributes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeEmptyAttributes { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExcelImportMapping
    {
        [JsonProperty("TargetObjectColumn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? TargetObjectColumn { get; set; }

        [JsonProperty("TargetObjectMappings", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<CellMapping<Guid>> TargetObjectMappings { get; set; } = new Collection<CellMapping<Guid>>();

        [JsonProperty("GuidColumn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? GuidColumn { get; set; }

        [JsonProperty("LevelColumn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? LevelColumn { get; set; }

        [JsonProperty("EntityColumn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? EntityColumn { get; set; }

        [JsonProperty("EntityMappings", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<EntityMapping> EntityMappings { get; set; } = new Collection<EntityMapping>();
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CellMapping<T>
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("Value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("To", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public T To { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EntityMapping
    {
        [JsonProperty("AttributeMappings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AttributeMapping> AttributeMappings { get; set; }

        [JsonProperty("ObjectNameMapping", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObjectNameMapping ObjectNameMapping { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("Value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("To", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid To { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AttributeMapping
    {
        [JsonProperty("AttributeType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AttributeMappingAttributeType? AttributeType { get; set; }

        [JsonProperty("Attribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Attribute { get; set; }

        [JsonProperty("Column", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 16384)]
        public int? Column { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ObjectNameMapping
    {
        [JsonProperty("EmptyNamePattern", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string EmptyNamePattern { get; set; }

        [JsonProperty("Column", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 16384)]
        public int? Column { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }


    }

    /// <summary>WOPI model</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CheckFileInfo
    {
        [JsonProperty("BaseFileName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string BaseFileName { get; set; }

        [JsonProperty("OwnerId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string OwnerId { get; set; }

        [JsonProperty("Size", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }

        [JsonProperty("SHA256", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SHA256 { get; set; }

        [JsonProperty("Version", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelImportSession
    {
        [JsonProperty("Analyzers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, IElementMappingAnalyzer> Analyzers { get; set; }

        [JsonProperty("Imports", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ModelImportItem> Imports { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Step", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelImportSessionStep? Step { get; set; }

        [JsonProperty("Settings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ImportSettings Settings { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class IElementMappingAnalyzer
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelImportItem
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("Model", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelNg Model { get; set; }

        [JsonProperty("Import", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessMetadata<int, object> Import { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ImportSettings
    {
        [JsonProperty("Source", Required = Required.Always)]
        public ImportSettingsSource Source { get; set; }

        [JsonProperty("Mode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ImportSettingsMode? Mode { get; set; }

        [JsonProperty("Data", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

        [JsonProperty("ContentMapping", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Guid> ContentMapping { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ModelNg
    {
        [JsonProperty("ContentType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public BaseItem<int> ContentType { get; set; }

        [JsonProperty("HasFiles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasFiles { get; set; }

        [JsonProperty("Locked", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Locked { get; set; }

        [JsonProperty("Children", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<NodeNg> Children { get; set; }

        [JsonProperty("HasChildren", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasChildren { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ModelNgType? Type { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class NodeNg
    {
        [JsonProperty("Children", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<NodeNg> Children { get; set; }

        [JsonProperty("HasChildren", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasChildren { get; set; }

        [JsonProperty("Level", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("Icon", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public NodeNgType? Type { get; set; }

        [JsonProperty("Id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(450)]
        public string Description { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementAttributeFilter
    {
        [JsonProperty("TargetAttribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ElementAttribute TargetAttribute { get; set; }

        [JsonProperty("Conditions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ElementAttributeFilterCondition> Conditions { get; set; }

        [JsonProperty("Models", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<long> Models { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementAttribute
    {
        [JsonProperty("Type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ElementAttributeType? Type { get; set; }

        [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("DisplayName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementAttributeFilterCondition
    {
        [JsonProperty("Logic", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Logic { get; set; }

        [JsonProperty("Attribute", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ElementAttribute Attribute { get; set; }

        [JsonProperty("Value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ClassSettings
    {
        [JsonProperty("Mapping", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ElementAttributeMapping Mapping { get; set; } = new ElementAttributeMapping();

        [JsonProperty("DefaultClassId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? DefaultClassId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ElementAttributeMapping
    {
        [JsonProperty("ElementAttribute", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ElementAttribute ElementAttribute { get; set; } = new ElementAttribute();

        [JsonProperty("Values", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StringValueMapping> Values { get; set; }

        [JsonProperty("Default", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IComplexMapping Default { get; set; }

        [JsonProperty("NotExists", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IComplexMapping NotExists { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class StringValueMapping
    {
        [JsonProperty("Value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("To", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IComplexMapping To { get; set; }

        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class IComplexMapping
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SourceMatch
    {
        [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid? Id { get; set; }

        [JsonProperty("State", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public SourceMatchState? State { get; set; }

        [JsonProperty("SourceString", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceString { get; set; }
    }

    public class QueryShaping
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public Dictionary<string, bool?> Order { get; set; }
        public Dictionary<string, string> Filter { get; set; }
    }

    public class QueryShapingResult<T>
    {
        public T[] Result { get; set; }
        public int Total { get; set; }
    }

    public class ViewerInstance<T> : BaseItem
    { 
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid[] Attributes { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public T Settings { get; set; }
    }
    
}
