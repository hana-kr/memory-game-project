using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _firstCard = null;
    private GameObject _secondCard = null;
    private int _cardsLeft;
    private bool _canFlip = true;
    [SerializeField]
    private float _timeBetweenFlips = 0.75f; 
    public bool canFlip
    {
        get
        {
            return _canFlip;
        }
        set
        {
            _canFlip = value;
        }
    }
    public int cardsLeft
    {
        get
        {
            return _cardsLeft;
        }
        set
        {
            _cardsLeft = value;
        }
    }
    IEnumerator DeactivateCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips); 
        _firstCard.SetActive(false);
        _secondCard.SetActive(false);
        Reset();
    }
    IEnumerator FlipCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips); 
        _firstCard.GetComponent<GamePlay>().ChangeSide();
        _secondCard.GetComponent<GamePlay>().ChangeSide();
        Reset();
    }
    public void Reset()
    {
        _firstCard = null;
        _secondCard = null;
        _canFlip = true;
    }
    
    bool CheckIfMatch()
    {
        if (_firstCard.GetComponent<GamePlay>().cardName == _secondCard.GetComponent<GamePlay>().cardName)
        {
            return true;
        }

        return false;
    }
}
