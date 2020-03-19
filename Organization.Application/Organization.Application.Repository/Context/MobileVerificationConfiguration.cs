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

    // MobileVerification
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class MobileVerificationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MobileVerification>
    {
        public MobileVerificationConfiguration()
            : this("dbo")
        {
        }

        public MobileVerificationConfiguration(string schema)
        {
            ToTable("MobileVerification", schema);
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.PersonId).HasColumnName(@"PersonID").IsOptional().HasColumnType("int");
            Property(x => x.VerificationCode).HasColumnName(@"VerificationCode").IsOptional().HasColumnType("int");
            Property(x => x.Created).HasColumnName(@"Created").IsOptional().HasColumnType("datetime");

            // Foreign keys
            HasOptional(a => a.Person).WithMany(b => b.MobileVerifications).HasForeignKey(c => c.PersonId).WillCascadeOnDelete(false); // FK_MobileVerification_Person
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
