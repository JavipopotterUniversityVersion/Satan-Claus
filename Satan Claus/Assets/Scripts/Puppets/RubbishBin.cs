using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
    
[RequireComponent(typeof(AnimationManager))]
public class RubbishBin : MonoBehaviour
{
    int RubbishCount = 0;
    [SerializeField] RubbishInfo rubbishInfo;
    public UnityEvent OnRubbishCleaned;
    bool _isMouthOpen = false;
    bool isMouthOpen
    {
        get
        {
            return _isMouthOpen;
        }
        set
        {
            if(_isMouthOpen == false && value) {AudioManager.instance.Play("open_mouth");}

            _isMouthOpen = value;
        }
    }
    AnimationManager animationManager;
    bool CleanedTrigger = false;

    private void Awake() {
        animationManager = GetComponent<AnimationManager>();
    }

    private void Start() {
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    void OnStateExit(GameState state)
    {
        if(state == GameState.Cleaning)
        {
            CleanedTrigger = true;
        }
    }

    private void Update() {

        isMouthOpen = Physics2D.Raycast(transform.position, Vector2.up * 0.5f, 100, LayerMask.GetMask("Rubbish"));

        animationManager.OpenMouth(isMouthOpen);

        Collider2D other = Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("Rubbish"));

        if(other && isMouthOpen)
        {
            AudioManager.instance.Play("eat");

            Destroy(other.gameObject);
            RubbishCount++;

            if(RubbishCount >= rubbishInfo.rubbishCount && CleanedTrigger)
            {
                CleanedTrigger = false;
                RubbishCount = 0;
                rubbishInfo.rubbishCount = 0;

                OnRubbishCleaned?.Invoke();
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, 0.3f);
        Gizmos.DrawRay(transform.position, Vector2.up * 100);
    }
}
