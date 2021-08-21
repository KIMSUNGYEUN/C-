using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explore_the_house
{
    interface IHasExteriorDoor
    {
        string DoorDescription
        {
            get;
        }
        Location DoorLocation { get; set; }
    }
    class Room : Location
    {
        private string decoration;

        public Room(string name, string decoration) : base(name)
        {
            this.decoration = decoration;
        }
        public override string Description
        {
            get
            {
                return base.Description + "You see " + decoration + ".";
            }
        }
    }

    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string doorDescription) : base(name, decoration)
        {
            this.doorDescription = doorDescription;
        }

        private string doorDescription;
        public string DoorDescription
        {
            get { return doorDescription; }
        }

        private Location doorLocation;
        public Location DoorLocation
        {
            get { return doorLocation; }
            set { doorLocation = value; }
        }
    }
}
