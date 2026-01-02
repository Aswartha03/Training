
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

// hashing the passwords and validating
// jwt token generation and validating
// role based authorization : middleware usage


value types and ref types : 

Value Types : 
    -> Directly stored the assignable data into the memory 
    -> Stored in stack
    -> Ex : int, double, float , bool , struct , char, enum , Datetime
Ref Types : 
    -> Store the data as a reference 
    -> reference stored in stack
    -> data stored in heap
    -> Ex : classes , Objects , string, array 

AddScoped : 
    -> one instance for every request .
    -> same instance is shared in the entire request
    -> used for DbContext, RequestContext.
AddSingleton :
    -> one instance for entire application
    -> same instance is shared for all routes and requests
    -> used for read - only and logs


Problem : How do we verify an access token from a third party

Access tokens are issued by the authorization server. 
If the token is a JWT, the resource server validates it locally using the issuer’s public key.
If it is opaque, the resource server validates it by calling the authorization server’s introspection endpoint.




DBMS Concepts : 

1 . Introduction :

-> Data vs Information -> 
    Data = raw input , Without meaning ,Ex :  101, Rahul, 85
    Information = useful output, with meaning  , Ex : Roll No 101 – Rahul scored 85 marks
-> Database -> 
    An organized collection of related data 
    stored in tables , rows, and columns
    Ex : student Db will store id, name, marks, course .....
-> DBMS ->
    Software to access the data from database
    Bridge between users and database
    Easy to update , delete, read, create
    Ex : MySQL,Oracle , SQL Server , etc...

2 . Data Models & Database Architecture : how data is structured and viewed inside a database
                                                *****  Data models : 
-> Relational Model -> 
    Data is stored in tables (relations)
    Tables have rows (records) and columns (attributes)
    Uses primary key (uniqueId in every table)
    relationships using foreign keys
-> Hierarchical Model -> 
    Data is stored as tree structure  Ex : Company
                                              └── Department
                                                      └── Employee
    One parent → many children 
    Each child has only one parent
-> Network Model -> 
    Data is stored as graph structure
    A record can have multiple parents
    Ex : One employee works on multiple projects
         One project has multiple employees
                                             ******  Schema vs Instance : 
-> Schema -> 
    Blueprint or Design of Database
    Defines the tables, rows, and columns in Db
    Rarely changes
    Ex : building plan
-> Instance -> 
    Actual data stored in the database at a particular time
    Changes frequently
    Ex : People living in the building
                                *** Three level database architecture : Used to seperate view from users to database
-> Internal level (physical level)
    data is physically stored
    Files, indexes, storage details
-> Conceptual Level (logical level)
    Data is stored in logical structure
    tables, rows and columns
-> External Level (view level)
    User viewing level
    Different users can see different data
                                 ***** Data Independence : Ability to change one level without affecting other levels
-> Physical Data Independence 
    Changes in internal level should not affect conceptual level 
    Ex : Moving furniture without changing house design 
-> Logical Data Independence 
    Changes in conceptual level should not affect external level
    Ex : Adding a new column to a table

3 . Relational Model Concepts :
            
-> Relation (Table)
      A relation is a table in a database
      Contains rows and columns
-> Tuple (Row)
      A tuple is one row in a table
      Represents one record 
-> Attribute (Column)
      An attribute is a column
      Describes a property of data
-> Domain 
      Allowed value for an attribute
      Tells us to enter valid value 
      Ex : Marks -> From 0 to 100
           Course -> Mpc/Bipc/Cec/Hec
Ex : Student Table 
        Relation -> Entire Table
                column1       column2....
                studentId     name     marks   course
       Row ->   101           vinod    85      Mpc
                102           Ganesh   80      Bipc
-> Keys 
    Uniquely identify records and create relationships.
    1 . Super Key
        Any set of attributes that can uniquely identify a row
        Many super keys possible
    2 . Candidate Key
        Minimal Super key
        No extra attributes
        Ex : StudentID , Email
    3 . Primary Key
        candidate key chosen as main key
        Cannot be NULL or duplicate of this key value
        Ex : studentId
    4 . Foreign Key 
        A key in one table that refers to primary key of another table
        Used to create relationships  
        Ex : studentId in Marks Table
    5 . Composite Key 
        A key made of more than one attribute
        Ex : (StudentID + SubjectID)

-> Integrity Constraints 
    Rules to maintain accuracy and consistency of data.
    1. Entity Integrity : 
        Primary key cannot be NULL 
        Ensures each row is identifiable
    2. Referential Integrity : 
        Foreign key must match existing primary key
        Prevents invalid relationships
    3 . Domain Constraints : 
        Attribute values must follow defined domain 
        Ex : Age must >= 0 
             Marks -> 0 - 100 only
4 . SQL Basics : 
    -> Data Definition Language (DDL) : 
        DDL commands are used to define or change the structure of database objects (tables, schemas).
       1 . CREATE : Used to create new database objects
                    Example: tables, databases
       2 . DROP : Used to delete the entire table
                  Structure + data are permanently removed
       3 . ALTER : Used to Update the table structure
                   Add / remove / change columns 
       4 . TRUNCATE : Deletes all rows from a table
                      Table structure remains 
                      Faster than DELETE
    -> Data Manipulation Language (DML) : 
        DML is used to work with the data inside tables
       1. INSERT : Used to add new reports (rows) into the table
       2. UPDATE : Used to modify the existing records
       3. DELETE : Used to delete the rows in the table 
                   Ex : DELETE From Student
                        WHERE StudentId = 103 // Deletes the report of student with studentId equal to 103
    -> Data Query Language (DQL) :   
        DQL is used to fetch (read) the data from the database.
        It does not change data, only displays it.
       1. SELECT : Retrieves data from a table based on the selected attributes
                   * -> Means All Columns 
       2. WHERE : Filters rows based on condition
       3. DISTINCT : Shows only unique results
       4. ORDER BY : Sorts result set
                     Default → ascending (ASC)
                     Descending → DESC
       5 . LIMIT : It limits the rows while displaying
                    Ex : LIMIT 5 -> only displays 5 rows

