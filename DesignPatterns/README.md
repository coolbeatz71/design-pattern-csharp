# Object-Oriented Design Patterns

## Overview

This document provides a comprehensive guide to the 23 classic Gang of Four design patterns implemented in C#. Each pattern is explained with its purpose, the problem it solves, practical scenarios where it would be useful, and complete code examples.

Design patterns are reusable solutions to commonly occurring problems in software design. They represent best practices and provide a common vocabulary for developers to communicate design concepts effectively.

## Pattern Categories

The 23 design patterns are divided into three main categories:

- **Creational Patterns** (5): Deal with object creation mechanisms
- **Structural Patterns** (7): Deal with object composition and relationships
- **Behavioral Patterns** (11): Deal with communication between objects and the assignment of responsibilities

---

## Creational Patterns

Creational patterns abstract the instantiation process and help make systems independent of how objects are created, composed, and represented.

### 1. Singleton Pattern

**Problem it solves:**
In many applications, there are scenarios where you need exactly one instance of a particular class throughout the entire application lifecycle. The challenge arises when multiple parts of your application try to create instances of the same class, potentially leading to resource conflicts, inconsistent state, or unnecessary resource consumption. For example, if you have a logging service and different parts of your application each create their own logger instance, you might end up with multiple log files, conflicting file access, or inconsistent logging formats. The Singleton pattern addresses this by ensuring that no matter how many times you try to instantiate a class, you always get the same single instance. This is particularly crucial for managing shared resources like database connections, configuration settings, or cache managers where having multiple instances could lead to synchronization issues, resource leaks, or inconsistent application behavior.

**When to use:**
- Managing shared resources like database connections, logging services, or configuration settings
- Coordinating actions across the system from a central point
- When you need exactly one instance of a class (like a printer spooler or cache manager)

**Real-world example:** A logging service where all parts of an application need to write to the same log file, or a database connection pool manager.

**Code Example:**
```csharp
public sealed class Logger
{
    private static Logger _instance = null;
    private static readonly object _lock = new object();
    
    private Logger() 
    {
        // Private constructor prevents instantiation
    }
    
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }
            return _instance;
        }
    }
    
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;
        
        logger1.Log("First message");
        logger2.Log("Second message");
        
        // Both references point to the same instance
        Console.WriteLine(ReferenceEquals(logger1, logger2)); // True
    }
}
```

### 2. Factory Method Pattern

**Problem it solves:**
When designing applications, you often encounter situations where you need to create objects, but the exact type of object to create isn't known until runtime, or you want to delegate the responsibility of object creation to subclasses. The traditional approach of using the `new` keyword directly in your code creates tight coupling between your code and specific concrete classes, making your system rigid and difficult to extend. This becomes particularly problematic when you need to create different types of objects based on user input, configuration settings, or runtime conditions. The Factory Method pattern solves this by providing an interface for creating objects while allowing subclasses to decide which specific class to instantiate. This approach eliminates the need for your client code to know about specific concrete classes, making the system more flexible and easier to extend. It also centralizes object creation logic, making it easier to manage and modify how objects are created without affecting the rest of your codebase.

**When to use:**
- When you need to delegate object creation to subclasses
- When the exact type of object to create isn't known until runtime
- When you want to localize the knowledge of which class gets created

**Real-world example:** A document editor that can create different types of documents (Word, PDF, HTML) based on user selection, where each document type has its own creation logic.

**Code Example:**
```csharp
// Product interface
public interface IDocument
{
    void Open();
    void Save();
}

// Concrete products
public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Word document");
    public void Save() => Console.WriteLine("Saving Word document");
}

public class PDFDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PDF document");
    public void Save() => Console.WriteLine("Saving PDF document");
}

// Creator abstract class
public abstract class DocumentCreator
{
    public abstract IDocument CreateDocument();
    
    public void ProcessDocument()
    {
        IDocument doc = CreateDocument();
        doc.Open();
        doc.Save();
    }
}

// Concrete creators
public class WordDocumentCreator : DocumentCreator
{
    public override IDocument CreateDocument() => new WordDocument();
}

public class PDFDocumentCreator : DocumentCreator
{
    public override IDocument CreateDocument() => new PDFDocument();
}

// Usage
class Program
{
    static void Main()
    {
        DocumentCreator wordCreator = new WordDocumentCreator();
        DocumentCreator pdfCreator = new PDFDocumentCreator();
        
        wordCreator.ProcessDocument();
        pdfCreator.ProcessDocument();
    }
}
```

### 3. Abstract Factory Pattern

**Problem it solves:**
In complex applications, you often need to create families of related objects that are designed to work together, and you want to ensure that objects from different families are not mixed together inadvertently. For instance, if you're building a cross-platform application, you might have different UI components for Windows, macOS, and Linux, where each platform has its own specific button, window, and menu implementations. The challenge is ensuring that when you create a Windows button, you also create Windows-compatible windows and menus, not a mixture of components from different platforms. Creating individual factories for each type of object would be cumbersome and wouldn't guarantee compatibility between related objects. The Abstract Factory pattern addresses this by providing an interface that creates entire families of related objects, ensuring that all objects created by a particular factory implementation are compatible with each other. This pattern guarantees consistency within object families while still allowing you to switch between different families based on runtime conditions or configuration.

**When to use:**
- When you need to create families of related products
- When you want to ensure that products from the same family are used together
- When you need to configure your system with multiple product lines

**Real-world example:** A UI framework that needs to create different sets of controls for different operating systems (Windows buttons, Mac buttons, Linux buttons) while ensuring consistency within each platform.

**Code Example:**
```csharp
// Abstract product interfaces
public interface IButton
{
    void Click();
}

public interface IWindow
{
    void Open();
}

// Windows family
public class WindowsButton : IButton
{
    public void Click() => Console.WriteLine("Windows button clicked");
}

public class WindowsWindow : IWindow
{
    public void Open() => Console.WriteLine("Windows window opened");
}

// Mac family
public class MacButton : IButton
{
    public void Click() => Console.WriteLine("Mac button clicked");
}

public class MacWindow : IWindow
{
    public void Open() => Console.WriteLine("Mac window opened");
}

// Abstract factory
public interface IGUIFactory
{
    IButton CreateButton();
    IWindow CreateWindow();
}

// Concrete factories
public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public IWindow CreateWindow() => new WindowsWindow();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public IWindow CreateWindow() => new MacWindow();
}

// Client
public class Application
{
    private IButton _button;
    private IWindow _window;
    
    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _window = factory.CreateWindow();
    }
    
    public void Run()
    {
        _window.Open();
        _button.Click();
    }
}

// Usage
class Program
{
    static void Main()
    {
        IGUIFactory factory = new WindowsFactory();
        Application app = new Application(factory);
        app.Run();
    }
}
```

### 4. Builder Pattern

**Problem it solves:**
When creating complex objects that have many optional parameters, constructors can quickly become unwieldy and difficult to use. You might end up with constructors that have dozens of parameters, making it hard to remember the order and meaning of each parameter. Additionally, many of these parameters might be optional, leading to multiple constructor overloads or the need to pass null values for unused parameters. This problem becomes even more complex when the object construction process involves multiple steps or when certain combinations of parameters are invalid. The traditional approach often results in either telescoping constructors (multiple overloaded constructors with increasing numbers of parameters) or the need to expose setter methods that compromise object immutability. The Builder pattern solves this by providing a step-by-step approach to object construction, where you can set only the parameters you need in any order, with meaningful method names that make the code self-documenting. It also allows for validation of parameter combinations and can ensure that the final object is in a valid state before creation.

**When to use:**
- When creating objects with many optional parameters
- When the construction process is complex or needs to be done in specific steps
- When you want to create immutable objects with many properties

**Real-world example:** Building a complex SQL query with optional WHERE clauses, JOIN statements, and ORDER BY conditions, or constructing a house with optional features like garage, swimming pool, and garden.

**Code Example:**
```csharp
// Product
public class House
{
    public string Foundation { get; set; }
    public string Structure { get; set; }
    public string Roof { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }
    public bool HasGarden { get; set; }
    
    public override string ToString()
    {
        return $"House: {Foundation}, {Structure}, {Roof}" +
               $"{(HasGarage ? ", Garage" : "")}" +
               $"{(HasSwimmingPool ? ", Swimming Pool" : "")}" +
               $"{(HasGarden ? ", Garden" : "")}";
    }
}

// Builder
public class HouseBuilder
{
    private House _house = new House();
    
    public HouseBuilder SetFoundation(string foundation)
    {
        _house.Foundation = foundation;
        return this;
    }
    
    public HouseBuilder SetStructure(string structure)
    {
        _house.Structure = structure;
        return this;
    }
    
    public HouseBuilder SetRoof(string roof)
    {
        _house.Roof = roof;
        return this;
    }
    
    public HouseBuilder AddGarage()
    {
        _house.HasGarage = true;
        return this;
    }
    
    public HouseBuilder AddSwimmingPool()
    {
        _house.HasSwimmingPool = true;
        return this;
    }
    
    public HouseBuilder AddGarden()
    {
        _house.HasGarden = true;
        return this;
    }
    
    public House Build()
    {
        if (string.IsNullOrEmpty(_house.Foundation) || 
            string.IsNullOrEmpty(_house.Structure) || 
            string.IsNullOrEmpty(_house.Roof))
        {
            throw new InvalidOperationException("Foundation, Structure, and Roof are required");
        }
        
        return _house;
    }
}

// Usage
class Program
{
    static void Main()
    {
        House luxuryHouse = new HouseBuilder()
            .SetFoundation("Concrete Foundation")
            .SetStructure("Brick Structure")
            .SetRoof("Tile Roof")
            .AddGarage()
            .AddSwimmingPool()
            .AddGarden()
            .Build();
            
        Console.WriteLine(luxuryHouse);
        
        House basicHouse = new HouseBuilder()
            .SetFoundation("Wood Foundation")
            .SetStructure("Wood Structure")
            .SetRoof("Shingle Roof")
            .Build();
            
        Console.WriteLine(basicHouse);
    }
}
```

### 5. Prototype Pattern

**Problem it solves:**
Object creation can be expensive in terms of both time and computational resources, especially when objects require complex initialization, database queries, network calls, or extensive calculations to set up their initial state. In some scenarios, you might need to create many objects that are similar to existing ones, differing only in a few properties. Creating each object from scratch using constructors would be inefficient and wasteful. Additionally, sometimes you don't know the exact class of the object you need to create until runtime, or you want to create objects without being tightly coupled to their specific classes. The traditional approach of using constructors requires compile-time knowledge of the exact class type and forces you to repeat expensive initialization processes. The Prototype pattern addresses these issues by allowing you to create new objects by cloning existing instances. This approach is much faster than creating objects from scratch because cloning typically involves copying memory structures rather than executing complex initialization logic. It also provides a way to create objects without knowing their exact classes, as long as you have a prototype instance to clone from.

