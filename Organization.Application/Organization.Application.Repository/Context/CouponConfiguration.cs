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

    // Coupon
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class CouponConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Coupon>
    {
        public CouponConfiguration()
            : this("dbo")
        {
        }

        public CouponConfiguration(string schema)
        {
            ToTable("Coupon", schema);
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Code).HasColumnName(@"Code").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Description).HasColumnName(@"Description").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Amount).HasColumnName(@"Amount").IsRequired().HasColumnType("int");
            Property(x => x.Symbol).HasColumnName(@"Symbol").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FromDate).HasColumnName(@"FromDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ToDate).HasColumnName(@"ToDate").IsOptional().HasColumnType("smalldatetime");
            Property(x => x.InActiveAsOf).HasColumnName(@"InActiveAsOf").IsOptional().HasColumnType("smalldatetime");
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>