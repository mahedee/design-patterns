/**
Creational Design Pattern
*/


// An object to access using singleton instance
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}


// sealed is used to restrict the inheritance
public sealed class SingletonEmployeeService
{
    // singleton static object
    private static SingletonEmployeeService instance;

    // List of employee object to access using singleton instance
    private List<Employee> _employees = null;


    private SingletonEmployeeService()
    {
        if (_employees == null)
        {
            _employees = new List<Employee>();
        }
    }

    // The static method to provide global access to the singleton object
    // Get singleton object of SingletonEmployeeService class
    public static SingletonEmployeeService GetInstance()
    {
        if (instance == null)
        {
            // Thread safe singleton
            /* When a thread enters the lock block, it attempts to acquire a lock on the specified object (in this case, typeof(SingletonEmployeeService)). 
            
            If no other thread currently holds the lock, the thread acquires it and continues executing.
            If another thread is already inside the lock block and holds the lock, any other threads that reach this point will be blocked and put into a queue, 
            waiting for the lock to be released.

            Once the thread that acquired the lock inside the lock block completes its work and exits the block, the lock is released, 
            and one of the waiting threads (if any) will acquire the lock and proceed with its work.
            */
            lock (typeof(SingletonEmployeeService))
            {
                instance = new SingletonEmployeeService();
            }

        }
        return instance;
    }

    // Add employee to the employee list
    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    // Get employee object by id
    public Employee GetEmployee(int id)
    {
        return _employees.Where(p => p.Id == id).FirstOrDefault();
    }

}

public class Program
{
    public static void Main(string[] args)
    {

        Employee employee1 = new Employee() { Id = 1, Name = "John", Age = 38 };
        Employee employee2 = new Employee() { Id = 2, Name = "Bob", Age = 30 };

        // Create singleton instance using GetInstance method not new
        SingletonEmployeeService singletonEmployeeService = SingletonEmployeeService.GetInstance();

        singletonEmployeeService.AddEmployee(employee1);
        singletonEmployeeService.AddEmployee(employee2);

        Console.WriteLine(singletonEmployeeService.GetEmployee(1).Name);

        Console.ReadKey();
    }
}

// Output:
// John