**When to use:**
- When object creation is expensive in terms of time or resources
- When you need to create objects that are similar to existing ones
- When you want to avoid the overhead of initializing an object

**Real-world example:** Creating new game characters based on existing templates, or duplicating complex document objects with all their formatting and content intact.

**Code Example:**
```csharp
// Prototype interface
public interface IPrototype<T>
{
    T Clone();
}

// Concrete prototype
public class GameCharacter : IPrototype<GameCharacter>
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public List<string> Equipment { get; set; }
    
    public GameCharacter(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        Equipment = new List<string>();
        
        // Simulate expensive initialization
        Console.WriteLine($"Expensive initialization for {name}...");
        Thread.Sleep(1000); // Simulate time-consuming setup
    }
    
    // Private constructor for cloning
    private GameCharacter(GameCharacter other)
    {
        Name = other.Name;
        Health = other.Health;
        AttackPower = other.AttackPower;
        Equipment = new List<string>(other.Equipment); // Deep copy
        
        Console.WriteLine($"Cloning {other.Name}... (fast!)");
    }
    
    public GameCharacter Clone()
    {
        return new GameCharacter(this);
    }
    
    public void AddEquipment(string item)
    {
        Equipment.Add(item);
    }
    
    public override string ToString()
    {
        return $"{Name}: Health={Health}, Attack={AttackPower}, Equipment=[{string.Join(", ", Equipment)}]";
    }
}

// Usage
class Program
{
    static void Main()
    {
        // Create original character (expensive)
        GameCharacter warrior = new GameCharacter("Warrior", 100, 20);
        warrior.AddEquipment("Sword");
        warrior.AddEquipment("Shield");
        
        Console.WriteLine("Original: " + warrior);
        
        // Clone characters (fast)
        GameCharacter warrior2 = warrior.Clone();
        warrior2.Name = "Elite Warrior";
        warrior2.Health = 150;
        warrior2.AddEquipment("Magic Armor");
        
        GameCharacter warrior3 = warrior.Clone();
        warrior3.Name = "Rookie Warrior";
        warrior3.Health = 75;
        
        Console.WriteLine("Clone 1: " + warrior2);
        Console.WriteLine("Clone 2: " + warrior3);
    }
}
```

---

## Structural Patterns

Structural patterns deal with object composition, helping to ensure that if one part changes, the entire structure doesn't need to change.

### 6. Adapter Pattern

**Problem it solves:**
In software development, you frequently encounter situations where you need to integrate components, libraries, or systems that have incompatible interfaces. This commonly occurs when working with third-party libraries, legacy systems, or when different parts of a system were developed independently with different interface designs. The fundamental issue is that while two classes might provide similar functionality, they expose this functionality through different method signatures, parameter types, or calling conventions. Without a solution, you would need to modify existing code to accommodate these differences, which is often impractical, risky, or impossible (especially with third-party or legacy code). The traditional approach might involve writing wrapper functions throughout your codebase or modifying existing classes, both of which create maintenance nightmares and violate the open-closed principle. The Adapter pattern elegantly solves this by creating a wrapper class that translates calls from one interface to another, allowing incompatible classes to work together without modifying their existing code. This pattern acts as a bridge between your existing code and the incompatible interface, converting method calls, data formats, and protocols as needed.

**When to use:**
- When you want to use an existing class with an incompatible interface
- When you need to create a reusable class that cooperates with unrelated classes
- When integrating third-party libraries with different interfaces

**Real-world example:** Using a third-party payment gateway that has a different interface than what your e-commerce system expects, or connecting a legacy system to a modern application.

**Code Example:**
```csharp
// Target interface (what our application expects)
public interface IMediaPlayer
{
    void Play(string audioType, string fileName);
}

// Adaptee classes (third-party classes with different interfaces)
public class Mp3Player
{
    public void PlayMp3(string fileName)
    {
        Console.WriteLine($"Playing MP3 file: {fileName}");
    }
}

public class Mp4Player
{
    public void PlayMp4(string fileName)
    {
        Console.WriteLine($"Playing MP4 file: {fileName}");
    }
}

public class VlcPlayer
{
    public void PlayVlc(string fileName)
    {
        Console.WriteLine($"Playing VLC file: {fileName}");
    }
}

// Adapter
public class MediaAdapter : IMediaPlayer
{
    private Mp3Player _mp3Player;
    private Mp4Player _mp4Player;
    private VlcPlayer _vlcPlayer;
    
    public MediaAdapter(string audioType)
    {
        switch (audioType.ToLower())
        {
            case "mp3":
                _mp3Player = new Mp3Player();
                break;
            case "mp4":
                _mp4Player = new Mp4Player();
                break;
            case "vlc":
                _vlcPlayer = new VlcPlayer();
                break;
        }
    }
    
    public void Play(string audioType, string fileName)
    {
        switch (audioType.ToLower())
        {
            case "mp3":
                _mp3Player?.PlayMp3(fileName);
                break;
            case "mp4":
                _mp4Player?.PlayMp4(fileName);
                break;
            case "vlc":
                _vlcPlayer?.PlayVlc(fileName);
                break;
            default:
                Console.WriteLine($"Invalid media. {audioType} format not supported");
                break;
        }
    }
}

// Client
public class AudioPlayer : IMediaPlayer
{
    private MediaAdapter _mediaAdapter;
    
    public void Play(string audioType, string fileName)
    {
        if (audioType.ToLower() == "mp3")
        {
            Console.WriteLine($"Playing MP3 file: {fileName}");
        }
        else
        {
            _mediaAdapter = new MediaAdapter(audioType);
            _mediaAdapter.Play(audioType, fileName);
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        AudioPlayer audioPlayer = new AudioPlayer();
        
        audioPlayer.Play("mp3", "song.mp3");
        audioPlayer.Play("mp4", "video.mp4");
        audioPlayer.Play("vlc", "movie.vlc");
        audioPlayer.Play("avi", "video.avi"); // Unsupported format
    }
}
```

### 7. Bridge Pattern

**Problem it solves:**
When designing class hierarchies, you sometimes need to extend functionality in multiple independent dimensions, which can lead to a combinatorial explosion of subclasses. For example, if you have shapes that can be drawn in different colors and using different rendering engines, a traditional inheritance approach would require creating separate classes for every combination: RedCircleDirectXRenderer, BlueCircleOpenGLRenderer, RedRectangleDirectXRenderer, and so on. This approach becomes unmanageable as the number of dimensions increases, leading to a massive number of classes that are difficult to maintain and extend. Additionally, this tight coupling between abstraction (what the object does) and implementation (how it does it) makes it difficult to change either aspect independently. The Bridge pattern addresses this problem by separating the abstraction from its implementation, allowing both to vary independently. Instead of having a single inheritance hierarchy that tries to capture all possible combinations, you create two separate hierarchies: one for the abstraction and one for the implementation, connected by a bridge. This approach allows you to add new abstractions or implementations without affecting existing code and significantly reduces the number of classes needed.

**When to use:**
- When you want to avoid permanent binding between abstraction and implementation
- When you need to share implementation among multiple objects
- When you want to extend classes in two independent dimensions

**Real-world example:** A drawing application where shapes (circles, rectangles) can be drawn using different rendering engines (DirectX, OpenGL) without the shapes knowing about the specific rendering implementation.

**Code Example:**
```csharp
// Implementation interface
public interface IRenderer
{
    void RenderCircle(double radius);
    void RenderRectangle(double width, double height);
}

// Concrete implementations
public class DirectXRenderer : IRenderer
{
    public void RenderCircle(double radius)
    {
        Console.WriteLine($"DirectX: Drawing circle with radius {radius}");
    }
    
    public void RenderRectangle(double width, double height)
    {
        Console.WriteLine($"DirectX: Drawing rectangle {width}x{height}");
    }
}

public class OpenGLRenderer : IRenderer
{
    public void RenderCircle(double radius)
    {
        Console.WriteLine($"OpenGL: Rendering circle with radius {radius}");
    }
    
    public void RenderRectangle(double width, double height)
    {
        Console.WriteLine($"OpenGL: Rendering rectangle {width}x{height}");
    }
}

// Abstraction
public abstract class Shape
{
    protected IRenderer _renderer;
    
    protected Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }
    
    public abstract void Draw();
}

// Refined abstractions
public class Circle : Shape
{
    private double _radius;
    
    public Circle(double radius, IRenderer renderer) : base(renderer)
    {
        _radius = radius;
    }
    
    public override void Draw()
    {
        _renderer.RenderCircle(_radius);
    }
}

public class Rectangle : Shape
{
    private double _width;
    private double _height;
    
    public Rectangle(double width, double height, IRenderer renderer) : base(renderer)
    {
        _width = width;
        _height = height;
    }
    
    public override void Draw()
    {
        _renderer.RenderRectangle(_width, _height);
    }
}

// Usage
class Program
{
    static void Main()
    {
        IRenderer directXRenderer = new DirectXRenderer();
        IRenderer openGLRenderer = new OpenGLRenderer();
        
        Shape circle1 = new Circle(5.0, directXRenderer);
        Shape circle2 = new Circle(3.0, openGLRenderer);
        Shape rectangle1 = new Rectangle(10.0, 8.0, directXRenderer);
        Shape rectangle2 = new Rectangle(15.0, 12.0, openGLRenderer);
        
        circle1.Draw();
        circle2.Draw();
        rectangle1.Draw();
        rectangle2.Draw();
    }
}
```

### 8. Composite Pattern

**Problem it solves:**
Many applications need to work with hierarchical or tree-like structures where individual objects and groups of objects should be treated uniformly. The challenge arises when client code needs to interact with both simple objects (leaves) and complex objects (composites containing other objects) differently, leading to complex conditional logic throughout the codebase. For example, in a file system, you might need to calculate the total size of both individual files and entire directories, but the logic for handling files versus directories is different. Without a unified approach, client code becomes cluttered with type-checking and different handling logic for different object types. This problem becomes more complex in nested structures where composites can contain other composites, requiring recursive traversal logic scattered throughout the application. The Composite pattern solves this by defining a common interface for both simple and complex objects, allowing client code to treat individual objects and compositions of objects uniformly. This eliminates the need for client code to distinguish between simple and composite objects, simplifying the codebase and making it easier to add new types of objects to the hierarchy.

**When to use:**
- When you need to represent hierarchical structures of objects
- When you want clients to ignore the difference between individual objects and compositions
- When working with tree-like structures

**Real-world example:** A file system where files and folders are treated uniformly, or a graphical user interface where windows can contain other windows, buttons, and controls in a hierarchical manner.

