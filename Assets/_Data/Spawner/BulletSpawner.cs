using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance; // cach de truy cap InputManager toan cuc
    public static BulletSpawner Instance => instance;

    public static string bulletOne = "Bullet_1";
    public static string bulletTwo = "Bullet_2";
    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        BulletSpawner.instance = this;// cach de truy cap InputManager toan cuc
    }
}
