using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Animator _Animator;
    private CharacterController _Ctrl;
    private SkinnedMeshRenderer _MeshRenderer;
    private Vector3 _MoveDirection;
    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int JumpState = Animator.StringToHash("Base Layer.jump");
    private static readonly int JumpTag = Animator.StringToHash("Jump");
    private static readonly int JumpPoseParameter = Animator.StringToHash("JumpPose");
    private static readonly int SpeedParameter = Animator.StringToHash("Speed");
    // Start is called before the first frame update
    void Start()
    {
        _Animator = this.GetComponent<Animator>();
        _Ctrl = this.GetComponent<CharacterController>();
        _MeshRenderer = this.transform.Find("Boy0.Humanoid.Body").gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GRAVITY();
        STATUS();
        if(!_Status.ContainsValue( true ) && ChangeView.isMove == true)
        {
            MOVE();
            JUMP();
        }
        else if(_Status.ContainsValue( true ))
        {
            int status_name = 0;
            foreach(var i in _Status)
            {
                if(i.Value == true)
                {
                    status_name = i.Key;
                    break;
                }
            }
            if(status_name == Jump)
            {
                MOVE();
                JUMP();
            }
        }
    }
    private const int Jump = 1;
    private const int Damage = 2;
    private const int Faint = 3;
    private Dictionary<int, bool> _Status = new Dictionary<int, bool>
    {
        {Jump, false },
    };
    private void STATUS ()
    {
        if(_Animator.GetCurrentAnimatorStateInfo(0).tagHash == JumpTag)
        {
            _Status[Jump] = true;
        }
        else if(_Animator.GetCurrentAnimatorStateInfo(0).tagHash != JumpTag)
        {
            _Status[Jump] = false;
        }
    }
    private void MOVE ()
    {
        float speed = _Animator.GetFloat(SpeedParameter);
        //------------------------------------------------------------ Speed
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4;
        }
        else 
        {
            speed = 2;
        }
        _Animator.SetFloat(SpeedParameter, speed);
        //moveRotation
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.rotation = Quaternion.Euler(0,90.0f,0);
            if(_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == MoveState)
            {
                Vector3 velocity = new Vector3(1.0f,0,0) * speed;
                MOVE_XZ(velocity);
                MOVE_RESET();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.rotation = Quaternion.Euler(0,-90.0f,0);
            if(_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == MoveState)
            {
                Vector3 velocity = new Vector3(-1.0f,0,0) * speed;
                MOVE_XZ(velocity);
                MOVE_RESET();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0,0.0f,0);
            if(_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == MoveState)
            {
                Vector3 velocity = new Vector3(0,0,1.0f) * speed;
                MOVE_XZ(velocity);
                MOVE_RESET();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0,180.0f,0);
            if(_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == MoveState)
            {
                Vector3 velocity = new Vector3(0,0,-1.0f) * speed;
                MOVE_XZ(velocity);
                MOVE_RESET();
            }
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if(_Animator.GetCurrentAnimatorStateInfo(0).tagHash != JumpTag)
            {
                _Animator.CrossFade(MoveState, 0.1f, 0, 0);
            }
        }
        KEY_UP();
    }

    private void KEY_UP ()
    {
        if(_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash != JumpState
            && !_Animator.IsInTransition(0))
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                _Animator.CrossFade(IdleState, 0.1f, 0, 0);
                }
            }
            else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                {
                if(Input.GetKey(KeyCode.A)){
                    _Animator.CrossFade(MoveState, 0.1f, 0, 0);
                }
                else if(Input.GetKey(KeyCode.D)){
                    _Animator.CrossFade(MoveState, 0.1f, 0, 0);
                }
                else{
                    _Animator.CrossFade(IdleState, 0.1f, 0, 0);
                }
                }
            }
        }
    }
    //--------------------------------------------------------------------- MOVE_SUB
    // value for moving
    //---------------------------------------------------------------------
    private void MOVE_XZ (Vector3 velocity)
    {
        _MoveDirection = new Vector3 (velocity.x, _MoveDirection.y, velocity.z);
        _Ctrl.Move(_MoveDirection * Time.deltaTime);
    }
    private void MOVE_RESET()
    {
        _MoveDirection.x = 0;
        _MoveDirection.z = 0;
    }
    private void GRAVITY ()
    {
        if(CheckGrounded())
        {
        if(_MoveDirection.y < -0.1f){
            _MoveDirection.y = -0.1f;
        }
        }
        _MoveDirection.y -= 0.1f;
        _Ctrl.Move(_MoveDirection * Time.deltaTime);
    }
    private bool CheckGrounded()
    {
        if (_Ctrl.isGrounded){
        return true;
        }
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        float range = 0.11f;
        return Physics.Raycast(ray, range);
    }
     private void JUMP ()
    {
        if(CheckGrounded())
        {
        /*
        if(Input.GetKeyDown(KeyCode.Space)
            && _Animator.GetCurrentAnimatorStateInfo(0).tagHash != JumpTag
            && !_Animator.IsInTransition(0))
        {
            _Animator.CrossFade(JumpState, 0.1f, 0, 0);
            // jump power
            _MoveDirection.y = 5.0f;
            _Animator.SetFloat(JumpPoseParameter, _MoveDirection.y);
        }
        */
        if (_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == JumpState
            && !_Animator.IsInTransition(0)
            && JumpPoseParameter < 0)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
            _Animator.CrossFade(MoveState, 0.3f, 0, 0);
            }
            else{
            _Animator.CrossFade(IdleState, 0.3f, 0, 0);
            }
        }
        }
        else if(!CheckGrounded())
        {
            if (_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash == JumpState
                && !_Animator.IsInTransition(0))
            {
                _Animator.SetFloat(JumpPoseParameter, _MoveDirection.y);
            }
            if(_Animator.GetCurrentAnimatorStateInfo(0).fullPathHash != JumpState
                && !_Animator.IsInTransition(0))
            {
                _Animator.CrossFade(JumpState, 0.1f, 0, 0);
            }
        }
    }
    
}