**Code Example:**
```csharp
// Component interface
public interface IFileSystemItem
{
    string Name { get; }
    long GetSize();
    void Display(int indent = 0);
}

// Leaf
public class File : IFileSystemItem
{
    public string Name { get; private set; }
    private long _size;
    
    public File(string name, long size)
    {
        Name = name;
        _size = size;
    }
    
    public long GetSize()
    {
        return _size;
    }
    
    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}- {Name} ({_size} bytes)");
    }
}

// Composite
public class Directory : IFileSystemItem
{
    public string Name { get; private set; }
    private List<IFileSystemItem> _items = new List<IFileSystemItem>();
    
    public Directory(string name)
    {
        Name = name;
    }
    
    public void Add(IFileSystemItem item)
    {
        _items.Add(item);
    }
    
    public void Remove(IFileSystemItem item)
    {
        _items.Remove(item);
    }
    
    public long GetSize()
    {
        return _items.Sum(item => item.GetSize());
    }
    
    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ {Name}/");
        foreach (var item in _items)
        {
            item.Display(indent + 2);
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        // Create files
        File file1 = new File("document.txt", 1024);
        File file2 = new File("image.jpg", 2048);
        File file3 = new File("video.mp4", 5120);
        File file4 = new File("readme.md", 512);
        
        // Create directories
        Directory documentsDir = new Directory("Documents");
        Directory mediaDir = new Directory("Media");
        Directory rootDir = new Directory("Root");
        
        // Build hierarchy
        documentsDir.Add(file1);
        documentsDir.Add(file4);
        
        mediaDir.Add(file2);
        mediaDir.Add(file3);
        
        rootDir.Add(documentsDir);
        rootDir.Add(mediaDir);
        
        // Display structure
        rootDir.Display();
        
        // Calculate total size
        Console.WriteLine($"\nTotal size: {rootDir.GetSize()} bytes");
    }
}
```

### 9. Decorator Pattern

**Problem it solves:**
Traditional inheritance has limitations when you need to add functionality to objects dynamically or when you want to combine multiple features in various ways. Creating subclasses for every possible combination of features leads to class explosion and rigid designs. For instance, if you have a basic text class and want to add features like bold, italic, underline, and different colors, creating subclasses for every combination (BoldText, ItalicText, BoldItalicText, BoldItalicUnderlineText, etc.) becomes impractical. Moreover, these combinations need to be determined at compile time, making it impossible to add or remove features dynamically based on user preferences or runtime conditions. The Decorator pattern addresses this by allowing you to wrap objects with decorator objects that add new behavior without altering the original object's structure. Multiple decorators can be stacked on top of each other, each adding its own functionality while maintaining the same interface as the original object. This approach provides tremendous flexibility, allowing you to create any combination of features at runtime while keeping individual decorators simple and focused on a single responsibility.

**When to use:**
- When you want to add responsibilities to objects without subclassing
- When extension by subclassing is impractical or impossible
- When you need to add or remove functionality at runtime

**Real-world example:** Adding features to a text editor like bold, italic, underline formatting, or adding toppings to a pizza order where each topping adds cost and functionality.

**Code Example:**

```csharp
// Component interface
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete component
public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple coffee";
    }

    public double GetCost()
    {
        return 2.0;
    }
}

// Base decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return _coffee.GetCost();
    }
}

// Concrete decorators
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", milk";
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 0.5;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", sugar";
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 0.3;
    }
}

public class WhipDecorator : CoffeeDecorator
{
    public WhipDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", whip";
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 0.7;
    }
}

// Usage
class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add milk
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add sugar
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add whip
        coffee = new WhipDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");
    }
}
```

### 10. Facade Pattern

**Problem it solves:**
Complex subsystems often expose many interdependent classes and interfaces that clients need to interact with, creating tight coupling and making the subsystem difficult to use correctly. When client code needs to perform common operations, it often requires knowledge of multiple classes, their relationships, and the correct sequence of method calls. This complexity makes the system error-prone, as clients might miss important steps, call methods in the wrong order, or fail to handle edge cases properly. Additionally, if the subsystem's internal structure changes, all client code that directly interacts with it needs to be updated. For example, to play a movie, a client might need to interact with file readers, codecs, audio systems, video renderers, and subtitle processors, each requiring specific initialization and configuration. The Facade pattern solves this by providing a simplified, unified interface that hides the complexity of the subsystem. The facade handles all the intricate interactions between subsystem components and presents a clean, easy-to-use interface to clients. This reduces coupling, makes the subsystem easier to use, and provides a buffer against changes in the subsystem's internal structure.

**When to use:**
- When you want to provide a simple interface to a complex subsystem
- When there are many dependencies between clients and implementation classes
- When you want to layer your subsystems

**Real-world example:** A home entertainment system controller that provides simple buttons to control multiple devices (TV, sound system, DVD player, lights) with a single interface, hiding the complexity of individual device controls.

**Code Example:**

```csharp
// Subsystem classes
public class DVDPlayer
{
    public void On() => Console.WriteLine("DVD Player is on");
    public void Play(string movie) => Console.WriteLine($"Playing movie: {movie}");
    public void Stop() => Console.WriteLine("DVD Player stopped");
    public void Off() => Console.WriteLine("DVD Player is off");
}

public class Projector
{
    public void On() => Console.WriteLine("Projector is on");
    public void SetInput(string input) => Console.WriteLine($"Projector input set to {input}");
    public void WideScreenMode() => Console.WriteLine("Projector in widescreen mode");
    public void Off() => Console.WriteLine("Projector is off");
}

public class SoundSystem
{
    public void On() => Console.WriteLine("Sound System is on");
    public void SetVolume(int volume) => Console.WriteLine($"Sound System volume set to {volume}");
    public void SetSurround() => Console.WriteLine("Sound System set to surround sound");
    public void Off() => Console.WriteLine("Sound System is off");
}

public class Lights
{
    public void Dim(int level) => Console.WriteLine($"Lights dimmed to {level}%");
    public void On() => Console.WriteLine("Lights are on");
}

// Facade
public class HomeTheaterFacade
{
    private DVDPlayer _dvdPlayer;
    private Projector _projector;
    private SoundSystem _soundSystem;
    private Lights _lights;

    public HomeTheaterFacade(DVDPlayer dvdPlayer, Projector projector, 
                           SoundSystem soundSystem, Lights lights)
    {
        _dvdPlayer = dvdPlayer;
        _projector = projector;
        _soundSystem = soundSystem;
        _lights = lights;
    }

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Get ready to watch a movie...");
        _lights.Dim(10);
        _projector.On();
        _projector.WideScreenMode();
        _soundSystem.On();
        _soundSystem.SetSurround();
        _soundSystem.SetVolume(5);
        _dvdPlayer.On();
        _dvdPlayer.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting movie theater down...");
        _dvdPlayer.Stop();
        _dvdPlayer.Off();
        _soundSystem.Off();
        _projector.Off();
        _lights.On();
    }
}

// Usage
class Program
{
    static void Main()
    {
        var dvdPlayer = new DVDPlayer();
        var projector = new Projector();
        var soundSystem = new SoundSystem();
        var lights = new Lights();

        var homeTheater = new HomeTheaterFacade(dvdPlayer, projector, soundSystem, lights);

        homeTheater.WatchMovie("The Matrix");
        Console.WriteLine();
        homeTheater.EndMovie();
    }
}
```

### 11. Flyweight Pattern

**Problem it solves:**
Applications that need to create large numbers of similar objects can quickly consume excessive amounts of memory, especially when these objects contain duplicate data. For example, in a text editor, each character might be represented as an object containing the character value, font, size, color, and style information. In a large document with thousands of characters, storing all this information separately for each character instance results in enormous memory waste, since many characters share the same font, size, and color properties. Similarly, in games with thousands of bullets, trees, or particles, each object storing its own copy of shared data like sprites, behaviors, or properties leads to memory exhaustion. The traditional approach of creating separate objects for each instance doesn't scale well and can cause performance issues due to memory pressure and increased garbage collection. The Flyweight pattern addresses this by separating intrinsic state (data that can be shared among multiple objects) from extrinsic state (data that is unique to each object instance). Intrinsic state is stored in flyweight objects that are shared among multiple contexts, while extrinsic state is passed to flyweight methods when needed, dramatically reducing memory consumption.

**When to use:**
- When you need to create a large number of similar objects
- When object creation is expensive
- When most object state can be made extrinsic (stored outside the object)

**Real-world example:** A text editor where each character in a document shares font and formatting information, or a game with thousands of bullets that share the same sprite and behavior but have different positions.

**Code Example:**

```csharp
// Flyweight interface
public interface ICharacterFlyweight
{
    void Display(int row, int column, string color, int fontSize);
}

// Concrete flyweight
public class Character : ICharacterFlyweight
{
    private char _symbol; // Intrinsic state
    private string _font; // Intrinsic state

    public Character(char symbol, string font)
    {
        _symbol = symbol;
        _font = font;
    }

    public void Display(int row, int column, string color, int fontSize)
    {
        Console.WriteLine($"Character '{_symbol}' displayed at ({row},{column}) " +
                         $"in {color} color, {_font} font, size {fontSize}");
    }
}

// Flyweight factory
public class CharacterFactory
{
    private Dictionary<string, ICharacterFlyweight> _flyweights = new Dictionary<string, ICharacterFlyweight>();

    public ICharacterFlyweight GetCharacter(char symbol, string font)
    {
        string key = $"{symbol}_{font}";
        
        if (!_flyweights.ContainsKey(key))
        {
            _flyweights[key] = new Character(symbol, font);
            Console.WriteLine($"Creating flyweight for: {key}");
        }
        
        return _flyweights[key];
    }

    public int GetFlyweightCount()
    {
        return _flyweights.Count;
    }
}

// Context class that holds extrinsic state
public class DocumentCharacter
{
    private ICharacterFlyweight _character;
    private int _row; // Extrinsic state
    private int _column; // Extrinsic state
    private string _color; // Extrinsic state
    private int _fontSize; // Extrinsic state

    public DocumentCharacter(ICharacterFlyweight character, int row, int column, string color, int fontSize)
    {
        _character = character;
        _row = row;
        _column = column;
        _color = color;
        _fontSize = fontSize;
    }

    public void Display()
    {
        _character.Display(_row, _column, _color, _fontSize);
    }
}

// Usage
class Program
{
    static void Main()
    {
        var factory = new CharacterFactory();
        var document = new List<DocumentCharacter>();

        // Create many characters - flyweights will be reused
        document.Add(new DocumentCharacter(factory.GetCharacter('H', "Arial"), 0, 0, "Black", 12));
        document.Add(new DocumentCharacter(factory.GetCharacter('e', "Arial"), 0, 1, "Black", 12));
        document.Add(new DocumentCharacter(factory.GetCharacter('l', "Arial"), 0, 2, "Black", 12));
        document.Add(new DocumentCharacter(factory.GetCharacter('l', "Arial"), 0, 3, "Black", 12));
        document.Add(new DocumentCharacter(factory.GetCharacter('o', "Arial"), 0, 4, "Black", 12));
        document.Add(new DocumentCharacter(factory.GetCharacter('H', "Times"), 1, 0, "Red", 14));
        document.Add(new DocumentCharacter(factory.GetCharacter('i', "Arial"), 1, 1, "Blue", 10));

        // Display all characters
        foreach (var character in document)
        {
            character.Display();
        }

        Console.WriteLine($"\nTotal flyweights created: {factory.GetFlyweightCount()}");
        Console.WriteLine($"Total characters in document: {document.Count}");
    }
}
```

