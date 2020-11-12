using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Api.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int TimeExpiration { get; set; }

        public string Emitter { get; set; }

        public string ValidatedAt { get; set; }

    }
}
