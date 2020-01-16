//////////////////////////////////////////////////////////////////////////////////
// HW 4 : EX 02
// CS371 - Whitworth University
// Originally outlined by: Bishesh Tuladhar
// Worked With : Sabin Sapkota & Novel Poudel
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using cs371entityframework.Models;

namespace cs371entityframework
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    MySqlDb fleet = new MySqlDb("db4free.net", "cs371student", "whitworth", "cs371ado");
                    fleet.OpenConnection();
                    Console.Clear();
                    Console.WriteLine("CONNECTION ESTABLISHED");
                    List<Ship> ships = fleet.GetAllShips();
                    foreach (Ship s in ships)
                    {
                        Console.WriteLine("{0} has registration number {1}", s.Name, s.Registration);
                    }

                    List<Roster> fullRosters = fleet.FullRoster(); //creating full roster
                    List<Roster> pilotRosters = fleet.PilotRoster(); //creating pilot roster

                    Console.WriteLine("********* Full Roster ************* ");
                    //printing the full rosters
                    foreach (Roster f in fullRosters)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", f.Name, f.Age, f.Role, f.ShipName, f.RegNum);
                    }
                    Console.WriteLine();

                    //printing the pilot rosters
                    Console.WriteLine("********* Pliot Roster ************* ");
                    foreach (Roster r in pilotRosters)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", r.Name, r.Age, r.Role, r.ShipName, r.RegNum);
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Connection failed: {0}", e.Message);
                }
            } while (true);
        }
    }
}