### 12. Proxy Pattern

**Problem it solves:**
Direct access to objects is not always desirable or possible due to various concerns such as security, performance, location, or resource management. Sometimes objects are expensive to create or maintain, located on remote systems, require special access permissions, or need additional processing before or after method calls. For instance, loading large images or videos immediately when they're referenced can slow down application startup, even if these resources are never actually displayed. Similarly, accessing remote services directly without any intermediary can lead to performance issues, security vulnerabilities, or lack of proper error handling. The traditional approach of direct object access doesn't provide opportunities to add these cross-cutting concerns without modifying the original object or cluttering client code with additional logic. The Proxy pattern solves this by providing a surrogate or placeholder object that controls access to the real object. The proxy implements the same interface as the real object but can add functionality such as lazy loading, access control, caching, logging, or remote communication. This allows for transparent enhancement of object access without changing client code or the original object's implementation.

**When to use:**
- When you need to control access to an object
- When you want to add functionality before or after accessing an object
- When you need lazy initialization of expensive objects

**Real-world example:** A virtual proxy that loads large images only when they're actually displayed, or a security proxy that checks permissions before allowing access to sensitive operations.

**Code Example:**

```csharp
// Subject interface
public interface IImage
{
    void Display();
    string GetInfo();
}

// Real subject
public class RealImage : IImage
{
    private string _filename;
    private byte[] _imageData;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadImageFromDisk();
    }

    private void LoadImageFromDisk()
    {
        Console.WriteLine($"Loading image from disk: {_filename}");
        // Simulate expensive loading operation
        Thread.Sleep(1000);
        _imageData = new byte[1024]; // Simulate image data
        Console.WriteLine($"Image {_filename} loaded successfully");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {_filename}");
    }

    public string GetInfo()
    {
        return $"Image: {_filename}, Size: {_imageData.Length} bytes";
    }
}

// Proxy
public class ImageProxy : IImage
{
    private string _filename;
    private RealImage _realImage;
    private DateTime _lastAccessed;

    public ImageProxy(string filename)
    {
        _filename = filename;
    }

    public void Display()
    {
        // Lazy loading - create real object only when needed
        if (_realImage == null)
        {
            _realImage = new RealImage(_filename);
        }
        
        _lastAccessed = DateTime.Now;
        _realImage.Display();
    }

    public string GetInfo()
    {
        if (_realImage == null)
        {
            return $"Image proxy for: {_filename} (not loaded yet)";
        }
        
        return _realImage.GetInfo() + $", Last accessed: {_lastAccessed}";
    }
}

// Security Proxy example
public interface IBankAccount
{
    void Withdraw(decimal amount);
    void Deposit(decimal amount);
    decimal GetBalance();
}

public class BankAccount : IBankAccount
{
    private decimal _balance;
    private string _accountNumber;

    public BankAccount(string accountNumber, decimal initialBalance)
    {
        _accountNumber = accountNumber;
        _balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrew ${amount}. New balance: ${_balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        Console.WriteLine($"Deposited ${amount}. New balance: ${_balance}");
    }

    public decimal GetBalance()
    {
        return _balance;
    }
}

public class SecureBankAccountProxy : IBankAccount
{
    private BankAccount _realAccount;
    private string _userRole;

    public SecureBankAccountProxy(BankAccount account, string userRole)
    {
        _realAccount = account;
        _userRole = userRole;
    }

    public void Withdraw(decimal amount)
    {
        if (HasPermission("WITHDRAW"))
        {
            _realAccount.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Access denied: Insufficient permissions for withdrawal");
        }
    }

    public void Deposit(decimal amount)
    {
        if (HasPermission("DEPOSIT"))
        {
            _realAccount.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Access denied: Insufficient permissions for deposit");
        }
    }

    public decimal GetBalance()
    {
        if (HasPermission("VIEW_BALANCE"))
        {
            return _realAccount.GetBalance();
        }
        else
        {
            Console.WriteLine("Access denied: Insufficient permissions to view balance");
            return 0;
        }
    }

    private bool HasPermission(string operation)
    {
        // Simple permission check
        return _userRole == "ADMIN" || 
               (_userRole == "USER" && (operation == "VIEW_BALANCE" || operation == "DEPOSIT"));
    }
}

// Usage
class Program
{
    static void Main()
    {
        // Virtual Proxy example
        Console.WriteLine("=== Virtual Proxy Example ===");
        IImage image1 = new ImageProxy("large_image.jpg");
        IImage image2 = new ImageProxy("another_image.png");

        Console.WriteLine("Images created (but not loaded yet)");
        Console.WriteLine(image1.GetInfo());
        Console.WriteLine(image2.GetInfo());

        Console.WriteLine("\nDisplaying first image:");
        image1.Display(); // This will trigger loading
        
        Console.WriteLine(image1.GetInfo());

        Console.WriteLine("\n=== Security Proxy Example ===");
        var account = new BankAccount("12345", 1000);
        var userProxy = new SecureBankAccountProxy(account, "USER");
        var adminProxy = new SecureBankAccountProxy(account, "ADMIN");

        Console.WriteLine("User operations:");
        userProxy.Deposit(100);
        Console.WriteLine($"Balance: ${userProxy.GetBalance()}");
        userProxy.Withdraw(50); // Should be denied

        Console.WriteLine("\nAdmin operations:");
        adminProxy.Withdraw(50); // Should be allowed
        Console.WriteLine($"Balance: ${adminProxy.GetBalance()}");
    }
}
```

---

## Behavioral Patterns

Behavioral patterns focus on communication between objects and the assignment of responsibilities between objects.

### 13. Chain of Responsibility Pattern

**Problem it solves:**
In many applications, requests need to be processed by different handlers depending on the request type, content, or current system state, but the specific handler for a given request isn't known in advance. The traditional approach often involves creating complex conditional logic or switch statements that tightly couple the request sender to specific handlers, making the system rigid and difficult to extend. When new handler types are added or the processing order changes, multiple parts of the code need modification. Additionally, you might want to allow multiple handlers to process the same request, or have fallback handlers when primary handlers can't process a request. The coupling between request senders and receivers makes it difficult to configure handler chains dynamically or reuse handlers in different contexts. The Chain of Responsibility pattern addresses this by establishing a chain of potential handlers, each with the opportunity to process the request or pass it to the next handler in the chain. This decouples the sender from receivers, allowing you to configure handler chains dynamically, add new handlers without modifying existing code, and create flexible processing pipelines where the actual handler is determined at runtime.

**When to use:**
- When more than one object can handle a request
- When you want to issue a request without knowing which object will handle it
- When the set of handlers should be specified dynamically

**Real-world example:** A help desk system where support requests are passed through different levels (Level 1, Level 2, Manager) until someone can resolve the issue, or an approval workflow where different managers approve expenses based on amount limits.

**Code Example:**

```csharp
// Handler interface
public abstract class ExpenseHandler
{
    protected ExpenseHandler _nextHandler;

    public void SetNext(ExpenseHandler handler)
    {
        _nextHandler = handler;
    }

    public abstract void HandleRequest(ExpenseRequest request);
}

// Request class
public class ExpenseRequest
{
    public string EmployeeName { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public ExpenseRequest(string employeeName, decimal amount, string description, string type)
    {
        EmployeeName = employeeName;
        Amount = amount;
        Description = description;
        Type = type;
    }
}

// Concrete handlers
public class TeamLeadHandler : ExpenseHandler
{
    public override void HandleRequest(ExpenseRequest request)
    {
        if (request.Amount <= 1000)
        {
            Console.WriteLine($"Team Lead approved expense of ${request.Amount} for {request.EmployeeName}");
            Console.WriteLine($"Description: {request.Description}");
        }
        else if (_nextHandler != null)
        {
            Console.WriteLine($"Team Lead cannot approve ${request.Amount}. Forwarding to next handler.");
            _nextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine($"No handler available for expense of ${request.Amount}");
        }
    }
}

public class ManagerHandler : ExpenseHandler
{
    public override void HandleRequest(ExpenseRequest request)
    {
        if (request.Amount <= 5000)
        {
            Console.WriteLine($"Manager approved expense of ${request.Amount} for {request.EmployeeName}");
            Console.WriteLine($"Description: {request.Description}");
        }
        else if (_nextHandler != null)
        {
            Console.WriteLine($"Manager cannot approve ${request.Amount}. Forwarding to next handler.");
            _nextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine($"No handler available for expense of ${request.Amount}");
        }
    }
}

public class DirectorHandler : ExpenseHandler
{
    public override void HandleRequest(ExpenseRequest request)
    {
        if (request.Amount <= 20000)
        {
            Console.WriteLine($"Director approved expense of ${request.Amount} for {request.EmployeeName}");
            Console.WriteLine($"Description: {request.Description}");
        }
        else if (_nextHandler != null)
        {
            Console.WriteLine($"Director cannot approve ${request.Amount}. Forwarding to next handler.");
            _nextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine($"Expense of ${request.Amount} exceeds all approval limits. Request denied.");
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        // Create handlers
        var teamLead = new TeamLeadHandler();
        var manager = new ManagerHandler();
        var director = new DirectorHandler();

        // Set up chain
        teamLead.SetNext(manager);
        manager.SetNext(director);

        // Create expense requests
        var requests = new List<ExpenseRequest>
        {
            new ExpenseRequest("John Doe", 500, "Office supplies", "Equipment"),
            new ExpenseRequest("Jane Smith", 3000, "Conference attendance", "Training"),
            new ExpenseRequest("Bob Johnson", 15000, "New server hardware", "Equipment"),
            new ExpenseRequest("Alice Brown", 25000, "Office renovation", "Infrastructure")
        };

        // Process requests
        foreach (var request in requests)
        {
            Console.WriteLine($"\n--- Processing expense request ---");
            teamLead.HandleRequest(request);
        }
    }
}
```

