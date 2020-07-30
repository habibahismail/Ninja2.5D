using UnityEngine;

namespace bebaSpace
{
    public class ThrownWeaponHandler : MonoBehaviour
    {

        private void Start()
        {
            Invoke("DestroyProjectile", 2.3f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy is hit.");
            }

            Destroy(gameObject);
            
        }

        private void DestroyProjectile()
        {
            Destroy(gameObject);
        }


    }
}
