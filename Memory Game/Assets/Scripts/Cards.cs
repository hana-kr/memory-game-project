using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    GameObject gameManager;
    public SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;
    public bool timerIsRunning = false;

    public float timeRemaining = 3;
    private void Start()
    {
        LoadIcons();
        timerIsRunning = true;
    }
    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                spriteRenderer.sprite = faces[faceIndex];
            }
            else
            {
               
                timeRemaining = 0;
                spriteRenderer.sprite = back;
                timerIsRunning = false;
            }
        }
    }
    void LoadIcons()
    {
        object[] loadedIcons = Resources.LoadAll("", typeof(Sprite));
        faces = new Sprite[loadedIcons.Length];
    
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            faces[x] = (Sprite)loadedIcons[x];
        }
       

    }

    private void OnMouseDown()
    {
     

        if (matched == false)
        {

            GameManager controlScript = gameManager.GetComponent<GameManager>();
            if (spriteRenderer.sprite == back)
            {

                if (controlScript.TokenUp(this))
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    controlScript.CheckTokens();
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                controlScript.TokenDown(this);
            }
        }
    }

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
}
