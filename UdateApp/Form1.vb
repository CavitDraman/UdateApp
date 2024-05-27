Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.ComponentModel

Public Class Form1

    Private LIC_Class As New LicenceClass
    Private UserName As String = "Cavit"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim currentVersion As String = "1.0.0" ' Mevcut program sürümü
        Dim releasesUrl As String = "https://raw.githubusercontent.com/CavitDraman/UdateApp/master/UdateApp/releases.json"   ' GitHub'daki releases.json dosyasının URL'si

        If Updater.CheckForUpdate(currentVersion, releasesUrl) Then
            ' Güncelleme yapıldıysa, program burada yeniden başlatılacak
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Key As String = LIC_Class.GenerateLicenseKey(UserName)
        LIC_Class.SaveLicenseKey(Key)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim licenseKey As String = LIC_Class.GenerateLicenseKey(UserName)

        If Not LIC_Class.ValidateLicenseKey(licenseKey) Then
            MessageBox.Show("Lisans anahtarınız geçersiz veya süresi dolmuş. Lütfen geçerli bir lisans anahtarı girin.")
            Application.Exit()
        Else
            MsgBox("Lisans Geçerli", MsgBoxStyle.Information)
        End If
    End Sub

End Class
