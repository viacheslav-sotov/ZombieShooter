//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingStrategy
{
    void Shoot(Transform gunPoint, GameObject bulletPrefab);
}


public class SingleShot : IShootingStrategy
{
    public void Shoot(Transform gunPoint, GameObject bulletPrefab)
    {
        GameObject bullet = Object.Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        bullet.GetComponent<Bullet>().Fire(bullet.transform.up);  
    }
}


public class ShotgunShot : IShootingStrategy
{
    public void Shoot(Transform gunPoint, GameObject bulletPrefab)
    {
        for (int i = -2; i <= 2; i++)
        {
            Quaternion spreadRotation = gunPoint.rotation * Quaternion.Euler(0, 0, i * 10);
            GameObject bullet = Object.Instantiate(bulletPrefab, gunPoint.position, spreadRotation);

            bullet.GetComponent<Bullet>().Fire(bullet.transform.up);
        }
    }
}
