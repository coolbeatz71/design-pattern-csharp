# Object-Oriented Design Patterns

## Overview

This document provides a comprehensive guide to the 23 classic Gang of Four design patterns implemented in C#. Each pattern is explained with its purpose, the problem it solves, and practical scenarios where it would be useful.

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

### 2. Factory Method Pattern

**Problem it solves:**
When designing applications, you often encounter situations where you need to create objects, but the exact type of object to create isn't known until runtime, or you want to delegate the responsibility of object creation to subclasses. The traditional approach of using the `new` keyword directly in your code creates tight coupling between your code and specific concrete classes, making your system rigid and difficult to extend. This becomes particularly problematic when you need to create different types of objects based on user input, configuration settings, or runtime conditions. The Factory Method pattern solves this by providing an interface for creating objects while allowing subclasses to decide which specific class to instantiate. This approach eliminates the need for your client code to know about specific concrete classes, making the system more flexible and easier to extend. It also centralizes object creation logic, making it easier to manage and modify how objects are created without affecting the rest of your codebase.

**When to use:**
- When you need to delegate object creation to subclasses
- When the exact type of object to create isn't known until runtime
- When you want to localize the knowledge of which class gets created

**Real-world example:** A document editor that can create different types of documents (Word, PDF, HTML) based on user selection, where each document type has its own creation logic.

### 3. Abstract Factory Pattern

**Problem it solves:**
In complex applications, you often need to create families of related objects that are designed to work together, and you want to ensure that objects from different families are not mixed together inadvertently. For instance, if you're building a cross-platform application, you might have different UI components for Windows, macOS, and Linux, where each platform has its own specific button, window, and menu implementations. The challenge is ensuring that when you create a Windows button, you also create Windows-compatible windows and menus, not a mixture of components from different platforms. Creating individual factories for each type of object would be cumbersome and wouldn't guarantee compatibility between related objects. The Abstract Factory pattern addresses this by providing an interface that creates entire families of related objects, ensuring that all objects created by a particular factory implementation are compatible with each other. This pattern guarantees consistency within object families while still allowing you to switch between different families based on runtime conditions or configuration.

**When to use:**
- When you need to create families of related products
- When you want to ensure that products from the same family are used together
- When you need to configure your system with multiple product lines

**Real-world example:** A UI framework that needs to create different sets of controls for different operating systems (Windows buttons, Mac buttons, Linux buttons) while ensuring consistency within each platform.

### 4. Builder Pattern

**Problem it solves:**
When creating complex objects that have many optional parameters, constructors can quickly become unwieldy and difficult to use. You might end up with constructors that have dozens of parameters, making it hard to remember the order and meaning of each parameter. Additionally, many of these parameters might be optional, leading to multiple constructor overloads or the need to pass null values for unused parameters. This problem becomes even more complex when the object construction process involves multiple steps or when certain combinations of parameters are invalid. The traditional approach often results in either telescoping constructors (multiple overloaded constructors with increasing numbers of parameters) or the need to expose setter methods that compromise object immutability. The Builder pattern solves this by providing a step-by-step approach to object construction, where you can set only the parameters you need in any order, with meaningful method names that make the code self-documenting. It also allows for validation of parameter combinations and can ensure that the final object is in a valid state before creation.

**When to use:**
- When creating objects with many optional parameters
- When the construction process is complex or needs to be done in specific steps
- When you want to create immutable objects with many properties

**Real-world example:** Building a complex SQL query with optional WHERE clauses, JOIN statements, and ORDER BY conditions, or constructing a house with optional features like garage, swimming pool, and garden.

### 5. Prototype Pattern

**Problem it solves:**
Object creation can be expensive in terms of both time and computational resources, especially when objects require complex initialization, database queries, network calls, or extensive calculations to set up their initial state. In some scenarios, you might need to create many objects that are similar to existing ones, differing only in a few properties. Creating each object from scratch using constructors would be inefficient and wasteful. Additionally, sometimes you don't know the exact class of the object you need to create until runtime, or you want to create objects without being tightly coupled to their specific classes. The traditional approach of using constructors requires compile-time knowledge of the exact class type and forces you to repeat expensive initialization processes. The Prototype pattern addresses these issues by allowing you to create new objects by cloning existing instances. This approach is much faster than creating objects from scratch because cloning typically involves copying memory structures rather than executing complex initialization logic. It also provides a way to create objects without knowing their exact classes, as long as you have a prototype instance to clone from.

