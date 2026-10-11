namespace WtLab5Banking.Razor.Models;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected BaseEntity(int id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
    }

    public abstract void PrintInfo();
}
