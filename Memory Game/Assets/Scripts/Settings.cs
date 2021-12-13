using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public enum LevelNum
    {
        NotSet =0,

        Easy = 10,
        Medium = 15,
        Hard = 20,

    };
    public struct Level
    {
        public LevelNum Pairs ;
    };

    private Level level;

    void Start()
    {
        level = new Level();
    }

    public void SetNumber(LevelNum Num)
    {
        level.Pairs = Num;
    }

    public LevelNum GetLevelNumber()
    {
        return level.Pairs;

    }
}
