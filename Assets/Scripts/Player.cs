using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int curHp;
    public int maxHp;

    public float moveSpeed;
    public float JumpForce;

    public float attackRange;
    public int damage;
    private bool isAttacking;

    public Rigidbody rig;

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }
            
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= moveSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;

    }

    void Jump()
    {
        if (CanJump())
        {
            rig.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    bool CanJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 0.35f))
        {
            return hit.collider != null;
        }

        return false;

    }

    public void TakeDamage(int damageToTake)
    {
        curHp -= damageToTake;

        // update the UI health bar

        if (curHp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Attack()
    {
        isAttacking = true;

        Invoke("TryDamage", 0.7f);

        Invoke("DisableIsAttacking", 1.5f);
    }

    void TryDamage()
    {
        Ray ray = new Ray(transform.position + transform.forward, transform.forward);
        RaycastHit[] hits = Physics.SphereCastAll(ray, attackRange, 1 << 8);

        foreach(RaycastHit hit in hits)
        {
            hit.collider.GetComponent<Enemy>()?.TakeDamage(damage);
        }

    }

    void DisableIsAttacking()
    {
        isAttacking = false;
    }

}
