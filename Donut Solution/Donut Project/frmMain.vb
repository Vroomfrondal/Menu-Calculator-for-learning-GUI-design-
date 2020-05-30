' Name:         Doughnut Project
' Purpose:      Doughnut calculator
' Programmer:   Christopher DeLeon on 3.15.2020

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain
    '  Procedures to find Subtotal
    Private Function doughnut() As Double
        ' function to calculate and return donut price
        Dim x As Double

        ' chooses which ever radio button is checked
        If radGlazed.Checked = True Then
            x = 1.05
        ElseIf radSugar.Checked = True Then
            x = 1.05
        ElseIf radChocolate.Checked = True Then
            x = 1.25
        ElseIf radFilled.Checked = True Then
            x = 1.5
        End If
        Return x
    End Function


    Private Function coffee() As Double
        ' function to calculate and return coffee price
        Dim y As Double

        'chooses which ever radio button is checked
        If radRegular.Checked = True Then
            y = 1.5
        ElseIf radCappuccino.Checked = True Then
            y = 2.75
        ElseIf radNone.Checked = True Then
            y = 0
        End If
        Return y
    End Function

    'Function to find Sales Tax
    Private Function calc_tax(ByVal z As Double) As Double

        'function to calculate tax on subtotal and return tax
        Return z * (6 / 100)
    End Function

    'Calculate
    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click

        Dim doughnut_price As Double = 0
        Dim coffee_price As Double = 0
        Dim sub_total, tax, total As Double

        'calling functions and assigning values to variables
        doughnut_price = doughnut()
        coffee_price = coffee()

        ' calculate subtotal
        sub_total = doughnut_price + coffee_price

        ' calculate tax
        tax = calc_tax(sub_total)

        ' calculate total due
        total = sub_total + tax

        ' display sub total, tax and total due
        txtSubTotal.Text = "$" + sub_total.ToString("#.##")
        txtSalesTax.Text = "$" + tax.ToString("#.##")
        txtTotalDue.Text = "$" + total.ToString("#.##")

    End Sub

    'Exit Confirmation
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim dlgButton As DialogResult
        dlgButton = MessageBox.Show("Do you want to exit?", "Donut Shoppe", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation)

        'If the No button selected, Do not close the form
        If dlgButton = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    ' Exit button
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'Clear output once new menu items are checked
    Private Sub radGlazed_CheckedChanged(sender As Object, e As EventArgs) Handles radGlazed.CheckedChanged,
                                                                            radSugar.CheckedChanged, radChocolate.CheckedChanged, radFilled.CheckedChanged,
                                                                            radNone.CheckedChanged, radRegular.CheckedChanged, radCappuccino.TextChanged
        txtSalesTax.Text = String.Empty
        txtSubTotal.Text = String.Empty
        txtTotalDue.Text = String.Empty

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
