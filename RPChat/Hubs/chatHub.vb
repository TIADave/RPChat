Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Timers
Imports Microsoft.AspNet.SignalR
Imports Newtonsoft.Json

Public Class ChatHub
    Inherits Hub
    Public Shared UserCount As Integer = 0
    Public Shared CurrentDJ As String = String.Empty
    Public Shared Users As New Dictionary(Of String, String)

    Public Sub Send(name As String, message As String)
        ' Call the broadcastMessage method to update clients.
        Clients.All.broadcastMessage(name, message)
    End Sub
    Public Sub AddUser(name As String)
        ' Call the broadcastMessage method to update clients.

        If Not Users.ContainsKey(Context.ConnectionId) Then
            Users.Add(Context.ConnectionId, name)
            Clients.All.reportUsers(String.Join(", ", Users.Values.ToArray))
        End If

    End Sub
    Public Overrides Function OnConnected() As System.Threading.Tasks.Task
        Interlocked.Increment(UserCount)
        Clients.All.reportConnections(UserCount)
        Return MyBase.OnConnected()
    End Function

    Public Overrides Function OnDisconnected(stopCalled As Boolean) As Task
        Interlocked.Decrement(UserCount)
        Clients.All.reportConnections(UserCount)
        If Users.ContainsKey(Context.ConnectionId) Then
            Users.Remove(Context.ConnectionId)
            Clients.All.reportUsers(String.Join(", ", Users.Values.ToArray))
        End If
        Return MyBase.OnDisconnected(stopCalled)
    End Function




End Class
