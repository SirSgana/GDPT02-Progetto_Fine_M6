using UnityEngine;

public class EnemySlimeLV3 : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _anim;
    private LifeController _life;
    private LifeController playerLife;

    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 1f);
    [SerializeField] private int _atkDamage;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _life = GetComponent<LifeController>();
        playerLife = GetComponent<LifeController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerLife != null)
            {
                playerLife.TakeDamage(_atkDamage);
                _life.TakeDamage(_atkDamage);
                _anim.SetBool("IsDead", true);
                CheckHP();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerLife != null)
            {
                //Danno
                playerLife.TakeDamage(_atkDamage);
                _life.TakeDamage(_atkDamage);

                //Animazione
                transform.localScale = targetScale;
                _anim.SetBool("InRange", true);

                //Fine
                Destroy(gameObject, 1f);
            }
        }
    }

    private void CheckHP()
    {
        if (!_life.IsAlive())
        {
            Destroy(gameObject, 1f);
        }
    }
}
