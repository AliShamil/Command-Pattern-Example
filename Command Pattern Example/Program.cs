//1. Əmri icra edən
public class Orders
{
    public void AddOrder() => Console.WriteLine("New order added successfully!");
    public void UpdateOrder() => Console.WriteLine("Order updated!");

}
//2. İcra ediləcək hər bir əmr standart interfeysə malik olmalıdır
public interface ICommand
{
    void Execute();
}


public class AddOrderCommand : ICommand
{
    private Orders _orders;
    public AddOrderCommand(Orders siparisIslemleri)
    {
        this._orders = siparisIslemleri;
    }

    public void Execute()
    {
        _orders.AddOrder();
    }
}
public class UpdateOrderCommand : ICommand
{
    private Orders _orders;
    public UpdateOrderCommand(Orders siparisIslemleri)
    {
        this._orders = siparisIslemleri;
    }
    public void Execute()
    {
        _orders.UpdateOrder();
    }
}

// Əmr obyektini qəbul edən obyektə ötürmək üçün obyekt
public class DatabaseCommandForwarder
{
    public void Execute(ICommand komut)
    {
        komut.Execute();
    }
}

class Program
{
    static void Main()
    {

        AddOrderCommand AddOrderCommand = new AddOrderCommand(new Orders());
        UpdateOrderCommand UpdateOrderCommand = new UpdateOrderCommand(new Orders());

        DatabaseCommandForwarder db= new DatabaseCommandForwarder();


        db.Execute(AddOrderCommand);
        db.Execute(UpdateOrderCommand);

        Console.ReadLine();
    }
}