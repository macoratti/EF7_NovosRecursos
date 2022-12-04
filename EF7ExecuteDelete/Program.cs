using EF7ExecuteDelete.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("\nIniciando Processamento...");

Console.WriteLine("\nSelecione a opção : ");
Console.WriteLine("(1)-Popula a tabela");
Console.WriteLine("(2)-Deleta Animais");
Console.WriteLine("(3)-Deleta Clientes");
Console.WriteLine("(4)-Atualiza Clientes (nome)");
Console.WriteLine("(5)-Atualiza Clientes (nome e email)");

Console.WriteLine("(9)-Encerra");

int opcao = Convert.ToInt32(Console.ReadLine());

if (opcao == 1)
    PopulaTabelas();
else if (opcao == 2)
    DeletaAnimais();
else if (opcao == 3)
    DeletaClientes();
else if (opcao == 4)
    AtualizaNomeClientes();
else if (opcao == 5)
    AtualizaNomeEmailClientes();
else if (opcao == 9)
    Console.WriteLine("Fim !!!");

Console.ReadKey();

static void AtualizaNomeClientes()
{
    using (var context = new AppDbContext())
    {
        var registros = context.Clientes.Count();
        Console.WriteLine($"\nExistem {registros} de clientes na tabela\n");

        Console.WriteLine("\nAtualizando nomes dos Clientes...");

        var clientesAtualizados = context.Clientes
                                  .Where(p => p.ClienteId <= 900)
                                  .ExecuteUpdate(p => p.SetProperty(x => x.Nome, x => "Atualizado"));

        Console.WriteLine($"\n{clientesAtualizados} clientes foram atualizados da tabela...");
    }
}

static void AtualizaNomeEmailClientes()
{
    using (var context = new AppDbContext())
    {
        var registros = context.Clientes.Count();
        Console.WriteLine($"\nExistem {registros} de clientes na tabela\n");

        Console.WriteLine("\nAtualizando nomes dos Clientes...");

        var clientesAtualizados = context.Clientes
                                  .Where(p => p.ClienteId <= 900)
                                  .ExecuteUpdate(p => p.SetProperty(x => x.Nome, x => "Novo Nome")
                                                      .SetProperty(e => e.Email, e => "Novo Email"));

        Console.WriteLine($"\n{clientesAtualizados} clientes foram atualizados na tabela...");
    }
}

static void DeletaAnimais()
{
    using (var context = new AppDbContext())
    {

        var registros = context.Animais.Count();
        Console.WriteLine($"\nExistem {registros} de animais na tabela\n");

        Console.WriteLine("\nDeletando Animais...");

        var animaisExcluidos = context.Animais
                                      .Where(p => p.Nome.Contains("1"))
                                      .ExecuteDelete();

        Console.WriteLine($"\n{animaisExcluidos} animais foram excluidos da tabela...");
    }
}

static void DeletaClientes()
{
    using (var context = new AppDbContext())
    {
        var registros = context.Clientes.Count();
        Console.WriteLine($"\nExistem {registros} de clientes na tabela\n");

        Console.WriteLine("\nDeletando Clientes (em cascata)...");

        var clientesDeletados = context.Clientes
                                        .Where(p => p.ClienteId <= 500)
                                        .ExecuteDelete();

        Console.WriteLine($"\n{clientesDeletados} clientes foram excluidos da tabela...");

        var enderecos = context.Enderecos.Count();
        Console.WriteLine($"\nAgora existem {enderecos} enderecos na tabela...");
        var animais = context.Animais.Count();
        Console.WriteLine($"\nAgora existem {animais} animais na tabela...");
    }
}

static void PopulaTabelas()
{
    using (var context = new AppDbContext())
    {
        Console.WriteLine("\nPopulando as tabelas...");
        SeedDatabase.PopulaDB(context);

        var clientes = context.Clientes.Count();
        var animais = context.Animais.Count();
        var enderecos = context.Enderecos.Count();

        Console.WriteLine($"\nExistem {clientes} clientes");
        Console.WriteLine($"Existem {animais} animais");
        Console.WriteLine($"Existem {enderecos} endereços");
    }
}