using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Console;

namespace Programming5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1
            string[] nameList = { "Sean", "Zane", "Amara", "Moze", "Flak", "Maya" };

            Console.WriteLine("Original Array");
            foreach(string name in nameList)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            List<string> listResult = QueryOverNames(nameList);

            Console.WriteLine("results from query after making adjustments");
            foreach(string n in listResult)
            {
                Console.WriteLine("Name: {0}", n);
            }
            #endregion
            #region Problem 2
            WriteLine("DataSets");

            var carsInventoryDS = new DataSet("Car Inventory");
            carsInventoryDS.ExtendedProperties["Timestamp"] = DateTime.Now;
            carsInventoryDS.ExtendedProperties["DatasetID"] = Guid.NewGuid;
            carsInventoryDS.ExtendedProperties["Company"] = "Sean's Stuff";

            FillDataSet(carsInventoryDS);
            PrintDataSet(carsInventoryDS);

            ReadLine();

            SaveAndLoadAsXml(carsInventoryDS);
            #endregion
        }

        #region Problem 1
        static List<string> QueryOverNames(string [] inputArray)
        {
            var subset = from name in inputArray
                         where(name.Contains("A") || name.Contains("F"))
                         select name;

            Console.WriteLine("Immediate results, names starting with A or F");
            foreach(var n in subset)
            {
                Console.WriteLine("Name: {0}", n);
            }
            Console.WriteLine();

            inputArray[0] = "Fred";
            inputArray[5] = "Alex";
            Console.WriteLine("Change to Array - Add new names");
            foreach(var n in subset)
            {
                Console.WriteLine("Name: {0}", n);
            }
            Console.WriteLine();


            List<string> outputList = (from name in inputArray
                                       where(name.Contains("A") || name.Contains("F"))
                                       orderby name
                                       select name).ToList<string>();
            return outputList;
          
        }
        #endregion

        #region Problem 2
        private static void ManipulatedataRowState()
        {
            var temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            var row = temp.NewRow();
            WriteLine($"After calling NewRow(): {row.RowState}");

            temp.Rows.Add(row);
            WriteLine($"After calling Rows.Add(): {row.RowState}");

            row["TempColumn"] = 10;
            WriteLine($"After first assignment: {row.RowState}");

            temp.AcceptChanges();
            WriteLine($"After calling AcceptChanges(): {row.RowState}");

            row["TempColumn"] = 11;
            WriteLine($"After first assignment: {row.RowState}");

            temp.Rows[0].Delete();
            WriteLine($"After calling Delete(): {row.RowState}");
        }

        static void FillDataSet(DataSet ds)
        {
            var carIDColumn = new DataColumn("CarID", typeof(int))
            {
                Caption = "Car ID",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };

            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));
            var carPetNameColumn = new DataColumn("PetName", typeof(string))
            { Caption = "Pet Name" };

            var inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new[] {carIDColumn, carMakeColumn,
            carColorColumn, carPetNameColumn});

            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["Pet Name"] = "Hamlet";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            carRow[1] = "Honda";
            carRow[2] = "Blue";
            carRow[3] = "Lady";
            inventoryTable.Rows.Add(carRow);

            inventoryTable.PrimaryKey = new[] { inventoryTable.Columns[0] };
            ds.Tables.Add(inventoryTable);
        }

        static void PrintDataSet(DataSet ds)
        {
            WriteLine($"Dataset is names: {ds.DataSetName}");
            foreach(DictionaryEntry de in ds.ExtendedProperties)
            {
                WriteLine($"Key = {de.Key}, Value = {de.Value}");
            }
            WriteLine();
            foreach(DataTable dt in ds.Tables)
            {
                WriteLine($"=> {dt.TableName} Table");

                for(var curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Write($"{dt.Columns[curCol].ColumnName}\t");
                }
                WriteLine("*********************************");

                for(var curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for(var curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Write($"{dt.Rows[curRow][curCol]}\t");
                    }
                    WriteLine();
                }

            }

        }
        static void SaveAndLoadAsXml(DataSet carsInventoryDS)
        {
            carsInventoryDS.WriteXml("carsDataSet.xml");
            carsInventoryDS.WriteXmlSchema("carsDataSet.xsd");
        }
        #endregion Problem 2
    }

}
