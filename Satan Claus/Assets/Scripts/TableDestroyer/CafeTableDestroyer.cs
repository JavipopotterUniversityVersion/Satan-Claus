using UnityEngine;

public class CafeTableDestroyer : MonoBehaviour
{
    private bool canHit;
    private int tableState;
    [SerializeField] Sprite[] tableDestruction;
    SpriteRenderer sr;
    GameTableDestroyer gameTableDestroyer;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Bat") && other.collider.attachedRigidbody.angularVelocity > 5 && canHit)
        {
            canHit = false;
            tableState++;
            DestroyTable();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.transform.CompareTag("Bat"))
        {
            canHit = true;
        }
    }
    private void DestroyTable()
    {
        gameTableDestroyer = FindObjectOfType<GameTableDestroyer>();
        gameTableDestroyer.OnHitEnter();
        if (tableState == 6)
        {
            GameManager.GM.ChangeStateOfGame(GameState.Cafe);
        }
        else
        {
            sr.sprite = tableDestruction[tableState];
        }
    }

    private void OnDisable() {
        tableState = 0;
    }
}
