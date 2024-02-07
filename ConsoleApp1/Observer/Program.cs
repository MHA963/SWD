using System;

public class Payload
{
    public string ? Message { get; set; }
}

public class Subject : IObservable<Payload>
{
    private ICollection<IObserver<Payload>> Observers { get; set; }

    public Subject()
    {
        Observers = new List<IObserver<Payload>>();
    }

    public IDisposable Subscribe(IObserver<Payload> observer)
    {         
        if (!Observers.Contains(observer))
        {
            Observers.Add(observer);
        }

        return new Unsubscriber(observer, new List<IObserver<Payload>>(Observers));
    }

    public void SendMessage(string message)
    {
        foreach (var observer in Observers)
        {
            observer.OnNext(new Payload { Message = message });
        }
    }
}

public class Unsubscriber : IDisposable
{
    private IObserver<Payload> observer;
    private IList<IObserver<Payload>> observers;

    public Unsubscriber(
        IObserver<Payload> observer,
        IList<IObserver<Payload>> observers)
    {
        this.observer = observer;
        this.observers = observers;
    }

    public void Dispose()
    {
        if (observer != null && observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }
}

public class Observer : IObserver<Payload>
{
    public string ? Message { get; set; }

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(Payload value)
    {
        Message = value.Message;
    }

    public IDisposable Register(Subject subject)
    {
        return subject.Subscribe(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject();

        Observer observer1 = new Observer();
        Observer observer2 = new Observer();

        IDisposable subscription1 = observer1.Register(subject);
        IDisposable subscription2 = observer2.Register(subject);

        subject.SendMessage("Hello, observers!");

        Console.WriteLine($"Observer 1 received: {observer1.Message}");
        Console.WriteLine($"Observer 2 received: {observer2.Message}");

        subscription1.Dispose();
        subscription2.Dispose();
    }
}