### 14. Command Pattern

**Problem it solves:**
Traditional approaches to handling user actions or system operations often result in tight coupling between the user interface (or request initiator) and the business logic that performs the actual work. This makes it difficult to implement features like undo/redo functionality, operation queuing, logging, or macro recording because the operations are executed immediately and their details are scattered throughout the codebase. For example, in a text editor, when a user performs actions like typing, deleting, or formatting, these operations are typically executed directly, making it impossible to reverse them later or replay them in different contexts. Similarly, when building systems that need to queue operations, execute them later, or execute them on different objects, the tight coupling between requesters and receivers creates significant challenges. The Command pattern solves this by encapsulating requests as objects, complete with all the information needed to perform the operation. This transformation allows operations to be stored, queued, logged, undone, or executed on different objects. Commands can be combined into macro commands, scheduled for later execution, or transmitted across network boundaries, providing tremendous flexibility in how operations are handled.

**When to use:**
- When you want to parameterize objects with operations
- When you need to queue, log, or support undo operations
- When you want to structure a system around high-level operations built on primitive operations

**Real-world example:** A text editor's undo/redo functionality where each operation (typing, deleting, formatting) is encapsulated as a command that can be undone, or a remote control where each button press is a command sent to different devices.

```csharp
// Command interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver - the object that performs the actual work
public class TextEditor
{
    private StringBuilder _content = new StringBuilder();
    
    public void InsertText(string text, int position)
    {
        _content.Insert(position, text);
        Console.WriteLine($"Inserted '{text}' at position {position}");
    }
    
    public void DeleteText(int position, int length)
    {
        _content.Remove(position, length);
        Console.WriteLine($"Deleted {length} characters at position {position}");
    }
    
    public string GetContent() => _content.ToString();
}

// Concrete Commands
public class InsertTextCommand : ICommand
{
    private TextEditor _editor;
    private string _text;
    private int _position;
    
    public InsertTextCommand(TextEditor editor, string text, int position)
    {
        _editor = editor;
        _text = text;
        _position = position;
    }
    
    public void Execute()
    {
        _editor.InsertText(_text, _position);
    }
    
    public void Undo()
    {
        _editor.DeleteText(_position, _text.Length);
    }
}

public class DeleteTextCommand : ICommand
{
    private TextEditor _editor;
    private int _position;
    private int _length;
    private string _deletedText;
    
    public DeleteTextCommand(TextEditor editor, int position, int length)
    {
        _editor = editor;
        _position = position;
        _length = length;
        // Store the text that will be deleted
        _deletedText = editor.GetContent().Substring(position, length);
    }
    
    public void Execute()
    {
        _editor.DeleteText(_position, _length);
    }
    
    public void Undo()
    {
        _editor.InsertText(_deletedText, _position);
    }
}

// Invoker - manages commands and provides undo/redo functionality
public class CommandManager
{
    private Stack<ICommand> _undoStack = new Stack<ICommand>();
    private Stack<ICommand> _redoStack = new Stack<ICommand>();
    
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear(); // Clear redo stack when new command is executed
    }
    
    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
        }
    }
    
    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var commandManager = new CommandManager();
        
        // Execute commands
        commandManager.ExecuteCommand(new InsertTextCommand(editor, "Hello", 0));
        commandManager.ExecuteCommand(new InsertTextCommand(editor, " World", 5));
        
        Console.WriteLine($"Content: {editor.GetContent()}");
        
        // Undo operations
        commandManager.Undo();
        Console.WriteLine($"After undo: {editor.GetContent()}");
        
        commandManager.Redo();
        Console.WriteLine($"After redo: {editor.GetContent()}");
    }
}
```

### 15. Interpreter Pattern

**Problem it solves:**
Many applications need to process structured input that follows specific grammar rules, such as mathematical expressions, search queries, configuration files, or domain-specific languages. The traditional approach often involves writing complex parsing logic with lengthy switch statements or nested conditionals that are difficult to understand, maintain, and extend. When the grammar rules change or new language features are added, the parsing logic becomes increasingly complex and error-prone. Additionally, the parsing logic is often intertwined with the execution logic, making it difficult to reuse the parser for different purposes or to optimize the interpretation process. The Interpreter pattern addresses this by representing each grammar rule as a separate class, creating a clean separation between different language constructs. Each class is responsible for interpreting its specific part of the language, and complex expressions are built by composing these simple interpreters. This approach makes the grammar explicit in the code structure, makes it easy to extend the language by adding new interpreter classes, and allows for easy modification of existing language constructs without affecting others.

**When to use:**
- When you have a simple language to interpret
- When the grammar is simple and efficiency isn't critical
- When you want to represent grammar rules as classes

**Real-world example:** A calculator application that interprets mathematical expressions, or a search engine that interprets query syntax with operators like AND, OR, and NOT.

```csharp
// Abstract Expression
public abstract class Expression
{
    public abstract int Interpret(Dictionary<string, int> context);
}

// Terminal Expression - represents variables
public class VariableExpression : Expression
{
    private string _name;
    
    public VariableExpression(string name)
    {
        _name = name;
    }
    
    public override int Interpret(Dictionary<string, int> context)
    {
        return context.ContainsKey(_name) ? context[_name] : 0;
    }
}

// Terminal Expression - represents numbers
public class NumberExpression : Expression
{
    private int _number;
    
    public NumberExpression(int number)
    {
        _number = number;
    }
    
    public override int Interpret(Dictionary<string, int> context)
    {
        return _number;
    }
}

// Non-terminal Expression - represents addition
public class AddExpression : Expression
{
    private Expression _leftExpression;
    private Expression _rightExpression;
    
    public AddExpression(Expression left, Expression right)
    {
        _leftExpression = left;
        _rightExpression = right;
    }
    
    public override int Interpret(Dictionary<string, int> context)
    {
        return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
    }
}

// Non-terminal Expression - represents subtraction
public class SubtractExpression : Expression
{
    private Expression _leftExpression;
    private Expression _rightExpression;
    
    public SubtractExpression(Expression left, Expression right)
    {
        _leftExpression = left;
        _rightExpression = right;
    }
    
    public override int Interpret(Dictionary<string, int> context)
    {
        return _leftExpression.Interpret(context) - _rightExpression.Interpret(context);
    }
}

// Usage
class Program
{
    static void Main()
    {
        // Build expression: x + y - 10
        var context = new Dictionary<string, int>
        {
            {"x", 5},
            {"y", 10}
        };
        
        var expression = new SubtractExpression(
            new AddExpression(
                new VariableExpression("x"),
                new VariableExpression("y")
            ),
            new NumberExpression(10)
        );
        
        int result = expression.Interpret(context);
        Console.WriteLine($"Result: {result}"); // Output: 5
    }
}
```

### 16. Iterator Pattern

**Problem it solves:**
Collections and data structures can be implemented in many different ways (arrays, linked lists, trees, hash tables), each with their own optimal traversal methods. Client code that needs to access elements in these collections often becomes tightly coupled to the specific collection implementation, making it difficult to switch between different collection types or traverse the same collection in different ways. For example, traversing a tree structure requires different logic than traversing an array, and client code needs to understand these implementation details. Additionally, when multiple clients need to traverse the same collection simultaneously, maintaining separate traversal states becomes complex and error-prone. The traditional approach of exposing internal collection structure or providing collection-specific traversal methods breaks encapsulation and creates dependencies that make code brittle and hard to maintain. The Iterator pattern solves this by providing a standard interface for traversing collections regardless of their internal implementation. Iterators encapsulate the traversal logic and maintain their own state, allowing multiple iterators to work on the same collection independently while hiding the collection's internal structure from client code.

**When to use:**
- When you want to access a collection's elements without exposing its internal structure
- When you need multiple ways to traverse the same collection
- When you want to provide a uniform interface for traversing different collection types

**Real-world example:** Iterating through items in a playlist, browsing through photos in a gallery, or traversing nodes in a tree structure without knowing the specific implementation details.

```csharp
// Iterator interface
public interface IIterator<T>
{
    bool HasNext();
    T Next();
    void Reset();
}

// Aggregate interface
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// Concrete Iterator
public class BookshelfIterator : IIterator<string>
{
    private Bookshelf _bookshelf;
    private int _index = 0;
    
    public BookshelfIterator(Bookshelf bookshelf)
    {
        _bookshelf = bookshelf;
    }
    
    public bool HasNext()
    {
        return _index < _bookshelf.GetLength();
    }
    
    public string Next()
    {
        if (HasNext())
        {
            return _bookshelf.GetBookAt(_index++);
        }
        throw new InvalidOperationException("No more elements");
    }
    
    public void Reset()
    {
        _index = 0;
    }
}

// Concrete Aggregate
public class Bookshelf : IAggregate<string>
{
    private List<string> _books = new List<string>();
    
    public void AddBook(string book)
    {
        _books.Add(book);
    }
    
    public string GetBookAt(int index)
    {
        return _books[index];
    }
    
    public int GetLength()
    {
        return _books.Count;
    }
    
    public IIterator<string> CreateIterator()
    {
        return new BookshelfIterator(this);
    }
}

// Alternative iterator for reverse traversal
public class ReverseBookshelfIterator : IIterator<string>
{
    private Bookshelf _bookshelf;
    private int _index;
    
    public ReverseBookshelfIterator(Bookshelf bookshelf)
    {
        _bookshelf = bookshelf;
        _index = bookshelf.GetLength() - 1;
    }
    
    public bool HasNext()
    {
        return _index >= 0;
    }
    
    public string Next()
    {
        if (HasNext())
        {
            return _bookshelf.GetBookAt(_index--);
        }
        throw new InvalidOperationException("No more elements");
    }
    
    public void Reset()
    {
        _index = _bookshelf.GetLength() - 1;
    }
}

// Usage
class Program
{
    static void Main()
    {
        var bookshelf = new Bookshelf();
        bookshelf.AddBook("Design Patterns");
        bookshelf.AddBook("Clean Code");
        bookshelf.AddBook("Refactoring");
        
        // Forward iteration
        var iterator = bookshelf.CreateIterator();
        Console.WriteLine("Forward iteration:");
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
        
        // Reverse iteration
        var reverseIterator = new ReverseBookshelfIterator(bookshelf);
        Console.WriteLine("\nReverse iteration:");
        while (reverseIterator.HasNext())
        {
            Console.WriteLine(reverseIterator.Next());
        }
    }
}
```

### 17. Mediator Pattern

