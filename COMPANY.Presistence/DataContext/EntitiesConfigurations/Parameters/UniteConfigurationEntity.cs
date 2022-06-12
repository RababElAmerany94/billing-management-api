namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class UniteConfigurationEntity : IEntityTypeConfiguration<Unite>
    {
        public void Configure(EntityTypeBuilder<Unite> builder)
        {
            //builder.ToTable("Unites");

            builder.HasData(new Unite[] {
                new Unite(){ Id= "Unite::1", Name = "€" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::2", Name = "kg" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::3", Name = "h" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::4", Name = "m2" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::5", Name = "m3" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::6", Name = "L" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::7", Name = "U" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::8", Name = "m" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::9", Name = "j" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::10", Name = "g" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::11", Name = "min" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::12", Name = "mL" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::13", Name = "lot" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::14", Name = "km" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::15", Name = "cm" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::16", Name = "cm2" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::17", Name = "cm3" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::18", Name = "t" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::19", Name = "mg" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::20", Name = "mm" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::21", Name = "BO" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::22", Name = "BOI" ,CreatedOn = new DateTime(2020,01,01)},
                new Unite(){ Id= "Unite::23", Name = "TUB" ,CreatedOn = new DateTime(2020,01,01)},
            });
        }
    }

}
