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

    // Location
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class LocationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Location>
    {
        public LocationConfiguration()
            : this("dbo")
        {
        }

        public LocationConfiguration(string schema)
        {
            ToTable("Location", schema);
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TransportId).HasColumnName(@"TransportID").IsRequired().HasColumnType("int");
            Property(x => x.Latitude).HasColumnName(@"latitude").IsRequired().HasColumnType("decimal").HasPrecision(9,6);
            Property(x => x.Longitude).HasColumnName(@"longitude").IsRequired().HasColumnType("decimal").HasPrecision(9,6);
            Property(x => x.LocationDate).HasColumnName(@"LocationDate").IsRequired().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.Transport).WithMany(b => b.Locations).HasForeignKey(c => c.TransportId).WillCascadeOnDelete(false); // FK_Location_Transport
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
