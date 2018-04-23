Namespace WindowsApplication1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.navBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
			Me.navBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
			Me.navBarItem2 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarItem1 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarGroup2 = New DevExpress.XtraNavBar.NavBarGroup()
			Me.navBarItem4 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarItem3 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarGroup3 = New DevExpress.XtraNavBar.NavBarGroup()
			Me.navBarItem6 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarItem5 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarGroup4 = New DevExpress.XtraNavBar.NavBarGroup()
			Me.navBarItem8 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarItem9 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarItem11 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarItem10 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarItem7 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarGroupStateHelper1 = New WindowsApplication1.NavBarGroupStateHelper()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.timer1 = New System.Timers.Timer()
			DirectCast(Me.navBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.navBarGroupStateHelper1.GroupEdit, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.timer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' navBarControl1
			' 
			Me.navBarControl1.ActiveGroup = Me.navBarGroup1
			Me.navBarControl1.ContentButtonHint = Nothing
			Me.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left
			Me.navBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() { Me.navBarGroup1, Me.navBarGroup2, Me.navBarGroup3, Me.navBarGroup4})
			Me.navBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() { Me.navBarItem1, Me.navBarItem2, Me.navBarItem3, Me.navBarItem4, Me.navBarItem5, Me.navBarItem6, Me.navBarItem7, Me.navBarItem8, Me.navBarItem9, Me.navBarItem10, Me.navBarItem11})
			Me.navBarControl1.Location = New System.Drawing.Point(0, 0)
			Me.navBarControl1.Name = "navBarControl1"
			Me.navBarControl1.OptionsNavPane.ExpandedWidth = 187
			Me.navBarControl1.Size = New System.Drawing.Size(184, 518)
			Me.navBarControl1.TabIndex = 0
			Me.navBarControl1.Text = "navBarControl1"
			' 
			' navBarGroup1
			' 
			Me.navBarGroup1.Caption = "navBarGroup1"
            Me.navBarGroup1.Expanded = True
            Me.navBarGroup1.Name = "navBarGroup1"
			Me.navBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem2),
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem1)
			})
			' 
			' navBarItem2
			' 
			Me.navBarItem2.Caption = "navBarItem2"
			Me.navBarItem2.Name = "navBarItem2"
			' 
			' navBarItem1
			' 
			Me.navBarItem1.Caption = "navBarItem1"
			Me.navBarItem1.Name = "navBarItem1"
			' 
			' navBarGroup2
			' 
			Me.navBarGroup2.Caption = "navBarGroup2"
            Me.navBarGroup2.Expanded = True
            Me.navBarGroup2.Name = "navBarGroup2"
			Me.navBarGroup2.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem4),
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem3)
			})
			' 
			' navBarItem4
			' 
			Me.navBarItem4.Caption = "navBarItem4"
			Me.navBarItem4.Name = "navBarItem4"
			' 
			' navBarItem3
			' 
			Me.navBarItem3.Caption = "navBarItem3"
			Me.navBarItem3.Name = "navBarItem3"
			' 
			' navBarGroup3
			' 
			Me.navBarGroup3.Caption = "navBarGroup3"
            Me.navBarGroup3.Expanded = True
            Me.navBarGroup3.Name = "navBarGroup3"
			Me.navBarGroup3.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem6),
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem5)
			})
			' 
			' navBarItem6
			' 
			Me.navBarItem6.Caption = "navBarItem6"
			Me.navBarItem6.Name = "navBarItem6"
			' 
			' navBarItem5
			' 
			Me.navBarItem5.Caption = "navBarItem5"
			Me.navBarItem5.Name = "navBarItem5"
			' 
			' navBarGroup4
			' 
			Me.navBarGroup4.Caption = "navBarGroup4"
            Me.navBarGroup4.Expanded = True
            Me.navBarGroup4.Name = "navBarGroup4"
			Me.navBarGroup4.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem8),
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem9),
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem11),
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem10),
				New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem7)
			})
			' 
			' navBarItem8
			' 
			Me.navBarItem8.Caption = "navBarItem8"
			Me.navBarItem8.Name = "navBarItem8"
			' 
			' navBarItem9
			' 
			Me.navBarItem9.Caption = "navBarItem9"
			Me.navBarItem9.Name = "navBarItem9"
			' 
			' navBarItem11
			' 
			Me.navBarItem11.Caption = "navBarItem11"
			Me.navBarItem11.Name = "navBarItem11"
			' 
			' navBarItem10
			' 
			Me.navBarItem10.Caption = "navBarItem10"
			Me.navBarItem10.Name = "navBarItem10"
			' 
			' navBarItem7
			' 
			Me.navBarItem7.Caption = "navBarItem7"
			Me.navBarItem7.Name = "navBarItem7"
			' 
			' navBarGroupStateHelper1
			' 
			Me.navBarGroupStateHelper1.CheckIndent = 5
			Me.navBarGroupStateHelper1.NavBarControl = Me.navBarControl1
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Black"
			' 
			' timer1
			' 
			Me.timer1.Interval = 3000
			Me.timer1.SynchronizingObject = Me
'			Me.timer1.Elapsed += New System.Timers.ElapsedEventHandler(Me.timer1_Elapsed)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(573, 518)
			Me.Controls.Add(Me.navBarControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
			DirectCast(Me.navBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.navBarGroupStateHelper1.GroupEdit, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.timer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private navBarControl1 As DevExpress.XtraNavBar.NavBarControl
		Private navBarGroupStateHelper1 As NavBarGroupStateHelper
		Private navBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
		Private navBarItem2 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem1 As DevExpress.XtraNavBar.NavBarItem
		Private navBarGroup2 As DevExpress.XtraNavBar.NavBarGroup
		Private navBarItem4 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem3 As DevExpress.XtraNavBar.NavBarItem
		Private navBarGroup3 As DevExpress.XtraNavBar.NavBarGroup
		Private navBarItem6 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem5 As DevExpress.XtraNavBar.NavBarItem
		Private navBarGroup4 As DevExpress.XtraNavBar.NavBarGroup
		Private navBarItem8 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem9 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem11 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem10 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem7 As DevExpress.XtraNavBar.NavBarItem
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private WithEvents timer1 As System.Timers.Timer
	End Class
End Namespace

