using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaper : MonoBehaviour
{
    [SerializeField]  private List<GameObject> _cardsToSpawn;
    [SerializeField]private int _rows ;
    [SerializeField] private int _columns ;
    private GameManager _gameManager;

    private float x_space, y_space;
    public float x_start, y_start;
    static bool ContainsPair = false;
    public static List<int> randomNumList = new List<int>();
    public static List<int> randomLocList = new List<int>();
    void Start()
    {
        x_space = 20 / _columns;
        y_space = 2;
        _gameManager = FindObjectOfType<GameManager>();
       
    }
    private void Update() 
    {
        Spawn();
        gameObject.SetActive(false);
        
    }
    int RandomNumGenerator( int Range )
    {
       int  MyNumber = Random.Range(0, Range);

        if (!randomNumList.Contains(MyNumber))
        {
            randomNumList.Add(MyNumber);
            return MyNumber;
        }
        else
        {
            return 1000;
        }
    }
    int RandomLocGenerator(int Range)
    {
        int MyNumber = Random.Range(0, Range);

        if (!randomLocList.Contains(MyNumber))
        {
            randomLocList.Add(MyNumber);
            return MyNumber;
        }
        else
        {
            return 1000;
        }
    }

    //void CheckPair(List<int> nums , int num)
    //{
    //    int PairCount = 0;


    //    for (int i = 0; i < nums.Count ; i++)
    //    {
    //        if (num == nums[i])
    //        {
    //            PairCount++;
    //        }
    //        if(PairCount == 2)
    //        {
    //            ContainsPair = true;

    //        }
    //    }
    //}
    void Spawn()
    {
        int maxCards = _rows * _columns;
        List<int> Nums = new List<int>(maxCards);
        for (int i = 0; i < maxCards; i++)
        {
            int random = 0;
            int r = 0, l = 0;
            do
            {
                r = RandomNumGenerator(_cardsToSpawn.Count );
            }
            while (r == 1000);

            random = r;
            int RandomLoc = 0;
            for (int j = 0; j < 2; j++)
            {
                do
                {
                    l = RandomLocGenerator(maxCards );
                    Debug.Log("l" + l);
                }
                while (l == 1000);
                RandomLoc = l;

                Nums[RandomLoc] = random;
            }
        }
        Debug.Log(Nums.Count);
        if (maxCards % 2 == 0)
        {
            for(int i = 0; i < maxCards; i++)
            {
                
                Instantiate(_cardsToSpawn[Nums[i]],
                new Vector3(x_start + (x_space * (i % _columns)), y_start + (-y_space * (i / _columns))), Quaternion.identity);
            }
            
        }
        else
        {
            Debug.Log("Number of cards must be even!");
        }
    }
}
