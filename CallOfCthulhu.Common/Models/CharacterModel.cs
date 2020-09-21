using System;
using System.Collections.Generic;

namespace CallOfCthulhu.Common
{
    public class CharacterModel
    {
        public CharacterDetails CharacterDetails { get; }
        public Characteristics Characteristics { get; set; }
        public VariableStats VariableStats { get; set; }
        public InvestigatorSkills Skills { get; set; }
        public Weapons Weapons { get; set; }
        public CombatStats CombatStats { get; set; }

        public CharacterModel()
        {
            CharacterDetails = new CharacterDetails();
            Characteristics = new Characteristics();
            VariableStats = null;
            Skills = null;
            Weapons = new Weapons();
            CombatStats = null;
        }
    }



    public class CharacterDetails
    {
        public string CampaignSetting { get; set; }
        public string Name { get; set; }
        public string Player { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Residence { get; set; }
        public string Birthplace { get; set; }

        public IEnumerable<string> GetFriendlyPropertyNames()
        {
            return new List<string>
            {
                "Campaign Setting",
                "Name",
                "Player",
                "Occupation",
                "Age",
                "Sex",
                "Residence",
                "Birthplace"
            };
        }
    }

    public class Characteristics 
    {
        public int Strength { get; set; }
        public int Constitution { get; set; }
        public int Size { get; set; }
        public int Dexterity { get; set; }
        public int Apperance { get; set; }
        public int Inteligent { get; set; }
        public int Willpower { get; set; }
        public int Education { get; set; }
        public int MoveRate { get; set; }

        public int CalculateMoveRate(int age)
        {
            //TODO: There are more penalties in the rulebook.
            var ageModifier = age >= 40 ? -1 : 0;

            if (Strength < Size && Dexterity < Size)
                return 7 + ageModifier;

            if (Strength > Size && Dexterity > Size)
                return 9 + ageModifier;

            return 8 + ageModifier;
        }
    }

    public class VariableStats 
    {
        public HitPoints HitPoints { get; set; }
        public Sanity Sanity { get; set; }
        public MagicPoints MagicPoints { get; set; }
        public Luck Luck { get; set; }

        public VariableStats(int constitution, int size, int willpower, int age)
        {
            HitPoints = new HitPoints(constitution, size);
            Sanity = new Sanity(willpower);
            MagicPoints = new MagicPoints(willpower);
            Luck = new Luck(age);
        }
    }
    public class HitPoints
    {
        public int Maximum { get; set; }
        public int Current { get; set; }
        public bool HasMajorWound { get; set; }
        public bool IsDying { get; set; }

        public HitPoints(int constitution, int size)
        {
            Maximum = (constitution + size) / 10;
            Current = (constitution + size) / 10;
            HasMajorWound = false;
            IsDying = false;
        }
    }
    public class Sanity
    {
        public int Maximum { get; set; }
        public int Current { get; set; }
        public bool IsTemporarilyInsane { get; set; }
        public bool IsIndefinitelyInsane { get; set; }

        public Sanity(int willpower)
        {
            Maximum = willpower;
            Current = willpower;
            IsTemporarilyInsane = false;
            IsIndefinitelyInsane = false;
        }
    }
    public class MagicPoints
    {
        public int Maximum { get; set; }
        
        public int Current { get; set; }

        public MagicPoints(int willpower)
        {
            Maximum = willpower / 5;
            Current = willpower / 5;
        }
    }
    public class Luck
    {
        public int Maximum { get; set; }
        public int Current { get; set; }

        public Luck(int age)
        {
            var firstRoll = DiceRoller.DiceRoller.RollDice("3d6") * 5;
            var secondRoll = DiceRoller.DiceRoller.RollDice("3d6") * 5;

            var result = age >= 20
                ? firstRoll
                : Math.Max(firstRoll, secondRoll);

            Maximum = result;
            Current = result;
        }
    }