**When to use:**
- When object creation is expensive in terms of time or resources
- When you need to create objects that are similar to existing ones
- When you want to avoid the overhead of initializing an object

**Real-world example:** Creating new game characters based on existing templates, or duplicating complex document objects with all their formatting and content intact.

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

### 7. Bridge Pattern

**Problem it solves:**
When designing class hierarchies, you sometimes need to extend functionality in multiple independent dimensions, which can lead to a combinatorial explosion of subclasses. For example, if you have shapes that can be drawn in different colors and using different rendering engines, a traditional inheritance approach would require creating separate classes for every combination: RedCircleDirectXRenderer, BlueCircleOpenGLRenderer, RedRectangleDirectXRenderer, and so on. This approach becomes unmanageable as the number of dimensions increases, leading to a massive number of classes that are difficult to maintain and extend. Additionally, this tight coupling between abstraction (what the object does) and implementation (how it does it) makes it difficult to change either aspect independently. The Bridge pattern addresses this problem by separating the abstraction from its implementation, allowing both to vary independently. Instead of having a single inheritance hierarchy that tries to capture all possible combinations, you create two separate hierarchies: one for the abstraction and one for the implementation, connected by a bridge. This approach allows you to add new abstractions or implementations without affecting existing code and significantly reduces the number of classes needed.

**When to use:**
- When you want to avoid permanent binding between abstraction and implementation
- When you need to share implementation among multiple objects
- When you want to extend classes in two independent dimensions

**Real-world example:** A drawing application where shapes (circles, rectangles) can be drawn using different rendering engines (DirectX, OpenGL) without the shapes knowing about the specific rendering implementation.

### 8. Composite Pattern

**Problem it solves:**
Many applications need to work with hierarchical or tree-like structures where individual objects and groups of objects should be treated uniformly. The challenge arises when client code needs to interact with both simple objects (leaves) and complex objects (composites containing other objects) differently, leading to complex conditional logic throughout the codebase. For example, in a file system, you might need to calculate the total size of both individual files and entire directories, but the logic for handling files versus directories is different. Without a unified approach, client code becomes cluttered with type-checking and different handling logic for different object types. This problem becomes more complex in nested structures where composites can contain other composites, requiring recursive traversal logic scattered throughout the application. The Composite pattern solves this by defining a common interface for both simple and complex objects, allowing client code to treat individual objects and compositions of objects uniformly. This eliminates the need for client code to distinguish between simple and composite objects, simplifying the codebase and making it easier to add new types of objects to the hierarchy.

**When to use:**
- When you need to represent hierarchical structures of objects
- When you want clients to ignore the difference between individual objects and compositions
- When working with tree-like structures

**Real-world example:** A file system where files and folders are treated uniformly, or a graphical user interface where windows can contain other windows, buttons, and controls in a hierarchical manner.

### 9. Decorator Pattern

**Problem it solves:**
Traditional inheritance has limitations when you need to add functionality to objects dynamically or when you want to combine multiple features in various ways. Creating subclasses for every possible combination of features leads to class explosion and rigid designs. For instance, if you have a basic text class and want to add features like bold, italic, underline, and different colors, creating subclasses for every combination (BoldText, ItalicText, BoldItalicText, BoldItalicUnderlineText, etc.) becomes impractical. Moreover, these combinations need to be determined at compile time, making it impossible to add or remove features dynamically based on user preferences or runtime conditions. The Decorator pattern addresses this by allowing you to wrap objects with decorator objects that add new behavior without altering the original object's structure. Multiple decorators can be stacked on top of each other, each adding its own functionality while maintaining the same interface as the original object. This approach provides tremendous flexibility, allowing you to create any combination of features at runtime while keeping individual decorators simple and focused on a single responsibility.

**When to use:**
- When you want to add responsibilities to objects without subclassing
- When extension by subclassing is impractical or impossible
- When you need to add or remove functionality at runtime

**Real-world example:** Adding features to a text editor like bold, italic, underline formatting, or adding toppings to a pizza order where each topping adds cost and functionality.

