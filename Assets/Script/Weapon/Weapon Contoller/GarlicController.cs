using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedGarlic = Instantiate(prefab);
        spawnedGarlic.transform.position = transform.position; //lay vi tri spawn la vi tri cua player
        spawnedGarlic.transform.parent = transform; //spawn tai vi tri player
    }

}
