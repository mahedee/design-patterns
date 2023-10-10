// Mediator Design pattern
// Category: Behavioral
// Definition: The Mediator Pattern is a behavioral design pattern that allows communication between objects by encapsulating the way objects interact with each other. 
// It promotes loose coupling between objects by eliminating the need for them to have direct references to each other


// Define the mediator interface
public interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}

// Define the colleague interface 
public abstract class Colleague
{
    protected IMediator _mediator;
    public Colleague(IMediator mediator)
    {
        _mediator = mediator;
    }
}

// Define the concrete colleague classes
// Both inherits Colleague class so that it can access mediator instance
public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(IMediator mediator) : base(mediator) { }
    public void Send(string message)
    {
        // It calles the SendMessage of ConcreteMediator class
        _mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine("ConcreteColleague1 receive message: " + message);
    }
}

public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(IMediator mediator) : base(mediator) { }
    public void Send(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine("ConcreteColleague2 receive message: " + message);
    }
}

// Define concrete mediator class
// Implementation of IMediator

public class ConcreteMediator : IMediator
{
    private ConcreteColleague1 colleague1;
    private ConcreteColleague2 colleague2;

    public void SetColleague1(ConcreteColleague1 colleague1)
    {
        this.colleague1 = colleague1;
    }

    public void SetColleague2(ConcreteColleague2 colleague2)
    {
        this.colleague2 = colleague2;
    }

    // Implementation of IMediator method
    public void SendMessage(string message, Colleague colleague)
    {
        if (colleague == colleague1)
        {
            colleague2.Receive(message);
        }
        else
        {
            colleague1.Receive(message);
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {

        var mediator = new ConcreteMediator();

        // send ConcreteMediator instance as mediator 
        var colleague1 = new ConcreteColleague1(mediator);
        var colleague2 = new ConcreteColleague2(mediator);

        // intialize colleague1 and colleague2 in ConcreteMediator class
        mediator.SetColleague1(colleague1);
        mediator.SetColleague2(colleague2);

        colleague1.Send("Hello, colleague2!");
        colleague2.Send("Hi, colleague1!");
    }
}


// Output
// ConcreteColleague2 receive message: Hello, colleague2!
// ConcreteColleague1 receive message: Hi, colleague1!