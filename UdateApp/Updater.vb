Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class Updater

    Public Shared Function CheckForUpdate(currentVersion As String, releasesUrl As String) As Boolean
        Try
            Dim client As New WebClient()
            Dim jsonData As String = client.DownloadString(releasesUrl)
            Dim releaseInfo As JObject = JObject.Parse(jsonData)
            Dim latestVersion As String = releaseInfo("version").ToString()
            Dim downloadUrl As String = releaseInfo("url").ToString()

            If String.Compare(currentVersion, latestVersion) < 0 Then
                DownloadUpdate(downloadUrl)
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Güncelleme kontrolü başarısız: " & ex.Message)
        End Try

        Return False
    End Function

    Private Shared Sub DownloadUpdate(url As String)
        Try
            Dim client As New WebClient()
            Dim tempFile As String = Path.Combine(Path.GetTempPath(), "program_update.exe")
            client.DownloadFile(url, tempFile)

            ' Geçici dosyayı yeni sürüm olarak kopyalayın
            Dim currentPath As String = Application.ExecutablePath
            File.Copy(tempFile, currentPath, True)

            ' Geçici dosyayı silin
            File.Delete(tempFile)
            MessageBox.Show("Güncelleme başarıyla indirildi. Program yeniden başlatılıyor...")
            Application.Restart()
        Catch ex As Exception
            MessageBox.Show("Güncelleme indirilemedi: " & ex.Message)
        End Try
    End Sub
End Class
