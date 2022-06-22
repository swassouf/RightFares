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

using Organization.Application.DTO.Entities;

namespace Organization.Application.Repository.Context
{

    // FareToPersonRelation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class FareToPersonRelationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FareToPersonRelation>
    {
        public FareToPersonRelationConfiguration()
            : this("dbo")
        {
        }

        public FareToPersonRelationConfiguration(string schema)
        {
            ToTable("FareToPersonRelation", schema);
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FareId).HasColumnName(@"FareID").IsRequired().HasColumnType("int");
            Property(x => x.PersonId).HasColumnName(@"PersonID").IsRequired().HasColumnType("int");
            Property(x => x.IsPrimary).HasColumnName(@"IsPrimary").IsRequired().HasColumnType("bit");
            Property(x => x.IsSharedAccepted).HasColumnName(@"IsSharedAccepted").IsRequired().HasColumnType("bit");
            Property(x => x.IsPaymentSucceed).HasColumnName(@"IsPaymentSucceed").IsRequired().HasColumnType("bit");
            Property(x => x.BraintreePaymentMessage).HasColumnName(@"BraintreePaymentMessage").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);

            // Foreign keys
            HasRequired(a => a.Fare).WithMany(b => b.FareToPersonRelations).HasForeignKey(c => c.FareId).WillCascadeOnDelete(false); // FK_FareToPersonRelation_Fares
            HasRequired(a => a.Person).WithMany(b => b.FareToPersonRelations).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false); // FK_FareToPersonRelation_Person
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>