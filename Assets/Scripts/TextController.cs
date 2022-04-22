using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextController : MonoBehaviour // responsible for the GUI 
{
    [SerializeField] private TextMeshProUGUI levelValue, currentXpValue, xpToLevelUpValue; // text that we are going to change 
    public LevelSystem levelSystem; // responsible for data about levels and leveling up in the game 


    // Start is called before the first frame update
    void Start()
    {
        levelSystem = ScriptableObject.CreateInstance<LevelSystem>();
        //if(levelSystem.levels == null || levelSystem.levels.Count == 0) // fill from code if no values are set in editor 
        levelSystem.SetLevelData(); 

        //set values in UI 
        currentXpValue.text = levelSystem.CurrentXP.ToString();
        xpToLevelUpValue.text = levelSystem.CurrentLevel.TargetXP.ToString();
        levelValue.text = levelSystem.CurrentLevel.Id.ToString();

    }

    public void AddButtonClicked()
    {
        // add Xp 
        levelSystem.AddXP();

        // update current XP 
        currentXpValue.text = levelSystem.CurrentXP.ToString();
        //check if level up is required
        if (levelSystem.CheckIfLevelUpRequired())
        {
            levelSystem.ToNextLevel();
            //update level and next XP target in GUI: 
            xpToLevelUpValue.text = levelSystem.CurrentLevel.TargetXP.ToString();
            levelValue.text = levelSystem.CurrentLevel.Id.ToString();
        }

    }



}

