using System;
using System.IO;
using System.Linq;
using System.Collections.Generic; 

public class Program {

  public static void Main(string[] args) {
    //Create Instantiate
    Method.Menu ExeDisplayMenu = new Method.Menu();
    Method.Menu ExeAuthenticate = new Method.Menu();
    Method.Menu ExeLogin = new Method.Menu();

    while(true){
      //Login Interface
      Console.WriteLine("[0]-Login\t[1]-Register");
      string choice = Console.ReadLine();

      try{
        if(int.Parse(choice) == 0){
          ExeLogin.Login();
          break;
        }
        else{
          Console.WriteLine("Empty");
        }
      }
      catch (Exception){
        Console.WriteLine("Invalid Input");
      }
    }
  }
  class Method{

    public class Menu{
      
      public void DisplayMenu(){
        using StreamWriter sw = File.AppendText("Orders.txt");
        sw.WriteLine("TESTasdasdasdasd");
      }
      public void Login(){
        //variables
        string username,password;
        bool result;

        //Authentication of the user
        while(true){

          //Ask credentials

          //Check if the input is empty
          while(true){
            Console.Write("Username: ");
            username = Console.ReadLine();
            bool returnval = CheckEmpty(username);
            if(returnval == true){
              Console.WriteLine("Cannot be empty, Please try again!");
            }
            else{
              break;
            }
          }
          while(true){
            Console.Write("Password: ");
            password = Console.ReadLine();
            bool returnval = CheckEmpty(username);
            if(returnval == true){
              Console.WriteLine("Cannot be empty, Please try again!");
            }
            else{
              break;
            }
          }

          //call the function to authenticate the account
          result = Authenticate(username,password);
          //check if the return value of result is true
          if(result == true){
            Console.WriteLine("Login Success!");
            break;
          }
          else{
            Console.WriteLine("Invalid Account, Please Try Again!");
          }
        }
        
        //Check the result value
        Console.WriteLine(result);


      }
      public bool Authenticate(string username, string password){
        using StreamReader sr = new StreamReader("Accounts.txt");
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] data = line.Split(';');
            if(data[0] == username && data[1] == password){
              return true;
              break;
            }
            
        }
        return false;
      }
      public bool CheckEmpty(string data){
        if (data == null || data.Trim() == "")
        {
            return true;
        }
        else
        {
            return false;
        }
      }
    }
  }
}