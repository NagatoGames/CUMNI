using System.Diagnostics;
using UnityEngine;

public class ContactsManager : MonoBehaviour
{
    public void showInst()
    {
        Process.Start("https://www.instagram.com/nikki.tok/");
    }

    public void showMail()
    {
        Process.Start("https://mail.google.com/mail/u/1/#inbox");
    }

    public void showLinked()
    {
        Process.Start("https://www.linkedin.com/in/nikita-devochko/");
    }

    public void showGit()
    {
        Process.Start("https://github.com/NagatoGames/CUMNI.git");
    }
}
