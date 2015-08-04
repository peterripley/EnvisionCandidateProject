<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sudoku.Web._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sudoku Puzzle Solver</title>
</head>
<body style="font-family:Verdana">
<h2 style="margin-left:30px">Sudoku Puzzle Solver</h2>
    <form id="main" runat="server">
        <table style="margin-left:30px">
            <tr>
                <td>
                <span>Original Puzzle</span>
                <br/>
                <br />
                <div id="original" runat="server">
    
                </div>
                <br/>
                <span>Solved Puzzle</span>
                <br/>
                <br/>

                <div id="solved" runat="server">
    
                </div>
            </td>
            </tr>
        </table>
    </form>
</body>
</html>
