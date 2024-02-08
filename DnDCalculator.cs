using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using UnityEngine;


enum CharacterClass{
    Artificer,
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Ranger,
    Rogue,
    Paladin,
    Sorcerer,
    Wizard,
    Warlock
}
public class DnDCalculator : MonoBehaviour
{

    [SerializeField]
    string name;
    [SerializeField]
    [Range(1,20)]
    int level;
    [SerializeField]
    CharacterClass characterClass;
    [SerializeField]
    [Min(0)]
    int ConScore;
    [SerializeField]
    bool isHillDwarf, hasToughFeat, averagedHP;
    

    int HP;

    int conMod;
    // Start is called before the first frame update
    void Start()
    {
      
        conMod = (ConScore - 10) / 2;
        int hitDice = GetHitDice(characterClass);
        HP = CalcHp(hitDice);
        print(HP);
    }
    int GetHitDice(CharacterClass @class)
    {
        switch (@class)
        {
            case CharacterClass.Barbarian:
                return 12;
            case CharacterClass.Artificer:
            case CharacterClass.Warlock:
            case CharacterClass.Bard:
            case CharacterClass.Cleric:   
            case CharacterClass.Druid:  
            case CharacterClass.Rogue:   
            case CharacterClass.Monk:
                return 8;
            case CharacterClass.Ranger:
            case CharacterClass.Fighter:
            case CharacterClass.Paladin:
                return 10;
            case CharacterClass.Sorcerer:
            case CharacterClass.Wizard:
                return 6;
           
            default: return -1;
        }
        
    }
    int CalcHp(int hitDice)
    {
        
      
        int modifiers = (Convert.ToInt32(hasToughFeat) * 2) + conMod + Convert.ToInt32(isHillDwarf);
        int finalHP = hitDice + modifiers + conMod;
        if (averagedHP)
        {
            finalHP += (int)((level-1) *(MathF.Ceiling((hitDice + 1) / 2f) + modifiers+conMod));
        }
        else
        {
            
            
            for (int i = 1; i < level; i++)
            {
                finalHP += Mathf.Clamp(UnityEngine.Random.Range(1, hitDice+1)+modifiers+conMod,0,int.MaxValue);
            }
        }
        return finalHP;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
