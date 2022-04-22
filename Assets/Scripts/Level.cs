using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level  //stores info about a single level 
{
    [SerializeField] public int Id { get; set; }
    [SerializeField] public int TargetXP { get; set; }

    public Level(int id, int targetXP)
    {
        Id = id;
        TargetXP = targetXP; 
    }
    public Level() { }
}
