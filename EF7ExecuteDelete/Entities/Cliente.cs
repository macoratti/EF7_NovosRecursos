namespace EF7ExecuteDelete.Entities;

public class Cliente
{
    public int ClienteId { get; set; }
    public string Nome { get; set; } = "";
    public string Email { get; set; } = "";
    public Endereco? Endereco { get; set; }
    public List<Animal> Animais { get; set; } = new List<Animal>();
}