### 10. Facade Pattern

**Problem it solves:**
Complex subsystems often expose many interdependent classes and interfaces that clients need to interact with, creating tight coupling and making the subsystem difficult to use correctly. When client code needs to perform common operations, it often requires knowledge of multiple classes, their relationships, and the correct sequence of method calls. This complexity makes the system error-prone, as clients might miss important steps, call methods in the wrong order, or fail to handle edge cases properly. Additionally, if the subsystem's internal structure changes, all client code that directly interacts with it needs to be updated. For example, to play a movie, a client might need to interact with file readers, codecs, audio systems, video renderers, and subtitle processors, each requiring specific initialization and configuration. The Facade pattern solves this by providing a simplified, unified interface that hides the complexity of the subsystem. The facade handles all the intricate interactions between subsystem components and presents a clean, easy-to-use interface to clients. This reduces coupling, makes the subsystem easier to use, and provides a buffer against changes in the subsystem's internal structure.

**When to use:**
- When you want to provide a simple interface to a complex subsystem
- When there are many dependencies between clients and implementation classes
- When you want to layer your subsystems

**Real-world example:** A home entertainment system controller that provides simple buttons to control multiple devices (TV, sound system, DVD player, lights) with a single interface, hiding the complexity of individual device controls.

### 11. Flyweight Pattern

**Problem it solves:**
Applications that need to create large numbers of similar objects can quickly consume excessive amounts of memory, especially when these objects contain duplicate data. For example, in a text editor, each character might be represented as an object containing the character value, font, size, color, and style information. In a large document with thousands of characters, storing all this information separately for each character instance results in enormous memory waste, since many characters share the same font, size, and color properties. Similarly, in games with thousands of bullets, trees, or particles, each object storing its own copy of shared data like sprites, behaviors, or properties leads to memory exhaustion. The traditional approach of creating separate objects for each instance doesn't scale well and can cause performance issues due to memory pressure and increased garbage collection. The Flyweight pattern addresses this by separating intrinsic state (data that can be shared among multiple objects) from extrinsic state (data that is unique to each object instance). Intrinsic state is stored in flyweight objects that are shared among multiple contexts, while extrinsic state is passed to flyweight methods when needed, dramatically reducing memory consumption.

**When to use:**
- When you need to create a large number of similar objects
- When object creation is expensive
- When most object state can be made extrinsic (stored outside the object)

**Real-world example:** A text editor where each character in a document shares font and formatting information, or a game with thousands of bullets that share the same sprite and behavior but have different positions.

### 12. Proxy Pattern

**Problem it solves:**
Direct access to objects is not always desirable or possible due to various concerns such as security, performance, location, or resource management. Sometimes objects are expensive to create or maintain, located on remote systems, require special access permissions, or need additional processing before or after method calls. For instance, loading large images or videos immediately when they're referenced can slow down application startup, even if these resources are never actually displayed. Similarly, accessing remote services directly without any intermediary can lead to performance issues, security vulnerabilities, or lack of proper error handling. The traditional approach of direct object access doesn't provide opportunities to add these cross-cutting concerns without modifying the original object or cluttering client code with additional logic. The Proxy pattern solves this by providing a surrogate or placeholder object that controls access to the real object. The proxy implements the same interface as the real object but can add functionality such as lazy loading, access control, caching, logging, or remote communication. This allows for transparent enhancement of object access without changing client code or the original object's implementation.

**When to use:**
- When you need to control access to an object
- When you want to add functionality before or after accessing an object
- When you need lazy initialization of expensive objects

**Real-world example:** A virtual proxy that loads large images only when they're actually displayed, or a security proxy that checks permissions before allowing access to sensitive operations.

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

### 14. Command Pattern

**Problem it solves:**
Traditional approaches to handling user actions or system operations often result in tight coupling between the user interface (or request initiator) and the business logic that performs the actual work. This makes it difficult to implement features like undo/redo functionality, operation queuing, logging, or macro recording because the operations are executed immediately and their details are scattered throughout the codebase. For example, in a text editor, when a user performs actions like typing, deleting, or formatting, these operations are typically executed directly, making it impossible to reverse them later or replay them in different contexts. Similarly, when building systems that need to queue operations, execute them later, or execute them on different objects, the tight coupling between requesters and receivers creates significant challenges. The Command pattern solves this by encapsulating requests as objects, complete with all the information needed to perform the operation. This transformation allows operations to be stored, queued, logged, undone, or executed on different objects. Commands can be combined into macro commands, scheduled for later execution, or transmitted across network boundaries, providing tremendous flexibility in how operations are handled.

