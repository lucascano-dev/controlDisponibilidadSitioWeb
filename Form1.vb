Imports System.Net
Imports System.IO
Imports System.Security.Policy

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim estado As String
        stateWeb.Text = ""
        estado = verificarPagina(TextBox1.Text)
        If estado Then
            stateWeb.Text = "Disponible"
            stateWeb.ForeColor = Color.ForestGreen
        Else
            stateWeb.Text = "No disponible"
            stateWeb.ForeColor = Color.Red
        End If

    End Sub

    Private Function verificarPagina(ByVal urlPAGINA As String) As Boolean
        Try
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create(urlPAGINA), HttpWebRequest)
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode = HttpStatusCode.OK Then
                TextBox2.Text = ($"Disponible (Código de estado: {response.StatusCode}")
                Return True
            Else
                TextBox2.Text = ($"Disponible (Código de estado: {response.StatusCode}")
                Return False
            End If
        Catch ex As Exception
            TextBox2.Text = ($"Error al verificar {urlPAGINA}: {ex.Message}")
            Return False
        End Try
    End Function
End Class
