using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerManager))]
public class PlayerInputs : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float shootHorizontal;
    private float shootVertical;

    private bool isMoving = false;
    private bool isShooting = false;
    private bool isRotating = false;
    private float lastFire;
    private float fireDelay = 0.5f;
    private Vector3 direction;

    private Vector3 movement;
    private Quaternion rotation;

    public bool IsMoving { get => isMoving; }
    public Vector3 Movement { get => movement; }
    public Quaternion Rotation { get => rotation; }
    public bool IsShooting { get => isShooting; }
    public float ShootHorizontal { get => shootHorizontal; }
    public float ShootVertical { get => shootVertical; }
    public bool IsRotating { get => isRotating; }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        shootHorizontal = Input.GetAxis("ShootHorizontal");
        shootVertical = Input.GetAxis("ShootVertical");

        if (horizontal != 0 || vertical != 0)
        {
            movement = new Vector3(horizontal, 0, vertical);
            isMoving = true;
        }
        else isMoving = false;

        if (shootHorizontal != 0 || shootVertical != 0)
        {
            direction = new Vector3(shootHorizontal, 0, shootVertical);
            rotation = Quaternion.LookRotation(direction);
            isRotating = true;
            if (Time.time > lastFire)
            {
                isShooting = true;
                lastFire = Time.time + fireDelay;
            }
            else isShooting = false;
        }
        else isRotating = false;
    }
}
