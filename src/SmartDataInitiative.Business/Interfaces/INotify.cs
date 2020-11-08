using SmartDataInitiative.Business.Notications;
using System.Collections.Generic;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface INotify
    {
        bool HaveNotifications();
        List<Notify> GetAllNotifications();
        void Handle(Notify notify);
        
    }
}
