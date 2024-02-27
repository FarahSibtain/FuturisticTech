using ReadyPlayerMe.Core;
using ReadyPlayerMe.Samples.AvatarCreatorWizard;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AvatarCreatorStateMachine avatarCreatorStateMachine;
    
    private AvatarObjectLoader avatarObjectLoader;

    private void OnEnable()
    {
        avatarCreatorStateMachine.AvatarSaved += OnAvatarSaved;
    }

    private void OnDisable()
    {
        avatarCreatorStateMachine.AvatarSaved -= OnAvatarSaved;
        avatarObjectLoader?.Cancel();
    }

    private void OnAvatarSaved(string avatarId)
    {
        avatarCreatorStateMachine.gameObject.SetActive(false);
        //Load metaverse scene
        AsyncOperation async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        Debug.Log("Metaverse_Room loading status: " + async.isDone);       

        MetaverseGM.AvatarID = avatarId;
    }
}

