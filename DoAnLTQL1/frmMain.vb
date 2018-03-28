Public Class frmMain
    
    Private Sub ProductsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsToolStripMenuItem.Click
        frmItem.Dispose()
        frmItem.ShowDialog()
    End Sub

    Private Sub StaffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaffToolStripMenuItem.Click
        If Me.lblRole.Text = "Admin" Then
            frmStaff.Dispose()
            frmStaff.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersToolStripMenuItem.Click
        frmCustomer.ShowDialog()
    End Sub

    Private Sub PointOfSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PointOfSaleToolStripMenuItem.Click
        frmPOS.Dispose()
        frmPOS.ShowDialog()
    End Sub

    Private Sub AvailableStocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvailableStocksToolStripMenuItem.Click
        frmAvailableStocks.Dispose()
        frmAvailableStocks.ShowDialog()
    End Sub

    Private Sub SoldItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoldItemsToolStripMenuItem.Click
        frmSoldItems.Dispose()
        frmSoldItems.ShowDialog()
    End Sub

    Private Sub SoldItemsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoldItemsToolStripMenuItem1.Click
        If Me.lblRole.Text = "Admin" Then
            frmReportSoldItems.Dispose()
            frmReportSoldItems.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If
    End Sub

    Private Sub StocksInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StocksInToolStripMenuItem.Click
        If Me.lblRole.Text = "Admin" Then
            frmReportStocksIn.Dispose()
            frmReportStocksIn.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.lblRole.Text = "Admin" Then
            frmStaff.Dispose()
            frmStaff.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        frmItem.Dispose()
        frmItem.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        frmCustomer.Dispose()
        frmCustomer.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        frmPOS.Dispose()
        frmPOS.ShowDialog()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If Me.lblRole.Text = "Admin" Then
            frmAvailableStocks.Dispose()
            frmAvailableStocks.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        frmSoldItems.Dispose()
        frmSoldItems.ShowDialog()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        If Me.lblRole.Text = "Admin" Then
            frmReportSoldItems.Dispose()
            frmReportSoldItems.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If Me.lblRole.Text = "Admin" Then
            frmReportStocksIn.Dispose()
            frmReportStocksIn.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmLogin.Dispose()
        frmLogin.ShowDialog()
    End Sub


    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        If Me.lblRole.Text = "Admin" Then
            frmUsers.Dispose()
            frmUsers.ShowDialog()
        Else
            MsgBox("Bạn không có quyền thực hiện", MsgBoxStyle.Critical, "Liên hệ với người quản lý")
            Exit Sub
        End If


    End Sub


    Private Sub DDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DDToolStripMenuItem.Click
        Me.ThoátToolStripMenuItem.Text = "Người dùng"
        Me.lblEmployeeNo.Text = ""
        Me.lblRole.Text = ""
        frmLogin.Dispose()
        frmLogin.ShowDialog()
    End Sub

    Private Sub ThoátToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ThoátToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub XemHosaDdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemHosaDdownToolStripMenuItem.Click
        frmLoadInvoid.Dispose()
        frmLoadInvoid.ShowDialog()
    End Sub
End Class
