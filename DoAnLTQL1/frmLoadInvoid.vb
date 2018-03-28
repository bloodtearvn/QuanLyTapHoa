
Imports System.Data.OleDb
Public Class frmLoadInvoid
    Private Sub LoadInvoid()
        Try
            sqL = "SELECT a.InvoiceNo,a.POSDate, a.TotalAmount,b.CustName FROM POS a Inner Join Customer b on (a.CustomerNo=b.CustomerNo) Order By InvoiceNo"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While dr.Read = True
                dgw.Rows.Add(dr(0), dr(1), dr(2), dr(3))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub Search()
        Try
            sqL = "SELECT a.InvoiceNo,a.POSDate,a.TotalAmount,b.CustName FROM POS a,Customer b where ((a.CustomerNo=b.CustomerNo) and a.InvoiceNo LIKE '%" & TextBox1.Text & "%' OR a.POSDate LIKE '" & TextBox1.Text & "%' OR b.CustName LIKE '%" & TextBox1.Text & "%') Order By InvoiceNo"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While dr.Read = True
                dgw.Rows.Add(dr(0), dr(1), dr(2), dr(3))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Search()
    End Sub

    Private Sub frmLoadInvoid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInvoid()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)

    End Sub

    Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw.CellClick
        Dim invoidno As String = Me.dgw.CurrentRow.Cells(0).Value
        Try
            sqL = "SELECT b.IDescription,a.Quantity,a.ItemPrice,a.ItemPrice*a.Quantity FROM POSDetail a Inner Join Item b on (a.ItemNo=b.ItemNo) Order By POSDetailNo"
            ConnDB()
            cmd = New OleDbCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw1.Rows.Clear()
            Do While dr.Read = True
                dgw1.Rows.Add(dr(0), dr(1), dr(2), dr(3))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
End Class