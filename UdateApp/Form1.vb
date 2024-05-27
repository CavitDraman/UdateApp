Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq
Public Class Form1

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim currentVersion As String = "1.0.0" ' Mevcut program sürümü
        Dim releasesUrl As String = "https://raw.githubusercontent.com/kullaniciadi/repoadi/main/releases.json" ' GitHub'daki releases.json dosyasının URL'si

        If Updater.CheckForUpdate(currentVersion, releasesUrl) Then
            ' Güncelleme yapıldıysa, program burada yeniden başlatılacak
            Application.Exit()
        End If

    End Sub

End Class
