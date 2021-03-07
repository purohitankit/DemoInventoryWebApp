//using CommonDLLs;
using InventoryIBL;
//using InventoryIDL;
using InventoryDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL
{
    public class BAL:IBAL
    {
        //IDAL idatalayer = ObjectFactory.GetInstance("IDAL") as IDAL;
        DAL idatalayer = new DAL();


        public DataTable GetInventoryList()
        {
            return idatalayer.GetInventoryList();
        }

        public DataTable GetInventoryById(int Id)
        {
            return idatalayer.GetInventoryById(Id);
        }

        public int SaveInventory(string Name, string Description, int Price, string Picture)
        {
            return idatalayer.SaveInventory(Name, Description, Price, Picture);
        }

        public int DeleteInventoryById(int Id)
        {
            return idatalayer.DeleteInventoryById(Id);
        }      
    }
}
