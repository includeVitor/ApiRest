using ApiRestful.Business.Notications;
using System.Collections.Generic;

namespace ApiRestful.Business.Interfaces
{
    public interface INotify
    {
        bool HaveNotifications();
        List<Notify> GetAllNotifications();
        void Handle(Notify notify);
        
    }
}
