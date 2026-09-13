using TMPro;
using UnityEngine;

[System.Serializable]

public class ParallaxLayer 
{
    public float speedX = 0.5f;
    public float speedY = 0.2f;

    private Transform _transform;
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    // private float _maxDistanceX;
    //private float _maxDistanceY;

    private SpriteRenderer _sprite;
    private float _spriteWidth;
    private bool _infiniteX;

    public ParallaxLayer(Transform t)
    {
        _transform = t;
        _targetPosition = t.position;
       // _startPosition = t.position;

        _sprite = t.GetComponent<SpriteRenderer>();

        if (_sprite != null)
        {
            _spriteWidth = _sprite.bounds.size.x;
            // _infiniteX = _spriteWidth > 0f;
        }

        var settings = t.GetComponent<ParallaxLayerSettings>();

        if (settings != null)
        {
            speedX = settings.speedX;
            speedY = settings.speedY;

           // _maxDistanceX = settings.maxDistanceX;
            //_maxDistanceY = settings.maxDistanceY;
        }
    }

    public void Move(Vector3 delta, bool vertical, float smoothing) // Permet de déplacer la couche de parallax en fonction du mouvement de la caméra et des paramètres de vitesse 
    {
        float moveX = delta.x * (1f - speedX);
        float moveY = vertical ? delta.y * (1f - speedY) : 0f;

        _targetPosition += new Vector3(moveX, moveY, 0f);
        _targetPosition.z = _startPosition.z; 
        _transform.position = smoothing > 0f ? Vector3.Lerp(_transform.position, _targetPosition, smoothing) : _targetPosition;

        if (_infiniteX)
        {
            WrapHorizontal();
        }
    }

   /* public void Move(Vector3 delta, bool vertical, float smoothing)
    { 
        float moveX = delta.x * (1f - speedX);
        float moveY = vertical ? delta.y * (1f - speedY) : 0f;
        _targetPosition += new Vector3(moveX, moveY, 0f);

        // Limite X
        float minX = _startPosition.x - _maxDistanceX;
        float maxX = _startPosititon.x + _maxDistanceX;

        _targetPosition.x = Mathf.Clamp(_targetPosition.x, minX, maxX);

        // Limite Y
        float minY = _startPosition.y - _maxDistanceY;
        float maxY = _startPosition.y + _maxDistanceY;

        _targetPosition.y = Mathf.Clamp(_targetPosition.y, minY, maxY);

        // Déplacement 
        _transform.position = smoothing > 0f ? Vector3.Lerp(_transform.position, _targetPosition, smoothing) : _targetPosition;

       /* if (_infiniteX)
        {
            WrapHorizontal();
        }
       
    }*/


    public void WrapHorizontal() 
    {
        float camX = Camera.main.transform.position.x;
        float diffX = camX - _transform.position.x; 

        if (Mathf.Abs(diffX) >= _spriteWidth)
        {
            float offset = diffX > 0f ? _spriteWidth : _spriteWidth;

            _transform.position += new Vector3(offset, 0f, 0f);
        }
    }
   
}
