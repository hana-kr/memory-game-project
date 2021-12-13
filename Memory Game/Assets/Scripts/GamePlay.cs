using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePlay : MonoBehaviour
{
    
    private bool _isUpsideDown = false; 
    private Sprite _backSideCardSprite;

    [SerializeField] private string _cardName;
    [SerializeField] private Sprite _frontSideCardSprite;

    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager; 

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _backSideCardSprite = _spriteRenderer.sprite;
    }
    public string cardName
    {
        get
        {
            return _cardName;
        }
        set
        {
            _cardName = value;
        }
    }
    private void OnMouseDown() 
    {
        if (!_isUpsideDown)
        {
            
            ChangeSide();
           
        }
    }
   public void ChangeSide()
    {
        if (!_isUpsideDown)
        {
            _spriteRenderer.sprite = _frontSideCardSprite;
            _isUpsideDown = true;
        }
        else
        {
            _spriteRenderer.sprite = _backSideCardSprite;
            _isUpsideDown = false;
        }
    }
}
