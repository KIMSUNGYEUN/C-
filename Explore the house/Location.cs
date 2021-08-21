using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explore_the_house
{
    abstract class Location
    {
        public Location(string name)
        {
            this.name = name;
        }
        public Location[] Exits;
        private string name;
        public string Name
        {
            get { return name; }
        }
        public virtual string Description
        {
            get
            {
                string description = "You're standing in the " + name + ". You see exits to the following places: ";
                for(int i =0; i< Exits.Length; i++)
                {
                    description += " " + Exits[i].Name;
                    if (i != Exits.Length - 1)
                        description += ",";
                }
                description += ".";
                return description;
            }
        }
    }
}
