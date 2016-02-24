using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{

    #region WeaponVariables

    private int numBarrels;

    public int NumBarrels
    {

        get { return numBarrels; }
        set { numBarrels = value; }

    }

    private List<Vector3> barrelPositions;

    public List<Vector3> BarrelPositions
    {

        get { return barrelPositions; }
        set { barrelPositions = value; }

    }

    private List<GameObject> bulletTypes;

    public List<GameObject> BulletTypes
    {

        get { return bulletTypes; }
        set { bulletTypes = value; }

    }

    private float rateOfFire;

    public float RateOfFire
    {

        get { return rateOfFire; }
        set { rateOfFire = value; }

    }

    protected float elapsedTime = 0;

    #endregion

    void Start()
    {

        this.InitializeWeapon();

	}

    void InitializeWeapon()
    {

        this.RateOfFire = 0.125f;
        this.NumBarrels = 1;

        List<Vector3> barrels = new List<Vector3>();
        List<GameObject> bullets = new List<GameObject>();

        barrels.Add(new Vector3(0, 0, 0));
        this.BarrelPositions = barrels;

        bullets.Add((GameObject)Resources.Load("Bullet"));
        this.BulletTypes = bullets;

    }

	void Update()
    {
	
	}

    public void Fire()
    {

        this.elapsedTime += Time.deltaTime;

        if (this.elapsedTime >= this.rateOfFire)
        {

            foreach(Vector3 barrelPos in this.BarrelPositions)
            {

                foreach(GameObject bulletType in this.BulletTypes)
                {

                    Instantiate(bulletType, transform.position + transform.TransformVector(barrelPos), transform.rotation);

                }

            }

            this.elapsedTime = 0;

        }

    }
}