**Problem it solves:**
In complex systems, objects often need to communicate and coordinate with each other, but direct communication creates tight coupling that makes the system difficult to understand, maintain, and extend. When objects reference each other directly, changes to one object can have cascading effects throughout the system, and the interaction logic becomes scattered across multiple classes. For example, in a user interface, when a button is clicked, it might need to update text fields, enable or disable other buttons, refresh lists, and validate form data. If the button directly references all these components, the system becomes a tangled web of interdependencies. Adding new components or changing interaction behavior requires modifying multiple existing classes, violating the open-closed principle and increasing the risk of introducing bugs. The Mediator pattern addresses this by centralizing communication logic in a mediator object that coordinates interactions between components. Instead of objects communicating directly with each other, they communicate through the mediator, which knows how to route messages and coordinate complex interactions. This approach reduces coupling, centralizes interaction logic, and makes the system easier to understand and modify.

**When to use:**
- When objects communicate in complex but well-defined ways
- When reusing an object is difficult because it refers to many other objects
- When behavior distributed between several classes should be customizable without lots of subclassing

**Real-world example:** An air traffic control system where pilots don't communicate directly with each other but through the control tower, or a chat room where users send messages through a central mediator rather than directly to each other.

```csharp
// Mediator interface
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
    void RemoveUser(User user);
}

// Concrete Mediator
public class ChatRoom : IChatMediator
{
    private List<User> _users = new List<User>();
    
    public void AddUser(User user)
    {
        _users.Add(user);
        user.SetMediator(this);
        Console.WriteLine($"{user.Name} joined the chat room");
    }
    
    public void RemoveUser(User user)
    {
        _users.Remove(user);
        Console.WriteLine($"{user.Name} left the chat room");
    }
    
    public void SendMessage(string message, User sender)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm}] {sender.Name}: {message}");
        
        // Send to all users except sender
        foreach (var user in _users.Where(u => u != sender))
        {
            user.Receive(message, sender.Name);
        }
    }
}

// Colleague base class
public abstract class User
{
    protected IChatMediator _mediator;
    public string Name { get; }
    
    protected User(string name)
    {
        Name = name;
    }
    
    public void SetMediator(IChatMediator mediator)
    {
        _mediator = mediator;
    }
    
    public abstract void Send(string message);
    public abstract void Receive(string message, string senderName);
}

// Concrete Colleagues
public class ConcreteUser : User
{
    public ConcreteUser(string name) : base(name) { }
    
    public override void Send(string message)
    {
        _mediator?.SendMessage(message, this);
    }
    
    public override void Receive(string message, string senderName)
    {
        Console.WriteLine($"  {Name} received: {message} (from {senderName})");
    }
}

// Usage
class Program
{
    static void Main()
    {
        var chatRoom = new ChatRoom();
        
        var alice = new ConcreteUser("Alice");
        var bob = new ConcreteUser("Bob");
        var charlie = new ConcreteUser("Charlie");
        
        chatRoom.AddUser(alice);
        chatRoom.AddUser(bob);
        chatRoom.AddUser(charlie);
        
        alice.Send("Hello everyone!");
        bob.Send("Hi Alice!");
        charlie.Send("Good morning all!");
        
        chatRoom.RemoveUser(bob);
        alice.Send("Bob left the chat");
    }
}
```

### 18. Memento Pattern

**Problem it solves:**
Many applications need to provide undo functionality or save/restore object states, but directly exposing an object's internal state violates encapsulation principles and creates tight coupling between the object and the code that manages its state. Objects often contain private data that should not be accessible to external code, yet this data needs to be captured to restore the object later. The traditional approach might involve making internal state public or providing getter methods for all internal data, which breaks encapsulation and makes the object's interface cluttered with methods that are only used for state management. Additionally, managing multiple saved states and ensuring they remain valid when the object's structure changes becomes complex and error-prone. The naive approach of storing references to objects doesn't work because the object's state continues to change, and deep copying everything is expensive and may not preserve object relationships correctly. The Memento pattern solves this by allowing objects to create snapshots of their internal state without exposing their internal structure. The object itself is responsible for creating and restoring from mementos, maintaining encapsulation while enabling state management functionality.

**When to use:**
- When you need to save and restore an object's state
- When you want to provide undo functionality
- When direct access to an object's state would violate encapsulation

**Real-world example:** A game's saving system that captures the complete game state at checkpoints, or a word processor that saves document states for undo operations while keeping the document's internal structure private.

```csharp
// Memento - stores the internal state
public class DocumentMemento
{
    public string Content { get; }
    public string FontName { get; }
    public int FontSize { get; }
    public DateTime Timestamp { get; }
    
    internal DocumentMemento(string content, string fontName, int fontSize)
    {
        Content = content;
        FontName = fontName;
        FontSize = fontSize;
        Timestamp = DateTime.Now;
    }
}

// Originator - creates and restores from mementos
public class Document
{
    public string Content { get; private set; } = "";
    public string FontName { get; private set; } = "Arial";
    public int FontSize { get; private set; } = 12;
    
    public void Write(string text)
    {
        Content += text;
        Console.WriteLine($"Document content: {Content}");
    }
    
    public void SetFont(string fontName, int fontSize)
    {
        FontName = fontName;
        FontSize = fontSize;
        Console.WriteLine($"Font changed to {FontName}, size {FontSize}");
    }
    
    public DocumentMemento CreateMemento()
    {
        Console.WriteLine("Creating memento...");
        return new DocumentMemento(Content, FontName, FontSize);
    }
    
    public void RestoreFromMemento(DocumentMemento memento)
    {
        Content = memento.Content;
        FontName = memento.FontName;
        FontSize = memento.FontSize;
        Console.WriteLine($"Restored to state from {memento.Timestamp}");
        Console.WriteLine($"Content: {Content}, Font: {FontName}, Size: {FontSize}");
    }
}

// Caretaker - manages mementos
public class DocumentHistory
{
    private Stack<DocumentMemento> _history = new Stack<DocumentMemento>();
    private Document _document;
    
    public DocumentHistory(Document document)
    {
        _document = document;
    }
    
    public void Save()
    {
        var memento = _document.CreateMemento();
        _history.Push(memento);
        Console.WriteLine($"State saved. History count: {_history.Count}");
    }
    
    public void Undo()
    {
        if (_history.Count > 0)
        {
            var memento = _history.Pop();
            _document.RestoreFromMemento(memento);
            Console.WriteLine($"Undo performed. History count: {_history.Count}");
        }
        else
        {
            Console.WriteLine("No more states to undo");
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        var document = new Document();
        var history = new DocumentHistory(document);
        
        // Make changes and save states
        document.Write("Hello ");
        history.Save();
        
        document.Write("World!");
        document.SetFont("Times New Roman", 14);
        history.Save();
        
        document.Write(" How are you?");
        document.SetFont("Courier", 10);
        
        Console.WriteLine("\nCurrent state:");
        Console.WriteLine($"Content: {document.Content}");
        Console.WriteLine($"Font: {document.FontName}, Size: {document.FontSize}");
        
        // Undo changes
        Console.WriteLine("\nPerforming undo operations:");
        history.Undo();
        history.Undo();
    }
}
```

### 19. Observer Pattern

**Problem it solves:**
In many applications, changes to one object need to trigger updates in multiple dependent objects, but you don't want to create tight coupling between the subject and its dependents. The traditional approach often involves the subject knowing about all its dependents and calling their update methods directly, which creates rigid dependencies and makes it difficult to add or remove dependents dynamically. This becomes particularly problematic in systems where the set of dependents can change at runtime, or where dependents are created by different parts of the system. For example, in a model-view architecture, when data changes, multiple views need to be updated, but the data model shouldn't need to know about specific view implementations. Hardcoding these relationships makes the system inflexible and violates the dependency inversion principle. Additionally, when dependents are added or removed frequently, managing these relationships becomes complex and error-prone. The Observer pattern addresses this by establishing a publish-subscribe mechanism where subjects maintain a list of observers and notify them automatically when changes occur. This approach decouples subjects from observers, allows for dynamic registration and removal of observers, and ensures that all interested parties are notified of changes without the subject needing to know their specific details.

**When to use:**
- When changes to one object require updating multiple dependent objects
- When an object should notify others without knowing who they are
- When you want to maintain consistency between related objects

**Real-world example:** A news subscription service where subscribers are automatically notified when new articles are published, or a model-view architecture where multiple views update automatically when the underlying data changes.

```csharp
// Observer interface
public interface IObserver
{
    void Update(string message);
}

// Subject interface
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject
public class NewsAgency : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _news;
    
    public string News
    {
        get => _news;
        set
        {
            _news = value;
            Console.WriteLine($"News Agency: Breaking news - {_news}");
            Notify();
        }
    }
    
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine("Observer attached to news agency");
    }
    
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Observer detached from news agency");
    }
    
    public void Notify()
    {
        Console.WriteLine($"Notifying {_observers.Count} observers...");
        foreach (var observer in _observers)
        {
            observer.Update(_news);
        }
    }
}

// Concrete Observers
public class NewsChannel : IObserver
{
    public string Name { get; }
    
    public NewsChannel(string name)
    {
        Name = name;
    }
    
    public void Update(string message)
    {
        Console.WriteLine($"{Name} received news: {message}");
        Console.WriteLine($"{Name} is broadcasting the news...");
    }
}

public class Newspaper : IObserver
{
    public string Name { get; }
    
    public Newspaper(string name)
    {
        Name = name;
    }
    
    public void Update(string message)
    {
        Console.WriteLine($"{Name} received news: {message}");
        Console.WriteLine($"{Name} is preparing to print the story...");
    }
}

public class OnlinePortal : IObserver
{
    public string Name { get; }
    
    public OnlinePortal(string name)
    {
        Name = name;
    }
    
    public void Update(string message)
    {
        Console.WriteLine($"{Name} received news: {message}");
        Console.WriteLine($"{Name} is updating the website...");
    }
}

// Usage
class Program
{
    static void Main()
    {
        var newsAgency = new NewsAgency();
        
        var cnnChannel = new NewsChannel("CNN");
        var bbcChannel = new NewsChannel("BBC");
        var timesNewspaper = new Newspaper("The Times");
        var newsPortal = new OnlinePortal("News.com");
        
        // Subscribe observers
        newsAgency.Attach(cnnChannel);
        newsAgency.Attach(bbcChannel);
        newsAgency.Attach(timesNewspaper);
        newsAgency.Attach(newsPortal);
        
        // Publish news
        newsAgency.News = "Major earthquake hits California";
        
        Console.WriteLine("\n" + new string('-', 50) + "\n");
        
        // Unsubscribe one observer
        newsAgency.Detach(bbcChannel);
        
        // Publish another news
        newsAgency.News = "New technology breakthrough announced";
    }
}
```

### 20. State Pattern

