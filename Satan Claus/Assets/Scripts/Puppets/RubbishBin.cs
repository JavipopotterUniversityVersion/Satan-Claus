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

    private void Awake() {
        animationManager = GetComponent<AnimationManager>();
    }

    private void Update() {
        isMouthOpen = Physics2D.Raycast(transform.position + Vector3.up * 2f, Vector2.up, 100, LayerMask.GetMask("Rubbish"));

        animationManager.OpenMouth(isMouthOpen);

        Collider2D other = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Rubbish"));

        if(other && isMouthOpen)
        {
            AudioManager.instance.Play("rubbish_in_bin");

            Destroy(other.gameObject);
            RubbishCount++;

            if(rubbishInfo.rubbishCount == RubbishCount)
            {
                RubbishCount = 0;
                rubbishInfo.rubbishCount = 0;

                OnRubbishCleaned?.Invoke();
            }
        }
    }
}
