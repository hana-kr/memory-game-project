using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject token;
 

    Cards tokenUp1 = null;
    Cards tokenUp2 = null;
    List<int> faceIndexes =
        new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11 };
    public static System.Random rnd = new System.Random();
    private int shuffleNum = 0;
    float tokenScale = 1.5f;
    int numOfTokens;
    public float timeRemaining = 1;
    public bool timerIsRunning = false;
    public float WinCondition;

    float x_space, y_space;
    public float x_start, y_start;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns =4;

    //private int clickCount = 0;
    private void Awake()
    {
        
        x_space = 18 / _columns;
        
        numOfTokens = _rows * _columns;
        WinCondition = numOfTokens/2;
        if (numOfTokens < 9)
        {
            y_space = 5f;
        }
        if (numOfTokens > 9 && numOfTokens < 16)
        {
            y_space = 3f;
        }
        if (numOfTokens >= 16)
        {
            y_space = 1.5f;
        }
        if(numOfTokens == 16)
        {
            y_space = 2f;
        }
        token = GameObject.Find("Cards");
        StartGame();
    }
    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; 
            }
            else
            {
                timeRemaining = 0;    
                timerIsRunning = false;
            }
        }
        if (timeRemaining == 0)
        {
            timeRemaining = 1;
            tokenUp1.spriteRenderer.sprite = tokenUp1.back;
            tokenUp2.spriteRenderer.sprite = tokenUp2.back;
            tokenUp1 = null;
            tokenUp2 = null;
            
        }

        if(WinCondition == 0)
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
   

    void StartGame()
    {
        int startTokenCount = numOfTokens;

        // The camera orthographicSize is 1/2 the height of the window
        float ortho = Camera.main.orthographicSize / 2.0f;
        for (int i = 0; i < startTokenCount ; i++)
        {
            shuffleNum = rnd.Next(0, (numOfTokens));
          
            var temp = Instantiate(token, new Vector3(x_start + (x_space * (i % _columns)), y_start + (-y_space * (i / _columns))), Quaternion.identity);
            temp.GetComponent<Cards>().faceIndex = faceIndexes[shuffleNum];

            temp.transform.localScale = new Vector3(ortho / (_rows *_columns)*7, ortho / (_rows * _columns) *7, 0);
            faceIndexes.Remove(faceIndexes[shuffleNum]);

            numOfTokens--;
          
        }
        token.SetActive(false);
    }

    public void TokenDown(Cards tempToken)
    {
        if (tokenUp1 == tempToken)
        {
            tokenUp1 = null;
        }
        else if (tokenUp2 == tempToken)
        {
            tokenUp2 = null;
        }
    }

    public bool TokenUp(Cards tempToken)
    {
        bool flipCard = true;
        if (tokenUp1 == null)
        {
            tokenUp1 = tempToken;
        }
        else if (tokenUp2 == null)
        {
            tokenUp2 = tempToken;
        }
        else
        {
            flipCard = false;
        }
        return flipCard;
    }

    public void CheckTokens()
    {
        //clickCount++;
        //clickCountTxt.text = clickCount.ToString();
        if (tokenUp1 != null && tokenUp2 != null &&
            tokenUp1.faceIndex == tokenUp2.faceIndex)
        {
            tokenUp1.matched = true;
            tokenUp2.matched = true;
            tokenUp1 = null;
            tokenUp2 = null;
            WinCondition--;
        }
        if (tokenUp1 != null && tokenUp2 != null &&
            tokenUp1.faceIndex != tokenUp2.faceIndex)
        {
            timerIsRunning = true;
            Debug.Log("here");
            //yield return new WaitForSeconds(3);
           
        }
    }


    //public void HardSetup()
    //{
    //    HideButtons();
    //    tokenScale = 12;
    //    yStart = 3.8f;
    //    numOfTokens = 24;
    //    yChange = -1.5f;
    //    StartGame();
    //}

    //public void MediumSetup()
    //{
    //    HideButtons();
    //    tokenScale = 8;
    //    yStart = 3.4f;
    //    numOfTokens = 16;
    //    yChange = -2.2f;
    //    StartGame();
    //}

    //public void EasySetup()
    //{
    //    HideButtons();
    //    StartGame();
    //}

    //private void HideButtons()
    //{
    //    easyBtn.gameObject.SetActive(false);
    //    mediumBtn.gameObject.SetActive(false);
    //    hardBtn.gameObject.SetActive(false);
    //    GameObject[] startImages =
    //        GameObject.FindGameObjectsWithTag("startImage");
    //    foreach (GameObject item in startImages)
    //        Destroy(item);
    //}

  

    //void OnEnable()
    //{
    //    easyBtn.onClick.AddListener(() => EasySetup());
    //    mediumBtn.onClick.AddListener(() => MediumSetup());
    //    hardBtn.onClick.AddListener(() => HardSetup());
    //}
}