**Problem it solves:**
Objects that change their behavior based on internal state often end up with complex conditional logic scattered throughout their methods, making the code difficult to understand, maintain, and extend. As the number of states and state-dependent behaviors increases, methods become cluttered with large switch statements or chains of if-else conditions that check the current state and execute different logic accordingly. This approach makes it difficult to add new states or modify state-specific behavior without affecting other parts of the code. Additionally, state transitions can become complex and error-prone when managed through simple variables and conditional logic, especially when certain transitions are only valid from specific states. The code becomes fragile because state-related logic is duplicated across multiple methods, and it's easy to forget to update all relevant places when adding new states or modifying existing ones. The State pattern solves this by encapsulating state-specific behavior in separate state classes and delegating state-dependent operations to the current state object. This approach eliminates conditional logic, makes states and their behaviors explicit, and makes it easy to add new states or modify existing ones without affecting other code.

**When to use:**
- When an object's behavior depends on its state
- When you have large conditional statements that depend on object state
- When state-specific behavior needs to be defined in separate classes

**Real-world example:** A vending machine that behaves differently when it has no money inserted, has money but no selection made, or has money and a selection made, or a media player that behaves differently when stopped, playing, or paused.

```csharp
// State interface
public interface IVendingMachineState
{
    void InsertMoney(VendingMachine machine, decimal amount);
    void SelectProduct(VendingMachine machine, string product);
    void DispenseProduct(VendingMachine machine);
    void RefundMoney(VendingMachine machine);
}

// Context class
public class VendingMachine
{
    private IVendingMachineState _currentState;
    public decimal InsertedAmount { get; set; }
    public string SelectedProduct { get; set; }
    public Dictionary<string, decimal> Products { get; set; }

    public VendingMachine()
    {
        Products = new Dictionary<string, decimal>
        {
            { "Coke", 1.50m },
            { "Chips", 2.00m },
            { "Water", 1.00m }
        };
        _currentState = new IdleState();
    }

    public void SetState(IVendingMachineState state)
    {
        _currentState = state;
    }

    public void InsertMoney(decimal amount) => _currentState.InsertMoney(this, amount);
    public void SelectProduct(string product) => _currentState.SelectProduct(this, product);
    public void DispenseProduct() => _currentState.DispenseProduct(this);
    public void RefundMoney() => _currentState.RefundMoney(this);
}

// Concrete states
public class IdleState : IVendingMachineState
{
    public void InsertMoney(VendingMachine machine, decimal amount)
    {
        machine.InsertedAmount = amount;
        Console.WriteLine($"Money inserted: ${amount}");
        machine.SetState(new MoneyInsertedState());
    }

    public void SelectProduct(VendingMachine machine, string product)
    {
        Console.WriteLine("Please insert money first");
    }

    public void DispenseProduct(VendingMachine machine)
    {
        Console.WriteLine("Please insert money and select product");
    }

    public void RefundMoney(VendingMachine machine)
    {
        Console.WriteLine("No money to refund");
    }
}

public class MoneyInsertedState : IVendingMachineState
{
    public void InsertMoney(VendingMachine machine, decimal amount)
    {
        machine.InsertedAmount += amount;
        Console.WriteLine($"Additional money inserted. Total: ${machine.InsertedAmount}");
    }

    public void SelectProduct(VendingMachine machine, string product)
    {
        if (machine.Products.ContainsKey(product))
        {
            if (machine.InsertedAmount >= machine.Products[product])
            {
                machine.SelectedProduct = product;
                Console.WriteLine($"Product selected: {product}");
                machine.SetState(new ProductSelectedState());
            }
            else
            {
                Console.WriteLine($"Insufficient funds. {product} costs ${machine.Products[product]}");
            }
        }
        else
        {
            Console.WriteLine("Product not available");
        }
    }

    public void DispenseProduct(VendingMachine machine)
    {
        Console.WriteLine("Please select a product first");
    }

    public void RefundMoney(VendingMachine machine)
    {
        Console.WriteLine($"Refunding ${machine.InsertedAmount}");
        machine.InsertedAmount = 0;
        machine.SetState(new IdleState());
    }
}

public class ProductSelectedState : IVendingMachineState
{
    public void InsertMoney(VendingMachine machine, decimal amount)
    {
        machine.InsertedAmount += amount;
        Console.WriteLine($"Additional money inserted. Total: ${machine.InsertedAmount}");
    }

    public void SelectProduct(VendingMachine machine, string product)
    {
        Console.WriteLine($"Product already selected: {machine.SelectedProduct}");
    }

    public void DispenseProduct(VendingMachine machine)
    {
        var productPrice = machine.Products[machine.SelectedProduct];
        var change = machine.InsertedAmount - productPrice;
        
        Console.WriteLine($"Dispensing {machine.SelectedProduct}");
        if (change > 0)
        {
            Console.WriteLine($"Change returned: ${change}");
        }
        
        machine.InsertedAmount = 0;
        machine.SelectedProduct = null;
        machine.SetState(new IdleState());
    }

    public void RefundMoney(VendingMachine machine)
    {
        Console.WriteLine($"Refunding ${machine.InsertedAmount}");
        machine.InsertedAmount = 0;
        machine.SelectedProduct = null;
        machine.SetState(new IdleState());
    }
}

// Usage
var vendingMachine = new VendingMachine();
vendingMachine.InsertMoney(2.00m);
vendingMachine.SelectProduct("Coke");
vendingMachine.DispenseProduct();
```

### 21. Strategy Pattern

**Problem it solves:**
Applications often need to perform the same type of operation but with different algorithms or approaches depending on context, user preferences, or runtime conditions. The traditional approach of using conditional statements to select algorithms creates rigid code that's difficult to extend and maintain. When new algorithms are added, existing code needs to be modified, violating the open-closed principle. Additionally, having all algorithm implementations in a single class violates the single responsibility principle and makes the class difficult to understand and test. For example, a sorting routine might need to use different algorithms based on data size, or a compression utility might need to choose between different compression techniques based on file type or user preferences. Embedding all these algorithms directly in the client code creates a monolithic, inflexible design. The Strategy pattern addresses this by encapsulating each algorithm in its own class and making them interchangeable through a common interface. This allows algorithms to be selected and switched at runtime without modifying client code, makes it easy to add new algorithms, and enables better testing since each algorithm can be tested independently.

**When to use:**
- When you have multiple ways to perform a task
- When you want to choose algorithms at runtime
- When you want to eliminate large conditional statements for algorithm selection

**Real-world example:** A navigation app that can calculate routes using different strategies (fastest route, shortest route, most scenic route), or a payment system that supports different payment methods (credit card, PayPal, bank transfer).

```csharp
// Strategy interface
public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
    bool ValidatePaymentDetails();
}

// Concrete strategies
public class CreditCardPayment : IPaymentStrategy
{
    private string _cardNumber;
    private string _expiryDate;
    private string _cvv;

    public CreditCardPayment(string cardNumber, string expiryDate, string cvv)
    {
        _cardNumber = cardNumber;
        _expiryDate = expiryDate;
        _cvv = cvv;
    }

    public bool ValidatePaymentDetails()
    {
        // Simulate credit card validation
        return !string.IsNullOrEmpty(_cardNumber) && 
               !string.IsNullOrEmpty(_expiryDate) && 
               !string.IsNullOrEmpty(_cvv);
    }

    public void ProcessPayment(decimal amount)
    {
        if (ValidatePaymentDetails())
        {
            Console.WriteLine($"Processing ${amount} payment via Credit Card ending in {_cardNumber.Substring(_cardNumber.Length - 4)}");
            // Simulate payment processing
            Console.WriteLine("Credit card payment processed successfully");
        }
        else
        {
            Console.WriteLine("Invalid credit card details");
        }
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private string _email;
    private string _password;

    public PayPalPayment(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public bool ValidatePaymentDetails()
    {
        return !string.IsNullOrEmpty(_email) && !string.IsNullOrEmpty(_password);
    }

    public void ProcessPayment(decimal amount)
    {
        if (ValidatePaymentDetails())
        {
            Console.WriteLine($"Processing ${amount} payment via PayPal for {_email}");
            // Simulate PayPal API call
            Console.WriteLine("PayPal payment processed successfully");
        }
        else
        {
            Console.WriteLine("Invalid PayPal credentials");
        }
    }
}

public class BankTransferPayment : IPaymentStrategy
{
    private string _accountNumber;
    private string _routingNumber;

    public BankTransferPayment(string accountNumber, string routingNumber)
    {
        _accountNumber = accountNumber;
        _routingNumber = routingNumber;
    }

    public bool ValidatePaymentDetails()
    {
        return !string.IsNullOrEmpty(_accountNumber) && !string.IsNullOrEmpty(_routingNumber);
    }

    public void ProcessPayment(decimal amount)
    {
        if (ValidatePaymentDetails())
        {
            Console.WriteLine($"Processing ${amount} payment via Bank Transfer");
            Console.WriteLine($"Account: ***{_accountNumber.Substring(_accountNumber.Length - 4)}");
            // Simulate bank transfer
            Console.WriteLine("Bank transfer initiated successfully");
        }
        else
        {
            Console.WriteLine("Invalid bank account details");
        }
    }
}

// Context class
public class PaymentProcessor
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        if (_paymentStrategy != null)
        {
            _paymentStrategy.ProcessPayment(amount);
        }
        else
        {
            Console.WriteLine("No payment strategy selected");
        }
    }
}

// Usage
var paymentProcessor = new PaymentProcessor();

// Use credit card payment
paymentProcessor.SetPaymentStrategy(new CreditCardPayment("1234567890123456", "12/25", "123"));
paymentProcessor.ProcessPayment(100.00m);

// Switch to PayPal payment
paymentProcessor.SetPaymentStrategy(new PayPalPayment("user@example.com", "password"));
paymentProcessor.ProcessPayment(75.50m);

// Switch to bank transfer
paymentProcessor.SetPaymentStrategy(new BankTransferPayment("9876543210", "123456789"));
paymentProcessor.ProcessPayment(200.00m);
```

### 22. Template Method Pattern

**Problem it solves:**
Many algorithms follow similar overall structures but differ in specific implementation details of individual steps. Without a structured approach, this often leads to code duplication where the same algorithmic skeleton is repeated across multiple classes with only minor variations in specific steps. This duplication makes maintenance difficult because changes to the overall algorithm structure need to be applied in multiple places, and it's easy to introduce inconsistencies between different implementations. Additionally, the overall algorithm structure becomes scattered and implicit rather than being clearly defined in one place. For example, different data processing pipelines might all follow the pattern of reading data, validating it, processing it, and saving results, but each step might be implemented differently for different data types or business requirements. The Template Method pattern solves this by defining the skeleton of an algorithm in a base class, with specific steps implemented as abstract or virtual methods that subclasses can override. This approach eliminates code duplication, makes the algorithm structure explicit and centralized, ensures consistency in how the algorithm is executed, and provides clear extension points for customization while maintaining control over the overall process.

