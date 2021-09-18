using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explore_the_house
{
    interface IHidingPlace
    {
        string HidingPlaceName { get; }
    }
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

    class RoomWithHidingPlace : Room, IHidingPlace
    {
        public RoomWithHidingPlace(string name, string decoration, string hidingPlaceName) : base(name, decoration)
        {
            this.hidingPlaceName = hidingPlaceName;
        }

        private string hidingPlaceName;
        public string HidingPlaceName
        {
            get { return hidingPlaceName; }
        }
        public override string Description
        {
            get { return base.Description + " Someone could hide " + hidingPlaceName + ".";

            }
        }
    }

    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string hidingPlaceName,string doorDescription) : base(name, decoration, hidingPlaceName)
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

    class OutsideWitchHidingPlace : Outside, IHidingPlace
    {
        public OutsideWitchHidingPlace (string name, bool hot, string hidingPlaceName):base(name, hot)
        {
            this.hidingPlaceName = hidingPlaceName;
        }

        private string hidingPlaceName;
    }
}
