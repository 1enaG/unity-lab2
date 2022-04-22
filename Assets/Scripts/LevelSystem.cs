using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelBalance", menuName = "LevelSystem")]
public class LevelSystem : ScriptableObject // stores data about levels and leveling up 
{
    public Level CurrentLevel { get; set; }
    public int CurrentXP { get; set; } //this is cumulative so does not have to be stored inside a level 
    //[SerializeField] 
    public List<Level> levels;

    public void ToNextLevel()
    {
        int lastLevelIdx = levels.Count - 1; //n - 1; 
        int nextLevelIdx = CurrentLevel.Id; 
        if(CurrentLevel.Id<=lastLevelIdx) // if we run out of levels, current XP keeps growing, but levels don't change 
            CurrentLevel = levels[nextLevelIdx]; 
    }


    public bool CheckIfLevelUpRequired()
    {
        if (CurrentXP >= CurrentLevel.TargetXP)
            return true;
        else return false;
    }

    // create levels and set first one (from code) 
    public void SetLevelData() // method to fill the scriptable with data 
    {
        levels = new List<Level>();
        
        levels.Add(new Level(1, 50));
        levels.Add(new Level(2, 100));
        levels.Add(new Level(3, 120));
        levels.Add(new Level(4, 160));

        CurrentLevel = levels[0]; 

    }

    public void AddXP()
    {
        CurrentXP += 10;
    }
}
