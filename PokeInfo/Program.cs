using System;
using System.Collections.Generic;
using System.Linq;
using Poke;
using Newtonsoft.Json;

namespace PokeInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<Pokemon> pokelist = JsonConvert.DeserializeObject<ICollection<Pokemon>>(Properties.Resources.pokedata);
            Console.Write("Enter the Pokemon you wish to look up! ");
            string user = Console.ReadLine();
            //if (user.Equals("t", StringComparison.OrdinalIgnoreCase)) ;
            DisplayStats(pokelist, user);
        }

        private static void DisplayStats(ICollection<Pokemon> pokelist, string user)
        {
            bool found = false;
            Pokemon specimen = null;

            if (user.Equals("q", StringComparison.OrdinalIgnoreCase)) return;

            foreach (Pokemon poke in pokelist)
            {
                if (user.Equals(poke.Name, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    specimen = poke;
                }
            }
            if (found && specimen != null)
            {
                WriteID(specimen);
                WriteType(specimen);
                WriteStats(specimen);
                WriteEffectiveness(specimen);
                Console.WriteLine();
                Console.Write("Enter another Pokemon! ");
                DisplayStats(pokelist, Console.ReadLine());
            }
            else
            {
                Console.Write("Please enter the Pokemon again. ");
                DisplayStats(pokelist, Console.ReadLine());
            }
        }

        private static void WriteID(Pokemon specimen)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("ID: " + specimen.ID);
            Console.WriteLine("Name: " + specimen.Name);
            Console.WriteLine();
        }

        private static void WriteType(Pokemon specimen)
        {
            Console.Write("Type: " + specimen.PrimaryType);
            if (specimen.hasSecondaryType) Console.WriteLine(" / " + specimen.SecondaryType);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void WriteStats(Pokemon specimen)
        {
            Console.WriteLine("Stats:");
            Console.WriteLine("    HP:              " + specimen.HP);
            Console.WriteLine("    Attack:          " + specimen.Attack);
            Console.WriteLine("    Defense:         " + specimen.Defense);
            Console.WriteLine("    Special Attack:  " + specimen.SpecialAttack);
            Console.WriteLine("    Special Defense: " + specimen.SpecialDefense);
            Console.WriteLine("    Speed:           " + specimen.Speed);
            Console.WriteLine();
        }

        private static void WriteEffectiveness(Pokemon specimen)
        {
            Console.WriteLine("Type Effectiveness:");
            PokeType type1 = Constants.TypeDict[specimen.PrimaryType];
            PokeType type2 = Constants.TypeDict[specimen.SecondaryType];

            Console.Write("4x:  ");
            if (specimen.hasSecondaryType) EToString(type1.Weak.Intersect(type2.Weak));
            else Console.WriteLine();

            Console.Write("2x:  ");
            EToString(Exclusive(type1.Weak, type2).Union(Exclusive(type2.Weak, type1)));

            Console.Write("1/2x:");
            EToString(Exclusive(type1.Resist, type2).Union(Exclusive(type2.Resist, type1)));

            Console.Write("1/4x:");
            if (specimen.hasSecondaryType) EToString(type1.Resist.Intersect(type2.Resist));
            else Console.WriteLine();

            Console.Write("0x:  ");
            EToString(type1.Immune.Union(type2.Immune));
        }

        private static IEnumerable<Types> Exclusive(Types[] type, PokeType type1)
        {
            return type.Except(type1.Weak.Union(type1.Resist.Union(type1.Immune)));
        }

        private static void EToString(IEnumerable<Types> enumerable)
        {
            foreach (Types type in enumerable)
            {
                Console.Write(" " + type);
            }
            Console.WriteLine();
        }
    }
}
