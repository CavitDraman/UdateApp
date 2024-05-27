Public Class LicenceClass

    Public Function GenerateLicenseKey(customerName As String) As String
        Dim key As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(customerName & "|" & DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd")))
        Return key
    End Function

    Public Function ValidateLicenseKey(licenseKey As String) As Boolean
        Try
            Dim decodedKey As String = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(licenseKey))
            Dim parts As String() = decodedKey.Split("|"c)
            Dim customerName As String = parts(0)
            Dim expirationDate As DateTime = DateTime.Parse(parts(1))

            If expirationDate >= DateTime.Now Then
                ' Lisans geçerli
                Return True
            End If
        Catch ex As Exception
            ' Anahtar geçersiz
            Return False
        End Try

        ' Lisans süresi dolmuş
        Return False
    End Function

    Public Function GetLicenseKeyFromUser() As String
        ' Burada kullanıcıdan lisans anahtarını almanız gerekecek. 
        ' Bu örnek için sabit bir anahtar döndürüyoruz.
        Return "Y3VzdG9tZXJuYW1lfDIwMjMtMDYtMTU=" ' Örnek lisans anahtarı
    End Function

    Public Sub SaveLicenseKey(licenseKey As String)
        ' Lisans anahtarını kayıt defterine kaydet
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\UpdatApp", "LicenseKey", licenseKey)
    End Sub

    Public Function LoadLicenseKey() As String
        ' Kayıt defterinden lisans anahtarını yükle
        Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\UpdatApp", "LicenseKey", Nothing)?.ToString()
    End Function

End Class
