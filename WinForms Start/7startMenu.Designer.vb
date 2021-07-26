<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.mainMenuList = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.searchTextBox = New System.Windows.Forms.TextBox()
        Me.powerMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuSleep = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRestart = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnShowAll = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTaskbarSettings = New System.Windows.Forms.Button()
        Me.powerToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnShutDown = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.powerOptionsMenu = New System.Windows.Forms.ToolStripDropDownButton()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SleepToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnControlPanel = New System.Windows.Forms.Button()
        Me.btnComputer = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.btnMusic = New System.Windows.Forms.Button()
        Me.btnPictures = New System.Windows.Forms.Button()
        Me.btnDocuments = New System.Windows.Forms.Button()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.powerMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.powerToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenuList
        '
        Me.mainMenuList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainMenuList.HideSelection = False
        Me.mainMenuList.LargeImageList = Me.ImageList1
        Me.mainMenuList.Location = New System.Drawing.Point(0, 0)
        Me.mainMenuList.Margin = New System.Windows.Forms.Padding(4)
        Me.mainMenuList.Name = "mainMenuList"
        Me.mainMenuList.Size = New System.Drawing.Size(544, 889)
        Me.mainMenuList.SmallImageList = Me.ImageList1
        Me.mainMenuList.TabIndex = 0
        Me.mainMenuList.UseCompatibleStateImageBehavior = False
        Me.mainMenuList.View = System.Windows.Forms.View.Tile
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ReactOS-Start-Menu-UI-11.png")
        Me.ImageList1.Images.SetKeyName(1, "ReactOS-Start-Menu-UI-12.png")
        Me.ImageList1.Images.SetKeyName(2, "ReactOS-Start-Menu-UI-14.png")
        Me.ImageList1.Images.SetKeyName(3, "ReactOS-Start-Menu-UI-13.png")
        '
        'searchTextBox
        '
        Me.searchTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTextBox.Location = New System.Drawing.Point(16, 64)
        Me.searchTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.searchTextBox.Name = "searchTextBox"
        Me.searchTextBox.Size = New System.Drawing.Size(519, 32)
        Me.searchTextBox.TabIndex = 4
        Me.searchTextBox.Text = "Search programs and files"
        '
        'powerMenu
        '
        Me.powerMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.powerMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSleep, Me.menuRestart})
        Me.powerMenu.Name = "powerMenu"
        Me.powerMenu.Size = New System.Drawing.Size(163, 80)
        '
        'menuSleep
        '
        Me.menuSleep.Name = "menuSleep"
        Me.menuSleep.Size = New System.Drawing.Size(162, 38)
        Me.menuSleep.Text = "Sleep"
        '
        'menuRestart
        '
        Me.menuRestart.Name = "menuRestart"
        Me.menuRestart.Size = New System.Drawing.Size(162, 38)
        Me.menuRestart.Text = "Restart"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnShowAll)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.searchTextBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 889)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(544, 111)
        Me.Panel2.TabIndex = 14
        '
        'btnShowAll
        '
        Me.btnShowAll.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnShowAll.Image = Global.SDN_Start_Menu.My.Resources.Resources.ReactOS_Start_Menu_UI_11
        Me.btnShowAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowAll.Location = New System.Drawing.Point(0, 0)
        Me.btnShowAll.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.Size = New System.Drawing.Size(544, 49)
        Me.btnShowAll.TabIndex = 9
        Me.btnShowAll.Text = "All Programs"
        Me.btnShowAll.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.BackgroundImage = Global.SDN_Start_Menu.My.Resources.Resources.ReactOS_Start_Menu_UI_08
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(501, 64)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 32)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.BackgroundImage = Global.SDN_Start_Menu.My.Resources.Resources.SDN_Start_Menu_01
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnTaskbarSettings)
        Me.Panel1.Controls.Add(Me.powerToolStrip)
        Me.Panel1.Controls.Add(Me.btnControlPanel)
        Me.Panel1.Controls.Add(Me.btnComputer)
        Me.Panel1.Controls.Add(Me.btnProfile)
        Me.Panel1.Controls.Add(Me.btnMusic)
        Me.Panel1.Controls.Add(Me.btnPictures)
        Me.Panel1.Controls.Add(Me.btnDocuments)
        Me.Panel1.Controls.Add(Me.btnUser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(544, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(256, 1000)
        Me.Panel1.TabIndex = 13
        '
        'btnTaskbarSettings
        '
        Me.btnTaskbarSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTaskbarSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTaskbarSettings.Location = New System.Drawing.Point(0, 532)
        Me.btnTaskbarSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTaskbarSettings.Name = "btnTaskbarSettings"
        Me.btnTaskbarSettings.Size = New System.Drawing.Size(256, 56)
        Me.btnTaskbarSettings.TabIndex = 17
        Me.btnTaskbarSettings.Text = "Taskbar Settings"
        Me.btnTaskbarSettings.UseVisualStyleBackColor = True
        '
        'powerToolStrip
        '
        Me.powerToolStrip.BackColor = System.Drawing.Color.Transparent
        Me.powerToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.powerToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.powerToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.powerToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShutDown, Me.ToolStripSeparator1, Me.powerOptionsMenu})
        Me.powerToolStrip.Location = New System.Drawing.Point(0, 958)
        Me.powerToolStrip.Name = "powerToolStrip"
        Me.powerToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.powerToolStrip.Size = New System.Drawing.Size(256, 42)
        Me.powerToolStrip.TabIndex = 16
        Me.powerToolStrip.Text = "Power Options"
        '
        'btnShutDown
        '
        Me.btnShutDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnShutDown.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnShutDown.Image = CType(resources.GetObject("btnShutDown.Image"), System.Drawing.Image)
        Me.btnShutDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShutDown.Name = "btnShutDown"
        Me.btnShutDown.Size = New System.Drawing.Size(137, 36)
        Me.btnShutDown.Text = "Shut Down"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 42)
        '
        'powerOptionsMenu
        '
        Me.powerOptionsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.powerOptionsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestartToolStripMenuItem, Me.SleepToolStripMenuItem})
        Me.powerOptionsMenu.Image = Global.SDN_Start_Menu.My.Resources.Resources.ReactOS_Start_Menu_UI_11
        Me.powerOptionsMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.powerOptionsMenu.Name = "powerOptionsMenu"
        Me.powerOptionsMenu.ShowDropDownArrow = False
        Me.powerOptionsMenu.Size = New System.Drawing.Size(28, 36)
        Me.powerOptionsMenu.Text = "Power Options"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(221, 44)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'SleepToolStripMenuItem
        '
        Me.SleepToolStripMenuItem.Name = "SleepToolStripMenuItem"
        Me.SleepToolStripMenuItem.Size = New System.Drawing.Size(221, 44)
        Me.SleepToolStripMenuItem.Text = "Sleep"
        '
        'btnControlPanel
        '
        Me.btnControlPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnControlPanel.Location = New System.Drawing.Point(0, 469)
        Me.btnControlPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnControlPanel.Name = "btnControlPanel"
        Me.btnControlPanel.Size = New System.Drawing.Size(256, 56)
        Me.btnControlPanel.TabIndex = 15
        Me.btnControlPanel.Text = "Control Panel"
        Me.btnControlPanel.UseVisualStyleBackColor = True
        '
        'btnComputer
        '
        Me.btnComputer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnComputer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComputer.Location = New System.Drawing.Point(0, 389)
        Me.btnComputer.Margin = New System.Windows.Forms.Padding(4)
        Me.btnComputer.Name = "btnComputer"
        Me.btnComputer.Size = New System.Drawing.Size(256, 56)
        Me.btnComputer.TabIndex = 14
        Me.btnComputer.Text = "Computer"
        Me.btnComputer.UseVisualStyleBackColor = True
        '
        'btnProfile
        '
        Me.btnProfile.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnProfile.BackgroundImage = Global.SDN_Start_Menu.My.Resources.Resources.ReactOS_Start_Menu_UI_111
        Me.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProfile.Location = New System.Drawing.Point(79, 15)
        Me.btnProfile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(100, 94)
        Me.btnProfile.TabIndex = 13
        Me.btnProfile.UseVisualStyleBackColor = True
        '
        'btnMusic
        '
        Me.btnMusic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMusic.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMusic.Location = New System.Drawing.Point(0, 308)
        Me.btnMusic.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMusic.Name = "btnMusic"
        Me.btnMusic.Size = New System.Drawing.Size(256, 56)
        Me.btnMusic.TabIndex = 12
        Me.btnMusic.Text = "Music"
        Me.btnMusic.UseVisualStyleBackColor = True
        '
        'btnPictures
        '
        Me.btnPictures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPictures.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPictures.Location = New System.Drawing.Point(0, 244)
        Me.btnPictures.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPictures.Name = "btnPictures"
        Me.btnPictures.Size = New System.Drawing.Size(256, 56)
        Me.btnPictures.TabIndex = 11
        Me.btnPictures.Text = "Pictures"
        Me.btnPictures.UseVisualStyleBackColor = True
        '
        'btnDocuments
        '
        Me.btnDocuments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDocuments.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDocuments.Location = New System.Drawing.Point(0, 180)
        Me.btnDocuments.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDocuments.Name = "btnDocuments"
        Me.btnDocuments.Size = New System.Drawing.Size(256, 56)
        Me.btnDocuments.TabIndex = 10
        Me.btnDocuments.Text = "Documents"
        Me.btnDocuments.UseVisualStyleBackColor = True
        '
        'btnUser
        '
        Me.btnUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.Location = New System.Drawing.Point(0, 116)
        Me.btnUser.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(256, 56)
        Me.btnUser.TabIndex = 9
        Me.btnUser.Text = "User"
        Me.btnUser.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 1000)
        Me.Controls.Add(Me.mainMenuList)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.powerMenu.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.powerToolStrip.ResumeLayout(False)
        Me.powerToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mainMenuList As System.Windows.Forms.ListView
    Friend WithEvents searchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnUser As System.Windows.Forms.Button
    Friend WithEvents btnDocuments As System.Windows.Forms.Button
    Friend WithEvents btnPictures As System.Windows.Forms.Button
    Friend WithEvents btnMusic As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnProfile As System.Windows.Forms.Button
    Friend WithEvents btnControlPanel As System.Windows.Forms.Button
    Friend WithEvents btnComputer As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents powerMenu As ContextMenuStrip
    Friend WithEvents menuSleep As ToolStripMenuItem
    Friend WithEvents menuRestart As ToolStripMenuItem
    Friend WithEvents powerToolStrip As ToolStrip
    Friend WithEvents btnShutDown As ToolStripButton
    Friend WithEvents powerOptionsMenu As ToolStripDropDownButton
    Friend WithEvents RestartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SleepToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnTaskbarSettings As Button
    Friend WithEvents btnShowAll As Button
End Class
