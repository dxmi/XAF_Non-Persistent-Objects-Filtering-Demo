Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base

Namespace NonPersistentObjectsDemo.Module.BusinessObjects

	<DefaultClassOptions>
	<DefaultProperty(NameOf(Article.Title))>
	<DevExpress.ExpressApp.ConditionalAppearance.Appearance("", Enabled := False, TargetItems := "*")>
	<DevExpress.ExpressApp.DC.DomainComponent>
	Public Class Article
		Inherits NonPersistentObjectBase

		Friend Sub New()
		End Sub
		Private _ID As Integer
		<Browsable(False)>
		<DevExpress.ExpressApp.Data.Key>
		Public Property ID() As Integer
			Get
				Return _ID
			End Get
			Set(ByVal value As Integer)
				_ID = value
			End Set
		End Property
		Private _Author As Contact
		Public Property Author() As Contact
			Get
				Return _Author
			End Get
			Set(ByVal value As Contact)
				SetPropertyValue(NameOf(Author), _Author, value)
			End Set
		End Property
		Private _Title As String
		Public Property Title() As String
			Get
				Return _Title
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)(NameOf(Title), _Title, value)
			End Set
		End Property
		Private _Content As String
		<FieldSize(-1)>
		Public Property Content() As String
			Get
				Return _Content
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)(NameOf(Content), _Content, value)
			End Set
		End Property
	End Class

	Friend Class ArticleAdapter
		Private objectSpace As NonPersistentObjectSpace
		Private Shared articles As List(Of Article)

		Public Sub New(ByVal npos As NonPersistentObjectSpace)
			Me.objectSpace = npos
			AddHandler objectSpace.ObjectsGetting, AddressOf ObjectSpace_ObjectsGetting
		End Sub
		Private Sub ObjectSpace_ObjectsGetting(ByVal sender As Object, ByVal e As ObjectsGettingEventArgs)
			If e.ObjectType Is GetType(Article) Then
				Dim collection = New DynamicCollection(objectSpace, e.ObjectType, e.Criteria, e.Sorting, e.InTransaction)
				AddHandler collection.FetchObjects, AddressOf DynamicCollection_FetchObjects
				e.Objects = collection
			End If
		End Sub
		Private Sub DynamicCollection_FetchObjects(ByVal sender As Object, ByVal e As FetchObjectsEventArgs)
			If e.ObjectType Is GetType(Article) Then
				e.Objects = articles
				e.ShapeData = True
			End If
		End Sub

		Shared Sub New()
			articles = New List(Of Article)()
			CreateDemoData()
		End Sub

		#Region "DemoData"
		Private Shared Sub CreateDemoData()
			Dim gen = New GenHelper()
			Dim contacts = ContactAdapter.GetAllContacts()
			For i As Integer = 0 To 4999
				Dim id1 = gen.Next(contacts.Count)
				Dim id2 = gen.Next(contacts.Count - 1)
				articles.Add(New Article() With {
					.ID = i,
					.Title = GenHelper.ToTitle(gen.MakeBlah(gen.Next(7))),
					.Content = gen.MakeBlahBlahBlah(5 + gen.Next(100), 7),
					.Author = contacts(id1)
				})
			Next i
		End Sub
		#End Region
	End Class
End Namespace
