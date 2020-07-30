using UnityEngine;

namespace bebaSpace
{
    public class ThrowWeapon : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject weaponToThrow;
        [SerializeField] private float speed = 20f;

        private PlayerController player;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }


        public void StartThrowWeapon()
        {
            Plane plane = new Plane(Vector3.forward, Vector3.zero);

            var projectile = Instantiate(weaponToThrow, firePoint.transform.position, transform.rotation);

            //Create a ray from the Mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            if (plane.Raycast(ray, out float enter))
            {
                //Get the point that is clicked
                Vector3 hitPoint = ray.GetPoint(enter);
                //Draw a debug ray to see where you are hitting
                Debug.DrawRay(ray.origin, ray.direction * enter, Color.green);
                
                // create a direction vector (hitPoint => Point
                Vector2 direction = new Vector2(
                    hitPoint.x - firePoint.transform.position.x,
                    hitPoint.y - firePoint.transform.position.y
                    );

                // addforce force to the projectiles rigidbody in that direction.
                projectile.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.VelocityChange);

            }
            
        }

          

        
    }
}
