using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code
public class Player : MonoBehaviour{

    //Variable

    //[SerializeField] private float speed;
    //[SerializeField] private float runSpeed;
    public float speed;
    public float runSpeed;

    private Rigidbody2D rig;
    private bool _isRolling;
    private bool _isRunning;
    private bool _isCutting;
    private float initialSpeed;
    private Vector2 _direction;

    //Function

    //
    private void Start(){
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    //Capturar imputs
    private void Update(){
        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
    }

    //Manipulação de fisicas
    private void FixedUpdate(){
        OnMove();
    }

    #region Propretis
    //"Propriedade" para acessar um private em outro script
    public Vector2 direction{
        get{return _direction;}
        set{_direction = value;}
    }

    public bool isRunning{
        get{return _isRunning;}
        set{_isRunning = value;}
    }

    public bool isRolling{
        get{return _isRolling;}
        set{_isRolling = value;}
    }

    public bool isCutting{
        get{return _isCutting;}
        set{_isCutting = value;}
    }

    #endregion

    #region Movement
    
    void OnInput(){
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove(){
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = runSpeed;
            _isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling(){
        if(Input.GetMouseButtonDown(1)){
            _isRolling = true;
        }

        if(Input.GetMouseButtonUp(1)){
            _isRolling = false;
        }
    }

    void OnCutting(){
        if(Input.GetMouseButtonDown(0)){
            _isCutting = true;
            speed = 0;
        }

        if(Input.GetMouseButtonUp(0)){
            _isCutting = false;
            speed = initialSpeed;
        }
    }
    
    #endregion 
}
