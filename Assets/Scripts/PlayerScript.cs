using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    #region Variables
    float velActual;
    public float velMax = 3f;

    public float xrl8I = 0.2f;
    public float xrl8 = 0.01f;
    public float dxrl8 = 0.07f;

    public float velRot = 130f;

    Animator animator;
    #endregion

    void Awake ()
    {
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        // Character's Moviment Input - Rotation
        float h = Input.GetAxisRaw("Horizontal");

        // Character's Rotation
        Vector3 rotation = Vector3.up * h * velRot * Time.deltaTime;

        // Character's Moviment Input - Move
        float v = Input.GetAxisRaw("Vertical");

        if(v > 0 && velActual < velMax)
        {
            velActual += (velActual == 0f) ? xrl8I : xrl8;
        }
        else if (v == 0 && velActual > 0)
        {
            velActual -= dxrl8;
        }

        velActual = Mathf.Clamp(velActual, 0, velMax);

        if (velActual > 0)
        {
            transform.Rotate(rotation);
        }

        transform.Translate(Vector3.forward * velActual * Time.deltaTime);

        // Setting Animation
        float valueAnim = Mathf.Clamp(velActual / velMax, 0,1);
        animator.SetFloat("speed", valueAnim);
    }
}
