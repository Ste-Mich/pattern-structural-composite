using System;
using System.Collections;
using System.Collections.Generic;

/*  Composite je způsob, kterým můžeme objekty skládat do stromu.
 *  - strom je tvořen pomocí TreeComponent. Každý objekt stromu má seznam svých
 */

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var mb = new Motherboard();
            for (int i = 0; i < 4; i++)
                mb.Children.Add(new Screws());

            var ram = new RAM();
            for (int i = 0; i < 4; i++)
                ram.Children.Add(new Screws());
            mb.Children.Add(ram);

            var processor = new Processor();
            var fan = new Fan();
            fan.Children.Add(new Screws());
            processor.Children.Add(fan);
            mb.Children.Add(processor);

            mb.IterateComponents();
        }
    }

    public class Motherboard : TreeComponent
    {
        override public string Name { get; set; } = "Motherboard";
        override public int Price { get; set; } = 500;
    }

    public class Processor : TreeComponent
    {
        override public string Name { get; set; } = "Processor";
        override public int Price { get; set; } = 1650;
    }

    public class Screws : TreeComponent
    {
        override public string Name { get; set; } = "Screw";
        override public int Price { get; set; } = 5;
    }

    public class RAM : TreeComponent
    {
        override public string Name { get; set; } = "RAM";
        override public int Price { get; set; } = 800;
    }

    public class Fan : TreeComponent
    {
        override public string Name { get; set; } = "Fan";
        override public int Price { get; set; } = 100;
    }

    public class TreeComponent : ITreeComponent
    {
        virtual public string Name { get; set; }
        virtual public int Price { get; set; }
        public List<TreeComponent> Children { get; set; } = new();

        public void IterateComponents()
        {
            foreach (var Child in Children)
            {
                Console.WriteLine(Child.Name);
                Child.IterateComponents();
            }
        }
    }

    public interface ITreeComponent
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<TreeComponent> Children { get; set; }
        public void IterateComponents();
    }
}
