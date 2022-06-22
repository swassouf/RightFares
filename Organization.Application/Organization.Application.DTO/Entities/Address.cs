// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.61
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Organization.Application.DTO.Interface;

namespace Organization.Application.DTO.Entities
{

    // Address
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class Address : IEntity
    {
        public int ID { get; set; } // ID (Primary key)
        public string AddressLine1 { get; set; } // AddressLine1 (length: 1000)
        public string AddressLine2 { get; set; } // AddressLine2 (length: 1000)
        public string AddressLine3 { get; set; } // AddressLine3 (length: 1000)
        public int? CityId { get; set; } // CityID
        public string PostalCode { get; set; } // PostalCode (length: 50)

        // Foreign keys
        public virtual City City { get; set; } // FK_Address_City

        public Address()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>