1. Classes (/Classes)

What it is: A class is the most fundamental concept. Think of it as a blueprint for creating "objects." It bundles related data (called fields or properties) and behavior (called methods) into a single, clean unit.

In Your Code: You've already done this in your Classes project!

Person.cs is a blueprint for creating Person objects.

Car.cs is a blueprint for creating Car objects.

Rectangle.cs is a blueprint for creating Rectangle objects.

Why it Matters: This is how you model real-world things in your code. Instead of having loose variables (like string personName, int personAge), you can create a Person object that contains its own Name and Age.

2. Access Modifiers (/Access Modifiers)

What they are: These are keywords that control visibility. They answer the question, "Who is allowed to see this?" The main ones are:

public: Everyone can see and use it.

private: Only code inside this exact class can see it.

protected: Only code inside this class or its children (see Inheritance) can see it.

internal: Only code inside the same project can see it.

Why it Matters: This is called Encapsulation. It protects the internal data of your class from being changed incorrectly. For example, you should make a Person's _age field private and provide a public method or property (like SetAge(int age)) that can check if the age is valid (e.g., > 0) before setting it.

3. Inheritance (/Inheritance)

What it is: This models an "is-a" relationship. It allows a new class (the child or derived class) to "inherit" all the public and protected fields and methods from an existing class (the parent or base class).

In Your Code: Your Inheritance project explores this. A classic example is:

A base Vehicle class with properties like Speed and methods like Move().

A child Car class that inherits from Vehicle. A Car is-a Vehicle. It gets the Speed property and Move() method for free, and it can add its own, like NumberOfDoors.

Why it Matters: It's all about code reuse. You don't have to rewrite the same logic for Car, Truck, and Motorcycle. You write it once in Vehicle, and they all inherit it.

4. Interfaces (/Interfaces)

What it is: An interface is a contract. It's a list of method and property signatures that a class must implement if it "signs" the contract. It defines what a class can do, but not how it does it.

In Your Code: Your Interfaces project is perfect for this. For example, you could define an ILogger interface:

public interface ILogger
{
    void LogError(string message);
    void LogInfo(string message);
}


Then, you could create a FileLogger class and a DatabaseLogger class that both implement ILogger. They will both have those two methods, but one will write to a file and the other to a database.

Why it Matters: This is called Polymorphism. It lets you write flexible code. Your application can just ask for an ILogger without caring if it's a FileLogger or DatabaseLogger. This makes your code loosely coupled and much easier to change or test.

5. Structs (/Struct)

What it is: A struct is similar to a class, but it's a Value Type, while a class is a Reference Type.

Why it Matters: This is a key difference in C#.

Value Type (Struct): The variable holds the data directly. When you pass a struct to a method, a copy is made. Changes to the copy don't affect the original.

Reference Type (Class): The variable holds a pointer (or reference) to where the object is stored in memory. When you pass a class object to a method, you are passing the pointer. Changes made inside the method do affect the original object.

Rule of Thumb: Use structs for small, simple data-holders (like Point(int x, int y) or RgbColor(byte r, byte g, byte b)). Use class for almost everything else.

6. Enums (/Enums)

What it is: An enum (enumeration) is a simple way to create a set of named constants. Behind the scenes, they are just integers, but they make your code much more readable.

In Your Code: Your Enums project shows this. Instead of writing code like if (userRole == 0) (what does 0 mean?), you can write if (userRole == UserRole.Admin).

Why it Matters: Readability and safety. It prevents bugs from "magic numbers" and makes your code self-explanatory.

7. Generics (/Generics)

What it is: Generics let you write classes and methods that can work with any data type (like int, string, or Person) without sacrificing type safety. You use a placeholder, <T>, to represent the type.

In Your Code: Your Generics project explores this. The most common example is List<T>.

List<int> numbers = new List<int>();

List<string> names = new List<string>();

Why it Matters: It's another powerful form of code reuse. You don't need to create an IntList, a StringList, and a PersonList. You create one List<T>, and it works for all of them.

8. The object Type (/The Object Type)

What it is: The "god" object. In C#, every single type (classes, structs, ints, strings, everything) automatically inherits from the object type.

Why it Matters: This is what allows different types to be treated in a common way. A List<object> can hold a string, an int, and a Person object all at the same time (though this is often not a good idea! Generics are better). It's the foundation of the entire C# type system.

9. Nested Types (/Nested Types)

What it is: A type (a class, struct, or enum) that is defined inside another class.

Why it Matters: It's used for organizational purposes. If you have a Node class that is only ever used by your LinkedList class, you can define Node as a nested private class inside LinkedList. This hides it from the rest of the world and ma