**When to use:**
- When you want to parameterize objects with operations
- When you need to queue, log, or support undo operations
- When you want to structure a system around high-level operations built on primitive operations

**Real-world example:** A text editor's undo/redo functionality where each operation (typing, deleting, formatting) is encapsulated as a command that can be undone, or a remote control where each button press is a command sent to different devices.

### 15. Interpreter Pattern

**Problem it solves:**
Many applications need to process structured input that follows specific grammar rules, such as mathematical expressions, search queries, configuration files, or domain-specific languages. The traditional approach often involves writing complex parsing logic with lengthy switch statements or nested conditionals that are difficult to understand, maintain, and extend. When the grammar rules change or new language features are added, the parsing logic becomes increasingly complex and error-prone. Additionally, the parsing logic is often intertwined with the execution logic, making it difficult to reuse the parser for different purposes or to optimize the interpretation process. The Interpreter pattern addresses this by representing each grammar rule as a separate class, creating a clean separation between different language constructs. Each class is responsible for interpreting its specific part of the language, and complex expressions are built by composing these simple interpreters. This approach makes the grammar explicit in the code structure, makes it easy to extend the language by adding new interpreter classes, and allows for easy modification of existing language constructs without affecting others.

**When to use:**
- When you have a simple language to interpret
- When the grammar is simple and efficiency isn't critical
- When you want to represent grammar rules as classes

**Real-world example:** A calculator application that interprets mathematical expressions, or a search engine that interprets query syntax with operators like AND, OR, and NOT.

### 16. Iterator Pattern

**Problem it solves:**
Collections and data structures can be implemented in many different ways (arrays, linked lists, trees, hash tables), each with their own optimal traversal methods. Client code that needs to access elements in these collections often becomes tightly coupled to the specific collection implementation, making it difficult to switch between different collection types or traverse the same collection in different ways. For example, traversing a tree structure requires different logic than traversing an array, and client code needs to understand these implementation details. Additionally, when multiple clients need to traverse the same collection simultaneously, maintaining separate traversal states becomes complex and error-prone. The traditional approach of exposing internal collection structure or providing collection-specific traversal methods breaks encapsulation and creates dependencies that make code brittle and hard to maintain. The Iterator pattern solves this by providing a standard interface for traversing collections regardless of their internal implementation. Iterators encapsulate the traversal logic and maintain their own state, allowing multiple iterators to work on the same collection independently while hiding the collection's internal structure from client code.

**When to use:**
- When you want to access a collection's elements without exposing its internal structure
- When you need multiple ways to traverse the same collection
- When you want to provide a uniform interface for traversing different collection types

**Real-world example:** Iterating through items in a playlist, browsing through photos in a gallery, or traversing nodes in a tree structure without knowing the specific implementation details.

### 17. Mediator Pattern

**Problem it solves:**
In complex systems, objects often need to communicate and coordinate with each other, but direct communication creates tight coupling that makes the system difficult to understand, maintain, and extend. When objects reference each other directly, changes to one object can have cascading effects throughout the system, and the interaction logic becomes scattered across multiple classes. For example, in a user interface, when a button is clicked, it might need to update text fields, enable or disable other buttons, refresh lists, and validate form data. If the button directly references all these components, the system becomes a tangled web of interdependencies. Adding new components or changing interaction behavior requires modifying multiple existing classes, violating the open-closed principle and increasing the risk of introducing bugs. The Mediator pattern addresses this by centralizing communication logic in a mediator object that coordinates interactions between components. Instead of objects communicating directly with each other, they communicate through the mediator, which knows how to route messages and coordinate complex interactions. This approach reduces coupling, centralizes interaction logic, and makes the system easier to understand and modify.

**When to use:**
- When objects communicate in complex but well-defined ways
- When reusing an object is difficult because it refers to many other objects
- When behavior distributed between several classes should be customizable without lots of subclassing

