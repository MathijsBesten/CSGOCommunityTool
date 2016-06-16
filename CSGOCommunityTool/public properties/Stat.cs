using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOCommunityTool.public_properties
{

    public class Stat
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class Achievement
    {
        public string name { get; set; }
        public int achieved { get; set; }
    }

    public class Playerstats
    {
        public string steamID { get; set; }
        public string gameName { get; set; }
        public List<Stat> stats { get; set; }
        public List<Achievement> achievements { get; set; }
    }

    public class RootObject
    {
        public Playerstats playerstats { get; set; }
    }

}
