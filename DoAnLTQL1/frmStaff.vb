
Imports System.Data.OleDb
Public Class frmStaff
    Public adding As Boolean
    Public updating As Boolean
    Public search As Boolean

    Private Sub GetStaffID()
        Try
            sqL = "SELECT StaffID FROM Staff Order By StaffID Desc"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtStaffID.Text = dr(0) + 1
            Else
                txtStaffID.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub AddStaff()
        Try
            sqL = "INSERT INTO Staff(Fullname, Address, ContactNo, [Position]) VALUES('" & txtFullname.Text & "', '" & txtAddress.Text & "', '" & txtContactNo.Text & "', '" & txtPosition.Text & "')"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Đã thêm nhân viên", MsgBoxStyle.Information, "Thêm nhân viên")
            Else
                MsgBox("Không thể thêm nhân viên", MsgBoxStyle.Critical, "Thêm nhân viên")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub UpdateStaff()
        Try
            sqL = "Update Staff SET Fullname ='" & txtFullname.Text & "', Address= '" & txtAddress.Text & "', ContactNo = '" & txtContactNo.Text & "', [Position] = '" & txtPosition.Text & "' WHERE StaffID = " & txtStaffID.Text & ""
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Đã sửa thông tin nhân viên", MsgBoxStyle.Information, "Sửa thông tin nhân viên")
            Else
                MsgBox("Không thể sửa lỗi nhân viên", MsgBoxStyle.Critical, "Sửa thông tin nhân viên")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub GetStaffRecord()
        Try
            sqL = "SELECT * From Staff WHERE StaffID = " & txtStaffID.Text & ""
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtFullname.Text = dr("Fullname")
                txtAddress.Text = dr("Address")
                txtContactNo.Text = dr("ContactNo")
                txtPosition.Text = dr("Position")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub CLearFields()
        txtStaffID.Text = ""
        txtFullname.Text = ""
        txtContactNo.Text = ""
        txtPosition.Text = ""
    End Sub

    Private Sub EnabledText()
        txtStaffID.Enabled = True
        txtFullname.Enabled = True
        txtAddress.Enabled = True
        txtContactNo.Enabled = True
        txtPosition.Enabled = True
    End Sub
    Private Sub DisabledText()
        txtStaffID.Enabled = False
        txtFullname.Enabled = False
        txtAddress.Enabled = False
        txtContactNo.Enabled = False
        txtPosition.Enabled = False
    End Sub

    Private Sub EnabledButton()
        btnAdd.Enabled = True
        btnUpdate.Enabled = True
        btnSearch.Enabled = True
        btnClose.Enabled = True

        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub DisabledButton()
        btnAdd.Enabled = False
        btnUpdate.Enabled = False
        btnSearch.Enabled = False
        btnClose.Enabled = False

        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub frmStaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisabledText()
        EnabledButton()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        adding = True
        updating = False

        EnabledText()
        CLearFields()
        DisabledButton()
        GetStaffID()
        txtFullname.Focus()
        txtStaffID.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtStaffID.Text = "" Then
            MsgBox("Vui lòng chọn nhân viên cần sửa", MsgBoxStyle.Information, "Sửa thông tin nhân viên")
            Exit Sub
        End If

        adding = False
        updating = True
        EnabledText()
        DisabledButton()
        txtFullname.Focus()
        txtStaffID.Enabled = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        search = True
        frmLoadStaff.ShowDialog()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If adding = True Then
            AddStaff()
            DisabledText()
            EnabledButton()
            CLearFields()
        Else
            UpdateStaff()
            DisabledText()
            EnabledButton()
            CLearFields()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisabledText()
        EnabledButton()
        CLearFields()
    End Sub

    Private Sub txtStaffID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStaffID.TextChanged
        If search = True Then
            GetStaffRecord()
            search = False
        End If

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class