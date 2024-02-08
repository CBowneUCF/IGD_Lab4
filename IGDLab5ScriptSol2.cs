
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IGDLab5Script : MonoBehaviour
{
    public string characterName;
    public int level;
    public int CONScore;
    public bool isHillDwarf;
    public bool hasToughFeat;
    public bool averageCalc;

    public enum ClassType {
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
        Warlock,
    };
    public ClassType inputClass;
    
    public class CharacterClass
    {
        public string name;
        public int dieMax;
        //Other Info

        public CharacterClass(string name, int dieMax)
        {
            this.name = name;
            this.dieMax = dieMax;
        }

    }

    List<CharacterClass> characterClasses = new List<CharacterClass>() 
    {
        new CharacterClass("Artificer", 8) ,
        new CharacterClass("Barbarian", 12),
        new CharacterClass("Bard",      8) ,
        new CharacterClass("Cleric,",   8) ,
        new CharacterClass("Druid",     8) ,
        new CharacterClass("Fighter",   10),
        new CharacterClass("Monk",      8) ,
        new CharacterClass("Ranger",    10),
        new CharacterClass("Rogue",     8) ,
        new CharacterClass("Paladin",   10),
        new CharacterClass("Sorcerer",  6) ,
        new CharacterClass("Wizard",    6) ,
        new CharacterClass("Warlock",   8) 
    };

    private void Start() => Main();

    void Main(){
        
        int CONModifier = (CONScore - 10) / 2;
        int modifiers = (hasToughFeat? 2:0) + CONModifier + (isHillDwarf?1:0);

        int maxDie = characterClasses[(int)inputClass].dieMax;
       
        int finalHP = maxDie + modifiers;
        if(averageCalc)
        {
	        finalHP+= (int)((level-1)*(Mathf.Ceil((maxDie + 1) / 2f) +modifiers));
        }
        else
        {
            for (int i = 0; i < level - 1; i++)
            {
                finalHP += Mathf.Clamp(Random.Range(1, maxDie+1) + modifiers, 0, int.MaxValue);
	        }
        }


        Debug.Log("Final HP is: " + finalHP);

    }

}