    public class InvestigatorSkills : List<SkillModel>
    {
        public InvestigatorSkills(int dexterity, int education) : base()
        {
            Add7eSkills(dexterity, education);
        }
        private void Add7eSkills(int dexterity, int education)
        {
            Add(new SkillModel 
            { 
                Name = "Accounting",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "Anthropology",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "Appraise",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "Archaeology",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "ArtCraft",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "Charm",
                Score = 15
            });
            Add(new SkillModel 
            { 
                Name = "Climb",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "CreditRating",
                Score = 0
            });
            Add(new SkillModel 
            { 
                Name = "CthulhuMythos",
                Score = 0
            });
            Add(new SkillModel 
            { 
                Name = "Disguise",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "Dodge",
                Score = dexterity / 2
            });
            Add(new SkillModel 
            { 
                Name = "DriveAuto",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "ElectricalRepair",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "FastTalk",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "FightingBrawl",
                Score = 25
            });
            Add(new SkillModel 
            { 
                Name = "FirearmsHandgun",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "FirearmsRifleShotgun",
                Score = 25
            });
            Add(new SkillModel 
            { 
                Name = "FirstAid",
                Score = 30
            });
            Add(new SkillModel 
            { 
                Name = "History",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "Intimidate",
                Score = 15
            });
            Add(new SkillModel 
            { 
                Name = "Jump",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "LanguageOther",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "LanguageOwn",
                Score = education
            });
            Add(new SkillModel 
            { 
                Name = "Law",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "LibraryUse",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "Listen",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "Locksmith",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "MechanicalRepair",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "Medicine",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "NaturalWorld",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "Navigate",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "Occult",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "OperateHeavyMachinery",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "Persuade",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "Pilot",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "Psychology",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "Psychoanalysis",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "Ride",
                Score = 5
            });
            Add(new SkillModel 
            { 
                Name = "Science",
                Score = 1
            });
            Add(new SkillModel 
            { 
                Name = "SleightOfHand",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "SpotHidde",
                Score = 25
            });
            Add(new SkillModel 
            { 
                Name = "Stealth",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "Survival",
                Score = 10
            });
            Add(new SkillModel 
            { 
                Name = "Swim",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "Throw",
                Score = 20
            });
            Add(new SkillModel 
            { 
                Name = "Track",
                Score = 10
            });
        }
    }
    public class SkillModel
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
        public int ScoreFumble => Score < 50 ? 96 : 100;
        public int Score { get; set; }
        public int ScoreHard => Score / 2;
        public int ScoreExtreme => Score / 5;
    }

    public class Weapons : List<Weapon>
    {
        public Weapons()
        {
            Add(new Weapon
            {
                Name = "Unarmed",
                Damage = "1d3",
                AddDamageBonusToDamage = true,
                Range = 0,
                Ammo = null,
                Malfunction = 100
            });
        }
    }
    public class Weapon
    {
        public string Name { get; set; }
        public int Regular { get; set; }
        public int Hard { get; set; }
        public int Extreme { get; set; }
        public string Damage { get; set; }
        public bool AddDamageBonusToDamage { get; set; }

        //TODO: Figure out units
        public int Range { get; set; }

        //TODO: Figure this out
        public Object AttacksPerRound { get; set; }
        public int? Ammo { get; set; }
        /// <summary>
        /// The chance to not malfunction
        /// </summary>
        public int Malfunction { get; set; }
    }

    public class CombatStats 
    {
        public string DamageBonusDieRoll { get; set; }
        public int Build { get; set; }
        //Note: Dodge comes from Skills

        public CombatStats(int strength, int size)
        {
            //TODO: More build ranges in rulebook
            var sum = strength + size;
            switch (sum)
            {
                case int n when n >= 65 && n < 85:
                    Build = -1;
                    DamageBonusDieRoll = "-1";
                    break;
                case int n when n >= 85 && n < 125:
                    Build = 0;
                    DamageBonusDieRoll = "0";
                    break;
                case int n when n >= 125 && n < 165:
                    Build = 1;
                    DamageBonusDieRoll = "1d4";
                    break;
                default:
                    throw new ArgumentException($"Sum is out of range. Consult rulebook and update code for CharacterModel.CombatStats constructor.");
            }

        }
    }


}
