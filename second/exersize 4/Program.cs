 using System;

namespace EquipmentInventory
{
    public enum EquipmentType
    {
        Mobile,
        Immobile
    }

    public interface IEquipment
    {
        string Name { get; set; }
        string Description { get; set; }
        int DistanceMoved { get; set; }
        int MaintenanceCost { get; set; }
        EquipmentType EquipmentType { get; set; }

        void MoveBy(int distance);
        void DisplayDetails();
    }

    public abstract class Equipment : IEquipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DistanceMoved { get; set; }
        public int MaintenanceCost { get; set; }
        public EquipmentType EquipmentType { get; set; }

        public Equipment(string name, string description, EquipmentType equipmentType)
        {
            Name = name;
            Description = description;
            EquipmentType = equipmentType;
        }

        public abstract void MoveBy(int distance);

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Description: {Description}, Distance Moved: {DistanceMoved} km, Maintenance Cost: {MaintenanceCost}");
        }
    }

    public class MobileEquipment : Equipment
    {
        public int NumberOfWheels { get; set; }

        public MobileEquipment(string name, string description, int numberOfWheels) : base(name, description, EquipmentType.Mobile)
        {
            NumberOfWheels = numberOfWheels;
        }

        public override void MoveBy(int distance)
        {
            DistanceMoved += distance;
            MaintenanceCost += (NumberOfWheels * distance);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Number of Wheels: {NumberOfWheels}");
        }
    }

    public class ImmobileEquipment : Equipment
    {
        public int Weight { get; set; }

        public ImmobileEquipment(string name, string description, int weight) : base(name, description, EquipmentType.Immobile)
        {
            Weight = weight;
        }

        public override void MoveBy(int distance)
        {
            DistanceMoved += distance;
            MaintenanceCost += (Weight * distance);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Weight: {Weight}");
        }
    }

    public class EquipmentManager
    {
        private IEquipment[] equipments;

        public EquipmentManager(int size)
        {
            equipments = new IEquipment[size];
        }

        public void AddEquipment(IEquipment equipment)
        {
            for (int i = 0; i < equipments.Length; i++)
            {
                if (equipments[i] == null)
                {
                    equipments[i] = equipment;
                    break;
                }
            }
        }

        public void MoveEquipment(int index, int distance)
        {
            equipments[index]?.MoveBy(distance);
        }

        public void DisplayEquipmentDetails(int index)
        {
            equipments[index]?.DisplayDetails();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EquipmentManager manager = new EquipmentManager(5);

            MobileEquipment jcb = new MobileEquipment("JCB", "A construction vehicle", 4);
            ImmobileEquipment ladder = new ImmobileEquipment("Ladder", "A climbing aid", 10);

            manager.AddEquipment(jcb);
            manager.AddEquipment(ladder);

            manager.MoveEquipment(0, 10);
            manager.MoveEquipment(1, 5);

            manager.DisplayEquipmentDetails(0);
            manager.DisplayEquipmentDetails(1);

            Console.ReadKey();
        }
    }
}
