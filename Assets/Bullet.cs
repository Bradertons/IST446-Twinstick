using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    #region Bullet Variables

    private Vector3 velocity;

    public Vector3 Velocity
    {

        get { return velocity; }
        set { velocity = value; }

    }

    private Rigidbody body;

    #endregion

    void Start()
    {

        InitializeBullet();

	}

    void InitializeBullet()
    {

        this.Velocity = Vector3.forward * 30;

        this.body = GetComponent<Rigidbody>();

    }

	void Update()
    {

        this.body.velocity = this.transform.TransformDirection(this.Velocity);

	}
}