**Real-world example:** An air traffic control system where pilots don't communicate directly with each other but through the control tower, or a chat room where users send messages through a central mediator rather than directly to each other.

### 18. Memento Pattern

**Problem it solves:**
Many applications need to provide undo functionality or save/restore object states, but directly exposing an object's internal state violates encapsulation principles and creates tight coupling between the object and the code that manages its state. Objects often contain private data that should not be accessible to external code, yet this data needs to be captured to restore the object later. The traditional approach might involve making internal state public or providing getter methods for all internal data, which breaks encapsulation and makes the object's interface cluttered with methods that are only used for state management. Additionally, managing multiple saved states and ensuring they remain valid when the object's structure changes becomes complex and error-prone. The naive approach of storing references to objects doesn't work because the object's state continues to change, and deep copying everything is expensive and may not preserve object relationships correctly. The Memento pattern solves this by allowing objects to create snapshots of their internal state without exposing their internal structure. The object itself is responsible for creating and restoring from mementos, maintaining encapsulation while enabling state management functionality.

**When to use:**
- When you need to save and restore an object's state
- When you want to provide undo functionality
- When direct access to an object's state would violate encapsulation

**Real-world example:** A game's saving system that captures the complete game state at checkpoints, or a word processor that saves document states for undo operations while keeping the document's internal structure private.

### 19. Observer Pattern

**Problem it solves:**
In many applications, changes to one object need to trigger updates in multiple dependent objects, but you don't want to create tight coupling between the subject and its dependents. The traditional approach often involves the subject knowing about all its dependents and calling their update methods directly, which creates rigid dependencies and makes it difficult to add or remove dependents dynamically. This becomes particularly problematic in systems where the set of dependents can change at runtime, or where dependents are created by different parts of the system. For example, in a model-view architecture, when data changes, multiple views need to be updated, but the data model shouldn't need to know about specific view implementations. Hardcoding these relationships makes the system inflexible and violates the dependency inversion principle. Additionally, when dependents are added or removed frequently, managing these relationships becomes complex and error-prone. The Observer pattern addresses this by establishing a publish-subscribe mechanism where subjects maintain a list of observers and notify them automatically when changes occur. This approach decouples subjects from observers, allows for dynamic registration and removal of observers, and ensures that all interested parties are notified of changes without the subject needing to know their specific details.

**When to use:**
- When changes to one object require updating multiple dependent objects
- When an object should notify others without knowing who they are
- When you want to maintain consistency between related objects

**Real-world example:** A news subscription service where subscribers are automatically notified when new articles are published, or a model-view architecture where multiple views update automatically when the underlying data changes.

### 20. State Pattern

**Problem it solves:**
Objects that change their behavior based on internal state often end up with complex conditional logic scattered throughout their methods, making the code difficult to understand, maintain, and extend. As the number of states and state-dependent behaviors increases, methods become cluttered with large switch statements or chains of if-else conditions that check the current state and execute different logic accordingly. This approach makes it difficult to add new states or modify state-specific behavior without affecting other parts of the code. Additionally, state transitions can become complex and error-prone when managed through simple variables and conditional logic, especially when certain transitions are only valid from specific states. The code becomes fragile because state-related logic is duplicated across multiple methods, and it's easy to forget to update all relevant places when adding new states or modifying existing ones. The State pattern solves this by encapsulating state-specific behavior in separate state classes and delegating state-dependent operations to the current state object. This approach eliminates conditional logic, makes states and their behaviors explicit, and makes it easy to add new states or modify existing ones without affecting other code.

**When to use:**
- When an object's behavior depends on its state
- When you have large conditional statements that depend on object state
- When state-specific behavior needs to be defined in separate classes

**Real-world example:** A vending machine that behaves differently when it has no money inserted, has money but no selection made, or has money and a selection made, or a media player that behaves differently when stopped, playing, or paused.

### 21. Strategy Pattern

