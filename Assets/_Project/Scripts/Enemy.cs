using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _atkDamage;

    private Animator _anim;
    private Rigidbody2D _rb;
    private Transform _player;
    private bool isChasing = false;
    private LifeController _playerLife;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _playerLife = GetComponent<LifeController>();
    }


    private void Update()
    {
        if (isChasing == true)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            _rb.velocity = direction * _speed;
        }

        CheckHP();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerLife != null)
            {
                _playerLife.TakeDamage(_atkDamage);
                _playerLife.TakeDamage(_atkDamage);
                _anim.SetBool("IsDead", true);

                _rb.velocity = Vector2.zero;
                _rb.constraints = RigidbodyConstraints2D.FreezeAll;

                Destroy(gameObject, 0.5f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_player == null)
            {
                _player = collision.transform;
            }
            isChasing = true;
            _anim.SetBool("InRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rb.velocity = Vector2.zero;
            isChasing = false;
            _anim.SetBool("InRange", false);

        }
    }




    //Avevo implementato questa funzione nella OnCollisionEnter2D ma gli slime continuavano ad essere vivi come mai?
    private void CheckHP()
    {
        if (!_playerLife.IsAlive())
        {
            _anim.SetBool("IsDead", true);
            _rb.velocity = Vector2.zero;
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;

            Destroy(gameObject, 0.5f);
        }
    }
}
