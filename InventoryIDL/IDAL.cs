using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryIDL
{
    public interface IDAL
    {
        DataTable GetInventoryList();

        DataTable GetInventoryById(int Id);

        int SaveInventory(string Name, string Description, int Price, string Picture);

        int DeleteInventoryById(int Id);
    }
}
