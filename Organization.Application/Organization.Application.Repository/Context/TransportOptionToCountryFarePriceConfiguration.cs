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

    // TransportOptionToCountryFarePrice
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class TransportOptionToCountryFarePriceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TransportOptionToCountryFarePrice>
    {
        public TransportOptionToCountryFarePriceConfiguration()
            : this("dbo")
        {
        }

        public TransportOptionToCountryFarePriceConfiguration(string schema)
        {
            ToTable("TransportOptionToCountryFarePrice", schema);
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TransportOptionId).HasColumnName(@"TransportOptionID").IsRequired().HasColumnType("int");
            Property(x => x.CountryRegionId).HasColumnName(@"CountryRegionID").IsRequired().HasColumnType("int");
            Property(x => x.BaseFare).HasColumnName(@"BaseFare").IsRequired().HasColumnType("decimal").HasPrecision(4,2);
            Property(x => x.PerMile).HasColumnName(@"PerMile").IsRequired().HasColumnType("decimal").HasPrecision(4,2);
            Property(x => x.PerMinute).HasColumnName(@"PerMinute").IsRequired().HasColumnType("decimal").HasPrecision(4,2);
            Property(x => x.SafeRideFee).HasColumnName(@"SafeRideFee").IsRequired().HasColumnType("decimal").HasPrecision(4,2);

            // Foreign keys
            HasRequired(a => a.CountryRegion).WithMany(b => b.TransportOptionToCountryFarePrices).HasForeignKey(c => c.CountryRegionId).WillCascadeOnDelete(false); // FK_TransportToCountryFarePrice_CountryRegion
            HasRequired(a => a.TransportOption).WithMany(b => b.TransportOptionToCountryFarePrices).HasForeignKey(c => c.TransportOptionId).WillCascadeOnDelete(false); // FK_TransportOptionToCountryFarePrice_TransportOption
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>