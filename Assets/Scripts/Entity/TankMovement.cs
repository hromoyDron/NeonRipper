using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TankMovement : MonoBehaviour
{
    [SerializeField] private int _moveSpeed;
    [SerializeField] private int _rotateSpeed;
    private Rigidbody2D _rigidbody2D;
    private float rotation;
    private float movement;

    public int moveSpeed { get{return _moveSpeed;}}
    public int rotateSpeed { get{return _rotateSpeed;}}

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rotation = Input.GetAxis("Horizontal");
        movement = Input.GetAxis("Vertical"); 
    }

    private void FixedUpdate()
    {
       Move();
       Rotate();
    }

    private void Move()
    {
        Vector2 move = transform.up * movement * moveSpeed * Time.deltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + move);
    }

    private void Rotate()
    { 
        float angle = rotation * rotateSpeed * Time.deltaTime;
        _rigidbody2D.MoveRotation (_rigidbody2D.rotation - angle);
    }
}
