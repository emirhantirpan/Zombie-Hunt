using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Manager : MonoBehaviour
{
    private NavMeshAgent _bot;
    [SerializeField] Transform _target;
    [SerializeField] float _lookDistance = 20f;
    public Animator anim;
    private IEnumerator _attackCoroutine;
    [SerializeField] private Player _player;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;

    void Start()
    {
        _bot = GetComponent<NavMeshAgent>();
        _bot.speed = 2f;
    }
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _target.position);
        _bot.SetDestination(_target.position);
        Vector3 relativePos = _target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(relativePos);
        Quaternion LookAtRotationY = Quaternion.Euler(transform.rotation.eulerAngles.x, lookrotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = LookAtRotationY;

        if (distance <= _lookDistance)
        {
            _bot.speed = 4f;
            anim.SetFloat("Speed", 4f);
        }
        else
        {
            _bot.speed = 2f;
            anim.SetFloat("Speed", 2f);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookDistance);
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("IsAttack", true);
            _bot.speed = 0;
            _attackCoroutine = Attack();
            StartCoroutine(_attackCoroutine);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("IsAttack", false);
            anim.SetFloat("Speed",  0f);
            _bot.speed = 15f;
            StopCoroutine(_attackCoroutine);
        }
    }
    private IEnumerator Attack()
    {
        while(true)
        {
            _player.TakeDamage(_damage);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }
}
