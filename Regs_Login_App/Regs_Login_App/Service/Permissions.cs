using System;
using System.Collections.Generic;
using System.Text;

namespace Regs_Login_App.Service
{
   public interface Permissions
    {
        bool CheckCamaraPermission();
        bool CheckReadWritePermission();
        void GrantCamaraPremission();
        void GrantReadWritePremission();
    }
}
