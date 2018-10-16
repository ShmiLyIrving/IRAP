VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4875
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6435
   LinkTopic       =   "Form1"
   ScaleHeight     =   4875
   ScaleWidth      =   6435
   StartUpPosition =   3  'Windows Default
   Begin MSWinsockLib.Winsock Winsock1 
      Left            =   6000
      Top             =   960
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
   Begin VB.Frame Frame1 
      Caption         =   "数据接收区"
      Height          =   3255
      Left            =   120
      TabIndex        =   8
      Top             =   1440
      Width           =   6135
      Begin VB.TextBox Text4 
         Height          =   2775
         Left            =   120
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   9
         Top             =   360
         Width           =   5895
      End
   End
   Begin VB.CommandButton Command2 
      Caption         =   "发送"
      Height          =   375
      Left            =   4560
      TabIndex        =   7
      Top             =   840
      Width           =   1335
   End
   Begin VB.TextBox Text3 
      Height          =   350
      Left            =   1200
      TabIndex        =   6
      Text            =   "1234567890abcdefghijk"
      Top             =   840
      Width           =   3015
   End
   Begin VB.CommandButton Command1 
      Caption         =   "连接"
      Height          =   375
      Left            =   4560
      TabIndex        =   4
      Top             =   240
      Width           =   1335
   End
   Begin VB.TextBox Text2 
      Height          =   350
      Left            =   3240
      TabIndex        =   3
      Text            =   "4001"
      Top             =   240
      Width           =   975
   End
   Begin VB.TextBox Text1 
      Height          =   350
      Left            =   960
      TabIndex        =   1
      Text            =   "192.168.0.178"
      Top             =   240
      Width           =   1455
   End
   Begin VB.Label Label3 
      Caption         =   "发送数据："
      Height          =   255
      Left            =   240
      TabIndex        =   5
      Top             =   960
      Width           =   975
   End
   Begin VB.Label Label2 
      Caption         =   "端口："
      Height          =   255
      Left            =   2640
      TabIndex        =   2
      Top             =   360
      Width           =   615
   End
   Begin VB.Label Label1 
      Caption         =   "设备IP："
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   360
      Width           =   735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim g_Connect As Byte

Private Sub SetConnectButton()
    Select Case g_Connect
        Case 0 '连接已断开
            Command1.Enabled = True
            Command1.Caption = "连接"
        Case 1 '连接成功
            Command1.Enabled = True
            Command1.Caption = "断开"
        Case 2 '正在连接
            Command1.Enabled = False
            Command1.Caption = "连接"
    End Select

End Sub

Private Sub Command1_Click()
    If g_Connect = 0 Then
        g_Connect = 2
        Winsock1.RemoteHost = Text1.Text
        Winsock1.RemotePort = Text2.Text
        Winsock1.Connect
    Else
        g_Connect = 0
        Winsock1.Close
    End If
    SetConnectButton
End Sub

Private Sub Command2_Click()
    Winsock1.SendData Text3.Text '发送数据
End Sub

Private Sub Form_Load()
    g_Connect = 0
End Sub

Private Sub Form_Unload(Cancel As Integer)
    If g_Connect <> 0 Then
        Winsock1.Close
    End If
End Sub

Private Sub Winsock1_Close()
    g_Connect = 0
    Winsock1.Close
    SetConnectButton
End Sub

Private Sub Winsock1_Connect()
    g_Connect = 1
    SetConnectButton
End Sub

Private Sub Winsock1_DataArrival(ByVal bytesTotal As Long)
   Dim strData As String
   Winsock1.GetData strData, vbString
   Text4.Text = Text4.Text & strData
End Sub

Private Sub Winsock1_Error(ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
    g_Connect = 0
    Winsock1.Close
    SetConnectButton
End Sub
