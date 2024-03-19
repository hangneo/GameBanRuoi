using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float _speed;
    public GameObject Explosion;
    void Start()
    {
        _speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up);
        if (transform.position.y >= 6.0f) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Va chạm");
            GameObject _Explosion = Instantiate(Explosion, new Vector3(other.transform.position.x, other.transform.position.y, 0.0f), Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Destroy(_Explosion, 2f);
        }
    }
}
