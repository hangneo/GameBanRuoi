using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject _enemy;
    public List<GameObject> _enemyList;
    Vector3 _pos;
    private int _numberEnemy; //Số máy bay sinh ra trong một hàng
    private float _spaceBetweenEnemy; //Khoảng cách giữa hai máy bay
    private bool _enableMove;

    void Start()
    {
        _numberEnemy = 16;
        _spaceBetweenEnemy = 1f;
        _pos = new Vector3(-8.4f, 4.0f, 0f);
        _enableMove = true;
        GenerateEnemy();
    }

    void Update()
    {
        if (_enableMove)
        {
            _enableMove = false;
            randomMoveEnemy();
            StartCoroutine(DelayForTranslate());
        }
    }

    //Tạo ra một hàng máy báy
    private void GenerateEnemy()
    {
        for (int i = 0; i< _numberEnemy; i++)
        {
            GameObject _newEnemy = Instantiate(_enemy, _pos, Quaternion.identity, transform);
            _enemyList.Add(_newEnemy);

            //dịch vị trí tạo sang bên phải 
            _pos = new Vector3(_pos.x + _spaceBetweenEnemy, _pos.y, _pos.z);
        }
    }

    private void randomMoveEnemy()
    {
        float _spaceToNext = Random.Range(-0.3f, 0.3f);
        //Kiểm soát dịch chuyển hợp lệ
        if ((_enemyList[0].transform.localPosition.x <-7.5f) && (_spaceToNext<0) )
        {
            _spaceToNext *= -1;
        }
        if ((_enemyList[0].transform.localPosition.x > -5.8f) && (_spaceToNext > 0))
        {
            _spaceToNext *= -1;
        }

        //Tiến hành dịch chuyển
        for (int i = 0; i < _numberEnemy; i++)
        {
            _enemyList[i].transform.localPosition = new Vector3(_enemyList[i].transform.localPosition.x + _spaceToNext, _enemyList[i].transform.localPosition.y, _enemyList[i].transform.localPosition.z);
        }
    }

    IEnumerator DelayForTranslate() 
    {
        float _timer = Random.Range(1f, 1.5f);
        yield return new WaitForSeconds(_timer);
        _enableMove = true;
    }
}
