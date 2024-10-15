using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12interface
{
    interface IdbHandler
    {
        //meg kell adni milyen függvények lesznek a dbHandler-en belül, ezeket nem itt hanem a dbHandlerben csináljuk meg
        void ReadAll();
        void InsertOne(user oneUser);
        void DeleteOne(user oneUser);
        void DeleteAll();
        void UpdateOne(user oneUser);
    }
}