5. SQL Advanced Concepts : 
   -> Aggregate Functions : 
      Used to perform mathematical calculations on multiple rows and returns single value
    1. COUNT : Count number of rows which matched the given condition
    2. SUM : Adds values of a column
    3. MAX : Returns Largest Value
    4. MIN : Returns Lowest Value
    5. AVG : Calculates average value
   -> GROUP BY & HAVING : 
      Used with aggregate functions to analyze the data group - wise.    
    1. GROUP BY : 
          Groups rows that have same values
          Aggregate functions work per group
    2 . HAVING :         
          Filters groups, not rows
          Used after GROUP BY
          Works with aggregate conditions
   -> JOINS : 
      JOINs are used to combine rows from two or more tables based on a related column.        
    1. INNER JOIN : Returns only matching records from both tables
                    Intersection of tables    
    2. LEFT JOIN : Returns all records from LEFT table
                   Matching records from RIGHT table
                   Non-matching → NULL            
    3. RIGHT JOIN : Returns all records from RIGHT table
                    Matching records from LEFT table
                    Non-matching → NULL
   -> Subqueries : Inner query or nested query
         A subquery is an SQL query inside another SQL query.
         It runs first
         Its result is used by the outer query                                                 
6. Normalization :
    -> Purpose of Normalization 
        Process of organizing data in tables to
            1. Reduce duplicate data (data redundency) : Same data stored multiple times.
            2. Improve data consistency        
            3. Make database easy to maintain
        Ex : | StudentID | Name  | Dept | DeptHead | 
             | 1         | Rahul | CSE  | Kumar    | 
             | 2         | Anita | CSE  | Kumar    |
    -> Problems caused by redundancy : Anomalies
            1.Insertion Anomaly : Cannot insert data without other data.
            2.Update Anomaly : Updating same data in multiple places.
            3.Deletion Anomaly : Deleting data causes loss of important info.
       Solution : Two tables for student and department
    -> Functional Dependency : A determines B
                Ex : If StudentID is known, Name & Dept are known
            Partial Dependency → Depends on part of composite key 
            Transitive Dependency → Depends indirectly 
    -> Normal Forms : 
            1. 1st Normal Forms 
                         No multi - valued attributes
                         Each cell must have atomic (single) value
            2. 2nd Normal Forms 
                         Must be in 1NF
                         No partial dependency
            3. 3rd Normal Form (3NF) 
                         Must be in 2NF
                         No transitive dependency
                         Each non-key depends only on primary key
              
7. Transactions & Concurrency : 
    -> Transaction : A transaction is a set of operations that must be treated as one single unit of work.
    EX : 1. Debit ₹1000 from Account A
         2. Credit ₹1000 to Account B 
        Both must be done.
    -> ACID Properties : Ensures reliability of transactions.
        Atomicity : All or Nothing  
        Consistency – Valid State to Valid State 
        Isolation – Transactions don’t interfere 
        Durability – Once committed, stays forever 
        All or nothing 
        Correctness 
        Independence
        Data persistence 
    -> Concurrency Control : Multiple transactions accessing database at the same time
         Concurrency Control ensures that simultaneous transactions do not corrupt the database.
      
      
      
8. Indexes : 
    Index → Speeds up data retrieval
    View → Virtual table based on query
    Authorization → Controls user access 
    Backup & Recovery → Protects data from failures
    Types : 
        Clustered Index :     
             Sorts and stores the actual table data in index order
             Only one clustered index per table
             Data is physically stored in the order of Id
        Non - Clustered Index : 
             Stored separately from table data
             Can create many non-clustered indexes
             Index points to where the data is stored
        Unique Index : 
             Ensures no duplicate values
        Composite Index : Index on multiple columns 
             Ex : Queries using Name AND Age
        Filtered Index : 
             Index on Specific Rows 
             Ex : Frequently searching adult students
    Checking the Existing Indexes : 
             EXEC sp_helpindex <tablename>;

9. Stored Procedures And Functions :
    -> Stored Procedure : 
           A Stored Procedure is a precompiled set of one or more SQL statements stored in the database.
           That is executed to perform business logic and data manipulation operations.
        Ex : When an employee places an order, a stored procedure saves the order details, 
             reduces the stock quantity, and completes the process in one step
    -> Functions : 
           A Function is a database object that accepts parameters,
           performs calculations or data transformation, and returns a single value or a table. 
           It is mainly used for read-only operations.
        Ex : While generating reports, a function calculates tax or age dynamically inside SELECT queries.

10 . B - tree : Balanced Tree Structure for efficient data searching
           Data is Stored Based on the ID 
        Clustered Index : Data is Directly stored in the Ids itself
        Non - Clustered Index : ID  + Pointer to the original Data 






// CLR -> Common Language Runtime 
// execution flow of c# code 
// value and ref types 
// struct  : A special type of class but it is the value type , 
// value types -> int , numerical , etc...  
// ref Types -> classes , objects , etc...

// what is auth 
// ways to auth
// ways of authorization  
// standards and specifications of oauth , oidc 
// diff cookie and jwt  
// use cases 
// single signout  
// Hashing and Encryption 
// Salt and pepper  
// Req -> context -> builder