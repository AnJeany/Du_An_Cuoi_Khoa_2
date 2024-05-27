using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    PlayerMovement move;
    void Start()
    {
        move = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Speed", Mathf.Abs(move.movement.x));
    }
}
