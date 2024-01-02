using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;

public class AuthController : MonoBehaviour
{

    protected Firebase.Auth.FirebaseAuth auth;
    protected Firebase.Auth.FirebaseUser user;

    private string displayName;

    public InputField inputFieldEmail;
    public InputField inputFieldPassword;
    public InputField inputFieldNickName;
    public FirebaseFirestore db;


    void Awake(){
        InitializerFirebase();
    }

    void InitializerFirebase(){
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        db = FirebaseFirestore.DefaultInstance;
        AuthStateChanged(this, null);
    }

    //Controla si el estado de inicio de sesión ha cambiado
    void AuthStateChanged(object sender, System.EventArgs eventArgs){
        if(auth.CurrentUser != user){
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if(!signedIn && user != null){
                Debug.Log("Signed out " + user.UserId);
                goLogin();
            }
            user = auth.CurrentUser;
            if(signedIn){
                Debug.Log("Signed In "+ user.UserId);
                displayName = user.DisplayName ?? "";
                goHome();

            }


        }
    }

    private IEnumerator UpdatePlayerNicknameAuth(string nickname)
    {
        //Crea el nuevo perfil
        UserProfile profile = new UserProfile {DisplayName = nickname };
        //Crea la task para que se actualice
        var ProfileTask = user.UpdateUserProfileAsync(profile);
        //Espera a que se complete la task
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        //Comprobacion del resultado
        if (ProfileTask.IsCanceled)
        {
            Debug.LogError("UpdateUserProfileAsync was canceled.");
        }
        if (ProfileTask.IsFaulted)
        {
            Debug.LogError("UpdateUserProfileAsync encountered an error: " + ProfileTask.Exception);

        }
        else
        {
            Debug.Log("User profile updated successfully.");
        }
    }


    private void UpdateNicknameFirestore(string nickname) {
        DocumentReference docRef = db.Collection("players").Document(user.UserId);
        Dictionary<string, object> info = new Dictionary<string, object>
        {
            { "Nickname", nickname }
        };
        docRef.SetAsync(user.UserId).ContinueWithOnMainThread(task => {
            Debug.Log($"Added data to the {user.UserId} in the cities collection.");
        });
    }


    //Registra usuario por email
    public void createUserByEmail(){
        string email = inputFieldEmail.text;
        string password = inputFieldPassword.text;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }else{
        }

        // Firebase user has been created.
        Firebase.Auth.FirebaseUser newUser = task.Result;
        UpdateNicknameFirestore(inputFieldNickName.text);
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);

        goHome();

        });
        
        
    }


    public void goHome()
    {
        SceneManager.LoadScene("Home");
    }
    
    public void ClearInputs()
    {
      inputFieldEmail.text = "";
      inputFieldPassword.text = "";
      inputFieldNickName.text = "";
    }
    
    public void goLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void loginUsuario(){

        //Son los datos para el login, se obtienen del canvas de la interfaz
        string email = inputFieldEmail.text;
        string password = inputFieldPassword.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            //Se guarda el usuario encontrado de la base de datos (Si se encontró)

            Firebase.Auth.FirebaseUser newUser = task.Result;

            //Muestra en el Debug los datos del usuario registrado
            goHome();
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
           

    }

    public static void signOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }

}
