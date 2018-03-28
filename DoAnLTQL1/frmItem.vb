
Imports System.Data.OleDb
Public Class frmItem

    Dim adding As Boolean
    Dim updating As Boolean
    Public search As Boolean
    Dim getStocksOnHand As Integer

    Private Sub GetQuantity()
        Try
            sqL = "SELECT StocksOnhand FROM Item WHERE ItemNo = " & txtItemNo.Text & ""
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                getStocksOnHand = dr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub AddStocksInUpdating()
        If txtItemNo.Text = "" Then
            MsgBox("Vui lòng chọn sản phẩm muốn nhập kho.", MsgBoxStyle.Critical, "Chọn sản phẩm")
            Exit Sub
        End If
        Dim strStocksIn As String
        strStocksIn = InputBox("Nhập số lượng sản phẩm : ", "Nhập kho")
        txtQuantity.Text = Val(txtQuantity.Text) + Val(strStocksIn)
        Try
            sqL = "INSERT INTO StocksIn(ItemNo, ItemQuantity, SIDate, CurrentStocks) VALUES('" & txtItemNo.Text & "', '" & strStocksIn & "', '" & Format(Date.Now, "Short Date") & "', " & txtQuantity.Text & ")"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            Dim i As Integer

            i = cmd.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Nhập kho thành công", MsgBoxStyle.Information, "Nhập kho")
                Updateproduct()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub AddStocksInAdding()
        Try
            sqL = "INSERT INTO StocksIn(ItemNo, ItemQuantity, SIDate) VALUES('" & txtItemNo.Text & "', '" & txtQuantity.Text & "', '" & Format(Date.Now, "Short Date") & "')"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub GetItemNo()
        Try
            sqL = "SELECT ItemNo From Item Order By ItemNo desc"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtItemNo.Text = dr(0) + 1
            Else
                txtItemNo.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub AddItem()
        txtUnitPrice.Text = txtUnitPrice.Text.Replace(",", "")
        Try
            sqL = "Insert Into Item(ItemCode, iDescription, StocksOnHand, UnitPrice ) VALUES('" & txtItemCode.Text & "', '" & txtDescription.Text & "', '" & txtQuantity.Text & "', '" & txtUnitPrice.Text & "')"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Đã thêm hàng hóa thành công", MsgBoxStyle.Information, "Thêm sản phẩm")
            Else
                MsgBox("Không thể thêm hàng hóa", MsgBoxStyle.Critical, "Thêm sản phẩm")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub UpdateItem()
        txtUnitPrice.Text = txtUnitPrice.Text.Replace(",", "")
        Try
            sqL = "UPDATE Item SET ItemCode = '" & txtItemCode.Text & "', iDescription = '" & txtDescription.Text & "', StocksOnHand = '" & txtQuantity.Text & "', UnitPrice = '" & txtUnitPrice.Text & "' WHERE ItemNo = " & txtItemNo.Text & ""
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Đã cập nhật sản phẩm", MsgBoxStyle.Information, "Cập nhật sản phẩm")
            Else
                MsgBox("Không thể cập nhật sản phẩm", MsgBoxStyle.Information, "Cập nhật sản phẩm")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub GetItemRecord()
        Try
            sqL = "SELECT ItemCode, iDescription, StocksOnHand, UnitPrice FROM Item Where ItemNo = " & txtItemNo.Text & ""
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtItemCode.Text = dr(0)
                txtDescription.Text = dr(1)
                txtQuantity.Text = dr(2)
                txtUnitPrice.Text = dr(3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
   
    Private Sub ClearFields()
        txtItemNo.Text = ""
        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtQuantity.Text = ""
        txtUnitPrice.Text = ""
    End Sub

    Private Sub EnabledText()
        txtItemNo.Enabled = True
        txtItemCode.Enabled = True
        txtDescription.Enabled = True
        txtQuantity.Enabled = True
        txtUnitPrice.Enabled = True
    End Sub

    Private Sub DisabledText()
        txtItemNo.Enabled = False
        txtItemCode.Enabled = False
        txtDescription.Enabled = False
        txtQuantity.Enabled = False
        txtUnitPrice.Enabled = False
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        adding = True
        updating = False

        EnabledText()
        DisabledButton()
        ClearFields()
        GetItemNo()
        txtItemCode.Focus()
        txtItemNo.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        adding = False
        updating = True
        EnabledText()
        DisabledButton()
        txtItemCode.Focus()
        txtItemNo.Enabled = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        search = True
        frmLoadItem.ShowDialog()
    End Sub

    Private Sub txtItemNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemNo.TextChanged
        If search = True Then
            GetItemRecord()
            search = False
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub Updateproduct()
        GetQuantity()
        UpdateItem()
        DisabledText()
        EnabledButton()
        ClearFields()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If adding = True Then
            AddItem()
            AddStocksInAdding()
            DisabledText()
            EnabledButton()
            ClearFields()
        Else
            Updateproduct()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisabledText()
        EnabledButton()
        ClearFields()
    End Sub

    Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnabledButton()
        DisabledText()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AddStocksInUpdating()
    End Sub
End Class