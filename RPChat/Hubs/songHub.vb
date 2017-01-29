Imports System.Timers
Imports Microsoft.AspNet.SignalR

Public Class songHub
    Inherits Hub
    Dim WithEvents timer As Timers.Timer
    Dim _CurrentLabel As String = String.Empty

    Public Sub New()
        timer = New Timers.Timer(10000)
        timer.Start()

    End Sub

    Public Sub updateClients(SongTitle As String)
        Clients.All.updateSong(SongTitle)
    End Sub

    Private Sub timer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles timer.Elapsed
        Dim newTitle As String = shoutCastRP.GetRadioInfo
        If Not _CurrentLabel.Equals(newTitle) AndAlso Not String.IsInterned(newTitle) Then
            _CurrentLabel = newTitle
            updateClients(_CurrentLabel)
        End If
    End Sub
End Class
