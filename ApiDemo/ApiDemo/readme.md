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
