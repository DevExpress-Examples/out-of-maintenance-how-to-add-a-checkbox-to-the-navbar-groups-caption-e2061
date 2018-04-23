Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraNavBar.ViewInfo
Imports System.Reflection

Namespace WindowsApplication1
	Public Class NavBarGroupStateHelper
		Inherits Component

		Private isLocked As Boolean

		Private _CheckIndent As Integer
		Public Property CheckIndent() As Integer
			Get
				Return _CheckIndent
			End Get
			Set(ByVal value As Integer)
				_CheckIndent = value
			End Set
		End Property

		Private _GroupEdit As RepositoryItemCheckEdit
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public Property GroupEdit() As RepositoryItemCheckEdit
			Get
				Return _GroupEdit
			End Get
			Set(ByVal value As RepositoryItemCheckEdit)
				_GroupEdit = value
			End Set
		End Property

		Private _NavBarControl As NavBarControl

		Public Property NavBarControl() As NavBarControl
			Get
				Return _NavBarControl
			End Get
			Set(ByVal value As NavBarControl)
				UnsubscribeEvents(value)
				_NavBarControl = value
				SubscribeEvents(value)
			End Set
		End Property

		Public Sub New()
			GroupEdit = New RepositoryItemCheckEdit()
		End Sub


		Private Function IsCustomDrawNeeded() As Boolean
			Return GroupEdit IsNot Nothing AndAlso NavBarControl IsNot Nothing AndAlso Not isLocked
		End Function


		Private Sub SubscribeEvents(ByVal navBarControl As NavBarControl)
			If navBarControl IsNot Nothing Then
				AddHandler Me.NavBarControl.CustomDrawGroupCaption, AddressOf NavBarControl_CustomDrawGroupCaption
				AddHandler Me.NavBarControl.MouseClick, AddressOf NavBarControl_MouseClick
			End If
		End Sub


		Private Sub UnsubscribeEvents(ByVal navBarControl As NavBarControl)
			If navBarControl Is Nothing Then
				RemoveHandler Me.NavBarControl.CustomDrawGroupCaption, AddressOf NavBarControl_CustomDrawGroupCaption
				RemoveHandler Me.NavBarControl.MouseClick, AddressOf NavBarControl_MouseClick
			End If
		End Sub

		Private Function GetCheckBoxWidth() As Integer
			Return CheckIndent * 2 + 10
		End Function

		Private Function GetCaptionBounds(ByVal originalCaptionBounds As Rectangle) As Rectangle
			Return New Rectangle(originalCaptionBounds.Location, New Size(originalCaptionBounds.Width - GetCheckBoxWidth(), originalCaptionBounds.Height))
		End Function

		Private Function GetCheckBoxBounds(ByVal fixedCaptionBounds As Rectangle) As Rectangle
			Return New Rectangle(fixedCaptionBounds.Right, fixedCaptionBounds.Top, GetCheckBoxWidth(), fixedCaptionBounds.Height)

		End Function

		Private Sub NavBarControl_CustomDrawGroupCaption(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs)
			If Not IsCustomDrawNeeded() Then
				Return
			End If
			Try
				isLocked = True
				Dim painter As BaseNavGroupPainter = NavBarControl.View.CreateGroupPainter(NavBarControl)
				Dim info As NavGroupInfoArgs = TryCast(e.ObjectInfo, NavGroupInfoArgs)

				Dim originalCaptionBounds As New Rectangle(info.CaptionClientBounds.X,info.CaptionClientBounds.Y,info.CaptionClientBounds.Width-info.ButtonBounds.Width,info.CaptionClientBounds.Height)
				Dim fixedCaptionBounds As Rectangle = GetCaptionBounds(originalCaptionBounds)
				Dim checkBoxBounds As Rectangle = GetCheckBoxBounds(fixedCaptionBounds)
				info.CaptionBounds = fixedCaptionBounds
				painter.DrawObject(info)
				info.CaptionBounds = originalCaptionBounds
				DrawCheckBox(e.Graphics, checkBoxBounds, IsGroupEnabled(info.Group))
				e.Handled = True
			Finally
				isLocked = False
			End Try
		End Sub
		Protected Sub DrawCheckBox(ByVal g As Graphics, ByVal r As Rectangle, ByVal Checked As Boolean)
			Dim painter As BaseEditPainter = GroupEdit.CreatePainter()
			Dim info As BaseEditViewInfo = GroupEdit.CreateViewInfo()
			info.EditValue = Checked
			info.Bounds = r
			info.CalcViewInfo(g)
			Dim args As New ControlGraphicsInfoArgs(info, New DevExpress.Utils.Drawing.GraphicsCache(g), r)
			painter.Draw(args)
			args.Cache.Dispose()
		End Sub
		Private hotRectangle As Rectangle
		Private hotGroup As NavBarGroup

		Private Shared Function GetNavBarView(ByVal NavBar As NavBarControl) As NavBarViewInfo
			Dim pi As PropertyInfo = GetType(NavBarControl).GetProperty("ViewInfo", BindingFlags.Instance Or BindingFlags.NonPublic)
			Return TryCast(pi.GetValue(NavBar, Nothing), NavBarViewInfo)
		End Function

		Private Function IsCheckBox(ByVal p As Point) As Boolean
			Dim hi As NavBarHitInfo = NavBarControl.CalcHitInfo(p)
			If hi.Group Is Nothing Then
				Return False
			End If

			Dim vi As NavBarViewInfo = GetNavBarView(NavBarControl)
			vi.Calc(NavBarControl.ClientRectangle)
			Dim groupInfo As NavGroupInfoArgs = vi.GetGroupInfo(hi.Group)
			Dim originalCaptionBounds As New Rectangle(groupInfo.CaptionClientBounds.X, groupInfo.CaptionClientBounds.Y, groupInfo.CaptionClientBounds.Width - groupInfo.ButtonBounds.Width, groupInfo.CaptionClientBounds.Height)
			Dim checkBounds As Rectangle = GetCheckBoxBounds(GetCaptionBounds(originalCaptionBounds))
			hotGroup = hi.Group
			hotRectangle = checkBounds
			Return checkBounds.Contains(p)
		End Function

		Private Sub NavBarControl_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
			If IsCheckBox(e.Location) Then
				ToggleGroupState(hotGroup)
			End If
		End Sub

		Private Shared Function IsGroupEnabled(ByVal group As NavBarGroup) As Boolean
			Return group.Tag Is Nothing
		End Function

		Private Sub ToggleGroupState(ByVal group As NavBarGroup)
			SetGroupState(group, (Not IsGroupEnabled(group)))
		End Sub

		Private Sub SetGroupState(ByVal group As NavBarGroup, ByVal enabled As Boolean)
			For Each link As NavBarItemLink In group.ItemLinks
				link.Item.Enabled = enabled
			Next link
			If enabled Then
				group.Tag = Nothing
			Else
				group.Tag = 0
			End If
			NavBarControl.Invalidate(hotRectangle)
		End Sub
	End Class
End Namespace