**When to use:**
- When you have common behavior with variations in specific steps
- When you want to control which parts of an algorithm can be extended
- When you want to avoid code duplication in similar algorithms

**Real-world example:** A data processing pipeline where the overall steps are the same (read data, process data, save results) but the specific implementation of each step varies, or a game where all characters follow the same turn sequence but have different actions.

```csharp
// Abstract base class defining the template method
public abstract class DataProcessor
{
    // Template method - defines the skeleton of the algorithm
    public void ProcessData()
    {
        ReadData();
        ValidateData();
        ProcessDataInternal();
        SaveData();
        Cleanup();
    }

    // Abstract methods that must be implemented by subclasses
    protected abstract void ReadData();
    protected abstract void ProcessDataInternal();
    protected abstract void SaveData();

    // Concrete method with default implementation
    protected virtual void ValidateData()
    {
        Console.WriteLine("Performing basic data validation...");
    }

    // Hook method - optional override
    protected virtual void Cleanup()
    {
        Console.WriteLine("Performing cleanup...");
    }
}

// Concrete implementation for CSV processing
public class CsvDataProcessor : DataProcessor
{
    private List<string[]> _csvData;

    protected override void ReadData()
    {
        Console.WriteLine("Reading data from CSV file...");
        // Simulate reading CSV data
        _csvData = new List<string[]>
        {
            new[] { "John", "25", "Engineer" },
            new[] { "Jane", "30", "Designer" },
            new[] { "Bob", "35", "Manager" }
        };
        Console.WriteLine($"Read {_csvData.Count} records from CSV");
    }

    protected override void ValidateData()
    {
        Console.WriteLine("Validating CSV data format...");
        foreach (var row in _csvData)
        {
            if (row.Length != 3)
            {
                throw new InvalidDataException("Invalid CSV row format");
            }
        }
        Console.WriteLine("CSV data validation completed");
    }

    protected override void ProcessDataInternal()
    {
        Console.WriteLine("Processing CSV data...");
        foreach (var row in _csvData)
        {
            Console.WriteLine($"Processing: {row[0]}, Age: {row[1]}, Role: {row[2]}");
            // Simulate data processing
        }
    }

    protected override void SaveData()
    {
        Console.WriteLine("Saving processed CSV data to database...");
        // Simulate saving to database
        Console.WriteLine("CSV data saved successfully");
    }
}

// Concrete implementation for XML processing
public class XmlDataProcessor : DataProcessor
{
    private List<Dictionary<string, string>> _xmlData;

    protected override void ReadData()
    {
        Console.WriteLine("Reading data from XML file...");
        // Simulate reading XML data
        _xmlData = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { {"name", "Alice"}, {"age", "28"}, {"department", "IT"} },
            new Dictionary<string, string> { {"name", "Charlie"}, {"age", "32"}, {"department", "HR"} }
        };
        Console.WriteLine($"Read {_xmlData.Count} records from XML");
    }

    protected override void ValidateData()
    {
        Console.WriteLine("Validating XML data structure...");
        foreach (var record in _xmlData)
        {
            if (!record.ContainsKey("name") || !record.ContainsKey("age") || !record.ContainsKey("department"))
            {
                throw new InvalidDataException("Missing required XML fields");
            }
        }
        Console.WriteLine("XML data validation completed");
    }

    protected override void ProcessDataInternal()
    {
        Console.WriteLine("Processing XML data...");
        foreach (var record in _xmlData)
        {
            Console.WriteLine($"Processing: {record["name"]}, Age: {record["age"]}, Dept: {record["department"]}");
            // Simulate XML-specific processing
        }
    }

    protected override void SaveData()
    {
        Console.WriteLine("Saving processed XML data to cloud storage...");
        // Simulate saving to cloud
        Console.WriteLine("XML data saved successfully");
    }

    protected override void Cleanup()
    {
        Console.WriteLine("Performing XML-specific cleanup...");
        _xmlData?.Clear();
        base.Cleanup();
    }
}

// Usage
Console.WriteLine("=== Processing CSV Data ===");
DataProcessor csvProcessor = new CsvDataProcessor();
csvProcessor.ProcessData();

Console.WriteLine("\n=== Processing XML Data ===");
DataProcessor xmlProcessor = new XmlDataProcessor();
xmlProcessor.ProcessData();
```

### 23. Visitor Pattern

**Problem it solves:**
Complex object structures often need to support many different operations, but adding new operations typically requires modifying every class in the structure, violating the open-closed principle. This becomes particularly problematic when the object structure is stable (classes rarely change) but new operations are frequently added. For example, a compiler's abstract syntax tree might need to support operations like pretty printing, code generation, optimization, and type checking, but adding each new operation requires modifying every node type in the tree. This approach leads to classes that violate the single responsibility principle by containing code for many different operations, and it makes the system difficult to maintain as operational logic becomes scattered across the entire object hierarchy. Additionally, when operations need to maintain state or coordinate between different object types, this becomes difficult to manage when the logic is distributed across multiple classes. The Visitor pattern addresses this by separating operations from the object structure, allowing you to define new operations without modifying existing classes. Operations are encapsulated in visitor classes that can traverse the object structure and perform their specific functionality, making it easy to add new operations while keeping the object structure stable and focused on its core responsibilities.

**When to use:**
- When you need to perform many different operations on objects in a complex structure
- When the classes defining the object structure rarely change, but you frequently add new operations
- When operations need to work across several classes with different interfaces

**Real-world example:** A compiler that needs to perform different operations (syntax checking, code generation, optimization) on the same abstract syntax tree, or a tax calculation system that applies different tax rules to various types of financial products.

```csharp
// Visitor interface
public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
    void Visit(Triangle triangle);
}

// Element interface
public interface IShape
{
    void Accept(IShapeVisitor visitor);
}

// Concrete elements
public class Circle : IShape
{
    public double Radius { get; }
    public double X { get; }
    public double Y { get; }

    public Circle(double radius, double x, double y)
    {
        Radius = radius;
        X = x;
        Y = y;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }
    public double X { get; }
    public double Y { get; }

    public Rectangle(double width, double height, double x, double y)
    {
        Width = width;
        Height = height;
        X = x;
        Y = y;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Triangle : IShape
{
    public double Base { get; }
    public double Height { get; }
    public double X { get; }
    public double Y { get; }

    public Triangle(double @base, double height, double x, double y)
    {
        Base = @base;
        Height = height;
        X = x;
        Y = y;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Concrete visitors
public class AreaCalculatorVisitor : IShapeVisitor
{
    public double TotalArea { get; private set; }

    public void Visit(Circle circle)
    {
        double area = Math.PI * circle.Radius * circle.Radius;
        Console.WriteLine($"Circle area: {area:F2}");
        TotalArea += area;
    }

    public void Visit(Rectangle rectangle)
    {
        double area = rectangle.Width * rectangle.Height;
        Console.WriteLine($"Rectangle area: {area:F2}");
        TotalArea += area;
    }

    public void Visit(Triangle triangle)
    {
        double area = 0.5 * triangle.Base * triangle.Height;
        Console.WriteLine($"Triangle area: {area:F2}");
        TotalArea += area;
    }
}

public class PerimeterCalculatorVisitor : IShapeVisitor
{
    public double TotalPerimeter { get; private set; }

    public void Visit(Circle circle)
    {
        double perimeter = 2 * Math.PI * circle.Radius;
        Console.WriteLine($"Circle perimeter: {perimeter:F2}");
        TotalPerimeter += perimeter;
    }

    public void Visit(Rectangle rectangle)
    {
        double perimeter = 2 * (rectangle.Width + rectangle.Height);
        Console.WriteLine($"Rectangle perimeter: {perimeter:F2}");
        TotalPerimeter += perimeter;
    }

    public void Visit(Triangle triangle)
    {
        // Assuming equilateral triangle for simplicity
        double side = triangle.Base;
        double perimeter = 3 * side;
        Console.WriteLine($"Triangle perimeter: {perimeter:F2}");
        TotalPerimeter += perimeter;
    }
}

public class DrawingVisitor : IShapeVisitor
{
    public void Visit(Circle circle)
    {
        Console.WriteLine($"Drawing Circle: radius={circle.Radius} at ({circle.X}, {circle.Y})");
    }

    public void Visit(Rectangle rectangle)
    {
        Console.WriteLine($"Drawing Rectangle: {rectangle.Width}x{rectangle.Height} at ({rectangle.X}, {rectangle.Y})");
    }

    public void Visit(Triangle triangle)
    {
        Console.WriteLine($"Drawing Triangle: base={triangle.Base}, height={triangle.Height} at ({triangle.X}, {triangle.Y})");
    }
}

// Object structure
public class Drawing
{
    private List<IShape> _shapes = new List<IShape>();

    public void AddShape(IShape shape)
    {
        _shapes.Add(shape);
    }

    public void Accept(IShapeVisitor visitor)
    {
        foreach (var shape in _shapes)
        {
            shape.Accept(visitor);
        }
    }
}

// Usage
var drawing = new Drawing();
drawing.AddShape(new Circle(5.0, 10, 15));
drawing.AddShape(new Rectangle(4.0, 6.0, 20, 25));
drawing.AddShape(new Triangle(8.0, 6.0, 30, 35));

Console.WriteLine("=== Calculating Areas ===");
var areaCalculator = new AreaCalculatorVisitor();
drawing.Accept(areaCalculator);
Console.WriteLine($"Total area: {areaCalculator.TotalArea:F2}");

Console.WriteLine("\n=== Calculating Perimeters ===");
var perimeterCalculator = new PerimeterCalculatorVisitor();
drawing.Accept(perimeterCalculator);
Console.WriteLine($"Total perimeter: {perimeterCalculator.TotalPerimeter:F2}");

Console.WriteLine("\n=== Drawing Shapes ===");
var drawer = new DrawingVisitor();
drawing.Accept(drawer);
```

---

## Conclusion

Design patterns provide proven solutions to recurring design problems and establish a common vocabulary for developers. When choosing which pattern to use, consider:

1. **The specific problem you're trying to solve**
2. **The trade-offs each pattern introduces**
3. **The complexity it adds to your codebase**
4. **Whether the pattern fits naturally with your existing architecture**

Remember that patterns should be applied when they solve real problems, not just for the sake of using them. Overuse of design patterns can lead to unnecessarily complex code. The key is to understand the problems each pattern solves and apply them judiciously when those problems arise in your projects.

Each pattern has its place in software development, and mastering them will make you a more effective developer by providing you with a toolkit of proven solutions to common design challenges.