using EF7ExecuteDelete.Entities;

namespace EF7ExecuteDelete.Data;

public class SeedDatabase
{
    public static void PopulaDB(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        //1000 clientes, 1000 endereços e 3000 animais
        context.Clientes.AddRange(Enumerable.Range(1, 1_000).Select(i =>
        {
            return new Cliente
            {
                Nome = $"{nameof(Cliente.Nome)}-{i}",
                Email = $"{nameof(Cliente.Email)}-{i}",
                Endereco = new Endereco
                {
                    Local = $"{nameof(Endereco.Local)}-{i}",
                },
                Animais = Enumerable.Range(1, 3).Select(i2 =>
                {
                    return new Animal
                    {
                        Raca = $"{nameof(Animal.Raca)}-{i}-{i2}",
                        Nome = $"{nameof(Animal.Nome)}-{i}-{i2}",
                    };
                }).ToList()
            };
        }));
        context.SaveChanges();
    }
}
