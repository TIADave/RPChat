Imports System.Net
Imports Newtonsoft.Json

Public Class shoutCastRP
    Public Shared Function GetRadioInfo() As String

        Try

            Dim json As String = String.Empty

            Using wc As New WebClient
                json = wc.DownloadString("http://request.radiopoverty.com:9234/statistics?json=1")
            End Using

            Dim rp As shoutCast = JsonConvert.DeserializeObject(Of shoutCast)(json)

            Return $"{rp.streams(0).servertitle} playing {rp.streams(0).songtitle}"
        Catch ex As Exception
            ' in case the structure of the object is not what we expected.
        End Try
        Return String.Empty

    End Function

End Class
