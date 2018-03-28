

Imports System.Data.OleDb

Public Class frmUsers
    Dim adding, Editing As Boolean
    Public uSearch As Boolean

    Private Sub AddUser()
        Try
            sqL = "INSERT INTO USERS VALUES('" & txtUser.Text & "','" & txtCpwd.Text & "','" & cmbRole.Text & "', '" & txtStaffID.Text & "')"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Thêm người dùng thành công", MsgBoxStyle.Information, "Thêm người dùng")
            Else
                MsgBox("Không thể thêm người dùng", MsgBoxStyle.Exclamation, "Thêm người dùng")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Private Sub EditUser()
        Try
            If (txtPwd.Text = "" And txtCpwd.Text = "") Or (txtCpwd.Text <> txtPwd.Text) Then
                sqL = "UPDATE USERS SET Username='" & txtUser.Text & "',role='" & cmbRole.Text & "',StaffID='" & txtStaffID.Text & "' WHERE Username= '" & txtUser.Text & "'"
            Else
                sqL = "UPDATE USERS SET Username='" & txtUser.Text & "',pwd='" & txtCpwd.Text & "',role='" & cmbRole.Text & "',StaffID='" & txtStaffID.Text & "' WHERE Username= '" & txtUser.Text & "'"
            End If
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Sửa người dùng thành công", MsgBoxStyle.Information, "Sửa người dùng")
            Else
                MsgBox("Không thể Sửa người dùng", MsgBoxStyle.Exclamation, "Sửa người dùng")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub DeleteUser()
        Try
            sqL = "DELETE FROM USERS Where username = '" & ListBox1.SelectedItem & "'"
            ConnDB()
            cmd = New OledbCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Đã xóa người dùng thành công", MsgBoxStyle.Information, "Xóa người dùng")
            Else
                MsgBox("Không thể xóa người dùng")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub Loadusers()
        Try
            sqL = "SELECT username from Users order by username"
            ConnDB()
            cmd = New OledbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            ListBox1.Items.Clear()
            Do While dr.Read = True
                ListBox1.Items.Add(dr(0))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If ListBox1.SelectedItem = "" Then
            MsgBox("Vui lòng chọn người dùng cần xóa", MsgBoxStyle.Exclamation, "Xóa người dùng")
        Else
            If MsgBox("Bạn có chắc chăn muốn xóa người dùng này?", MsgBoxStyle.YesNo, "Xóa người dùng") = MsgBoxResult.Yes Then
                DeleteUser()
                Loadusers()
            Else
                Exit Sub
            End If

           
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtUser.Enabled = True
        txtCpwd.Enabled = True
        txtpwd.Enabled = True
        txtStaffID.Enabled = True
        cmbRole.Enabled = True
        adding = True
        txtUser.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtPwd.Text <> txtCpwd.Text Then
            MsgBox("Mật khẩu không giuống nhau", MsgBoxStyle.Exclamation, "Thêm người dùng")
            txtPwd.SelectAll()
            txtCpwd.SelectAll()
            txtPwd.Focus()
            Exit Sub
        End If
        If adding = True Then
            AddUser()
            Loadusers()
            txtUser.Enabled = False
            txtCpwd.Enabled = False
            txtPwd.Enabled = False
            txtStaffID.Enabled = False
            cmbRole.Enabled = False
            txtCpwd.Text = ""
            txtPwd.Text = ""
            txtUser.Text = ""
            txtStaffID.Text = ""
            cmbRole.Text = ""
            adding = False
        End If
        If editing = True Then
            EditUser()
            Loadusers()
            txtUser.Enabled = False
            txtCpwd.Enabled = False
            txtPwd.Enabled = False
            txtStaffID.Enabled = False
            cmbRole.Enabled = False
            txtCpwd.Text = ""
            txtPwd.Text = ""
            txtUser.Text = ""
            txtStaffID.Text = ""
            cmbRole.Text = ""
            Editing = False
        Else
            MsgBox("Vui lòng kiểm tra lại", MsgBoxStyle.Information, "Sửa người dùng")
        End If


    End Sub

    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUser.Enabled = False
        txtCpwd.Enabled = False
        txtpwd.Enabled = False
        txtStaffID.Enabled = False
        cmbRole.Enabled = False
        txtCpwd.Text = ""
        txtPwd.Text = ""
        txtUser.Text = ""
        txtStaffID.Text = ""
        cmbRole.Text = ""
        Loadusers()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        uSearch = True
        frmLoadStaff.ShowDialog()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        txtUser.Enabled = False
        txtCpwd.Enabled = False
        txtPwd.Enabled = False
        txtStaffID.Enabled = False
        cmbRole.Enabled = False
        Try
            sqL = "SELECT * FROM Users WHERE Username = '" & ListBox1.Text & "'"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtUser.Text = dr("Username")
                txtPwd.Text = ""
                txtCpwd.Text = ""
                cmbRole.Text = dr("role").ToString()
                txtStaffID.Text = dr("StaffID")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtUser.Enabled = False
        txtCpwd.Enabled = True
        txtPwd.Enabled = True
        txtStaffID.Enabled = True
        cmbRole.Enabled = True
        Editing = True
        txtUser.Focus()
    End Sub
End Class