using Firebase.Auth;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public void signOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
