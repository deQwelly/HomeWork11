using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_2_.Classes
{
    internal class DevAndOrgInfoAttribute : Attribute
    {
        public string DevName { get; private set; }
        public string OrgName { get; private set; }

        public DevAndOrgInfoAttribute(string devName, string orgName)
        {
            DevName = devName;
            OrgName = orgName;
        }

        public override string ToString()
        {
            return $"{DevName} {OrgName}";
        }
    }
}
