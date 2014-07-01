Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports System.Xml.Linq
Imports System.ComponentModel

Partial Public Class MainPage 
    Inherits PhoneApplicationPage
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    Private _Content As String = "Empty"

    Public Sub New()
        InitializeComponent()
        DataContext = Me

        XmlContent = LoadXml("Assets/Manager.xml")
    End Sub

    Property XmlContent As String
        Get
            Return _Content
        End Get
        Set(ByVal value As String)
            _Content = value
            NotifyPropertyChanged("XmlContent")
        End Set
    End Property

    Private Function LoadXml(fileName As String)
        Dim el As XElement = XElement.Load(fileName)
        LoadXml = el.ToString
    End Function

    Private Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

End Class