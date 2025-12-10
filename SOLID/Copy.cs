using System;
namespace COPY
{
	// Shallow Copy and Deep Copy
	public class Copy
	{
		class Employee
		{
			public string Name;
			public Address Address;
			public Employee(string name , Address address)
			{
				Name = name;
				Address = address;
			}
			public Employee DeepCopy()
			{
				return new Employee
				{
					Name = this.Name,
					Address = new Address(this.Address.City)
				}
			};
		}
		class Address
		{
			public string City;
			public Address(string city)
			{
				City = city;
			}
		}

		static public void Main()
		{
			// Creating First Employee Object
			Employee employee1 = new Employee("Employee1", new Address("Employee1 City"));
			Console.WriteLine(employee1.Name); // Employee1
			Console.WriteLine(employee1.Address.City) // Employee1 City 


			// shallow copying the employee1 object 

			Employee employee2 = s1;
			employee2.Name = "Employee2";
			employee2.Address.City = "Employee2 City";
			// Trying to print the employee 1 details . but due to shallow copy we will get employee 2 details
			// Shallow Copy will copies only references not Direct object.

			Console.WriteLine(employee1.Name); // Employee2
			Console.WriteLine(employee1.Address.City) // Employee2 City 


			// Deep Copying the employee1 object 

			Employee employee3 = s2.DeepCopy(); // Creating the new Object of s2 not reference 
			employee3.Name = "Employee3";
			employee3.Address.City = "Employee3 City";

			Console.WriteLine(employee1.Name); // Employee2
			Console.WriteLine(employee1.Address.City) // Employee2 City 
		}
	}
}
