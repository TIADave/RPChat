Imports System.Net
Imports Newtonsoft.Json

Public Class cShoutCast

    Public Shared Function getSong() As shoutSnapshot

        ' Returns data from a web service.
        Dim json As String = String.Empty
        Dim newSong As New shoutSnapshot
        Try
            Using wc As New WebClient
                json = wc.DownloadString("http://equinox.shoutca.st:9288/statistics?json=1")
            End Using

            Dim rp As shoutCast = JsonConvert.DeserializeObject(Of shoutCast)(json)
            newSong = New shoutSnapshot(rp.streams(0).servertitle, rp.streams(0).songtitle)

        Catch ex As Exception

        End Try

        Return newSong
    End Function
End Class

Public Class shoutSnapshot
    Dim _ServerTitle As String = String.Empty
    Dim _Song As String = String.Empty

    Public Overrides Function ToString() As String
        Return $"[{_ServerTitle}] playing {_Song}"
    End Function
    Public Sub New()

    End Sub
    Public Sub New(_ServerTitle As String, _Song As String)
        Me._ServerTitle = _ServerTitle
        Me._Song = _Song
    End Sub

    Public Property ServerTitle As String
        Get
            Return _ServerTitle
        End Get
        Set(value As String)
            _ServerTitle = value
        End Set
    End Property

    Public Property Song As String
        Get
            Return _Song
        End Get
        Set(value As String)
            _Song = value
        End Set
    End Property
End Class