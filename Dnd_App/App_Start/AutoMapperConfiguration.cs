using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnd_App
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            AbilityScore();
            Action();
            Armor();
            Challenge();
            Condition();
            Damage();
            HitPoint();
            Language();
            SavingThrow();
            Sense();
            Size();
            Skill();
            SpecialTrait();
            Speed();
        }

        public void AbilityScore()
        {
            CreateMap<Dnd_App.Entitites.AbilityScore, Dnd_App.Models.Characters.AbilityScore>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.shortName))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.value))
            .ForMember(dest => dest.SavingThrow, opt => opt.MapFrom(src => src.savingThrow))
            .ForMember(dest => dest.InputValue, opt => opt.MapFrom(src => src.inputValue))
            .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => src.bonus));

            CreateMap<Dnd_App.Models.Characters.AbilityScore, Dnd_App.Entitites.AbilityScore>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.shortName, opt => opt.MapFrom(src => src.ShortName))
            .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.savingThrow, opt => opt.MapFrom(src => src.SavingThrow))
            .ForMember(dest => dest.inputValue, opt => opt.MapFrom(src => src.InputValue))
            .ForMember(dest => dest.bonus, opt => opt.MapFrom(src => src.Bonus));
        }
        
        public void Action()
        {
            CreateMap<Dnd_App.Entitites.Action, Dnd_App.Models.Characters.Action>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Limited, opt => opt.MapFrom(src => src.limited))
            .ForMember(dest => dest.TypeAction, opt => opt.MapFrom(src => ((Dnd_App.Models.Enum.TypeSize)src.typeAction)))
            .ForMember(dest => dest.BonusAttack, opt => opt.MapFrom(src => src.bonusAttack))
            .ForMember(dest => dest.TotalBonusAttack, opt => opt.MapFrom(src => src.totalBonusAttack))
            .ForMember(dest => dest.AbilityAction, opt => opt.MapFrom(src => src.abilityAction))
            .ForMember(dest => dest.Range, opt => opt.MapFrom(src => src.range))
            .ForMember(dest => dest.Min, opt => opt.MapFrom(src => src.min))
            .ForMember(dest => dest.Max, opt => opt.MapFrom(src => src.max))
            .ForMember(dest => dest.Target, opt => opt.MapFrom(src => src.target))
            .ForMember(dest => dest.HitDie, opt => opt.MapFrom(src => src.hitDie))
            .ForMember(dest => dest.Die, opt => opt.MapFrom(src => src.die))
            .ForMember(dest => dest.AbilityDamage, opt => opt.MapFrom(src => src.abilityDamage))
            .ForMember(dest => dest.BonusDamage, opt => opt.MapFrom(src => src.bonusDamage))
            .ForMember(dest => dest.TypeDamage, opt => opt.MapFrom(src => (Dnd_App.Models.Enum.TypeDamage)src.typeDamage))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));

            CreateMap<Dnd_App.Models.Characters.Action, Dnd_App.Entitites.Action>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.limited, opt => opt.MapFrom(src => src.Limited))
            .ForMember(dest => dest.typeAction, opt => opt.MapFrom(src => ((int)src.TypeAction)))
            .ForMember(dest => dest.bonusAttack, opt => opt.MapFrom(src => src.BonusAttack))
            .ForMember(dest => dest.totalBonusAttack, opt => opt.MapFrom(src => src.TotalBonusAttack))
            .ForMember(dest => dest.abilityAction, opt => opt.MapFrom(src => src.AbilityAction))
            .ForMember(dest => dest.range, opt => opt.MapFrom(src => src.Range))
            .ForMember(dest => dest.min, opt => opt.MapFrom(src => src.Min))
            .ForMember(dest => dest.max, opt => opt.MapFrom(src => src.Max))
            .ForMember(dest => dest.target, opt => opt.MapFrom(src => src.Target))
            .ForMember(dest => dest.hitDie, opt => opt.MapFrom(src => src.HitDie))
            .ForMember(dest => dest.die, opt => opt.MapFrom(src => src.Die))
            .ForMember(dest => dest.abilityDamage, opt => opt.MapFrom(src => src.AbilityDamage))
            .ForMember(dest => dest.bonusDamage, opt => opt.MapFrom(src => src.BonusDamage))
            .ForMember(dest => dest.typeDamage, opt => opt.MapFrom(src => (int)src.TypeDamage))
            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.Description));



            
        }

        public void Armor()
        {
            CreateMap<Dnd_App.Entitites.Armor, Dnd_App.Models.Characters.Armor>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.BaseArmor, opt => opt.MapFrom(src => src.baseArmor))
            .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => src.bonus))
            .ForMember(dest => dest.MaxDexMod, opt => opt.MapFrom(src => src.maxDexMod))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total))
            .ForMember(dest => dest.Shield, opt => opt.MapFrom(src => src.shield))
            .ForMember(dest => dest.Stealth, opt => opt.MapFrom(src => src.stealth));

            CreateMap<Dnd_App.Models.Characters.Armor, Dnd_App.Entitites.Armor>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.baseArmor, opt => opt.MapFrom(src => src.BaseArmor))
            .ForMember(dest => dest.bonus, opt => opt.MapFrom(src => src.Bonus))
            .ForMember(dest => dest.maxDexMod, opt => opt.MapFrom(src => src.MaxDexMod))
            .ForMember(dest => dest.total, opt => opt.MapFrom(src => src.Total))
            .ForMember(dest => dest.shield, opt => opt.MapFrom(src => src.Shield))
            .ForMember(dest => dest.stealth, opt => opt.MapFrom(src => src.Stealth));
        }

        public void Challenge()
        {

            CreateMap<Dnd_App.Entitites.Challenge, Dnd_App.Models.Characters.Challenge>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.value))
            .ForMember(dest => dest.XP, opt => opt.MapFrom(src => src.xp))
            .ForMember(dest => dest.ProficiencyBonus, opt => opt.MapFrom(src => src.proficiencyBonus));

            CreateMap<Dnd_App.Models.Characters.Challenge, Dnd_App.Entitites.Challenge>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.xp, opt => opt.MapFrom(src => src.XP))
            .ForMember(dest => dest.proficiencyBonus, opt => opt.MapFrom(src => src.ProficiencyBonus));

        }

        public void Condition()
        {
            CreateMap<Dnd_App.Entitites.Condition, Dnd_App.Models.Characters.Condition>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.TypeCondition, opt => opt.MapFrom(src => (Dnd_App.Models.Enum.TypeCondition)src.condition1));

            CreateMap<Dnd_App.Models.Characters.Condition, Dnd_App.Entitites.Condition>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.condition1, opt => opt.MapFrom(src => (int)src.TypeCondition));

        }

        public void Damage()
        {
            CreateMap<Dnd_App.Entitites.Damage, Dnd_App.Models.Characters.Damage>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.TypeDamage, opt => opt.MapFrom(src => (Dnd_App.Models.Enum.TypeDamage)src.typeDamage));

            CreateMap<Dnd_App.Models.Characters.Damage, Dnd_App.Entitites.Damage>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.typeDamage, opt => opt.MapFrom(src => (int)src.TypeDamage));

        }

        public void HitPoint()
        {
            CreateMap<Dnd_App.Entitites.HitPoint, Dnd_App.Models.Characters.HitPoint>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.HitPointsAVG, opt => opt.MapFrom(src => src.hitPointsAVG))
            .ForMember(dest => dest.Die, opt => opt.MapFrom(src => src.die))
            .ForMember(dest => dest.BonusCon, opt => opt.MapFrom(src => src.bonusCon))
            .ForMember(dest => dest.TypeDie, opt => opt.MapFrom(src =>(Dnd_App.Models.Enum.TypeDie) src.typeDie))
            .ForMember(dest => dest.BonusMultiplied, opt => opt.MapFrom(src => src.bonusMultiplied));

            CreateMap<Dnd_App.Models.Characters.HitPoint, Dnd_App.Entitites.HitPoint>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.hitPointsAVG, opt => opt.MapFrom(src => src.HitPointsAVG))
            .ForMember(dest => dest.die, opt => opt.MapFrom(src => src.Die))
            .ForMember(dest => dest.bonusCon, opt => opt.MapFrom(src => src.BonusCon))
            .ForMember(dest => dest.typeDie, opt => opt.MapFrom(src => (int)src.TypeDie))
            .ForMember(dest => dest.bonusMultiplied, opt => opt.MapFrom(src => src.BonusMultiplied));

        }

        public void Language()
        {
            CreateMap<Dnd_App.Entitites.Language, Dnd_App.Models.Characters.Language>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => (Dnd_App.Models.Enum.LanguageName)src.typeLanguage));

            CreateMap<Dnd_App.Models.Characters.Language, Dnd_App.Entitites.Language>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.typeLanguage, opt => opt.MapFrom(src => (int)src.LanguageName));

        }

        public void SavingThrow()
        {

            CreateMap<Dnd_App.Entitites.SavingThrow, Dnd_App.Models.Characters.SavingThrow>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.value))
            .ForMember(dest => dest.ModName, opt => opt.MapFrom(src => src.modName));

            CreateMap<Dnd_App.Models.Characters.SavingThrow, Dnd_App.Entitites.SavingThrow>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.modName, opt => opt.MapFrom(src => src.ModName));

        }

        public void Sense()
        {
            CreateMap<Dnd_App.Entitites.Sense, Dnd_App.Models.Characters.Sense>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.range, opt => opt.MapFrom(src => src.range))
            .ForMember(dest => dest.TypeSense, opt => opt.MapFrom(src => (Dnd_App.Models.Enum.TypeSense)src.type));

            CreateMap<Dnd_App.Models.Characters.Sense, Dnd_App.Entitites.Sense>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.range, opt => opt.MapFrom(src => src.range))
            .ForMember(dest => dest.type, opt => opt.MapFrom(src => (int)src.TypeSense));

        }

        public void Size()
        {

            CreateMap<Dnd_App.Entitites.Size, Dnd_App.Models.Characters.Size>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.TypeSize, opt => opt.MapFrom(src => ((Dnd_App.Models.Enum.TypeSize)src.size1)))
            .ForMember(dest => dest.Space, opt => opt.MapFrom(src => src.space));

            CreateMap<Dnd_App.Models.Characters.Size, Dnd_App.Entitites.Size>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.size1, opt => opt.MapFrom(src => (int)src.TypeSize))
            .ForMember(dest => dest.space, opt => opt.MapFrom(src => src.Space));
        }

        public void Skill()
        {

            CreateMap<Dnd_App.Entitites.Skill, Dnd_App.Models.Characters.Skill>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.value))
            .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => src.bonus))
            .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => ((Dnd_App.Models.Enum.TypeSize)src.nameSkill)))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total));

            CreateMap<Dnd_App.Models.Characters.Skill, Dnd_App.Entitites.Skill>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.bonus, opt => opt.MapFrom(src => src.Bonus))
            .ForMember(dest => dest.nameSkill, opt => opt.MapFrom(src => ((int)src.SkillName)))
            .ForMember(dest => dest.total, opt => opt.MapFrom(src => src.Total));



        }

        public void SpecialTrait()
        {

            CreateMap<Dnd_App.Entitites.SpecialTrait, Dnd_App.Models.Characters.SpecialTrait>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));

            CreateMap<Dnd_App.Models.Characters.SpecialTrait, Dnd_App.Entitites.SpecialTrait>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.Description));

        }

        public void Speed()
        {
            CreateMap<Dnd_App.Entitites.Speed, Dnd_App.Models.Characters.Speed>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Speedft, opt => opt.MapFrom(src => src.speedft))
            .ForMember(dest => dest.TypeSpeed, opt => opt.MapFrom(src => (Dnd_App.Models.Enum.TypeSpeed)src.typeSpeed));

            CreateMap<Dnd_App.Models.Characters.Speed, Dnd_App.Entitites.Speed>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.speedft, opt => opt.MapFrom(src => src.Speedft))
            .ForMember(dest => dest.typeSpeed, opt => opt.MapFrom(src => (int)src.TypeSpeed));

        }

    }
}