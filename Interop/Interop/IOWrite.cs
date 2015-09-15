using System;
using interopExcel = Microsoft.Office.Interop.Excel;


namespace Excel
{
	public class IOWrite
	{

		private DataStruct _data;
		private interopExcel.Application excel;

		public IOWrite (DataStruct data)
		{
			
		}

		public bool exportTable()
		{
			try{
				//Подготовка
				excel = interopExcel.Application ();
				if (excel == null) return false;

				interopExcel.Workbook workbook = excel.Workbooks.Add();
				if (workbook == null) return false;

				//Попълване на таблицата





				//Запаметяване и затваряне
				workbook.SaveCopyAs(getPath());
				excel.DisplayAlerts = false;  // изключваме всички съобщения на Excel
				workbook.Close();
				excel.Quit();
				return true;
				}catch
			{
				return false;
			}
		}

		public void addRow(DataRow _row)
		{
			try{
			

			}catch{
			}
		}
		public virtual void runFile()
		{
			try{
				System.Diagnostics.Process.Start(getPath());

			}catch{
			}
		}
		private string getPath ()
		{
			return System.IO.Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "table1.xlsx");
		}
	}
}

