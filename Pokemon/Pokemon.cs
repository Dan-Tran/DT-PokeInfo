using System;

namespace Poke
{
    public class Pokemon
    {
        private int _id;
        private string _name;
        private Types _primaryType;
        private Types _secondaryType;
        private int _HP, _attack, _defense, _specialAttack, _specialDefense, _speed;
        private int _generation;
        private bool _isLegendary;

        public Pokemon(int id, string name, Types primaryType, Types secondaryType, int HP, int attack, int defense, int specialAttack, int specialDefense, int speed, int generation, bool isLegendary)
        {
            if (name == null)
            {
                throw new NullReferenceException();
            }

            _id = id;
            _name = name;
            _primaryType = primaryType;
            _secondaryType = secondaryType;
            _HP = HP;
            _attack = attack;
            _defense = defense;
            _specialAttack = specialAttack;
            _specialDefense = specialDefense;
            _speed = speed;
            _generation = generation;
            _isLegendary = isLegendary;
        }

        public int ID
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Types PrimaryType
        {
            get { return _primaryType; }
        }

        public Types SecondaryType
        {
            get { return _secondaryType; }
        }

        public bool hasSecondaryType
        {
            get { return _secondaryType != Types.Empty; }
        }

        public int HP
        {
            get { return _HP; }
        }

        public int Attack
        {
            get { return _attack; }
        }

        public int Defense
        {
            get { return _defense; }
        }

        public int SpecialAttack
        {
            get { return _specialAttack; }
        }

        public int SpecialDefense
        {
            get { return _specialDefense; }
        }

        public int Speed
        {
            get { return _speed; }
        }

        public int Total
        {
            get { return _HP + _attack + _defense + _specialAttack + _specialDefense + _speed; }
        }

        public int Generation
        {
            get { return _generation; }
        }

        public bool IsLegendary
        {
            get { return _isLegendary; }
        }
    }
}
