using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
	public class NameObject
	{
		public string FullName;
		public string LastName;
	}

	public class Program
    {
		//Method to sort the unordered names
		//Param: array of string consists of names
		public static string[] sortNames(string[] names)
		{
			//Create the list of NameObject
			List<NameObject> nameObjects = new List<NameObject>();

			//Loop through all names
			foreach (string name in names)
			{
				//Create new nameObject
				NameObject nameObject = new NameObject();

				//Store name in the fullname property
				nameObject.FullName = name;

				//Split the name using space
				string[] groupOfNames = name.Split(' ');

				//Get the last name and store it in the LastName property
				nameObject.LastName = groupOfNames[groupOfNames.Length - 1];

				//Add the nameObject into nameObjects list
				nameObjects.Add(nameObject);
			}

			//Sort nameObjects using last name
			string[] sortedNames = nameObjects.OrderBy(x => x.LastName).Select(x => x.FullName).ToArray();

			return sortedNames;
		}

		public static void Main(string[] args)
        {
            //Check if there's any args passed
            if (args.Any())
            {
				//Read the first args as file name parameter
				var fileName = args[0];

				//Check whether the file exist or not
				if (File.Exists(fileName))
				{
					//Read the file
					string[] names = System.IO.File.ReadAllLines(fileName);

					//Pass the names into sortNames method and get the sortedNames value
					var sortedNames = sortNames(names);

					//Loop through all sortedNames and print it on the screen
					foreach (string name in sortedNames)
					{
						System.Console.WriteLine(name);
					}

					//Write the sortedNames into file
					System.IO.File.WriteAllLines(@"sorted-names-list.txt", sortedNames);
				}
				else
				{
					System.Console.WriteLine("File does not exist");
				}
			}
			else
			{
				System.Console.WriteLine("No file to be processed");
			}
		}
	}
}
