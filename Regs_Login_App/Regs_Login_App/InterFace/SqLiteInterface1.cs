using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regs_Login_App.InterFace
{
   public interface SqLiteInterface1
    {

        SQLiteConnection CreateConnection();    
    }
}
