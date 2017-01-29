Imports System.Net
Imports System.Timers
Imports System.Web.SessionState
Imports Microsoft.AspNet.SignalR
Imports Newtonsoft.Json

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Dim _BroadcastTimer As New Timers.Timer(10000)
    Dim CurrentSong As String = String.Empty

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        AddHandler _BroadcastTimer.Elapsed, AddressOf BroadcastTimerElapsed
        _BroadcastTimer.Enabled = True
    End Sub

    Private Sub BroadcastTimerElapsed(sender As Object, e As ElapsedEventArgs)

        Dim newTitle As shoutSnapshot = cShoutCast.getSong

        If Not CurrentSong.Equals(newTitle.ToString) AndAlso Not String.IsInterned(newTitle.ToString) Then
            CurrentSong = newTitle.ToString
            Dim context = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)()
            context.Clients.All.updateSong(newTitle.ServerTitle, newTitle.Song)
        End If
    End Sub


    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class