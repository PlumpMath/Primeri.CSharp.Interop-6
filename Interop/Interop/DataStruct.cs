using System;
using System.Collections.Generic;

namespace Excel
{
	public class DataStruct
	{
		public List<DataRow> table = new List<DataRow> ();
		public DataStruct ()
		{
			
		}
		public void addRow (string _fname, string _lname, string _age)
		{
			table.Add (new DataRow (_fname, _lname, _age));
		}
		public void printTable ()
		{
			try{
				foreach (DataRow row in table)
				{
					Console.WriteLine(row.firstName + " " + row.lastName + ", " + row.age);
				}


			}catch{
			}
		}




	}
	public class DataRow
	{
		public string _firstName = "";
		public string _lastName = "";
		public string _age = "";


		public DataRow (string __firstName, string __lastName, string __age)
		{
			_firstName = __firstName; _lastName = __lastName; _age = __age;
		}

		public string firstName
		{
			set {_firstName = value; }
			get {return _firstName; }
		}

		public string lastName
		{
			set {_lastName = value; }
			get {return _lastName; }
		}

		public string age
		{
			set {_age = value; }
			get {return _age; }
		}
	}

}

