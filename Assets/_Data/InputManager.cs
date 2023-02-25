using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance; // cach de truy cap InputManager toan cuc
    public static InputManager Instance { get => instance;}


    [SerializeField] protected Vector3 mouseWorldPos; //Vector3 se gom 3 toa do laf: x, y, z
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring; //Vector3 se gom 3 toa do laf: x, y, z
    public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;// cach de truy cap InputManager toan cuc
    }

    private void Update()
    {
        this.GetMouseDown();//Ham nay de nhan biet khi nao click chuot

    }

    void FixedUpdate(){
        this.GetMousePos();//Ham nay de nhan biet vi tri con tro chuot
    }


    protected virtual void GetMouseDown() //Ham nay de nhan biet khi nao click chuot, de ban dan
    {
        this.onFiring = Input.GetAxis("Fire1"); //Fire1 la lay toa do chuot trai
    }
    protected virtual void GetMousePos(){
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gan wordPosition = vi tri con tro chuot
    }
}
