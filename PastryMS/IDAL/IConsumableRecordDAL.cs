using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public  interface IConsumableRecordDAL:IBaseDAL<ConsumableRecord>
    {
        DbSet<ConsumableRecord> GetConsumableRecords();
    }
}
