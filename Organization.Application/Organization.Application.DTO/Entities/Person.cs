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

    // Person
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class Person : IEntity
    {
        public int ID { get; set; } // ID (Primary key)
        public string FirstName { get; set; } // FirstName (length: 100)
        public string MiddleName { get; set; } // MiddleName (length: 100)
        public string LastName { get; set; } // LastName (length: 100)
        public string MobileCountryCode { get; set; } // MobileCountryCode (length: 50)
        public string MobilePhone { get; set; } // MobilePhone (length: 50)
        public string PrimaryEmail { get; set; } // PrimaryEmail (length: 100)
        public System.DateTime? Created { get; set; } // Created
        public string CreatedBy { get; set; } // CreatedBy (length: 100)
        public string Password { get; set; } // Password (length: 1000)
        public bool IsSuspended { get; set; } // IsSuspended
        public bool IsMobileVerified { get; set; } // IsMobileVerified
        public string Ssn { get; set; } // SSN (length: 100)
        public bool IsAcknowledged { get; set; } // IsAcknowledged
        public bool IsOnline { get; set; } // IsOnline
        public bool IsLimoOrTaxiDriver { get; set; } // IsLimoOrTaxiDriver
        public bool EmailConfirmed { get; set; } // EmailConfirmed
        public string SecurityStamp { get; set; } // SecurityStamp
        public bool TwoFactorEnabled { get; set; } // TwoFactorEnabled
        public System.DateTime? LockoutEndDateUtc { get; set; } // LockoutEndDateUtc
        public bool LockoutEnabled { get; set; } // LockoutEnabled
        public int AccessFailedCount { get; set; } // AccessFailedCount
        public string UserName { get; set; } // UserName (length: 256)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } // AspNetUserClaims.FK_AspNetUserClaims_Person
        public virtual System.Collections.Generic.ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } // AspNetUserLogins.FK_AspNetUserLogins_Person
        public virtual System.Collections.Generic.ICollection<Fare> Fares { get; set; } // Fares.FK_Fares_Person
        public virtual System.Collections.Generic.ICollection<FareToPersonRelation> FareToPersonRelations { get; set; } // FareToPersonRelation.FK_FareToPersonRelation_Person
        public virtual System.Collections.Generic.ICollection<MobileVerification> MobileVerifications { get; set; } // MobileVerification.FK_MobileVerification_Person
        public virtual System.Collections.Generic.ICollection<PersonDocument> PersonDocuments { get; set; } // PersonDocument.FK_PersonDocuments_Person
        public virtual System.Collections.Generic.ICollection<PersonRole> PersonRoles { get; set; } // PersonRole.FK_PersonRole_Person
        public virtual System.Collections.Generic.ICollection<PersonToCoupon> PersonToCoupons { get; set; } // PersonToCoupon.FK_PersonToCoupon_Person
        public virtual System.Collections.Generic.ICollection<Transport> Transports { get; set; } // Transport.FK_Transport_Person

        public Person()
        {
            IsSuspended = false;
            IsMobileVerified = false;
            IsAcknowledged = false;
            IsOnline = false;
            IsLimoOrTaxiDriver = false;
            TwoFactorEnabled = false;
            LockoutEnabled = false;
            AspNetUserClaims = new System.Collections.Generic.List<AspNetUserClaim>();
            AspNetUserLogins = new System.Collections.Generic.List<AspNetUserLogin>();
            Fares = new System.Collections.Generic.List<Fare>();
            FareToPersonRelations = new System.Collections.Generic.List<FareToPersonRelation>();
            MobileVerifications = new System.Collections.Generic.List<MobileVerification>();
            PersonDocuments = new System.Collections.Generic.List<PersonDocument>();
            PersonRoles = new System.Collections.Generic.List<PersonRole>();
            PersonToCoupons = new System.Collections.Generic.List<PersonToCoupon>();
            Transports = new System.Collections.Generic.List<Transport>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
