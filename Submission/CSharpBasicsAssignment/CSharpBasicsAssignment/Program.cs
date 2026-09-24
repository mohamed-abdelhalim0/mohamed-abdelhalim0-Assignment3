/*
    .csproj:
    This file contains the project settings,
    such as the output type, .NET version, implicit usings,
    and nullable settings.

    Program.cs:
    This is the main C# file where we write our program code.
    It contains the Main method, where the program starts.

    obj/:
    This folder contains temporary and intermediate files
    created by .NET during the build process.

    bin/:
    This folder contains the final files created after building
    the project, such as the compiled program.
*/

/*
    We use a file-scoped namespace here.
    It removes one level of indentation because we don't need
    to wrap the namespace code inside { }.
*/

namespace CSharpBasicsAssignment;

/*
    This project uses the newer .slnx solution format.

    --One advantage of the classic .sln format is that it has
    wider support in older versions of Visual Studio and other tools.
*/

internal class Program
{
    // D1 - Field scope:
    // A private field can be accessed by different methods
    // inside the same class.
    private static int fieldValue = 50;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        RunTypesDemo();
        RunScopeDemo();
        RunCompoundAssignmentDemo();
        RunBitwiseDemo();
        RunValueVsReferenceDemo();
    }
    static void RunTypesDemo()
    {
     
        int myInt = 25;
        long myLong = 100000L;
        double myDouble = 10.5;
        decimal myDecimal = 55.5m;
        bool myBool = true;
        char myChar = 'M';
        string myString = "Mohamed";
        var myVar = 123;

        Console.WriteLine("---------- Variables and Types : -----------------------");

        Console.WriteLine($"int: {myInt}, Runtime Type: {myInt.GetType()}");
        Console.WriteLine($"long: {myLong}, Runtime Type: {myLong.GetType()}");
        Console.WriteLine($"double: {myDouble}, Runtime Type: {myDouble.GetType()}");
        Console.WriteLine($"decimal: {myDecimal}, Runtime Type: {myDecimal.GetType()}");
        Console.WriteLine($"bool: {myBool}, Runtime Type: {myBool.GetType()}");
        Console.WriteLine($"char: {myChar}, Runtime Type: {myChar.GetType()}");
        Console.WriteLine($"string: {myString}, Runtime Type: {myString.GetType()}");
        Console.WriteLine($"var: {myVar}, Runtime Type: {myVar.GetType()}");

        // 2 - Implicit conversion: No cast is required because long can store all int values,and int can store all char values.

        int number = 100;
        long longNumber = number;

        char letter = 'A';
        int letterNumber = letter;

        Console.WriteLine("\n------ Implicit Conversion: --------");
        Console.WriteLine($"int to long: {longNumber}");
        Console.WriteLine($"char to int: {letterNumber}");

        // 3 - Explicit conversion : Casting double to int removes the decimal part (truncation).
        //Convert.ToInt32 rounds the number to the nearest integer.





        double value = 10.7;

        int castResult = (int)value;
        int convertResult = Convert.ToInt32(value);

        Console.WriteLine("\n------ Explicit Conversion --------");
        Console.WriteLine($"(int) result: {castResult}");
        Console.WriteLine($"Convert.ToInt32 result: {convertResult}"); 

        /*
            4 - Integer division trap :

           -- 5 / 2 uses integer division, so the decimal part is removed. 

           -- 5.0 / 2 uses double division, so the decimal result is kept.
        */

        int integerDivision = 5 / 2;
        double doubleDivision = 5.0 / 2;

        Console.WriteLine("\n------------ Division :-----------");
        Console.WriteLine($"5 / 2 = {integerDivision}");
        Console.WriteLine($"5.0 / 2 = {doubleDivision}");


        /*
            5. Boxing and unboxing :

            -- Boxing converts a value type into an object.

            -- Unboxing gets the original value type back from the object.
        */

        int firstNumber = 50;

        object boxedNumber = firstNumber;

        Console.WriteLine("\n-----------Boxing and Unboxing :------------");
        Console.WriteLine($"After boxing: {boxedNumber}");

        int unboxedNumber = (int)boxedNumber;

        Console.WriteLine($"After unboxing: {unboxedNumber}");


        /*
            6. Parsing :

            -- int.Parse converts a valid numeric string into an int.

            -- TryParse returns false instead of throwing an exception when the string is not a valid number.
        */

        string firstString = "50";
        int parsedNumber = int.Parse(firstString);

        Console.WriteLine("\n-- Parsing ---");
        Console.WriteLine($"int.Parse(\"50\"): {parsedNumber}");

        string secondString = "abc";

        bool success = int.TryParse(secondString, out int result);

        Console.WriteLine($"TryParse(\"abc\") succeeded: {success}");

        if (!success)
        {
            Console.WriteLine("The string could not be converted to an integer.");
        }


        /*
            7. float to decimal :

           -- float cannot be implicitly converted to decimal because decimal has higher precision and the conversion may lose information.
            
            float floatValue = 10.5f;
            decimal decimalValue = floatValue; // This does not compile.

            We need an explicit cast instead.
        */

        float floatValue = 10.5f;
        decimal decimalValue = (decimal)floatValue;

        Console.WriteLine("\n--------- Float to Decimal ----------");
        Console.WriteLine($"float to decimal: {decimalValue}");
    }


    // D1 - Field scope
    static void RunScopeDemo()
    {
        Console.WriteLine("\n=== Scope Demo ===");

        Console.WriteLine($"Field from RunScopeDemo: {fieldValue}");

        ShowFieldAgain();
        ShowMethodScope();
        ShowBlockScope();
    }

    // The same field can also be accessed from another method.
    static void ShowFieldAgain()
    {
        Console.WriteLine($"Field from ShowFieldAgain: {fieldValue}");
    }

    // D1 - Method scope
    static void ShowMethodScope()
    {
        // This variable belongs only to this method.
        int localNumber = 100;

        Console.WriteLine($"Local variable inside method: {localNumber}");

        // localNumber cannot be used outside this method
        // because it has method scope.
    }

    // D1 - Block scope
    static void ShowBlockScope()
    {
        for (int i = 0; i < 3; i++)
        {
            int insideLoop = i * 10;

            Console.WriteLine($"Loop variable: {i}");
            Console.WriteLine($"Variable inside loop: {insideLoop}");
        }

        // Console.WriteLine(i);
        // Console.WriteLine(insideLoop);

        /*
            This causes a compile error because i and insideLoop
            are declared inside the for-loop block.
            They are not visible after the block ends.
        */
    }


    // D2 - Compound Assignment Operators
    static void RunCompoundAssignmentDemo()
    {
        Console.WriteLine("\n=== Compound Assignment ===");

        int total = 100;

        total += 5;
        Console.WriteLine($"After += 5: {total}");

        total -= 10;
        Console.WriteLine($"After -= 10: {total}");

        total *= 2;
        Console.WriteLine($"After *= 2: {total}");

        total /= 5;
        Console.WriteLine($"After /= 5: {total}");

        total %= 7;
        Console.WriteLine($"After %= 7: {total}");

        /*
            These two lines are equivalent:

            total += 5;
            total = total + 5;
        */
    }


    // D3 - Bitwise Operators
    static void RunBitwiseDemo()
    {
        Console.WriteLine("\n=== Bitwise Operators ===");

        int a = 12;
        int b = 10;

        int andResult = a & b;
        int orResult = a | b;
        int xorResult = a ^ b;

        Console.WriteLine($"a & b = {andResult}");
        Console.WriteLine($"a | b = {orResult}");
        Console.WriteLine($"a ^ b = {xorResult}");
          
        /*
            Bitwise & compares bits directly,
            while logical && works with conditions and can stop
            checking the right side when the left condition is false.
        */
    }

    // Part C: Value Types vs Reference Types
    static void RunValueVsReferenceDemo()
    {
        Console.WriteLine("\n=== Part C: Value vs Reference Types ===");

        /*
            Experiment 1 - Struct copy semantics

            A struct is a value type.
            When p1 is assigned to p2, the values are copied.
            Therefore, changing p2 does not change p1.
        */

        Point p1 = new Point { X = 1, Y = 2 };
        Point p2 = p1;

        p2.X = 99;

        Console.WriteLine("\n--- Experiment 1: Struct ---");
        Console.WriteLine($"p1.X = {p1.X}");
        Console.WriteLine($"p2.X = {p2.X}");


        /*
            Experiment 2 - Class reference semantics

            Order is a class, so it is a reference type.
            When o1 is assigned to o2, the reference is copied,
            not the object itself.
            Therefore, both variables point to the same object on the heap.
        */

        Order o1 = new Order
        {
            OrderId = 1,
            CustomerName = "Ali",
            Quantity = 3,
            UnitPrice = 100m,
            TotalPrice = 0m,
            IsPaid = false,
            DiscountPercent = 10,
            ShippingCity = "Alexandria",
            Priority = 'H',
            ItemCode = 123456L
        };

        o1.CalculateTotal();

        Order o2 = o1;

        o2.IsPaid = true;

        Console.WriteLine("\n--- Experiment 2: Class ---");
        Console.WriteLine($"o1.IsPaid = {o1.IsPaid}");
        Console.WriteLine($"o2.IsPaid = {o2.IsPaid}");

        /*
            Both values are true because o1 and o2 refer to the same
            Order object on the heap.
        */


        /*
            Working with object:

            Order is already a reference type, so assigning it to object
            does not create a new object or perform boxing.
            boxedOrder stores the same reference.
        */

        object boxedOrder = o1;

        Order o3 = (Order)boxedOrder;

        Console.WriteLine(
            $"ReferenceEquals(o1, o3): {object.ReferenceEquals(o1, o3)}");


        /*
            o2.PrintSummary() uses the same Order object.
            Therefore, it reflects the IsPaid change made through o2.
        */

        o2.PrintSummary();


        /*
            Final explanation:

            Value types store their actual values, and assigning one value type
            variable to another copies the value.
            Reference types store a reference to an object, and assigning one
            reference variable to another copies the reference.
            The object itself is stored on the heap, while local variables and
            references are typically associated with stack frames.
            Storing a reference type in an object variable does not create a new
            object because the same reference is stored.
        */
    }
}  
// Part c :
struct Point
{
    public int X;
    public int Y;
}

class Order
{
    public int OrderId;
    public string CustomerName;
    public int Quantity;
    public decimal UnitPrice;
    public decimal TotalPrice;
    public bool IsPaid;
    public double DiscountPercent;
    public string ShippingCity;
    public char Priority;
    public long ItemCode;

    public void CalculateTotal()
    {
        TotalPrice = Quantity * UnitPrice * (decimal)(1 - DiscountPercent / 100);

    }

    public void PrintSummary()
    {
        Console.WriteLine(
            $"OrderId: {OrderId}, Customer: {CustomerName}, " + $"Total: {TotalPrice}, IsPaid: {IsPaid}");

    }
}