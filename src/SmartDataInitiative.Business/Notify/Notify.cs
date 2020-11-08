using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Notify
{
    public class Notify 
    {
        public string Mesage { get; set; }

        public Notify(string mesage)
        {
            Mesage = mesage;
        }
    }
}