**Problem it solves:**
Applications often need to perform the same type of operation but with different algorithms or approaches depending on context, user preferences, or runtime conditions. The traditional approach of using conditional statements to select algorithms creates rigid code that's difficult to extend and maintain. When new algorithms are added, existing code needs to be modified, violating the open-closed principle. Additionally, having all algorithm implementations in a single class violates the single responsibility principle and makes the class difficult to understand and test. For example, a sorting routine might need to use different algorithms based on data size, or a compression utility might need to choose between different compression techniques based on file type or user preferences. Embedding all these algorithms directly in the client code creates a monolithic, inflexible design. The Strategy pattern addresses this by encapsulating each algorithm in its own class and making them interchangeable through a common interface. This allows algorithms to be selected and switched at runtime without modifying client code, makes it easy to add new algorithms, and enables better testing since each algorithm can be tested independently.

**When to use:**
- When you have multiple ways to perform a task
- When you want to choose algorithms at runtime
- When you want to eliminate large conditional statements for algorithm selection

**Real-world example:** A navigation app that can calculate routes using different strategies (fastest route, shortest route, most scenic route), or a payment system that supports different payment methods (credit card, PayPal, bank transfer).

### 22. Template Method Pattern

**Problem it solves:**
Many algorithms follow similar overall structures but differ in specific implementation details of individual steps. Without a structured approach, this often leads to code duplication where the same algorithmic skeleton is repeated across multiple classes with only minor variations in specific steps. This duplication makes maintenance difficult because changes to the overall algorithm structure need to be applied in multiple places, and it's easy to introduce inconsistencies between different implementations. Additionally, the overall algorithm structure becomes scattered and implicit rather than being clearly defined in one place. For example, different data processing pipelines might all follow the pattern of reading data, validating it, processing it, and saving results, but each step might be implemented differently for different data types or business requirements. The Template Method pattern solves this by defining the skeleton of an algorithm in a base class, with specific steps implemented as abstract or virtual methods that subclasses can override. This approach eliminates code duplication, makes the algorithm structure explicit and centralized, ensures consistency in how the algorithm is executed, and provides clear extension points for customization while maintaining control over the overall process.

**When to use:**
- When you have common behavior with variations in specific steps
- When you want to control which parts of an algorithm can be extended
- When you want to avoid code duplication in similar algorithms

**Real-world example:** A data processing pipeline where the overall steps are the same (read data, process data, save results) but the specific implementation of each step varies, or a game where all characters follow the same turn sequence but have different actions.

### 23. Visitor Pattern

**Problem it solves:**
Complex object structures often need to support many different operations, but adding new operations typically requires modifying every class in the structure, violating the open-closed principle. This becomes particularly problematic when the object structure is stable (classes rarely change) but new operations are frequently added. For example, a compiler's abstract syntax tree might need to support operations like pretty printing, code generation, optimization, and type checking, but adding each new operation requires modifying every node type in the tree. This approach leads to classes that violate the single responsibility principle by containing code for many different operations, and it makes the system difficult to maintain as operational logic becomes scattered across the entire object hierarchy. Additionally, when operations need to maintain state or coordinate between different object types, this becomes difficult to manage when the logic is distributed across multiple classes. The Visitor pattern addresses this by separating operations from the object structure, allowing you to define new operations without modifying existing classes. Operations are encapsulated in visitor classes that can traverse the object structure and perform their specific functionality, making it easy to add new operations while keeping the object structure stable and focused on its core responsibilities.

**When to use:**
- When you need to perform many different operations on objects in a complex structure
- When the classes defining the object structure rarely change, but you frequently add new operations
- When operations need to work across several classes with different interfaces

**Real-world example:** A compiler that needs to perform different operations (syntax checking, code generation, optimization) on the same abstract syntax tree, or a tax calculation system that applies different tax rules to various types of financial products.

---

## Conclusion

Design patterns provide proven solutions to recurring design problems and establish a common vocabulary for developers. When choosing which pattern to use, consider:

1. **The specific problem you're trying to solve**
2. **The trade-offs each pattern introduces**
3. **The complexity it adds to your codebase**
4. **Whether the pattern fits naturally with your existing architecture**

Remember that patterns should be applied when they solve real problems, not just for the sake of using them. Overuse of design patterns can lead to unnecessarily complex code. The key is to understand the problems each pattern solves and apply them judiciously when those problems arise in your projects.

Each pattern has its place in software development, and mastering them will make you a more effective developer by providing you with a toolkit of proven solutions to common design challenges.
