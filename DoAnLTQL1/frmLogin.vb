Imports System.Data.OleDb
Public Class frmLogin

    Private Function GetFullName(ByVal StaffID As Integer) As String
        Dim result As String
        result = ""
        Try
            sqL = "SELECT * FROM Staff WHERE StaffID = " & StaffID
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                result = dr("Fullname")
            Else
                result = "-"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
        GetFullName = result
    End Function
    Private Sub Login()
        Try
            sqL = "SELECT * FROM Users WHERE Username = '" & txtUser.Text & "' AND pwd = '" & txtPwd.Text & "'"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                frmMain.lblRole.Text = dr("Role")
                frmMain.lblEmployeeNo.Text = dr("StaffID")
                frmPOS.Label5.Text = dr("StaffID")
                frmMain.ThoátToolStripMenuItem.Text = GetFullName(dr("StaffID"))
                txtUser.Text = ""
                txtPwd.Text = ""
                Me.Close()
            Else
                MsgBox("Sai mật khẩu hoặc tên người dùng!", MsgBoxStyle.Critical, "Đăng nhập")
                txtPwd.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
   
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Login()
    End Sub

    Private Sub txtUser_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUser.GotFocus
        AcceptButton = btnLogin
    End Sub


    Private Sub txtPwd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPwd.GotFocus
        AcceptButton = btnLogin
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click

        If MsgBox("Bạn có muốn thoát chương trình?", MsgBoxStyle.YesNo, "Đóng cửa sổ") = MsgBoxResult.Yes Then
            End
        End If
        txtUser.Focus()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class