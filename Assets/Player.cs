using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour
{

    #region  Player Variables

    private float movement_speed;

    public float MovementSpeed
    {
        get { return movement_speed; }
        set { movement_speed = value; }

    }

    private Vector2 direction;

    public Vector2 Direction
    {

        get { return direction; }
        set { direction = value; }

    }

    private Weapon primary;

    public Weapon Primary
    {

        get { return primary; }
        set { primary = value; }
    }

    #endregion

    void Start()
    {

        this.InitializePlayer();

	}

    void InitializePlayer()
    {

        this.MovementSpeed = 10;

        this.Primary = (Weapon)GameObject.Find("Weapon").GetComponent("Weapon");
    }

    //TODO: Add Mousey Keyboard
    float GetMovementX()
    {

        return Input.GetAxis("LeftStickHorizontal");

    }

    float GetMovementY()
    {

        return Input.GetAxis("LeftStickVertical");

    }

    float GetAimX()
    {

        return Input.GetAxis("RightStickHorizontal");

    }

    float GetAimY()
    {

        return Input.GetAxis("RightStickVertical");

    }

    bool GetFire()
    {

        return Input.GetAxis("RightTrigger") >= 0.85;

    }

    void Update()
    {

        float movementX = this.GetMovementX();
        float movementY = this.GetMovementY();

        float aimX = this.GetAimX();
        float aimY = this.GetAimY();

        if(aimX != 0 || aimY != 0)
        {

            direction.x = aimX;
            direction.y = aimY;

            direction.Normalize();

        }

        transform.Translate(movementX * this.MovementSpeed * Time.deltaTime, 0, -movementY * this.MovementSpeed * Time.deltaTime, Space.World);

        transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(direction.x, -direction.y), Vector3.up);

        if(this.GetFire())
        {

            this.Primary.Fire();

        }

	}
}
