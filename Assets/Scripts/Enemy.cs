using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed; //tốc độ tự bay xuống của máy bay địch
    public GameObject Explosion;

    void Start()
    {
        _speed = 0.1f; //tốc độ mặc định
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject _Explosion = Instantiate(Explosion, new Vector3(other.transform.position.x, other.transform.position.y, 0.0f),Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(_Explosion, 2f);
        }
    }
}
