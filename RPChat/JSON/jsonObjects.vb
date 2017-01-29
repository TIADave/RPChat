Public Class Stream
    Public Property id As Integer
    Public Property currentlisteners As Integer
    Public Property peaklisteners As Integer
    Public Property maxlisteners As Integer
    Public Property uniquelisteners As Integer
    Public Property averagetime As Integer
    Public Property servergenre As String
    Public Property servergenre2 As String
    Public Property servergenre3 As String
    Public Property servergenre4 As String
    Public Property servergenre5 As String
    Public Property serverurl As String
    Public Property servertitle As String
    Public Property songtitle As String
    Public Property streamhits As Integer
    Public Property streamstatus As Integer
    Public Property backupstatus As Integer
    Public Property streamlisted As Integer
    Public Property streamsource As String
    Public Property streampath As String
    Public Property streamuptime As Integer
    Public Property bitrate As String
    Public Property samplerate As String
    Public Property content As String
    Public Property streamlistederror As Integer?
End Class

Public Class shoutCast
    Public Property totalstreams As Integer
    Public Property activestreams As Integer
    Public Property currentlisteners As Integer
    Public Property peaklisteners As Integer
    Public Property maxlisteners As Integer
    Public Property uniquelisteners As Integer
    Public Property averagetime As Integer
    Public Property version As String
    Public Property streams As Stream()
End Class
