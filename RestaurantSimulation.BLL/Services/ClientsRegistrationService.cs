using RestaurantSimulation.BLL.Models;
using RestaurantSimulation.BLL.Services.CustomExeptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSimulation.BLL.Services
{
    public class ClientsRegistrationService
    {         
        public WaiterService WaiterService { get; private set; } 
        public List<Table> Tables { get; private set; }         

        public ClientsRegistrationService()
        {

            Tables = new List<Table> { new Table { SeatCount = 2, TableNumber = 1, Reserved = false },
                new Table { SeatCount = 2, TableNumber = 2, Reserved = false },
                new Table { SeatCount = 3, TableNumber = 3, Reserved = false },
                new Table { SeatCount = 3, TableNumber = 4, Reserved = false } };
            
            WaiterService = new WaiterService();
            
        }

        public ClientsService AddClients(int visitorsNumber)
        {
            // Find table whith nearest seats count
            var closestTable = Tables.Where(item => item.Reserved == false && item.SeatCount >= visitorsNumber).OrderBy(item => Math.Abs(visitorsNumber - item.SeatCount)).FirstOrDefault();

            if (closestTable == null)
                throw new TableNotFoundException("No matching table found");

            // Indicate that the table is busy            
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Tables.Where(item => item.TableNumber == closestTable.TableNumber).Select(u =>{ u.Reserved = true; return u; }).ToList();


            var clients = new ClientsService {TableNumber = closestTable.TableNumber, WaiterService = WaiterService};

            return clients;          
        }

        public void RemoveClients(int tableNumber)
        {           
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Tables.Where(item => item.TableNumber == tableNumber).Select(u => { u.Reserved = false; return u; }).ToList();
        }
    }
}
