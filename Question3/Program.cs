// See https://aka.ms/new-console-template for more information
using Question3;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        //string variable to create the path of the csv file.
        string filePath = @"C:\Users\johan\OneDrive\Escritorio\Programming 3\Assignments\301216096(Lema)_Lab01\Medals.csv";


        //Creating a list with the class we just created to populate our data.   
        List<Medal> AthleteList = new List<Medal>();

        //Reading the lines in our file, and converting in a list and saving in the lines variable
        List<string> lines = File.ReadAllLines(filePath).ToList();


        //foreach loop to iterate throug the list string.
        foreach (var line in lines)
        {
            //Split the lines into multiple entries
            string[] entries = line.Split(',');

            //Create a new medal entry
            Medal newMedal = new Medal();

            //We are going to populate depending on the properties we created previously.
            newMedal.Athlete = entries[0];
            newMedal.Year = entries[1];
            newMedal.GoldMedal = entries[2];
            newMedal.SilverMedal = entries[3];
            newMedal.BronzeMedal = entries[4];

            //Add to our athlete list.
            AthleteList.Add(newMedal);
        }

        //foreach loop to read our csv file.
        foreach (var entry in AthleteList)
        {
            Console.WriteLine($"\nAthlete:{entry.Athlete}\nYear:{entry.Year}\nGold M:{entry.GoldMedal}\nSilver M:{entry.SilverMedal}\nBronce M:{entry.BronzeMedal}");
        }


        //Using addRecord method to add a new record in our csv file
        //addRecord("Esteban Dido", "2014", "13", "5", "2", filePath);

        ////Using addRecord method to add another record in our csv file
        ////addRecord("Gerardo Munoz", "2012", "13", "14", "15", filePath);

        Console.WriteLine();
        Console.WriteLine("Data Created in the last block above");

        //Using searchRecord method to find an specific row in our csv file.
        Console.WriteLine();
        Console.WriteLine("Looking for the data:");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"{string.Join(" ", searchRecord("Barbara Mensing", filePath, 1))}");
        Console.WriteLine("------------------------------------------");

        ////Using deleteRecord method to delete a record in our csv file
        deleteRecord("Rod White", filePath, 1);

        Console.ReadKey();


        //add Record method with 6 parameters we need to pass and read our csv file
        static void addRecord(string athlete, string year, string medal1, string medal2, string medal3, string filePath)
        {
            //try and catch 
            try
            {
                //StreamWriter with an object called file. 
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath, true))
                {
                    //Our object will separate each parameter through a comma.
                    file.WriteLine($"{athlete},{year},{medal1},{medal2},{medal3}");
                }

            }
            //Catch to know what our exception is.
            catch (Exception ex)
            {
                throw new ApplicationException($"{ex}");
            }
        }

        static string[] searchRecord(string searchTerm, string filePath, int positionTerm)
        {
            //positionTerm-- to reduce 1 in our array since arrays starts with 0
            positionTerm--;

            //Create an error if th record is not found.
            string[] recordNotFound = { "Record Not Found" };
            try
            {
                //string array variable to store every single line in the file.
                string[] lines = System.IO.File.ReadAllLines(@filePath);

                //for loop to iterate in through the previuos array 
                for (int i = 0; i < lines.Length; i++)
                {

                    //split method that will allow us to analyze each element individually
                    string[] fields = lines[i].Split(',');
                    if (recordMatches(searchTerm, fields, positionTerm))
                    {
                        return fields;
                    }
                }
                return recordNotFound;
            }
            //Exception if the data is not found 
            catch (Exception ex)
            {

                Console.WriteLine("Record not found");
                return recordNotFound;
                throw new ApplicationException($"{ex}");
            }
        }
        static bool recordMatches(string searchTerm, string[] record, int positionOfSearchTerm)
        {
            //If statement to check if record exists.
            if (record[positionOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }

        static void deleteRecord(string searchTerm, string filePath, int positionOfSearchTerm)
        {
            //positionTerm-- to reduce 1 in our array since arrays starts with 0
            positionOfSearchTerm--;

            //file to store our data temporarly
            string tempFile = @"C:\Users\johan\OneDrive\Escritorio\Programming 3\Assignments\301216096(Lema)_Lab01\TempFile.csv";

            bool deleted = false;
            try
            {
                //array string to read our csv file.
                string[] lines = System.IO.File.ReadAllLines(@filePath);


                //for loop to iterate through the whole csv file 
                for (int i = 0; i < lines.Length; i++)
                {
                    //Array string to separate each element in our medal list
                    string[] fields = lines[i].Split(',');

                    //if statement to verify if the record to match exists 
                    if (!(recordMatches(searchTerm, fields, positionOfSearchTerm)) || deleted)
                    {
                        addRecord(fields[0], fields[1], fields[2], fields[3], fields[4], @tempFile);
                    }
                    else
                    {
                        deleted = true;
                    }
                }
                //Delete filePath and replace in the tempFile
                File.Delete(@filePath);
                System.IO.File.Move(tempFile, filePath);

            }
            //Exception if the data is not found
            catch (Exception ex)
            {
                Console.WriteLine($"Sorry record not found.");
                throw new ApplicationException($"{ex}");
            }
        }
    }
}