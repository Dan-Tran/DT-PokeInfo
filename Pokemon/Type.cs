using System;
using System.Collections.Generic;
using System.Linq;

namespace Poke
{
    public enum Types { Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel, Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy, Empty }

    public struct PokeType
    {
        Types _name;
        Types[] _weak;
        Types[] _resist;
        Types[] _immune;

        public PokeType(Types name, Types[] weak, Types[] resist, Types[] immune)
        {
            _name = name;
            _weak = weak;
            _resist = resist;
            _immune = immune;
        }

        public Types Name
        {
            get { return _name; }
        }

        public Types[] Weak
        {
            get { return _weak; }
        }
        public Types[] Resist
        {
            get { return _resist; }
        }
        public Types[] Immune
        {
            get { return _immune; }
        }
        public override string ToString()
        {
            return Enum.GetName(typeof(Types), _name);
        }
    }

    public class Constants
    {
        public static Types[] EmptyTypesArray = new Types[0];
        public static readonly PokeType Normal = new PokeType(Types.Normal, new Types[1] { Types.Fighting }, EmptyTypesArray, new Types[1] { Types.Ghost });
        public static readonly PokeType Fighting = new PokeType(Types.Fighting, new Types[3] { Types.Fairy, Types.Flying, Types.Psychic }, new Types[3] { Types.Bug, Types.Dark, Types.Rock }, EmptyTypesArray);
        public static readonly PokeType Flying = new PokeType(Types.Flying, new Types[3] { Types.Electric, Types.Ice, Types.Rock }, new Types[3] { Types.Bug, Types.Fighting, Types.Grass }, new Types[1] { Types.Ground });
        public static readonly PokeType Poison = new PokeType(Types.Poison, new Types[2] { Types.Ground, Types.Psychic }, new Types[5] { Types.Fighting, Types.Poison, Types.Bug, Types.Grass, Types.Fairy }, EmptyTypesArray);
        public static readonly PokeType Ground = new PokeType(Types.Ground, new Types[3] { Types.Grass, Types.Ice, Types.Water }, new Types[2] { Types.Poison, Types.Rock }, new Types[1] { Types.Electric });
        public static readonly PokeType Rock = new PokeType(Types.Rock, new Types[5] { Types.Fighting, Types.Grass, Types.Ground, Types.Steel, Types.Water }, new Types[4] { Types.Fire, Types.Flying, Types.Normal, Types.Poison }, EmptyTypesArray);
        public static readonly PokeType Bug = new PokeType(Types.Bug, new Types[3] { Types.Fire, Types.Flying, Types.Rock }, new Types[3] { Types.Fighting, Types.Grass, Types.Ground }, EmptyTypesArray);
        public static readonly PokeType Ghost = new PokeType(Types.Ghost, new Types[2] { Types.Dark, Types.Ghost }, new Types[2] { Types.Bug, Types.Poison }, new Types[2] { Types.Normal, Types.Fighting });
        public static readonly PokeType Steel = new PokeType(Types.Steel, new Types[3] { Types.Fighting, Types.Fire, Types.Ground }, new Types[10] { Types.Bug, Types.Dragon, Types.Fairy, Types.Flying, Types.Grass, Types.Ice, Types.Normal, Types.Psychic, Types.Rock, Types.Steel }, new Types[1] { Types.Poison });
        public static readonly PokeType Fire = new PokeType(Types.Fire, new Types[3] { Types.Ground, Types.Rock, Types.Water }, new Types[6] { Types.Bug, Types.Fairy, Types.Fire, Types.Grass, Types.Ice, Types.Steel }, EmptyTypesArray);
        public static readonly PokeType Water = new PokeType(Types.Water, new Types[2] { Types.Electric, Types.Grass }, new Types[4] { Types.Fire, Types.Ice, Types.Steel, Types.Water }, EmptyTypesArray);
        public static readonly PokeType Grass = new PokeType(Types.Grass, new Types[5] { Types.Bug, Types.Fire, Types.Flying, Types.Ice, Types.Poison }, new Types[4] { Types.Electric, Types.Grass, Types.Ground, Types.Water }, EmptyTypesArray);
        public static readonly PokeType Electric = new PokeType(Types.Electric, new Types[1] { Types.Ground }, new Types[3] { Types.Electric, Types.Flying, Types.Steel }, EmptyTypesArray);
        public static readonly PokeType Psychic = new PokeType(Types.Psychic, new Types[3] { Types.Bug, Types.Dark, Types.Ghost }, new Types[2] { Types.Fighting, Types.Psychic }, EmptyTypesArray);
        public static readonly PokeType Ice = new PokeType(Types.Ice, new Types[4] { Types.Fighting, Types.Fire, Types.Rock, Types.Steel }, new Types[1] { Types.Ice }, EmptyTypesArray);
        public static readonly PokeType Dragon = new PokeType(Types.Dragon, new Types[3] { Types.Dragon, Types.Fairy, Types.Ice }, new Types[4] { Types.Electric, Types.Fire, Types.Grass, Types.Water }, EmptyTypesArray);
        public static readonly PokeType Dark = new PokeType(Types.Dark, new Types[3] { Types.Bug, Types.Fairy, Types.Fighting }, new Types[2] { Types.Dark, Types.Ghost }, new Types[1] { Types.Psychic });
        public static readonly PokeType Fairy = new PokeType(Types.Fairy, new Types[2] { Types.Poison, Types.Steel }, new Types[3] { Types.Bug, Types.Dark, Types.Fighting }, new Types[1] { Types.Dragon });
        public static readonly PokeType Empty = new PokeType(Types.Empty, EmptyTypesArray, EmptyTypesArray, EmptyTypesArray);
        public static readonly IDictionary<Types, PokeType> TypeDict = (new PokeType[] { Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel, Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy, Empty }).ToDictionary(t => t.Name);
    }
}
