using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface Notify
    {
        bool HaveNotifications();
        List<Notify> GetAllNotifications();
        void Handle(Notify notify);
        
    }
}
