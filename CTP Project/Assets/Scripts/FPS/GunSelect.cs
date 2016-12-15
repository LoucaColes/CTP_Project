using UnityEngine;
using System.Collections;

public class GunSelect : MonoBehaviour {

    private Transform gunSpawnPoint;
    public GameObject[] guns;
    private int currentGunID;
    private GameObject currentGun;

	// Use this for initialization
	void Start () {
        //get Spawn Point
	    gunSpawnPoint = gameObject.transform.GetChild(0).GetChild(0);

        //Automatically spawn pistol
        SpawnPistol();
    }
	
	// Update is called once per frame
	void Update () {
        CheckForGunSwitch();
	}

    void CheckForGunSwitch()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Keypad1)) && currentGunID != 0)
        {
            DestroyCurrentGun();
            SpawnPistol();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && currentGunID != 1)
        {
            DestroyCurrentGun();
            SpawnShotgun();
        }
    }

    void DestroyCurrentGun()
    {
        if (currentGun != null)
        {
            Destroy(currentGun);
        }
    }

    void SpawnPistol()
    {
        GameObject pistol = (GameObject)Instantiate(guns[0], gunSpawnPoint.position, gunSpawnPoint.parent.transform.rotation);
        pistol.gameObject.transform.SetParent(gunSpawnPoint);
        currentGun = pistol;
        currentGunID = 0;
    }
    void SpawnShotgun()
    {
        GameObject shotgun = (GameObject)Instantiate(guns[1], gunSpawnPoint.position, gunSpawnPoint.parent.transform.rotation);
        shotgun.gameObject.transform.SetParent(gunSpawnPoint);
        currentGun = shotgun;
        currentGunID = 1;
    }

    public GameObject GetCurrrentGun()
    {
        return currentGun;
    }
}
