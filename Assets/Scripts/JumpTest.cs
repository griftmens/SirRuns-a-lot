//no se usa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour {

	public Transform Target;
    public float Angle = 89.0f;
    public float gravity = 9.8f;
 
    public Transform Player;    
    private Transform myTransform;

    public static JumpTest instance;
 
    void Awake()
    {
        instance = this;
        myTransform = transform;    
    }
 
    void Update()
    {        
       
    }
 
 
   public void SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
     
     
        // Move projectile to the position of throwing object + add some offset if needed.
        Player.position = myTransform.position + new Vector3(0, 0.0f, 0);
     
        // Calculate distance to target
        float target_Distance = Vector3.Distance(Player.position, Target.position);
 
        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * Angle * Mathf.Deg2Rad) / gravity);
     
        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(Angle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(Angle * Mathf.Deg2Rad);
 
        // Calculate flight time.
        float flightDuration = target_Distance / Vx;
 
        // Rotate projectile to face the target.
        //Player.rotation = Quaternion.LookRotation(Target.position - Player.position);
     
        float elapse_time = 0;
 
        if(elapse_time < flightDuration)
        {
             Player.Translate(0, (Vy - (gravity * elapse_time))*Time.deltaTime , Vx * Time.deltaTime);
           // Projectile.Translate(0, (Vy - (gravity )) * elapse_time, Vx * Time.time);
            // Projectile.transform.position += new Vector3(0F,( Vy * elapse_time)-gravity , Vx )*Time.time ;
            elapse_time += Time.deltaTime;
 
 
        }
   
    }
}
