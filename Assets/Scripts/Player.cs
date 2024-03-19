using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public float _speed; //Tốc độ
    public GameObject _laserPrefab; //Đạn bắn
    public float _fireRate;
    private float _canFire;
    void Start()
    {
        _speed = 5.0f; //Thiết lập tốc độ bay ban đầu cho máy bay
        _fireRate = 0.25f; //Tốc độ bắn
        _canFire = 0.0f;
        transform.position = new Vector3(0.0f, -4.0f, 0.0f);
    }

    void Update()
    {
        //Kiểm tra di chuyển
        Movement();

        //Kiểm tra người chơi bắn đạn
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //Code bắn ở đây
        //_canFire là thời gian có thể bắn, Time.time là thời gian hiện tại
        if (!(_canFire < Time.time)) return;
        Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        _canFire = Time.time + _fireRate;
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(_speed * horizontalInput * Time.deltaTime * Vector3.right);
        transform.Translate(_speed * verticalInput * Time.deltaTime * Vector3.up);

        //Giới hạn biên trên dưới
        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0.0f);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0.0f);
        }

        //Xử lý hướng đi ngang
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f , transform.position.y, 0.0f);
        } else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0.0f);
        }
    }
}
