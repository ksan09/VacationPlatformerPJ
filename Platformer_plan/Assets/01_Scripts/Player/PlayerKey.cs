using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public KeyCode LeftMoveKey;
    public KeyCode RightMoveKey;
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode JumpKey;

    private KeyCode _attackKey = KeyCode.Mouse0;
    public KeyCode AttackKey => _attackKey;
}
