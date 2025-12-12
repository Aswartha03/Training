// get , post -> Retriving Data Difference 
// API , REST API  , GraphQL , Sockets


From Body , From Query

[FromBody] 
 -> Data comes from the Request Body 
 -> Used for POST , PUT , PATCH requests 
 -> Data is in JSON Format 
 -> Postman - Body - Raw - JSON 

Example Api Method : Post Request : https://localhost:7242/student/add-student
Data in Request : 
            {
                "name": "Vijay",
                "age": 29
            }
Accessing Data :



[FromQuery]
 -> Data comes from the Query String in the URL 
 -> Used for GET requests 
 -> Data is in Key-Value Pairs
 -> Used For Filtering , Sorting , Pagination 
 Example Api Method : Get Request : https://localhost:7242/student/get-student?name=Vijay&age=29

Accessing Data :    



Difference Between throw and throw new Exception();

1. throw :
   - Used to re-throw the current exception 
   - Preserves the original stack trace 
   - Syntax : 
         try
         {
             // code that may throw an exception
         }
         catch (Exception ex)
         {
             throw; 
         }
  2. throw new Exception() :
   - Used to throw a new exception 
   - Resets the stack trace to the point where the new exception is thrown 
   - Syntax : 
         try
         {
             // code that may throw an exception
         }
         catch (Exception ex)
         {
             throw new Exception("New exception message", ex); 
         }


Wrappers :
Wrappers are classes or functions that encapsulate other classes or functions to provide additional functionality, modify behavior, or simplify usage.
They act as intermediaries between the client code and the underlying implementation.
Example of a Wrapper Class in C# :
   public class LoggerWrapper
{
    private readonly ILogger _logger;
    public LoggerWrapper(ILogger logger)
    {
        _logger = logger;
    }
    public void LogInfo(string message)
    {
        _logger.LogInformation(message);
    }
    public void LogError(string message, Exception ex)
    {
        _logger.LogError(ex, message);
    }
}

Attributes :

Attributes are metadata added to code elements (classes, methods, properties) to provide additional information or modify behavior at runtime.
They are defined using square brackets [] and can be accessed via reflection.


Static keyword :
The static keyword in C# is used to declare members (methods, properties, fields) that belong 
to the type itself rather than to a specific instance of the type.
Static members can be accessed without creating an instance of the class.   
Example of Static Method :
   public class MathUtilities
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}       
Usage :
   int sum = MathUtilities.Add(5, 10);
  
