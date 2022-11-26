//1. Əmri icra edən (Reciever)
public class Orders
{
    public void AddOrder() => Console.WriteLine("New product added successfully!");
    public void UpdateOrder() => Console.WriteLine("Product updated successfully!");

}
//2. İcra ediləcək hər bir əmr standart interfeysə malik olmalıdır
public interface ICommand
{
    void Execute();
}

//Concrete command
public class AddOrderCommand : ICommand
{
    private Orders _orders;
    public AddOrderCommand(Orders orders)
    {
        this._orders = orders;
    }

    public void Execute()
    {
        _orders.AddOrder();
    }
}


//Concrete command
public class UpdateOrderCommand : ICommand
{
    private Orders _orders;
    public UpdateOrderCommand(Orders orders)
    {
        this._orders = orders;
    }
    public void Execute()
    {
        _orders.UpdateOrder();
    }
}

// Əmr obyektini qəbul edən obyektə ötürmək üçün obyekt
//Invoker
public class StockController
{
    private List<ICommand> _orderCommands;

    public StockController()
    {
        _orderCommands = new List<ICommand>();
    }

    public void TakeOrder(ICommand command)
    {
        _orderCommands.Add(command);
    }
    public void RemoveOrder(ICommand command)
    {
        if(_orderCommands.Contains(command))
            _orderCommands.Remove(command);
        else
            Console.WriteLine($"{nameof(command)} is not found in order list!");
    }

    public void PlaceOrders() //Execute
    {
        foreach (ICommand command in _orderCommands)
        {
            command.Execute();
        }

        _orderCommands.Clear();
    }
}

class Program
{
    static void Main()
    {

        AddOrderCommand AddOrderCommand = new AddOrderCommand(new Orders());
        UpdateOrderCommand UpdateOrderCommand = new UpdateOrderCommand(new Orders());

        StockController db = new StockController();


        db.TakeOrder(AddOrderCommand);
        db.TakeOrder(AddOrderCommand);
        db.TakeOrder(UpdateOrderCommand);

        //db.RemoveOrder(AddOrderCommand);

        db.PlaceOrders();

        Console.ReadLine();
    }
}