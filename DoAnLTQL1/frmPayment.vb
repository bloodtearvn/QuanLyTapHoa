
Imports System.Data.OleDb
Public Class frmPayment



    Private Sub AddPayment()
        txtCash.Text = txtCash.Text.Replace(",", "")
        Try
            sqL = "INSERT INTO PAYMENT(InvoiceNo,[Cash],[Change]) VALUES('" & frmPOS.lblInvoiceNo.Text & "','" & txtCash.Text & "', '" & txtChange.Text & "')"
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

    Private Sub txtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            If txtCash.Text = "" Then
                MsgBox("Vui lòng nhập tiền thu vào! ", MsgBoxStyle.Information, "Thanh toán")
                txtCash.Focus()
                Exit Sub
            End If

            If Val(txtCash.Text) < Val(txtTA.Text) Then
                MsgBox("Tiền thu vào nhỏ hơn tiền hàng hóa", MsgBoxStyle.Exclamation, "Thanh toán")
                txtCash.SelectAll()
                txtCash.Focus()
                Exit Sub
            End If

            frmPOS.AddPOS()
            AddPayment()
            MsgBox("Đang in hóa đơn", MsgBoxStyle.Information, "Hóa đơn")
            frmPrintReceipt.Show()
            frmPOS.NewTransaction()
            frmPOS.txtSearch.Focus()
            Me.Close()
        End If
    End Sub

    Private Sub txtCash_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCash.TextChanged
        txtChange.Text = Format(Val(txtCash.Text.Replace(",", "")) - Val(txtTA.Text.Replace(",", "")), "0.00")
    End Sub

    Private Sub frmPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTA.Text = frmPOS.lblTotalCost.Text
    End Sub

   
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class