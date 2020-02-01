using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._012_OperationWithProcedure
{
    class _001_OWP
    {
        public class Phone
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class MobileContext : DbContext
        {
            public DbSet<Phone> Phones { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                // переопределение добавления
                modelBuilder.Entity<Phone>()
                    .MapToStoredProcedures(b => b.Insert(sp => sp.HasName("InsertPhone")
                        .Parameter(pm => pm.Name, "Model")
                        .Parameter(pm => pm.Price, "Price")
                        .Result(rs => rs.Id, "Id")));

                // переопределение обновления
                modelBuilder.Entity<Phone>()
                    .MapToStoredProcedures(b => b.Update(sp => sp.HasName("UpdatePhone")
                        .Parameter(pm => pm.Name, "Model")
                        .Parameter(pm => pm.Price, "Price")
                        .Parameter(pm => pm.Id, "Id")));

                // переопределение удаления
                modelBuilder.Entity<Phone>()
                    .MapToStoredProcedures(b => b.Delete(sp => sp.HasName("DeletePhone")
                        .Parameter(pm => pm.Id, "Id")));

                base.OnModelCreating(modelBuilder);
            }
        }

        /*
CREATE PROCEDURE [dbo].[UpdatePhone]
    @model nvarchar(50),
    @price int,
    @id int
AS
UPDATE Phones SET Name=@model, Price=@price WHERE Id=@id
GO

CREATE PROCEDURE [dbo].[DeletePhone]
    @id int
AS
    DELETE FROM Phones WHERE Id=@id
GO
         */
    }
}
