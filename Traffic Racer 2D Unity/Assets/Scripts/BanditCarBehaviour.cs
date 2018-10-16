using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCarBehaviour : MonoBehaviour 
{
    public GameObject bomb;
    public int bombsAmount;
    public int banditCarVerticalSpeed;
    public int banditCarHorizontalSpeed;
    public float bombDelay;

    private float _delay;
    private GameObject _playerCar;
    private Vector3 _banditCarPosition;

    private void Start()
    {
        _playerCar = GameObject.FindWithTag("Player");
        _delay = bombDelay;
    }

    private void Update()
    {
        if (_playerCar == null)
        {
            _playerCar = GameObject.FindWithTag("Player");   
        }
        else
        {
            if (gameObject.transform.position.y > 3.8f)
                this.gameObject.transform.Translate(new Vector3(0, -1, 0) * banditCarVerticalSpeed * Time.deltaTime);

            else
            {
                _banditCarPosition = Vector3.Lerp(transform.position, _playerCar.transform.position, Time.fixedDeltaTime * banditCarHorizontalSpeed);
                //our position, object to follow position, time.

                transform.position = new Vector3(_banditCarPosition.x, transform.position.y, 0);
            }
        }
    }

}
