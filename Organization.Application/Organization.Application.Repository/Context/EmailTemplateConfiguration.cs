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

    // EmailTemplate
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class EmailTemplateConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EmailTemplate>
    {
        public EmailTemplateConfiguration()
            : this("dbo")
        {
        }

        public EmailTemplateConfiguration(string schema)
        {
            ToTable("EmailTemplate", schema);
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.EmailKey).HasColumnName(@"EmailKey").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Subject).HasColumnName(@"Subject").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Body).HasColumnName(@"Body").IsOptional().IsUnicode(false).HasColumnType("varchar(max)");
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>